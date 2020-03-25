using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Farasat";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Text = "Typing...";
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Aqua;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Beige;
        }
    }
}
