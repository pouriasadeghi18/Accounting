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
            guna2DataGridView1.Columns["Password"].Visible = false;
            guna2DataGridView1.Columns["FullName"].HeaderText = "نام";
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
            guna2DataGridView1.Columns["Password"].Visible = false;
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
            int costomerId = int.Parse(guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
            if(MessageBox.Show("آیا میخواهید فیلد مورد نظر را حذف کنید", "حذف",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Bl.Delete(costomerId);
            }
            
            SetDataGrid();
        }
    }
}
