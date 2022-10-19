using System;
using System.Collections;
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
    public partial class Form5 : Form
    {
        class adatok
        {            
            public string name;
            public DateTime date;
            public int num;
        }
        public Form5()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("eladasok.txt");
            List<adatok> list = new List<adatok>();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darab = sor.Split(';');
                adatok a = new adatok();
                a.name = darab[0];
                a.date = Convert.ToDateTime(darab[1]);
                a.num = Convert.ToInt32(darab[2]);
                list.Add(a);
            }
            sr.Close();


            //HashSet<string> stat2 = new HashSet<string>();
            //HashSet<int> stat = new HashSet<int>();
            //foreach (var item in list)
            //{
            //    int szam = new int();
            //    szam= Convert.ToInt32(item.num);
            //    stat2.Add(item.name);
            //    stat.Add(szam);
            //}

            //foreach (var item in stat)
            //{
            //    int db = 0;
            //    foreach (var item2 in list)
            //    {
            //        if (item==int.Parse(item2.num.ToString()))
            //        {
            //            db++;
            //        }
            //    }
            //    richTextBox1.Text += stat2 + " " + stat.Count() + "\n";
            //}

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in list)
            {
                // r = new RomaiSorszam(item.name);
                if (!dic.ContainsKey(item.name))
                {
                    dic.Add(item.name, item.num);
                }                               
                else
                {                                              
                    dic[item.name]+=item.num;
                }
            }
                richTextBox1.Text = "";
                foreach (var item in dic)
                {
                    richTextBox1.Text += item.Key + " " + item.Value + "\n";
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.richTextBox1.Width, this.richTextBox1.Height);
            richTextBox1.DrawToBitmap(bm, new Rectangle(0, 0, this.richTextBox1.Width, this.richTextBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
