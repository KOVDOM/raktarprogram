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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace raktar
{
    public partial class Form2 : Form
    {
        class adatok
        {
            public int num;
            public string name;
        }

        static List<adatok> list = new List<adatok>();
        public void termekbe()
        {
            StreamReader sr = new StreamReader("termekek.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darab=sor.Split(';');
                adatok a = new adatok();
                a.num = Convert.ToInt32(darab[0]);
                a.name= darab[1];
                list.Add(a);
            }
            sr.Close();
        }
        public Form2()
        {
            InitializeComponent();
            termekbe();
            foreach (var item in list)
            {
                richTextBox1.Text = item.num.ToString()+" "+item.name+"\n";
            }
            richTextBox1.Text = File.ReadAllText("termekek.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            StreamWriter sw = new StreamWriter("termekek.txt", true);

            sw.WriteLine(textBox1.Text + ";" + textBox2.Text);
            textBox1.Text = "";
            sw.Close();
            richTextBox1.Text = File.ReadAllText("termekek.txt");            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in list)
            {
                if (item.num.ToString() == textBox3.Text)
                {
                    list.Remove(item);
                    break;
                }
            }
            StreamWriter sw = new StreamWriter("termekek.txt");
            foreach (var item in list)
            {
                sw.WriteLine(item.num + ";" + item.name);
            }
            sw.Close();
            richTextBox1.Text = File.ReadAllText("termekek.txt");
            termekbe();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
