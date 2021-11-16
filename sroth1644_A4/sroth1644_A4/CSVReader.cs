/*
 * FILE             :   CSVReader.cs
 * PROJECT          :   Assignment-04: Data Visualization
 * PROGRAMMER       :   Sky Roth
 * FIRST VERSION    :   November 11, 2021
 * DESCRIPTION      :   This file will read the inputted CSV containing the COVID data
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace sroth1644_A4
{
    class CSVReader
    {
        private string[] columnHeaders;



        /*
         *  FUNCTION    :   ReadCSV()
         *  DESCRIPTION :   This function will read the inputted CSV and parse its data
         */
        public int ReadCSV(string path)
        {
            List<string> columns = new List<string>();
            List<string> data = new List<string>();
            SQLCharts charts = new SQLCharts();

            if (charts.writeToSQL() > 0)
            {
                return -1;
            }

            if (charts.canConnectToSQL() == -1)
            {
                MessageBox.Show("Cannot connect your SQL client, please try again later", "Error: SQL Connection Failed");
                System.Windows.Forms.Application.Exit();
                return -1;
            }

            foreach (string line in File.ReadAllLines(path))
            {
                columns.Add(string.Join("", line.Split(';')));
            }

            columnHeaders = columns[0].Split(',');

            int i = 0;
            foreach (var column in columns)
            {
                data = new List<string>();
                foreach (var item in column.Split(','))
                {
                   if (i > 0)
                   {
                        data.Add(item);
                   }
                    
                }
                parseData(data);
                i += 1;
            }

            return 0;
        }



        /*
         *  FUNCTION    :   parseData()
         *  DESCRIPTION :   This function will add new data to a dictionary
         */
        public int parseData(List<String> data)
        {
            int i = 0;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            SQLCharts charts = new SQLCharts();
            foreach (var item in data)
            {
                dict.Add(columnHeaders[i], item);
                i += 1;
            }

            return 0;
        }
    }
}
