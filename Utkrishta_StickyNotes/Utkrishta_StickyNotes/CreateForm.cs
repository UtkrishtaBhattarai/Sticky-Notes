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
    public partial class CreateForm : Form
    {
        CreateFormBll createformBll = new CreateFormBll();
        
        public CreateForm(int id)
        {
            InitializeComponent();
            createformBll.UserID = id;
        }
        CategoryBll category = new CategoryBll();
        private void button1_Click(object sender, EventArgs e)
        {
            string selectedID;
            selectedID = cmbcategory.SelectedValue.ToString();
            createformBll.CategoryID = int.Parse(selectedID.ToString());
            bool completed;
            bool stickied;
            if (chkCompleted.Checked == true)
            {
                completed = true;
            }
            else
            {
                completed = false;
            }

            if (chkStickied.Checked == true)
            {
                stickied = true;
            }
            else
            {
                stickied = false;
            }

           
            createformBll.DateCreated=dateTimePicker1.Text;
            createformBll.Completed = completed;
            createformBll.Sticked = stickied;
            createformBll.Title = txttitle.Text;
            createformBll.Contents = txtnote.Text;
            if (cmbcategory.Text == "")
            {
                return;
            }
            if (txttitle.Text == "")
            {
                return;
            }
            else
            {
                createformBll.insert();
                
            }
            StickyNotes stickyNotes = new StickyNotes(createformBll.UserID);
            this.Close();
            this.Hide();
            stickyNotes.ShowDialog();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Category category = new Category(createformBll.UserID);
            category.ShowDialog();
            
            CreateForm createForm = new CreateForm(createformBll.UserID);
            this.Refresh();
            createForm.ShowDialog();
        }


        private void CreateForm_Load(object sender, EventArgs e)
        {
            cmbcategory.DataSource = createformBll.displaycmb();
            cmbcategory.DisplayMember = "CategoryType";
            cmbcategory.ValueMember = "CategoryID";
        }

        private void chkCompleted_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
