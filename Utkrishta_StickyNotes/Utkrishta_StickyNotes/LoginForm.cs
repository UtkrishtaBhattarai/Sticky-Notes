
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
    public partial class LoginForm : Form
    {
        LoginBll loginBll = new LoginBll();
        UserBll usrbll = new UserBll();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            loginBll.Username = txtusername.Text;

            loginBll.UPassword = txtPassword.Text;



            if (comboBox1.Text == "Admin")
            {
                if (txtusername.Text == "Admin" && txtPassword.Text == "Admin")
                {
                    this.Hide();
                    Users usr = new Users();
                    usr.ShowDialog();
                    this.Close();
                }
             else
                {
                    MessageBox.Show("Incorrect UserName or Password");
                    txtusername.Text = "";
                    txtPassword.Text = "";
                    return;
                   
                }
            }
            else if (comboBox1.Text == "User")
            {
                   if (loginBll.check())
                   {
                        int uid;
                        uid = loginBll.selectID();
                        StickyNotes stickynotes = new StickyNotes(uid);
                        MessageBox.Show("Login Successful");
                        this.Hide();
                        stickynotes.ShowDialog();
                        this.Close();
                   }
                    else
                    {
                        MessageBox.Show("UserName and Password Donot Match");
                        txtusername.Text = "";
                        txtPassword.Text = "";
                        return;
                    }
            }

                else
                {
                    MessageBox.Show("Please select UserType");
                    return;
                }
               
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
            comboBox1.DataSource = usrbll.displaycmb();
            comboBox1.DisplayMember = "UserTypeName";
            comboBox1.ValueMember = "UserTypeID";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Users user = new Users();
            user.ShowDialog();
        }
    }
}
