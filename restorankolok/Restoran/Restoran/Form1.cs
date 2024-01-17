using BusinessLayer;
using DataLayer;
using DataLayer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran
{
    public partial class Form1 : Form
    {
        private MenuItemsBusiness MenuItemsBusiness;
        public Form1()
        {
            InitializeComponent();
            this.MenuItemsBusiness = new MenuItemsBusiness();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Restorancic> restorani = MenuItemsBusiness.GetRestorans();

            foreach (var restoran in restorani)
            {
                listBox1.Items.Add($"Id: {restoran.Id}, Name: {restoran.Name}, Description: {restoran.Description}, Price: {restoran.Price}");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Restorancic primer = new Restorancic()
            {
                Name = textBox1.Text,
                Description = textBox2.Text,
                Price = decimal.Parse(textBox3.Text),
            };
            MenuItemsBusiness.SetRestorans(primer);
        }
    }
}

