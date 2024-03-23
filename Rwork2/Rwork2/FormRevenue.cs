using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rwork2
{

    public partial class FormRevenue : Form
    {
        List<string> SearchOrderslist = new List<string>()
        { "Orders.Oid", "State", "Pname", "Mname", "Ocount", "OPrice", "OSale", "Ototalprice", "Oremark" };
        List<string> SearchOrderslist2 = new List<string>()
        { "OrderDate", "ODueDate" , "OShipDate"};
        List<int> txData = new List<int>();
        List<int> tyData = new List<int>();
        DateTime starttime = DateTime.Now;
        DateTime endtime = DateTime.Now;
        public FormRevenue()
        {
            InitializeComponent();
        }

        private void FormRevenue_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            initOrderListView();

            cbSearchOrder2.Items.Clear();
            cbSearchOrder2.Items.Add("訂貨日期");
            cbSearchOrder2.Items.Add("到期日期");
            cbSearchOrder2.Items.Add("出貨日期");
            cbSearchOrder2.SelectedIndex = 0;
            
            chartRevenue.Titles.Add("營業額");
            chartRevenue.BackColor = Color.Transparent;
            chartRevenue.ChartAreas.Add(new ChartArea()); //生成繪圖區域
            chartRevenue.ChartAreas[0].Axes[0].MajorGrid.Enabled = false; //X軸虛線
            chartRevenue.ChartAreas[0].Axes[0].MajorGrid.LineDashStyle = ChartDashStyle.Dash;//X軸虛線類型
            chartRevenue.ChartAreas[0].Axes[0].MajorGrid.LineColor = Color.Gray;//X軸虛線顏色
            chartRevenue.ChartAreas[0].Axes[0].MajorTickMark.Enabled = true; //X軸突出線
            chartRevenue.ChartAreas[0].Axes[0].MajorGrid.LineWidth = 1;//X軸虛線寬度
            chartRevenue.ChartAreas[0].Axes[0].LabelStyle.Format = "#年"; //x軸文字表示

            chartRevenue.ChartAreas[0].Axes[1].MajorGrid.Enabled = false; //Y軸虛線
            chartRevenue.ChartAreas[0].Axes[1].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //Y軸虛線類型
            chartRevenue.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Gray;              //Y軸虛線顏色
            chartRevenue.ChartAreas[0].Axes[1].MajorTickMark.Enabled = true; //Y軸突出線
            chartRevenue.ChartAreas[0].Axes[1].IsInterlaced = true; //顯示交錯背景
            chartRevenue.ChartAreas[0].Axes[1].MajorGrid.LineWidth = 1;//X軸虛線寬度
            chartRevenue.ChartAreas[0].BackColor = System.Drawing.Color.Transparent; //繪圖區域背景透明
            dtpStart.Value = new DateTime(1980,1,1);
            dtpEnd.Value = DateTime.Now;
            starttime = dtpStart.Value;
            endtime = dtpEnd.Value;
            RevenueCal();
            DataChart();
        }
        private void butSearch_Click(object sender, EventArgs e)
        {
            SeriesChartType seriesChartType = chartRevenue.Series[0].ChartType;
            starttime = dtpStart.Value;
            endtime = dtpEnd.Value;
            Search();
            RevenueCal();
            DataChart();
            chartRevenue.Series[0].ChartType = seriesChartType;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            initOrderListView();
            dtpStart.Value = new DateTime(1980, 1, 1);
            dtpEnd.Value = DateTime.Now;
            starttime = dtpStart.Value;
            endtime = dtpEnd.Value;
            RevenueCal();
            DataChart();
        }

        private void butWeek_Click(object sender, EventArgs e)
        {
            SeriesChartType seriesChartType = chartRevenue.Series[0].ChartType;
            starttime = DateTime.Now.AddDays(- 7);
            endtime = DateTime.Now;
            Search();
            RevenueCal();
            DataChart();
            chartRevenue.Series[0].ChartType = seriesChartType;
        }

        private void butMonth_Click(object sender, EventArgs e)
        {
            SeriesChartType seriesChartType = chartRevenue.Series[0].ChartType;
            starttime = DateTime.Now.AddMonths(-1);
            endtime = DateTime.Now;
            Search();
            RevenueCal();
            DataChart();
            chartRevenue.Series[0].ChartType = seriesChartType;
        }
        private void butYear_Click(object sender, EventArgs e)
        {
            SeriesChartType seriesChartType = chartRevenue.Series[0].ChartType;
            starttime = DateTime.Now.AddYears(-1);
            endtime = DateTime.Now;
            Search();
            RevenueCal();
            DataChart();
            chartRevenue.Series[0].ChartType=seriesChartType;
        }

        private void butColumn_Click(object sender, EventArgs e)
        {
            chartRevenue.Series[0].ChartType = SeriesChartType.Column; //圖類型
        }

        private void butBar_Click(object sender, EventArgs e)
        {
            chartRevenue.Series[0].ChartType = SeriesChartType.Bar; //圖類型
        }

        private void butLine_Click(object sender, EventArgs e)
        {
            chartRevenue.Series[0].ChartType = SeriesChartType.Line; //圖類型
        }

        private void butPie_Click(object sender, EventArgs e)
        {
            chartRevenue.Series[0].ChartType = SeriesChartType.Pie; //圖類型
            //   Line
            //   Column
            //   Pie
            //   Bar
        }

        public void initlvOrder()
        {
            lvOrder.Clear();
            lvOrder.Columns.Add("選擇", 50, HorizontalAlignment.Center);
            lvOrder.Columns.Add("ID", 70, HorizontalAlignment.Center);
            lvOrder.Columns.Add("狀態", 80, HorizontalAlignment.Center);
            lvOrder.Columns.Add("口味", 120, HorizontalAlignment.Center);
            lvOrder.Columns.Add("訂購人", 120, HorizontalAlignment.Center);
            lvOrder.Columns.Add("數量", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("價格", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("折扣", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("總價", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("訂貨日期", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("到期日期", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("出貨日期", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("備註", 200, HorizontalAlignment.Center);
        }

        public void initOrderListView()
        {
            initlvOrder();
            lvOrder.BeginUpdate();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT Orders.*, Products.Pname, Member.Mname ,OrdersState.State " +
                "FROM Orders " +
                "JOIN Products ON Orders.Pid = Products.Pid " +
                "JOIN Member ON Orders.Mid = Member.Mid " +
                "JOIN OrdersState ON Orders.Sid = OrdersState.Sid ";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "口";
                listViewItem.SubItems.Add(reader["Oid"].ToString());
                listViewItem.SubItems.Add(reader["State"].ToString());
                listViewItem.SubItems.Add(reader["Pname"].ToString());
                listViewItem.SubItems.Add(reader["Mname"].ToString());
                listViewItem.SubItems.Add(reader["Ocount"].ToString());
                listViewItem.SubItems.Add(reader["OPrice"].ToString());
                listViewItem.SubItems.Add(reader["OSale"].ToString());
                listViewItem.SubItems.Add(reader["Ototalprice"].ToString());
                listViewItem.SubItems.Add(((DateTime)reader["OrderDate"]).ToString("yyyy/MM/dd"));
                listViewItem.SubItems.Add(((DateTime)reader["ODueDate"]).ToString("yyyy/MM/dd"));
                if (reader["OShipDate"] == DBNull.Value)
                {
                    listViewItem.SubItems.Add("無日期");
                }
                else
                {
                    listViewItem.SubItems.Add(((DateTime)reader["OShipDate"]).ToString("yyyy/MM/dd"));
                }
                listViewItem.SubItems.Add(reader["Oremark"].ToString());
                lvOrder.Items.Add(listViewItem);
            }
            reader.Close();
            con.Close();
            lvOrder.EndUpdate();
        }

        void DataChart()
        {
            //#VALX 显示当前图例的X轴的对应文本(或数据)
            //#VAL
            //#VALY,显示当前图例的Y轴的对应文本(或数据)
            //#VALY2,#VALY3,显示当前图例的辅助Y轴的对应文本(或数据)
            //#SER:显示当前图例的名称
            //#LABEL显示当前图例的标签文本
            //#INDEX显示当前图例的索引
            //#PERCENT显示当前图例的所占的百分比
            //#TOTAL总数量
            //#LEGENDTEXT图例文本
            chartRevenue.Series.Clear();
            chartRevenue.Series.Add(new Series()); //生成圖表序列
            chartRevenue.Series[0].Label = "#VAL"; //顯示點上值
            chartRevenue.Series[0].ToolTip = "#VALX年\t#VAL"; //滑鼠移動到對應點顯示值
            chartRevenue.Series[0].ChartArea = chartRevenue.ChartAreas[0].Name; //背景設定 
            chartRevenue.Series[0].ChartType = SeriesChartType.Column; //圖類型
            chartRevenue.Series[0].Points.DataBindXY(txData, tyData); //添加數據                                                       

            chartRevenue.Series[0].Color = Color.Red; //線條顏色
            chartRevenue.Series[0].BorderWidth = 5; //線條粗細
            chartRevenue.Series[0].MarkerBorderColor = Color.Red; //線上點顏色
            chartRevenue.Series[0].MarkerBorderWidth = 1; //線上點框大小
            chartRevenue.Series[0].MarkerColor = Color.Red; //線上點中心顏色
            chartRevenue.Series[0].MarkerSize = 3; //線上點中心大小
            chartRevenue.Series[0].MarkerStyle = MarkerStyle.Circle; //線上點類型

            //圓餅圖設定
            chartRevenue.Series[0]["PieLabelStyle"] = "Outside";//文字在外側
            chartRevenue.Series[0]["PieLineColor"] = "Red";     //連接文字線顏色
            //長方圖設定
            chartRevenue.Series[0]["DrawingStyle"] = "Emboss"; //設置長方圖形狀
            chartRevenue.Series[0]["PointWidth"] = "0.1"; //設置長方大小*/

            //   Line
            //   Column
            //   Pie
            //   Bar
        }
        void RevenueCal()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT  YEAR(" + SearchOrderslist2[cbSearchOrder2.SelectedIndex] + ")as salesYear,sum(Ototalprice)as salesAmount " +
                "FROM Orders " +
                "WHERE " + SearchOrderslist2[cbSearchOrder2.SelectedIndex] + ">=@SearchStartYear and " + SearchOrderslist2[cbSearchOrder2.SelectedIndex] + "<=@SearchEndYear " +
                "group by YEAR(" + SearchOrderslist2[cbSearchOrder2.SelectedIndex] + ") " +
                "order by YEAR(" + SearchOrderslist2[cbSearchOrder2.SelectedIndex] + ")";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchStartYear", starttime);
            cmd.Parameters.AddWithValue("@SearchEndYear", endtime);
            SqlDataReader reader = cmd.ExecuteReader();
            txData.Clear();
            tyData.Clear();
            while (reader.Read())
            {
                txData.Add((int)reader["salesYear"]);
                tyData.Add((int.Parse(reader["salesAmount"].ToString())));
            }
            reader.Close();
            con.Close();
        }

        void Search()
        {
            initlvOrder();
            lvOrder.BeginUpdate();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT Orders.*, Products.Pname, Member.Mname ,OrdersState.State " +
                "FROM Orders " +
                "JOIN Products ON Orders.Pid = Products.Pid " +
                "JOIN Member ON Orders.Mid = Member.Mid " +
                "JOIN OrdersState ON Orders.Sid = OrdersState.Sid " +
                "WHERE " + SearchOrderslist2[cbSearchOrder2.SelectedIndex] + ">=@SearchStartYear " +
                "and " + SearchOrderslist2[cbSearchOrder2.SelectedIndex] + "<=@SearchEndYear ";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchStartYear", starttime);
            cmd.Parameters.AddWithValue("@SearchEndYear", endtime);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "口";
                listViewItem.SubItems.Add(reader["Oid"].ToString());
                listViewItem.SubItems.Add(reader["State"].ToString());
                listViewItem.SubItems.Add(reader["Pname"].ToString());
                listViewItem.SubItems.Add(reader["Mname"].ToString());
                listViewItem.SubItems.Add(reader["Ocount"].ToString());
                listViewItem.SubItems.Add(reader["OPrice"].ToString());
                listViewItem.SubItems.Add(reader["OSale"].ToString());
                listViewItem.SubItems.Add(reader["Ototalprice"].ToString());
                listViewItem.SubItems.Add(((DateTime)reader["OrderDate"]).ToString("yyyy/MM/dd"));
                listViewItem.SubItems.Add(((DateTime)reader["ODueDate"]).ToString("yyyy/MM/dd"));
                if (reader["OShipDate"] == DBNull.Value)
                {
                    listViewItem.SubItems.Add("無日期");
                }
                else
                {
                    listViewItem.SubItems.Add(((DateTime)reader["OShipDate"]).ToString("yyyy/MM/dd"));
                }
                listViewItem.SubItems.Add(reader["Oremark"].ToString());
                lvOrder.Items.Add(listViewItem);
            }
            reader.Close();
            con.Close();
            lvOrder.EndUpdate();
        }
    }
}
