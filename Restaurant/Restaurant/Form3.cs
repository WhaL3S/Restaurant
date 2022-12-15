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

    public partial class Form3 : Form
    {
        Dictionary<string, Food> menu = IOUtils.Read("C:\\Users\\WhaLeS\\source\\repos\\Restaurant\\Restaurant\\Menu.txt");
        public LinkedList<string> order = new LinkedList<string>();  
        double totalSum = 0.00;
        string tableName = "Table ";
        private int time = 0;

        public int GetTime() { return time; }
        public string GetTableName() { return tableName; }

        public void Refresh()
        {
            Controls.Clear();
            InitializeComponent();
            foreach (string s in menu.Keys)
            {
                comboBox2.Items.Add(s);
            }
            totalSum = 0.00;
            tableName = "Table ";
            time = 0;
            order.Clear();
        }

        public Form3()
        {
            InitializeComponent();
            foreach(string s in menu.Keys)
            {
                comboBox2.Items.Add(s);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                listBox1.Items.Add(comboBox2.SelectedItem);
                if (menu.TryGetValue(comboBox2.SelectedItem.ToString(), out Food f))
                {
                    totalSum += f.GetPrice();
                    string text = String.Format("{0, 10:f2}", totalSum).Trim();
                    textBox1.Text = text;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = (Form2)Tag;
            form2.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text != "" && totalSum != 0)
            {
                if(tableName.Length <= 6)
                    tableName += comboBox1.Text;
                string[] text = new string[20];
                listBox1.Items.CopyTo(text, 0);
                if (order.Count == 0)
                    foreach (string s in text)
                        if (s != null)
                        {
                            order.AddLast(s);
                            if (menu.TryGetValue(s, out Food f))
                            {
                                time += f.GetPreparationTime();
                            }
                        }
                Form4 form4 = new Form4
                {
                    Tag = this
                };
                form4.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("You did not choose your table or order");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            foreach (string s in menu.Keys)
            {
                comboBox2.Items.Add(s);
            }
            totalSum = 0.00;
            tableName = "Table ";
            time = 0;
            order.Clear();
        }
    }
}
