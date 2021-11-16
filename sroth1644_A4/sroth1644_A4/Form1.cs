/*
 * FILE             :   Form1.cs
 * PROJECT          :   Assignment-04: Data Visualization
 * PROGRAMMER       :   Sky Roth
 * FIRST VERSION    :   November 11, 2021
 * DESCRIPTION      :   This file will supply the backend for the designed windows form
 */



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
using System.Text.RegularExpressions;

namespace sroth1644_A4
{
    public partial class lineChart : Form
    {

        private string totalCaseSeries = "Cases Total";
        private string totalConfCaseSeries = "Confirmed Cases Total";
        private string totalTestedSeries = "Number of Individuals Tested";

        public lineChart()
        {
            InitializeComponent();

            readCSV();
            initDateComboBox();
            initRegionComboBox();
            initPieChart();
            initLineChart();
            initMainWindow();
        }

        public void initMainWindow()
        {
            this.Text = "Covid-19 Tracker";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        /*
         *  FUNCTION    :   initPieChart()
         *  DESCRIPTION :   This function will declare the pie chart and create its series
         */
        public void initPieChart()
        {
            Title pieTitle = new Title();
            pieTitle.Text = "Total Number of Cases";
            pieChart.Titles.Add(pieTitle);

            pieChart.Series.Clear();
            pieChart.Legends.Clear();

            pieChart.Legends.Add("Regions");
            pieChart.Legends[0].Docking = Docking.Bottom;
            pieChart.Legends[0].LegendStyle = LegendStyle.Table;
            pieChart.Legends[0].Title = "Regions";

            pieChart.Series.Add(totalCaseSeries);
            pieChart.Series[totalCaseSeries].ChartType = SeriesChartType.Pie;
            pieChart.Series[totalCaseSeries].IsValueShownAsLabel = true;

            updatePieChart();
        }


        /*
         *  FUNCTION    :   updatePieChart()
         *  DESCRIPTION :   This function willupdate the pie chart with new values from a SQL query
         */
        public void updatePieChart()
        {
            SQLCharts sqlCharts = new SQLCharts();
            pieChart.Series[0].ChartType = SeriesChartType.Pie;
            pieChart.Legends[0].Enabled = true;

            DataTable dt = sqlCharts.getData(dateComboBox.SelectedItem.ToString(), caseDataType.totalCases);
            
            pieChart.DataSource = dt;
            pieChart.Series[totalCaseSeries].XValueMember = "Region";
            pieChart.Series[totalCaseSeries].YValueMembers = "Total Cases";
        }


        /*
         *  FUNCTION    :   initLineChart()
         *  DESCRIPTION :   This function will declare the line chart and create its series
         */
        public void initLineChart()
        {
            Title lineTitle = new Title();
            SQLCharts charts = new SQLCharts();
            DataTable dt = new DataTable();

            lineTitle.Text = "Confimed Cases and Individuals Tested";
            lineGraph.Titles.Add(lineTitle);

            lineGraph.Series.Clear();
            lineGraph.Legends.Clear();

            lineGraph.Legends.Add("Legend");
            lineGraph.Legends[0].Docking = Docking.Bottom;
            lineGraph.Legends[0].LegendStyle = LegendStyle.Table;
            lineGraph.Legends[0].Title = "Legend";

            lineGraph.Series.Add(totalConfCaseSeries);
            lineGraph.Series.Add(totalTestedSeries);
            lineGraph.Series[totalConfCaseSeries].ChartType = SeriesChartType.Line;
            lineGraph.Series[totalConfCaseSeries].IsValueShownAsLabel = true;

            lineGraph.Series[totalTestedSeries].ChartType = SeriesChartType.Line;
            lineGraph.Series[totalTestedSeries].IsValueShownAsLabel = true;

            int week = endDate.Items.Count;
            if (endDate.Items.Count > 7)
            {
                week = 7;
            }

            startDate.SelectedIndex = 0;
            endDate.SelectedIndex = week;

            dt = charts.getTimeFrameData(startDate.Items[week].ToString(), endDate.Items[0].ToString(), lineRegionComboBox.SelectedItem.ToString());
            updateLineGraph(dt);
        }


        /*
         *  FUNCTION    :   updateLineGraph()
         *  DESCRIPTION :   This function will update the line graph
         */
        public void updateLineGraph(DataTable dt)
        {
            SQLCharts sqlCharts = new SQLCharts();
            lineGraph.Series[0].ChartType = SeriesChartType.Line;
            lineGraph.Legends[0].Enabled = true;

            lineGraph.DataSource = dt;

            lineGraph.Series[totalConfCaseSeries].XValueType = ChartValueType.DateTime;
            lineGraph.DataManipulator.IsStartFromFirst = true;
            lineGraph.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            lineGraph.ChartAreas[0].AxisX.Interval = 2;
            lineGraph.Series[totalConfCaseSeries].XValueMember = "Date";
            lineGraph.Series[totalConfCaseSeries].YValueMembers = "Num Cases";

            lineGraph.Series[totalTestedSeries].XValueType = ChartValueType.DateTime;
            lineGraph.Series[totalTestedSeries].XValueMember = "Date";
            lineGraph.Series[totalTestedSeries].YValueMembers = "Num Tested";
        }


        /*
         *  FUNCTION    :   initDateComboBox()
         *  DESCRIPTION :   This function will fille the date combo box with values
         */
        public void initDateComboBox()
        {
            SQLCharts sqlCharts = new SQLCharts();
            List<string> dates = new List<string>();
            dates = sqlCharts.getAllDates();

            dateComboBox.DataSource = dates;
            dateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            dateComboBox.SelectedItem = dateComboBox.Items[0];
            dateComboBox.SelectedText = dateComboBox.Items[0].ToString();

            dateComboBox.SelectedIndexChanged += new System.EventHandler(dateComboBox_SelectedIndexChanged);

            startDate.BindingContext = new BindingContext();
            startDate.DataSource = dates;
            startDate.DropDownStyle = ComboBoxStyle.DropDownList;

            endDate.BindingContext = new BindingContext();
            endDate.DataSource = dates;
            endDate.DropDownStyle = ComboBoxStyle.DropDownList;
        }



        /*
         *  FUNCTION    :   initRegionComboBox()
         *  DESCRIPTION :   This function will update the region combo box with values
         */
        public void initRegionComboBox()
        {
            var dataSource = new List<string>();
            dataSource.Add("Canada");
            dataSource.Add("Alberta");
            dataSource.Add("British Columbia");
            dataSource.Add("Manitoba");
            dataSource.Add("New Brunswick");
            dataSource.Add("Newfoundland and Labrador");
            dataSource.Add("Northwest Territories");
            dataSource.Add("Nova Scotia");
            dataSource.Add("Nunavut");
            dataSource.Add("Ontario");
            dataSource.Add("Prince Edward Island");
            dataSource.Add("Quebec");
            dataSource.Add("Repatriated Travellers");
            dataSource.Add("Saskatchewan");
            dataSource.Add("Yukon");

            lineRegionComboBox.DataSource = dataSource;
            lineRegionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            lineRegionComboBox.SelectedItem = lineRegionComboBox.Items[0];
            lineRegionComboBox.SelectedText = lineRegionComboBox.Items[0].ToString();
        }

        private void dateComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            updatePieChart();
        }



        /*
         *  FUNCTION    :   readCSV()
         *  DESCRIPTION :   This function will read the inputted CSV
         */
        public void readCSV()
        {
            CSVReader reader = new CSVReader();
            ConfigString cs = new ConfigString();
            string path = cs.getFilePath();
            reader.ReadCSV(path);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(startDate.Text);
            DateTime end = Convert.ToDateTime(endDate.Text);
            SQLCharts charts = new SQLCharts();

            if (start < end)
            {
                DataTable dt = new DataTable();
                dt = charts.getTimeFrameData(startDate.Text, endDate.Text, lineRegionComboBox.SelectedItem.ToString());
                updateLineGraph(dt);
            } else
            {
                MessageBox.Show("Please choose a start date that's before the end date", "Error: Incorrect Date Range");
            }
        }

        private void removeAllSQLDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLCharts charts = new SQLCharts();
            DialogResult dr = MessageBox.Show("Are you sure you want to remove all imported SQL data?", "Delete Data", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                charts.removeAllSQLData();
            } else
            {
                return;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
