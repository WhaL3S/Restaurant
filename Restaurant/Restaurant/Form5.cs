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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            foreach(string s in Form1.ordersQueue)
            {
                listBox1.Items.Add(s);
            }
            foreach (string s in Form1.ready)
            {
                listBox2.Items.Add(s);
            }
            label1.Text = Form1.timeLeft + " minutes";
            timer1.Start();
            timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Form1.timeLeft + " minutes";
            listBox1.Items.Clear();
            foreach (string s in Form1.ordersQueue)
            {
                listBox1.Items.Add(s);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach (string s in Form1.ready)
            {
                listBox2.Items.Add(s);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
