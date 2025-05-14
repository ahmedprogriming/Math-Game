using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labTime.Text = DateTime.Now.ToString("HH:MM tt");
            
        }

        private void tBName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tBName.Text))
            {
                e.Cancel = true;
                tBName.Focus();
                errorProvider1.SetError(tBName, "Enter Name");

            }
            else {

                e.Cancel = false;
                errorProvider1.SetError(tBName,"");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tBName.Clear();
            comOption.Text = "";
            comDifc.Text = "";
            numericUpDown1.Value = 0;
            tBName.Focus();
        }

        private void btnEixt_Click(object sender, EventArgs e)
        {
            tBName.Text = "Exit";
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form f2 = new Start_Game(tBName.Text,comOption.Text,comDifc.Text,numericUpDown1.Value);
            f2.Show();
        }
    }
}
