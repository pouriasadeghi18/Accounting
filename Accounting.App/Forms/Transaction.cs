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
    public partial class Transaction : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
              (
                  int nLeftRect,     // x-coordinate of upper-left corner
                  int nTopRect,      // y-coordinate of upper-left corner
                  int nRightRect,    // x-coordinate of lower-right corner
                  int nBottomRect,   // y-coordinate of lower-right corner
                  int nWidthEllipse, // width of ellipse
                  int nHeightEllipse); // height of ellipse
        public Transaction()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        bool check;
        public int AccountID = 0;
        void SetDataGrid()
        {
            CostomerBL Bl = new CostomerBL();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = Bl.Read();
            guna2DataGridView1.Columns["CostomerID"].Visible = false;
            guna2DataGridView1.Columns["PicAddress"].Visible = false;
            guna2DataGridView1.Columns["Address"].Visible = false;

            guna2DataGridView1.Columns["FullName"].HeaderText = "نام اشخاص";
            guna2DataGridView1.Columns["E_Post"].Visible = false;
            guna2DataGridView1.Columns["Mobile"].Visible = false;

        }
        public void nexttextbox(object btnSender, KeyEventArgs e)
        {
            if (btnSender != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        void SearchData(string TextBox)
        {
            CostomerBL Bl = new CostomerBL();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = Bl.Read(TextBox);
            guna2DataGridView1.Columns["CostomerID"].Visible = false;
            guna2DataGridView1.Columns["PicAddress"].Visible = false;
            guna2DataGridView1.Columns["Address"].Visible = false;
            
            guna2DataGridView1.Columns["FullName"].HeaderText = "نام اشخاص";
            guna2DataGridView1.Columns["E_Post"].Visible = false;
            guna2DataGridView1.Columns["Mobile"].Visible = false;
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            SetDataGrid();
            if (AccountID != 0)
            {
                CostomerBL cBl = new CostomerBL();
                AccountingBl abl = new AccountingBl();
                var accont = abl.Read(AccountID);

                guna2TextBox1.Text = cBl.GetCustomerNameByID(accont.Costomerid);
                if (accont.Typeid == 1)
                {
                    rjRadioButton2.Checked = true;
                }
                else
                {
                    rjRadioButton1.Checked = true;
                }
                guna2NumericUpDown1.Value = accont.Amount;
                rjTextBox2.Texts = accont.Discraption;
                this.Text = "ویرایش";
                rjButton1.Text = "ویرایش";
            }

        }



        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {
            SearchData(rjTextBox1.Texts);
        }


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = Application.StartupPath + "/Images/";
            guna2TextBox1.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            rjCircularPictureBox1.ImageLocation = path + guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == string.Empty)
            {
                guna2TextBox1.Focus();
                errorProvider1.SetError(guna2TextBox1, "لطفا طرف شخص را از لیست انتخاب کنید");
                check = false;
            }
            else
            {
                errorProvider1.Clear();
                check = true;
            }
            if (rjRadioButton1.Checked || rjRadioButton2.Checked)
            {
                check = true;
            }
            else
            {
                MessageBox.Show("لطفا نوع تراکنش را انتخاب کنید");
                check = false;

            }

            if ((guna2NumericUpDown1.Value == 0))
            {
                guna2NumericUpDown1.Focus();
                errorProvider1.SetError(guna2NumericUpDown1, "لطفا مبلغ را وارد کنید");
                check = false;
            }
            else
            {
                errorProvider1.Clear();
                check = true;
            }


            if (check == true)
            {
                CostomerBL Bl = new CostomerBL();

                BusinessEntity.Accounting Accounting = new BusinessEntity.Accounting();
                Accounting.Amount = int.Parse(guna2NumericUpDown1.Value.ToString());
                try
                {
                    Accounting.Costomerid = Bl.GetId(guna2TextBox1.Text);
                }
                catch
                {
                    
                }
                
                Accounting.Typeid = (rjRadioButton2.Checked) ? 1 : 2;
                Accounting.DataTitle = DateTime.Now;
                Accounting.Discraption = rjTextBox2.Texts;
                AccountingBl bl = new AccountingBl();
                if (AccountID == 0)
                {
                    try
                    {
                        MessageBox.Show(bl.Create(Accounting));
                    }
                    catch
                    {
                        MessageBox.Show("شخص مورد نظر خود را انتخاب کنید");
                    }
                    
                }
                else
                {
                    MessageBox.Show(bl.Update(AccountID, Accounting));
                    DialogResult = DialogResult.OK;
                }



            }
        }

   

        private void Transaction_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

     

     

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void rjRadioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void rjRadioButton2_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2NumericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void rjTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void rjTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }
    }
}