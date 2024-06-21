using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Finalc_
{
    
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adam_\OneDrive\Documents\dbDMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand(); //data connect
        SqlDataReader dr;
        public UserForm()
        {
            InitializeComponent();
            LoadUser(); //refresh
        }

        public void LoadUser()
        {
            int i = 0;
            DGVUser.Rows.Clear();   
            cm= new SqlCommand("Select * From tbUser", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++; //adds append feature for row adding when new user entry is saved
                DGVUser.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm(); //gets the add btn in btmm corner working for the child form
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();
            LoadUser();
        }

        private void DGVUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = DGVUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.txtUserName.Text = DGVUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFullName.Text = DGVUser.Rows[e.RowIndex].Cells[2].Value.ToString(); //populating cells
                userModule.txtPassword.Text = DGVUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPhone.Text = DGVUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                userModule.btnSave.Enabled = false;
                userModule.btnUpdate.Enabled = true; //this time update btn is true bc we're adding the update feature in our userform to update user data
                userModule.txtUserName.Enabled = false;
                userModule.ShowDialog();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Entry",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("Delete From tbUser Where username Like'" + DGVUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Entry has been deleted successfully.");
                }
            }
            LoadUser();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
