using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utkrishta_StickyNotes
{
    public partial class Users : Form
    {
        UserBll usrbll = new UserBll();
        public Users()
        {
            InitializeComponent();
        }
        private void btnregister_Click(object sender, EventArgs e)
        {
            string gender;
            if (rdomale.Checked == true)
            {
                gender = "Male";
            }
            else if (rdofemale.Checked == true)
            {
                gender = "Female";
            }
            else if (rdoothers.Checked == true)
            {
                gender = "Others";
            }
            else
            {
                MessageBox.Show("Please select an option.");
                return;
            }
            usrbll.FirstName = txtfname.Text;
            usrbll.LastName = txtlname.Text;
            usrbll.UAddress = txtaddress.Text;
            usrbll.PhoneNumber = txtphoneno.Text;
            usrbll.Gender = gender;
            usrbll.Username = txtusername.Text;
            usrbll.UPassword = txtpassword.Text;

            if (btnregister.Text == "Register")
            {
                if (txtpassword.Text == txtcpassword.Text)
                {
                    usrbll.insert();
                }
                else
                {
                    MessageBox.Show("Passwords Donot Match");
                    return;
                }
                
            }
            else
            {
                if (txtpassword.Text == txtcpassword.Text)
                {
                    usrbll.update();
                }
                else
                {
                    MessageBox.Show("Passwords  Donot Match");
                    return;
                }
                
            }
            displayDatas();
            txtfname.Text = "";
            txtlname.Text = "";
            txtaddress.Text = "";
            txtphoneno.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtcpassword.Text = "";
            rdomale.Checked = false;
            rdofemale.Checked = false;
            rdoothers.Checked = false;
            btnregister.Text = "Register";
        }
        private void displayDatas()
        {
            UserBll usrbll = new UserBll();
            dataGridView1.DataSource = usrbll.display();
        }
        private void Users_Load(object sender, EventArgs e)
        {
            displayDatas();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            try
            {
                usrbll.UserID = int.Parse(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
             DataTable dt;
            if (dataGridView1.CurrentRow.Cells[columnIndex].Value.ToString() == "Edit")
            {
                dt = usrbll.edisplay();
                txtfname.Text = dt.Rows[0][0].ToString();
                txtlname.Text = dt.Rows[0][1].ToString();
                txtaddress.Text = dt.Rows[0][2].ToString();
                if (dt.Rows[0][4].ToString() == "Male")
                {
                    rdomale.Checked = true;
                }
                else if (dt.Rows[0][4].ToString() == "Female")
                {
                    rdofemale.Checked = true;
                }
                else        
                {
                   rdoothers.Checked = true;
                }

                txtphoneno.Text = dt.Rows[0][3].ToString();
                txtusername.Text = dt.Rows[0][5].ToString();
                txtpassword.Text = dt.Rows[0][6].ToString();
                txtcpassword.Text = dt.Rows[0][6].ToString();

                btnregister.Text = "Update";
            }
            else if (dataGridView1.CurrentRow.Cells[columnIndex].Value.ToString() == "Delete")
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete"
                   , MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    usrbll.delete();
                }
                displayDatas();
                txtfname.Text = "";
                txtlname.Text = "";
                txtaddress.Text = "";
                txtphoneno.Text = "";
                txtusername.Text = "";
                txtpassword.Text = "";
                txtcpassword.Text = "";
                rdomale.Checked = false;
                rdofemale.Checked = false;
                rdoothers.Checked = false;
                btnregister.Text = "Register";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtfname.Text = "";
            txtlname.Text = "";
            txtaddress.Text = "";
            txtphoneno.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtcpassword.Text = "";
            rdomale.Checked = false;
            rdofemale.Checked = false;
            rdoothers.Checked = false;

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            
        }
    }
}

