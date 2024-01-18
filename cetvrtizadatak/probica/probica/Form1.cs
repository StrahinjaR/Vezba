using BusinessLayer;
using DataLayer.Shared;

namespace probica
{
    public partial class Form1 : Form
    {
        PharaBusiness PharaBusiness = new PharaBusiness();
        public Form1()
        {
            InitializeComponent();
        }
        public void GetPrescriptions()
        {
            listBox1.Items.Clear();
            List<Prescriptions> lista = PharaBusiness.GetPrescriptions();
            foreach (Prescriptions presc in lista)
            {
                listBox1.Items.Add(presc.Id + " " + presc.PatientName + " " + presc.Prescribed + " " + presc.PrescrpitonDate + " " + presc.Price);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetPrescriptions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prescriptions preskri = new Prescriptions()
            {
                PatientName = textBox1.Text,
                Prescribed = textBox2.Text,
                PrescrpitonDate = DateTime.Parse(textBox3.Text),
                Price = decimal.Parse(textBox4.Text)
            };
        PharaBusiness.SetPrescriptions(preskri);
            GetPrescriptions();
        }
    }
}
