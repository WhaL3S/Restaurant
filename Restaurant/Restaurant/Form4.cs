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
    public partial class Form4 : Form
    {
        Dictionary<string, Food> menu = IOUtils.Read("C:\\Users\\WhaLeS\\source\\repos\\Restaurant\\Restaurant\\Menu.txt");

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = (Form3)Tag;
            form3.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "1")
                MessageBox.Show("Wrong number");
            else
            {
                MessageBox.Show("Your order is successfully added to the queue");
                Form3 form3 = (Form3)Tag;
                Table t = new Table(form3.GetTableName());
                foreach(string s in form3.order)
                    if (s != null && menu.TryGetValue(s, out Food f))
                        t.AddFood(f);
                Form1.ordersQueue.Enqueue(t.GetName());
                Form1.timeQueue.Enqueue(form3.GetTime());
                form3.order.Clear();
                form3.Show();
                form3.Refresh();
                Close();
            }

        }
    }
}
