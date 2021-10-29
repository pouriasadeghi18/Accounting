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
    public partial class Report : Form
    {

        public Report()
        {
            
            
            
            
            
            
            InitializeComponent();

        }
        public int TypeId;
        private string ReportName;
      private  void Refresh()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.Rows.Clear();
            AccountingBl bl = new AccountingBl();
            CostomerBL cbl = new CostomerBL();
            rjComboBox1.SelectedIndex = 0;
            maskedTextBox1.Text = string.Empty;
            maskedTextBox2.Text = string.Empty;
              
            List<BusinessEntity.Accounting> result = new List<BusinessEntity.Accounting>();
            result.AddRange(bl.Read().Where(i => i.Typeid == TypeId));
            foreach (var item in result)
            {
 
                string CustomerName = cbl.GetCustomerNameByID(item.Costomerid);
                guna2DataGridView1.Rows.Add(item.id, CustomerName, item.Amount, item.DataTitle.ToShamsi(), item.Discraption);
            }
        }
        void Filter()
        {
            DateTime? startDate;
            DateTime? endDate;


            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.Rows.Clear();
            AccountingBl bl = new AccountingBl();
            CostomerBL cbl = new CostomerBL();
            List<BusinessEntity.Accounting> result = new List<BusinessEntity.Accounting>();
            if ((int)rjComboBox1.SelectedIndex != 0)
            {
                int CostomerId = int.Parse(rjComboBox1.SelectedIndex.ToString());
                result.AddRange(bl.Read().Where(i => i.Costomerid == CostomerId && i.Typeid == TypeId));
            }
            else
            {
                result.AddRange(bl.Read().Where(i => i.Typeid == TypeId));
            }

            try
            {
                if (maskedTextBox1.Text != "    /  /")
                {

                    startDate = Convert.ToDateTime(maskedTextBox1.Text);
                    startDate = DateConvertor.ToMiladi(startDate.Value);
                    result = result.Where(i => i.DataTitle >= startDate).ToList();

                }
                if (maskedTextBox2.Text != "    /  /")
                {

                    endDate = Convert.ToDateTime(maskedTextBox2.Text);
                    endDate = DateConvertor.ToMiladi(endDate.Value);
                    result = result.Where(i => i.DataTitle <= endDate).ToList();
                }
            }
            catch
            {
                MessageBox.Show("تاریخ مورد نظر را به درستی وارد کنید");
            }
         
            foreach (var item in result)
            {
                string CustomerName = cbl.GetCustomerNameByID(item.Costomerid);
                guna2DataGridView1.Rows.Add(item.id, CustomerName, item.Amount, item.DataTitle.ToShamsi(), item.Discraption);
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.CurrentRow != null)
            {
                int id = int.Parse(guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا از حذف مطمئن هستید؟", "حذف", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    AccountingBl bl = new AccountingBl();
                    bl.Delete(id);
                }

                Filter();
            }
        }



        private void toolStripButton2_Click_1(object sender, EventArgs e)

        {

            if (guna2DataGridView1.CurrentRow != null)
            {
                int id = int.Parse(guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                Forms.Transaction transaction = new Transaction();
                transaction.AccountID = id;
                if (transaction.ShowDialog() == DialogResult.OK)
                {
                    Filter();
                }
            }

        }

        private void Report_Load(object sender, EventArgs e)
        {
            List<CostomerViewModel> costomerlist = new List<CostomerViewModel>();
            costomerlist.Add(new CostomerViewModel() { CostomerID = 0, FullName = "انتخاب کنید" });
            CostomerBL bL = new CostomerBL();
            costomerlist.AddRange(bL.GetNameCustomer());
            rjComboBox1.DataSource = costomerlist;
            rjComboBox1.DisplayMember = "FullName";
            rjComboBox1.ValueMember = "CostomerID";
            Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (TypeId == 1)
            {
                ReportName = "گذارش پرداختی ها";
            }
            else
            {
                ReportName = "گذارش دریافتی ها";
            }


            DataTable dtprint = new DataTable();
            dtprint.Columns.Add("Costomer");
            dtprint.Columns.Add("Amount");
            dtprint.Columns.Add("DataTitle");
            dtprint.Columns.Add("Discraption");
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                dtprint.Rows.Add(item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString(), item.Cells[3].Value.ToString(), item.Cells[4].Value.ToString());

            }
            stiReport1.Dictionary.Variables["Name"].Value = ReportName;
            
            stiReport1.RegData("DT", dtprint);
            stiReport1.Render();
            stiReport1.Show();
        }

        private void Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
