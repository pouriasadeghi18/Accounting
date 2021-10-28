using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BusinessEntity;
using BusinessLogic;

namespace Accounting.App.Forms
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }
       public int sum; AccountingBl bl = new AccountingBl();


       





        //private int check(int typeid)
        //{

        //    List<BusinessEntity.Accounting> l = new List<BusinessEntity.Accounting>();
        //    if (typeid == 1)
        //    {
        //        l.AddRange(bl.Read().Where(i => i.Typeid == 1));
        //    }
        //    else
        //    {
        //        l.AddRange(bl.Read().Where(i => i.Typeid == 2));
        //    }
        //    return 
        //    //return/* sum = l.Sum(i => i.Amount);*/


        //}
        //private List<BusinessEntity.Accounting> check(int typeid)
        //{
        //    return bl.Read().Where(i => i.Typeid == typeid).Single();
            
        //    if (typeid == 1)
        //    {
        //        l.AddRange(bl.Read().Where(i => i.Typeid == 1));
        //    }
        //    else
        //    {
        //        l.AddRange(bl.Read().Where(i => i.Typeid == 2));
        //    }
        //    return sum = l.Sum(i => i.Amount);


        //}
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Chart_Load(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); }
            try
            {
                List<BusinessEntity.Accounting> accountings = bl.Read().Where(i => i.Typeid == 1).ToList();
                List<BusinessEntity.Accounting> accountingss = bl.Read().Where(i => i.Typeid == 2).ToList();
                List<DateTime> dates = accountings.Select(i => i.DataTitle).ToList();
                List<int> amountss = accountings.Select(i => i.Amount).ToList();
                List<DateTime> datess = accountingss.Select(i => i.DataTitle).ToList();
                List<int> amountsss = accountingss.Select(i => i.Amount).ToList();

                for (int i = 0; i < accountings.Count; i++)
                {
                    chart1.Series["hazine"].Points.AddXY(dates[i], amountss[i]);
                    
                }
                for (int i = 0; i < accountingss.Count; i++)
                {
                    chart1.Series["daramad"].Points.AddXY(datess[i], amountsss[i]);
                }
            }catch(Exception ex)
            {
                
                MessageBox.Show(ex.Message, "خطا");
            }
           

          
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); series.ChartType = SeriesChartType.Spline; }
            try
            {
                List<BusinessEntity.Accounting> accountings = bl.Read().Where(i => i.Typeid == 1).ToList();
                List<BusinessEntity.Accounting> accountingss = bl.Read().Where(i => i.Typeid == 2).ToList();
                List<DateTime> dates = accountings.Select(i => i.DataTitle).ToList();
                List<int> amountss = accountings.Select(i => i.Amount).ToList();
                List<DateTime> datess = accountingss.Select(i => i.DataTitle).ToList();
                List<int> amountsss = accountingss.Select(i => i.Amount).ToList();

                for (int i = 0; i < accountings.Count; i++)
                {
                    chart1.Series["hazine"].Points.AddXY(dates[i], amountss[i]);

                }
                for (int i = 0; i < accountingss.Count; i++)
                {
                    chart1.Series["daramad"].Points.AddXY(datess[i], amountsss[i]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطا");
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); series.ChartType = SeriesChartType.Column; }
            try
            {
                List<BusinessEntity.Accounting> accountings = bl.Read().Where(i => i.Typeid == 1).ToList();
                List<BusinessEntity.Accounting> accountingss = bl.Read().Where(i => i.Typeid == 2).ToList();
                List<DateTime> dates = accountings.Select(i => i.DataTitle).ToList();
                List<int> amountss = accountings.Select(i => i.Amount).ToList();
                List<DateTime> datess = accountingss.Select(i => i.DataTitle).ToList();
                List<int> amountsss = accountingss.Select(i => i.Amount).ToList();

                for (int i = 0; i < accountings.Count; i++)
                {
                    chart1.Series["hazine"].Points.AddXY(dates[i], amountss[i]);

                }
                for (int i = 0; i < accountingss.Count; i++)
                {
                    chart1.Series["daramad"].Points.AddXY(datess[i], amountsss[i]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطا");
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); series.ChartType = SeriesChartType.Point; }
            try
            {
                List<BusinessEntity.Accounting> accountings = bl.Read().Where(i => i.Typeid == 1).ToList();
                List<BusinessEntity.Accounting> accountingss = bl.Read().Where(i => i.Typeid == 2).ToList();
                List<DateTime> dates = accountings.Select(i => i.DataTitle).ToList();
                List<int> amountss = accountings.Select(i => i.Amount).ToList();
                List<DateTime> datess = accountingss.Select(i => i.DataTitle).ToList();
                List<int> amountsss = accountingss.Select(i => i.Amount).ToList();

                for (int i = 0; i < accountings.Count; i++)
                {
                    chart1.Series["hazine"].Points.AddXY(dates[i], amountss[i]);

                }
                for (int i = 0; i < accountingss.Count; i++)
                {
                    chart1.Series["daramad"].Points.AddXY(datess[i], amountsss[i]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطا");
            }
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); series.ChartType = SeriesChartType.Line; }
            try
            {
                List<BusinessEntity.Accounting> accountings = bl.Read().Where(i => i.Typeid == 1).ToList();
                List<BusinessEntity.Accounting> accountingss = bl.Read().Where(i => i.Typeid == 2).ToList();
                List<DateTime> dates = accountings.Select(i => i.DataTitle).ToList();
                List<int> amountss = accountings.Select(i => i.Amount).ToList();
                List<DateTime> datess = accountingss.Select(i => i.DataTitle).ToList();
                List<int> amountsss = accountingss.Select(i => i.Amount).ToList();

                for (int i = 0; i < accountings.Count; i++)
                {
                    chart1.Series["hazine"].Points.AddXY(dates[i], amountss[i]);

                }
                for (int i = 0; i < accountingss.Count; i++)
                {
                    chart1.Series["daramad"].Points.AddXY(datess[i], amountsss[i]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطا");
            }
        }
    }
}
