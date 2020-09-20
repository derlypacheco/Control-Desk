using Control_Desk.general;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Control_Desk.general.dashboard;
using Control_Desk.general.produccion;
using Control_Desk.general.empaque;

namespace Control_Desk
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void panelTopSup_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void OpenFormPanel(object fomrpanel)
        {
            if (this.panelContent.Controls.Count > 0)
            {
                this.panelContent.Controls.RemoveAt(0);
            }
            Form fm = fomrpanel as Form;
            fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(fm);
            this.panelContent.Tag = fm;
            fm.Show();
        }

        private void btnSlider_Click(object sender, EventArgs e)
        {
            int zize = panelSilder.Width;
            if (zize == 250)
            {
                panelSilder.Width = 75;
                btnSlider.Location = new Point(80, 13);
            }
            if (zize == 75)
            {
                panelSilder.Width = 250;
                btnSlider.Location = new Point(265, 13);
            }
            
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            string question = "Estas seguro de cerrar la aplicación?";
            FormBoxResult questionResult = new FormBoxResult(question);
            if (questionResult.ShowDialog(this) == DialogResult.OK)
            {
                if (Application.OpenForms.Count != 0)
                {
                    this.Close();
                    Application.ExitThread();
                    Application.Exit();
                }
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            string question = "Estas seguro de cerrar la aplicación?";
            FormBoxResult questionResult = new FormBoxResult(question);
            if (questionResult.ShowDialog(this) == DialogResult.OK)
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            } else
            {
                e.Cancel = true;
                return;
            }
        }

        private void hideActive()
        {
            activeBtn1.Visible = false;
            activeBtn2.Visible = false;
            activeBtn3.Visible = false;
            activeBtn4.Visible = false;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenFormPanel(new frmDash());
            hideActive();
            activeBtn1.Visible = true;
        }

        private void btnProducction_Click(object sender, EventArgs e)
        {
            OpenFormPanel(new frmProd());
            hideActive();
            activeBtn2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFormPanel(new frmEmp());
            hideActive();
            activeBtn3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideActive();
            activeBtn4.Visible = true;
        }
    }
}
