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
    public partial class Form1 : Form
    {
        public static Queue<int> timeQueue = new Queue<int>();
        public static Queue<string> ordersQueue = new Queue<string>();
        public static Queue<string> ready = new Queue<string>();
        public static int timeLeft = 0;
        public static int timeToDisappear = 20;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2
            {
                Tag = this
            };
            form2.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5
            {
                Tag = this
            };
            if (timeQueue.Count != 0 && timeLeft == 0)
            {
                timeLeft = timeQueue.Dequeue();
                timer1.Start();
            }
            form5.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
            }
            else if(timeLeft == 0 && ordersQueue.Count != 0)
            {
                ready.Enqueue(ordersQueue.Dequeue());
                if(timeQueue.Count != 0)
                    timeLeft = timeQueue.Dequeue();
                timer2.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeToDisappear > 0)
            {
                timeToDisappear = timeToDisappear - 1;
            }
            else if (timeToDisappear == 0 && ready.Count != 0)
            {
                _ = ready.Dequeue();
                timeToDisappear = 20;
            }
            else
            {
                timer2.Stop();
                timeToDisappear = 20;
            }
        }
    }
}
