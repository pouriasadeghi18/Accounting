using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using System.IO;

namespace Accounting.App.Forms
{
    public partial class AccountSideAddForm : Form
    {
        public int CustomerId = 0;
        public AccountSideAddForm()
        {
            InitializeComponent();
        }

        bool chack = false;
        CostomerBL bl = new CostomerBL();

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (rjTextBox1.Texts.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^[\u0600-\u06FF ]+$");

                if (!mRegxExpression.IsMatch(rjTextBox1.Texts.Trim()))
                {
                    rjTextBox1.Focus();
                    errorProvider1.SetError(rjTextBox1, " لطفا نام خود را به فارسی تایپ کنید");
                    chack = false;

                }
                else if (mRegxExpression.IsMatch(rjTextBox1.Texts.Trim()))
                {
                    errorProvider1.Clear();
                    chack = true;
                }
            }
        }

        private void rjTextBox2__TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(rjTextBox2.Texts.Trim()))
                {
                    rjTextBox2.Focus();
                    errorProvider1.SetError(rjTextBox2, "قالب آدرس ایمیل شما صحیح نیست");
                    chack = false;

                }
                else
                {
                    errorProvider1.Clear();
                    chack = true;
                }
            
        }

        private void rjTextBox3__TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            
                mRegxExpression = new Regex(@"([0-9])$");

                if (!mRegxExpression.IsMatch(rjTextBox3.Texts.Trim()) || rjTextBox3.Texts.Length != 11)
                {

                    errorProvider1.SetError(rjTextBox3, " قالب شماره تلفن شما اشتباه است");
                    chack = false;



                }
                else if (mRegxExpression.IsMatch(rjTextBox3.Texts.Trim()) || rjTextBox3.Texts.Length == 11)
                {
                    errorProvider1.Clear();
                    chack = true;
                }
            
        }

        

      

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.ImageLocation = openFile.FileName;
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {  
            if(rjTextBox1.Texts.Trim() == string.Empty)
            {
                rjTextBox1.Focus();
                chack = false;
            }
          
          
            if(chack == true)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(guna2PictureBox1.ImageLocation);
                string path = Application.StartupPath + "/Images/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                guna2PictureBox1.Image.Save(path + imageName);


                Costomer costomer = new Costomer();
                costomer.FullName = rjTextBox1.Texts;
                costomer.E_Post = rjTextBox2.Texts;
                costomer.Mobile = rjTextBox3.Texts;
                
                costomer.Address = rjTextBox4.Texts;
                costomer.PicAddress = imageName;
                
                if(CustomerId == 0)
                {
                    MessageBox.Show(bl.Creat(costomer));
                }
                else
                {
                    MessageBox.Show(bl.Update(CustomerId, costomer));
                }

                DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("لطفا اطلاعات  را دقیق وارد کنید");
            }

        }

        private void AccountSideAddForm_Load(object sender, EventArgs e)
        {
            if (CustomerId != 0)
            {
                this.Text="ویرایش شخص";
                rjButton2.Text = "ویرایش";
                var customer = bl.Read(CustomerId);
                rjTextBox1.Texts = customer.FullName;
                rjTextBox2.Texts = customer.E_Post;
                rjTextBox3.Texts = customer.Mobile;
                
                rjTextBox4.Texts = customer.Address;
                guna2PictureBox1.ImageLocation = Application.StartupPath + "/Images/" + customer.PicAddress;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
