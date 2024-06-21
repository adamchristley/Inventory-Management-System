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

namespace Finalc_
{
    public partial class CustomerModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adam_\OneDrive\Documents\dbDMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand(); //connect for CMF
        public CustomerModuleForm()
        {
            InitializeComponent();
        } //inputted loader

        private void btnSave_Click(object sender, EventArgs e) //save func for btn
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this customer?", "Saving Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //messagebox for save ft
                {
                    cm = new SqlCommand("Insert into tbCustomer(CustomerName,CustomerPhone)Values(@CustomerName,@CustomerPhone)", con); //inserting saved data to respective database spot
                    cm.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text); //telling it how and where to add data from enterred data
                    cm.Parameters.AddWithValue("@CustomerPhone", txtCustomerPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery(); //boom
                    con.Close();
                    MessageBox.Show("Customer entry has been saved."); //ui or user help through process
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            txtCustomerName.Clear();
            txtCustomerPhone.Clear(); // clear func
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose(); // close
        }

        private void CustomerModuleForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this customer?", "Update Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { }
                {
                    cm = new SqlCommand("Update tbCustomer set CustomerName=@CustomerName,CustomerPhone=@CustomerPhone where cid like  '" + lblCID.Text + "'", con);
                    cm.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cm.Parameters.AddWithValue("@CustomerPhone", txtCustomerPhone.Text); //update func copy paste method from above
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer entry has been updated.");
                    this.Dispose(); // exit 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
