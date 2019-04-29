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
    public partial class Category : Form
    {
        CategoryBll categoryBll = new CategoryBll();
        UserBll userBll = new UserBll();
        CreateFormBll createformBll = new CreateFormBll();
        LoginBll loginBll = new LoginBll();
        public Category(int uid)
        {
            InitializeComponent();
            categoryBll.UserID = uid;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            categoryBll.CategoryType = txtCategory.Text;

            if (btnCreate.Text == "Create")
            {
                if (txtCategory.Text != "")
                {
                    categoryBll.insert();
                    txtCategory.Text = "";
                    display();
                    createformBll.displaycmb();

                }
                else
                {
                    MessageBox.Show("Empty Category Field");
                    return;
                }
            }
            else
            {
                categoryBll.update();
                txtCategory.Text = "";
                display();
                btnCreate.Text = "Create";

            }
         }
        private void Category_Load(object sender, EventArgs e)
        {
            display();
        }
        private void display()
        {
            dataGridView1.DataSource = categoryBll.displaydatas();
        }
        

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                categoryBll.CategoryID = int.Parse(dataGridView1.CurrentRow.Cells["CategoryID"].Value.ToString());
                DataTable dt;
                if (dataGridView1.CurrentRow.Cells[columnIndex].Value.ToString() == "Edit")
                {
                    dt = categoryBll.edisplaydatas();
                    txtCategory.Text = dt.Rows[0][0].ToString();
                    btnCreate.Text = "Update";

                }
                else if (dataGridView1.CurrentRow.Cells[columnIndex].Value.ToString() == "Delete")
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete"
                       , MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        categoryBll.delete();
                    }
                    display();

                    txtCategory.Text = "";
                    btnCreate.Text = "Create";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
