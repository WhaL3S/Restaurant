using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Form2 : Form
    {
        Dictionary<string, Food> menu = IOUtils.Read("C:\\Users\\WhaLeS\\source\\repos\\Restaurant\\Restaurant\\Menu.txt");

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(" Type            Name             Price    Time (minutes)  ");
            listBox1.Items.Add("-----------------------------------------------------------------");
            foreach (Food f in menu.Values)
            {
                listBox1.Items.Add(f.ToString());
            }
            listBox1.Items.Add("-----------------------------------------------------------------");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3
            {
                Tag = this
            };
            form3.Show();
            Hide();
        }
    }
}
