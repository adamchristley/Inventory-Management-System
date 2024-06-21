using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Finalc_
{
    public partial class UserModuleForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adam_\OneDrive\Documents\dbDMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand(); //user connect
        public UserModuleForm()
        {
            InitializeComponent();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //the make sure message prior to closing app
                {
                    cm = new SqlCommand("Insert into tbUser(username,fullname,password,phone)Values(@username,@fullname,@password,@phone)", con); //telling sql where to add the data to database
                    cm.Parameters.AddWithValue("@username", txtUserName.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text); //where to add data entries
                    cm.Parameters.AddWithValue("@password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open(); 
                    cm.ExecuteNonQuery(); //boom function
                    con.Close();
                    MessageBox.Show("User entry has been saved."); //ui help for user
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); //shows error if try doesn't work
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //perms when using clear
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Clear() //clear func
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
        }

        private void UserModuleForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e) //update func everything copy paste basically from above or other form
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this user?", "Update Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { }
                {
                    cm = new SqlCommand("Update tbUser set fullname=@fullname,password=@password,phone=@phone where username like  '"+ txtUserName.Text + "'", con);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User entry has been updated.");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); //shows error
            }
        }
    }
}
