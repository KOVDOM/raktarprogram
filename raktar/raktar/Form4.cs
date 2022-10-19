using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raktar
{
    public partial class Form4 : Form
    {
        class adatok
        {
            public int num;
            public string name;
        }
        public Form4()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("termekek.txt");
            List<adatok> list = new List<adatok>();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darab = sor.Split(';');
                adatok a = new adatok();
                a.num = Convert.ToInt32(darab[0]);
                a.name = darab[1];
                list.Add(a);
            }
            sr.Close();

            foreach (adatok a in list)
            {
                comboBox1.Items.Add(a.name);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("eladasok.txt",true);
            string line = "";
            line += Convert.ToString(comboBox1.Text) + ";" + Convert.ToDateTime(dateTimePicker1.Text) + ";" + Convert.ToString(numericUpDown1.Value)+"\n";
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
