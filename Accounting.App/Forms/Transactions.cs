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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }
        CostomerBL Bl = new CostomerBL();
        
        bool check = false;
        void SetDataGrid()
        {

            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = Bl.Read();
            guna2DataGridView1.Columns["CostomerID"].Visible = false;
            guna2DataGridView1.Columns["PicAddress"].Visible = false;
            guna2DataGridView1.Columns["Address"].Visible = false;
            guna2DataGridView1.Columns["Password"].Visible = false;
            guna2DataGridView1.Columns["FullName"].HeaderText = "نام";
            guna2DataGridView1.Columns["E_Post"].Visible = false;
            guna2DataGridView1.Columns["Mobile"].Visible = false;



        }
        void SearchData(string TextBox)
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = Bl.Read(TextBox);
            guna2DataGridView1.Columns["CostomerID"].Visible = false;
            guna2DataGridView1.Columns["PicAddress"].Visible = false;
            guna2DataGridView1.Columns["Address"].Visible = false;
            guna2DataGridView1.Columns["Password"].Visible = false;
            guna2DataGridView1.Columns["FullName"].HeaderText = "نام اشخاص";
            guna2DataGridView1.Columns["E_Post"].Visible = false;
            guna2DataGridView1.Columns["Mobile"].Visible = false;
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            SetDataGrid();
            
        }

    

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            SearchData(guna2TextBox1.Text);
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox2.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == string.Empty)
            {
                guna2TextBox2.Focus();
                errorProvider1.SetError(guna2TextBox2, "لطفا طرف شخص را از لیست انتخاب کنید");
                check = false;
            }
         
            
            else if (guna2NumericUpDown1.Value == 0)
            {
                guna2NumericUpDown1.Focus();
                errorProvider1.SetError(guna2NumericUpDown1, "لطفا مبلغ را وارد کنید");
                check = false;

            }

            else
            {
                errorProvider1.Clear();
            }
           
            if(rjRadioButton1.Checked || rjRadioButton2.Checked)
            {
                check = true;
            }
            else
            {
                MessageBox.Show("لطفا نوع تراکنش را انتخاب کنید");
                check = false;

            }
            if(check == true)
            {
                BusinessEntity.Accounting Accounting = new BusinessEntity.Accounting() {
                    Amount = int.Parse(guna2NumericUpDown1.Value.ToString()),
                    Costomerid = Bl.GetId(guna2TextBox2.Text),
                    Typeid = (rjRadioButton2.Checked) ? 1 : 2,
                    DataTitle = DateTime.Now,
                    Discraption = rjTextBox2.Texts
                };

                AccountingBl bl = new AccountingBl();
                MessageBox.Show(bl.Create(Accounting));



            }
            
        }
    }
}
