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
    public partial class IndividualForm : Form
    {
        IndividualBll ibll = new IndividualBll();
        UserBll userBll = new UserBll();
        LoginBll loginBll = new LoginBll();
        DataTable dt;
        public IndividualForm(int uiid)
        {
            ibll.UserID = uiid; 
             InitializeComponent();
        }
        private void IndividualForm_Load(object sender, EventArgs e)
        {
            displayDatas();
            dt = ibll.edisplay();
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
           
        }
        private void displayDatas()
        {
            LoginBll lbll = new LoginBll();

            dataGridView1.DataSource = ibll.display();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            try
            {
                ibll.UserID = int.Parse(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errrorrr!!!!!::" + ex);
            }
            DataTable dt;
            try
            {
                if (dataGridView1.CurrentRow.Cells[columnIndex].Value.ToString() == "Edit")
                {
                    dt = ibll.edisplay();
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

                    btnupdate.Text = "Update";
                }
                else if (dataGridView1.CurrentRow.Cells[columnIndex].Value.ToString() == "Delete")
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete"
                       , MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        ibll.delete();
                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.ShowDialog();
                        this.Close();
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
                    btnupdate.Text = "Register";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
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

            
            ibll.Username = txtusername.Text;
            ibll.UPassword = txtpassword.Text;
            ibll.FirstName = txtfname.Text;
            ibll.LastName = txtlname.Text;
            ibll.UAddress = txtaddress.Text;
            ibll.PhoneNumber = txtphoneno.Text;
            ibll.Gender = gender;
            ibll.update();

            displayDatas();

        }
    }
}
