using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finalc_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm) //connects childform 
        {
            if (activeForm != null)
                activeForm.Close(); 
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;    
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void consumerButton2_Click(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonWorkPls2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e) //opens user child form
        {
            openChildForm(new UserForm());
        }


        private void buttonWorkPls3_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e) // open customer form
        {
            openChildForm(new CustomerForm());
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) // closes main form but I don't think it actually does bc it already has this.disposefunc.
        
        {
            Application.Exit();
        }
        
    }
}
