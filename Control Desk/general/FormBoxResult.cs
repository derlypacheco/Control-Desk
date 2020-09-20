using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Desk.general
{
    public partial class FormBoxResult : Form
    {
        public FormBoxResult(string question)
        {
            InitializeComponent();
            lbl_question.Text = question;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            
        }
    }
}
