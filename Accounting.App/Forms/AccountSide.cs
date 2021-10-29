using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;

namespace Accounting.App.Forms
{
    public partial class AccountSide : Form
    {
        public AccountSide()
        {
            InitializeComponent();
        }
        CostomerBL Bl = new CostomerBL();
        void SetDataGrid()
        {
           
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = Bl.Read();
            guna2DataGridView1.Columns["CostomerID"].Visible = false;
            guna2DataGridView1.Columns["PicAddress"].Visible = false;
            guna2DataGridView1.Columns["Address"].Visible = false;
            
            guna2DataGridView1.Columns["FullName"].HeaderText = "نام اشخاص";
            guna2DataGridView1.Columns["E_Post"].HeaderText = "ایمیل";
            guna2DataGridView1.Columns["Mobile"].HeaderText = "موبایل";
           


        }
        void SearchData(string TextBox)
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = Bl.Read(TextBox);
            guna2DataGridView1.Columns["CostomerID"].Visible = false;
            guna2DataGridView1.Columns["PicAddress"].Visible = false;
            guna2DataGridView1.Columns["Address"].Visible = false;
        
            guna2DataGridView1.Columns["FullName"].HeaderText = "نام";
            guna2DataGridView1.Columns["E_Post"].HeaderText = "ایمیل";
            guna2DataGridView1.Columns["Mobile"].HeaderText = "موبایل";
        }

        private void AccountSide_Load(object sender, EventArgs e)
        {
            SetDataGrid();
        }

        

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SetDataGrid();
            guna2TextBox1.Text = "";
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            SearchData(guna2TextBox1.Text);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int costomerId = int.Parse(guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                string message = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();

                if (MessageBox.Show($"آیا از حذف {message} مطئن هستید؟", "حذف", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Bl.Delete(costomerId);
                }
            }
            catch
            {
                MessageBox.Show("شخصی را انتخاب نکرده اید");
            }
           
            
            SetDataGrid();
        }

        private void Btnaddcostmoer_Click(object sender, EventArgs e)
        {
            AccountSideAddForm AddForm = new AccountSideAddForm();

            if (AddForm.ShowDialog() == DialogResult.OK)
            {
                SetDataGrid();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(guna2DataGridView1.CurrentRow != null)
            {
                int customerID =int.Parse(guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                AccountSideAddForm editForm = new AccountSideAddForm();
                editForm.CustomerId = customerID;
                if(editForm.ShowDialog() == DialogResult.OK)
                {
                    SetDataGrid();
                }
            }
            

        }

       
    }
}
