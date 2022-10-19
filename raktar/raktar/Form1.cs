using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace raktar
{
    public partial class Form1 : Form
    {
        class adatok
        {
            public string nev;
            public string jelszo;
        }
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("User.txt");
            List<adatok> list = new List<adatok>();
            while (!sr.EndOfStream)
            {
                adatok adatok = new adatok();
                string sor = sr.ReadLine();
                string[] darab = sor.Split(' ');
                adatok a = new adatok();
                a.nev = darab[0];
                a.jelszo = darab[1];
                list.Add(a);
            }
            sr.Close();
            bool be = false;
            foreach (var item in list)
            {
                if (textBox1.Text == item.nev && textBox2.Text == item.jelszo)
                {
                    be = true;
                    Form3 f3 = new Form3();
                    f3.Show();
                    this.Hide();
                }
              
            }
            if (!be)
            {
                MessageBox.Show("Nem található ilyen felhasználó");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
