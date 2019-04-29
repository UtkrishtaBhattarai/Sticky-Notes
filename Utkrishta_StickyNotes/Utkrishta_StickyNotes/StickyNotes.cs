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
    public partial class StickyNotes : Form
    {
        DataTable dataTable;
        DataTable dt;
        LoginBll loginBll = new LoginBll();
        StickyNotesBll stickynotesBll = new StickyNotesBll();
        int Completed=0;
        int incomplete=0;


        public StickyNotes(int userid)
        {

            stickynotesBll.UserID = userid;
            InitializeComponent();
            PieChart pieChart = new PieChart(userid);
        }

        RichTextBox textContent = new RichTextBox();
        private void StickyNotes_Load(object sender, EventArgs e)
        {
            try
            {
                lblid.Text = stickynotesBll.UserID.ToString();
                lblname.Text = stickynotesBll.Getname();
                DataTable dt2 = stickynotesBll.NoofCompletedNotes();
                DataTable dt3 = stickynotesBll.NoofIncompleteNotes();
                if (dt2.Rows.Count > 0 || dt3.Rows.Count > 0)
                {
                    int a = int.Parse(dt2.Rows[0][0].ToString());
                    int b = int.Parse(dt3.Rows[0][0].ToString());
                    Completed = (a * 100 / (a + b));
                    incomplete = (b * 100 / (a + b));
                    lblcom.Text = Completed+"%".ToString();
                    lblinc.Text = incomplete+"%".ToString();
                }
                else
                {
                    lblcom.Text = 0.ToString();
                    lblinc.Text = 0.ToString();
                }
                dt = stickynotesBll.NoteCount();
                dataTable = stickynotesBll.getNote();
                load();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void load()
        {
            int x, y;
            x = 50;
            y = 30;
            int j = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //childpanel
                Panel childPanel = new Panel();
                childPanel.Location = new Point(x, y);
                childPanel.BackColor = Color.Red;
                childPanel.Size = new Size(290, 264);

                //label1
                Label lblCategory = new Label();
                lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
                lblCategory.Location = new System.Drawing.Point(0, 0);
                lblCategory.Size = new System.Drawing.Size(1, 1);
                lblCategory.Text = dataTable.Rows[i]["CategoryID"].ToString();
                stickynotesBll.CategoryID = Int32.Parse(lblCategory.Text);
                DataTable dt1 = stickynotesBll.Category();

                //lblNoteid
                Label lblid = new Label();
                lblid.Location = new Point(1, 2);
                lblid.Visible = false;
                lblid.Text = dataTable.Rows[i]["NoteID"].ToString();


                Label lblCategoryname = new Label();
                lblCategoryname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
                lblCategoryname.Location = new System.Drawing.Point(3, 7);
                lblCategoryname.Size = new System.Drawing.Size(130, 16);
                lblCategoryname.Text = dt1.Rows[0]["CategoryType"].ToString();

                // 
                Label lblTitle = new Label();
                lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
                lblTitle.Location = new System.Drawing.Point(3, 34);
                lblTitle.Size = new System.Drawing.Size(130, 16);
                lblTitle.TabIndex = 1;
                lblTitle.Text = dataTable.Rows[i][1].ToString();

                //datapicker
                Label date = new Label();
                date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
                date.Location = new System.Drawing.Point(182, 3);
                date.Size = new System.Drawing.Size(105, 22);
                date.Text = dataTable.Rows[i][0].ToString();

                //checkbox1
                CheckBox chk1 = new CheckBox();
                chk1.Text = "Completed";
                chk1.Location = new Point(6, 235);
                chk1.Size = new Size(102, 20);
                chk1.Font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
                if (dataTable.Rows[i][4].ToString() == "False")
                {
                    chk1.Checked = false;
                }
                else if (dataTable.Rows[i][4].ToString() == "True")
                {
                    chk1.Checked = true;
                }

                //checkbox2
                CheckBox chk2 = new CheckBox();
                chk2.Text = "Sticked";
                chk2.Location = new Point(114, 235);
                chk2.Size = new Size(83, 20);
                chk2.Font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
                if (dataTable.Rows[i][3].ToString() == "False")
                {
                    chk2.Checked = false;
                }
                else if (dataTable.Rows[i][3].ToString() == "True")
                {
                    chk2.Checked = true;
                }

                //textbox
                RichTextBox textContent = new RichTextBox();
                textContent.Location = new Point(6, 54);
                textContent.Multiline = true;
                textContent.Size = new Size(223, 175);
                textContent.BackColor = Color.LightYellow;
                textContent.Font = new Font("Arial", 11);
                textContent.Text = dataTable.Rows[i][2].ToString();
                //picUpdate
                PictureBox picUpdate = new PictureBox();
                picUpdate.Image = global::Utkrishta_StickyNotes.Properties.Resources.edit;
                picUpdate.Location = new Point(245, 54);
                picUpdate.Size = new Size(35, 51);
                picUpdate.SizeMode = PictureBoxSizeMode.Zoom;
                picUpdate.Cursor = Cursors.Hand;
                picUpdate.Click += (s, a) =>
                  {
                      stickynotesBll.NoteID = int.Parse(lblid.Text);
                      stickynotesBll.Contents = textContent.Text;
                      if (chk1.Checked == true)
                      {
                          stickynotesBll.Completed = true;
                      }
                      else
                      {
                          stickynotesBll.Completed = false;
                      }
                      if (chk2.Checked == true)
                      {
                          stickynotesBll.Sticked = true;
                      }
                      else
                      {
                          stickynotesBll.Sticked = false;
                      }
                      
                     
                      stickynotesBll.update();
                      MessageBox.Show("Successfully Edited");
                  };
                // picDelete
                PictureBox picDelete = new PictureBox();
                picDelete.Image = global::Utkrishta_StickyNotes.Properties.Resources.delete;
                picDelete.Location = new Point(245, 120);
                picDelete.Size = new Size(35, 51);
                picDelete.SizeMode = PictureBoxSizeMode.Zoom;
                picDelete.Cursor = Cursors.Hand;
                picDelete.Click += (s, a) =>
                {
                    MessageBox.Show("Deleted");
                    this.Close();
                    this.Hide();
                    StickyNotes sticky = new StickyNotes(stickynotesBll.UserID);
                    stickynotesBll.NoteID = int.Parse(lblid.Text);
                    
                    stickynotesBll.delete();
                    stickynotesBll.getNote();
                    sticky.ShowDialog();
                    
                };

               
                //add controls
                childPanel.Controls.Add(lblCategory);
                childPanel.Controls.Add(lblTitle);
                childPanel.Controls.Add(lblCategoryname);
                childPanel.Controls.Add(lblCategory);
                childPanel.Controls.Add(picUpdate);
                childPanel.Controls.Add(picDelete);
                childPanel.Controls.Add(textContent);
                childPanel.Controls.Add(chk1);
                childPanel.Controls.Add(chk2);
                childPanel.Controls.Add(date);
                parentPanel.Controls.Add(childPanel);

                if (x + childPanel.Width > parentPanel.Width)
                {
                    x = 50;
                    y = y + childPanel.Width + -5;
                    childPanel.Location = new Point(x, y);

                }
                else
                {
                    childPanel.Location = new Point(x, y);
                }
                parentPanel.Controls.Add(childPanel);

                x = x + childPanel.Width + 21;
                j = j + 1;
            }

        }
        private void pieChartProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PieChart pieChart = new PieChart(stickynotesBll.UserID);
            pieChart.ShowDialog();
        }

        private void createNewNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            CreateForm createForm = new CreateForm(stickynotesBll.UserID);
            createForm.ShowDialog();
            
        }

        private void addANewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category category = new Category(stickynotesBll.UserID);
            category.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you have any complain and errors using this application " +
                             "Contact: wedevelopers1@gmail.com ");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright to Nepal Developers" +
                            "  Version:122.122.133.1" + " Realese Date:12/12/2018");
        }

        private void viewMyDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            IndividualForm individualForm = new IndividualForm(stickynotesBll.UserID);
            individualForm.ShowDialog();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void searchNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            stickynotesBll.searchvalue = txtsearch.Text;
            dt = stickynotesBll.countNote();
            dataTable = stickynotesBll.searchNote();
            if (txtsearch.Text == "")
            {
                MessageBox.Show("Please enter a search value");
                return;
            }
            else if (dt.Rows.Count > 0)
            {
                parentPanel.Controls.Clear();
                load();
            }
            else
            {
                MessageBox.Show("No Notes Found");
                return;
            }

        }
        private void parentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            
            StickyNotes sticky = new StickyNotes(stickynotesBll.UserID);
            sticky.ShowDialog();
            this.Close();
            parentPanel.Controls.Clear();
            dt = stickynotesBll.NoteCount();
            dataTable = stickynotesBll.getNote();
            load();
            
        }
        private void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }

}










