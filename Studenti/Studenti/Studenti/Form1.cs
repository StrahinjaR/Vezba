using BusinessLayer;
using DataLayer.Shared;
using System.Windows.Forms;

namespace Studenti
{
    public partial class Form1 : Form
    {
        StudentBusiness studentbiz;
        public Form1()
        {
            InitializeComponent();
            this.studentbiz = new StudentBusiness();
        }
        private void GetBudgetStudents()
        {
            listBox1.Items.Clear();
            List<Student> listOfBudgetStudents = this.studentbiz.GetStudents();

            foreach (Student s in listOfBudgetStudents)
            {
                listBox1.Items.Add(s.id + ". " + s.studentname + " " + s.indexnumber + " " + (s.testpoints + s.projectpoints) + " " + s.exammark);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.studentname = textBox1.Text;
            s.indexnumber = textBox2.Text;
            s.projectpoints = int.Parse(textBox3.Text);
            s.testpoints = int.Parse(textBox4.Text);
            s.exammark = int.Parse(textBox5.Text);
            studentbiz.InsertStudents(s);
            GetBudgetStudents();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetBudgetStudents();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GetBudgetStudents();
            if (checkBox1.Checked)
            {
                listBox1.Items.Clear();
                List<Student> listOfBudgetStudents = this.studentbiz.FiltriraniStudenti();

                foreach (Student s in listOfBudgetStudents)
                {
                    listBox1.Items.Add(s.id + ". " + s.studentname + " " + s.indexnumber + " " + (s.testpoints + s.projectpoints) + " " + s.exammark);
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            GetBudgetStudents();
            if (checkBox2.Checked)
            {
                listBox1.Items.Clear();
                List<Student> listOfBudgetStudents = this.studentbiz.FiltriraniStudentiPoOceni();

                foreach (Student s in listOfBudgetStudents)
                {
                    listBox1.Items.Add(s.id + ". " + s.studentname + " " + s.indexnumber + " " + (s.testpoints + s.projectpoints) + " " + s.exammark);
                }
            }
        }
    }
}
