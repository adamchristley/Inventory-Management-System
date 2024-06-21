using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finalc_
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adam_\OneDrive\Documents\dbDMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand(); //login data connect
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
                txtPassword.UseSystemPasswordChar = true; //show pass
            else 
                txtPassword.UseSystemPasswordChar = false; //dont show pass
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //confirm you want app to close
            {
                Application.Exit(); //exit
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("Select * From tbUser Where username=@username And password=@password", con); //creates the new commands for this class or form
                cm.Parameters.AddWithValue("@username", txtUserName.Text); //add
                cm.Parameters.AddWithValue("@password", txtPassword.Text); //add
                con.Open();
                dr = cm.ExecuteReader(); //boom func for adding
                dr.Read();  
                if (dr.HasRows) 
                {
                    MessageBox.Show("Welcome, " + dr["fullname"].ToString() , "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information); //message once correct login
                    MainForm main = new MainForm();
                    this.Hide(); //hide login form
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information); //if wrong login credentials then error box
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //ex error statement box
            }
        }
    }
}
