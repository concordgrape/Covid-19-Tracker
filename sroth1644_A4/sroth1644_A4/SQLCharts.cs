/*
 * FILE             :   SQLCharts.cs
 * PROJECT          :   Assignment-04: Data Visualization
 * PROGRAMMER       :   Sky Roth
 * FIRST VERSION    :   November 11, 2021
 * DESCRIPTION      :   This file will read and write to a specific SQL database
 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace sroth1644_A4
{
    enum caseDataType
    {
        totalCases,
        totalTested
    }

    class SQLCharts
    {


        /*
         *  FUNCTION    :   canConnectToSQL()
         *  DESCRIPTION :   This function will check the connection with the SQL database
         */
        public int canConnectToSQL()
        {
            ConfigString cs = new ConfigString();
            SqlConnection conn = new SqlConnection(cs.getConnString());

            try
            {
                conn.Open();
                conn.Close();
                return 0;
            } catch
            {
                conn.Close();
                return -1;
            }
        }



        /*
         *  FUNCTION    :   writeToSQL()
         *  DESCRIPTION :   This function check if any data is found in the CovidData table
         */
        public int writeToSQL()
        {
            ConfigString cs = new ConfigString();
            int toReturn = 0;
            using (SqlConnection connection = new SqlConnection(cs.getConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from CovidData";
                cmd.Connection = connection;
                cmd.Connection.Open();

                try
                {
                    toReturn = (int)cmd.ExecuteScalar();
                } catch
                {
                    toReturn = 0;
                }

                cmd.Connection.Close();
            }
            return toReturn;
        }


        /*
         *  FUNCTION    :   executeLineQuery()
         *  DESCRIPTION :   This function will fill the CovidData table
         */
        public int executeLineQuery(IDictionary<string, string>data)
        {
            int rows = 0;
            ConfigString cs = new ConfigString();
            using (SqlConnection connection = new SqlConnection(cs.getConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO CovidData VALUES (@pruid,@prname,@prnameFR,@selectedDate,@lastUpdate,@numconf,@numprob,@numdeaths,
                                    @numtotal,@numtested,@numtests,@numrecovered,@percentrecovered,@ratetested,@ratetests,@numtoday,@percentoday,@ratetotal,@ratedeaths,
                                    @numdeathstoday,@percentdeath,@numtestedtoday,@numteststoday,@numrecoveredtoday,@percentactive,@numactive,@rateactive,@numtotal_last14,
                                    @ratetotal_last14,@numdeaths_last14,@ratedeaths_last14,@numtotal_last7,@ratetotal_last7,@numdeaths_last7,@ratedeaths_last7,@avgtotal_last7,
                                    @avgincidence_last7,@avgdeaths_last7,@avgratedeaths_last7,@raterecovered)";
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@pruid", retrieveIntValue(data, "pruid"));
                cmd.Parameters.AddWithValue("@prname", retrieveStringValue(data, "prname"));
                cmd.Parameters.AddWithValue("@prnameFR", retrieveStringValue(data, "prnameFR"));
                cmd.Parameters.AddWithValue("@selectedDate", retrieveStringValue(data, "date"));
                cmd.Parameters.AddWithValue("@lastUpdate", retrieveIntValue(data, "lastUpdate"));
                cmd.Parameters.AddWithValue("@numconf", retrieveIntValue(data, "numconf"));
                cmd.Parameters.AddWithValue("@numprob", retrieveIntValue(data, "numprob"));
                cmd.Parameters.AddWithValue("@numdeaths", retrieveIntValue(data, "numdeaths"));
                cmd.Parameters.AddWithValue("@numtotal", retrieveIntValue(data, "numtotal"));
                cmd.Parameters.AddWithValue("@numtested", retrieveIntValue(data, "numtested"));
                cmd.Parameters.AddWithValue("@numtests", retrieveIntValue(data, "numtests"));
                cmd.Parameters.AddWithValue("@numrecovered", retrieveIntValue(data, "numrecovered"));
                cmd.Parameters.AddWithValue("@percentrecovered", retrieveIntValue(data, "percentrecovered"));
                cmd.Parameters.AddWithValue("@ratetested", retrieveIntValue(data, "ratetested"));
                cmd.Parameters.AddWithValue("@ratetests", retrieveIntValue(data, "ratetests"));
                cmd.Parameters.AddWithValue("@numtoday", retrieveIntValue(data, "numtoday"));
                cmd.Parameters.AddWithValue("@percentoday", retrieveIntValue(data, "percentoday"));
                cmd.Parameters.AddWithValue("@ratetotal", retrieveIntValue(data, "ratetotal"));
                cmd.Parameters.AddWithValue("@ratedeaths", retrieveIntValue(data, "ratedeaths"));
                cmd.Parameters.AddWithValue("@numdeathstoday", retrieveIntValue(data, "numdeathstoday"));
                cmd.Parameters.AddWithValue("@percentdeath", retrieveIntValue(data, "percentdeath"));
                cmd.Parameters.AddWithValue("@numtestedtoday", retrieveIntValue(data, "numtestedtoday"));
                cmd.Parameters.AddWithValue("@numteststoday", retrieveIntValue(data, "numteststoday"));
                cmd.Parameters.AddWithValue("@numrecoveredtoday", retrieveIntValue(data, "numrecoveredtoday"));
                cmd.Parameters.AddWithValue("@percentactive", retrieveIntValue(data, "percentactive"));
                cmd.Parameters.AddWithValue("@numactive", retrieveIntValue(data, "numactive"));
                cmd.Parameters.AddWithValue("@rateactive", retrieveIntValue(data, "rateactive"));
                cmd.Parameters.AddWithValue("@numtotal_last14", retrieveIntValue(data, "numtotal_last14"));
                cmd.Parameters.AddWithValue("@ratetotal_last14", retrieveIntValue(data, "ratetotal_last14"));
                cmd.Parameters.AddWithValue("@numdeaths_last14", retrieveIntValue(data, "numdeaths_last14"));
                cmd.Parameters.AddWithValue("@ratedeaths_last14", retrieveIntValue(data, "ratedeaths_last14"));
                cmd.Parameters.AddWithValue("@numtotal_last7", retrieveIntValue(data, "numtotal_last7"));
                cmd.Parameters.AddWithValue("@ratetotal_last7", retrieveIntValue(data, "ratetotal_last7"));
                cmd.Parameters.AddWithValue("@numdeaths_last7", retrieveIntValue(data, "numdeaths_last7"));
                cmd.Parameters.AddWithValue("@ratedeaths_last7", retrieveIntValue(data, "ratedeaths_last7"));
                cmd.Parameters.AddWithValue("@avgtotal_last7", retrieveIntValue(data, "avgtotal_last7"));
                cmd.Parameters.AddWithValue("@avgincidence_last7", retrieveIntValue(data, "avgincidence_last7"));
                cmd.Parameters.AddWithValue("@avgdeaths_last7", retrieveIntValue(data, "avgdeaths_last7"));
                cmd.Parameters.AddWithValue("@avgratedeaths_last7", retrieveIntValue(data, "avgratedeaths_last7"));
                cmd.Parameters.AddWithValue("@raterecovered", retrieveIntValue(data, "raterecovered"));

                try
                {
                    rows = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    rows = -1;
                }
                cmd.Connection.Close();
            }
           
            return rows;
        }

        public string retrieveStringValue(IDictionary<string, string> dict, string key)
        {
            string toReturn = "";

            dict.TryGetValue(key, out toReturn);

            return toReturn;
        }

        public double retrieveIntValue(IDictionary<string, string> dict, string key)
        {
            string toReturn = "";

            dict.TryGetValue(key, out toReturn);

            double t = 0;

            if (!Double.TryParse(toReturn, out t))
            {
                t = 0;
            }

            return t;
        }


        /*
         *  FUNCTION    :   getAllDates()
         *  DESCRIPTION :   This function will retrieve all the dates found in the SQL database
         */
        public List<string> getAllDates()
        {
            List<string> toReturn = new List<string>();
            ConfigString cs = new ConfigString();
            using (SqlConnection connection = new SqlConnection(cs.getConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT CONVERT(VARCHAR(15), selectedDate, 110) from CovidData GROUP BY selectedDate ORDER BY selectedDate DESC";
                cmd.Connection = connection;
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    toReturn.Add(reader[0].ToString());
                    i += 1;
                }
            }
            return toReturn;
        }


        /*
         *  FUNCTION    :   getData()
         *  DESCRIPTION :   This function will retireve data from the SQL table
         */
        public DataTable getData(string date, caseDataType type)
        {
            DataTable dt = new DataTable();

            ConfigString cs = new ConfigString();

            if (type == caseDataType.totalCases)
            {
                using (SqlConnection connection = new SqlConnection(cs.getConnString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = $"SELECT prname AS 'Region',numtotal AS 'Total Cases' from CovidData WHERE selectedDate='{date}' AND NOT (prname='Canada') AND NOT (numtoday=0);";
                    cmd.Connection = connection;
                    cmd.Connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                return dt;
            } else
            {
                using (SqlConnection connection = new SqlConnection(cs.getConnString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = $"SELECT prname AS 'Region',numtested AS 'Num Tested',numconf AS 'Num Cases' from CovidData WHERE selectedDate = '{date}' AND NOT(prname= 'Canada'); ";
                    cmd.Connection = connection;
                    cmd.Connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                return dt;
            }
        }

        public DataTable getTimeFrameData(string start, string end, string region)
        {
            DataTable dt = new DataTable();

            ConfigString cs = new ConfigString();
            using (SqlConnection connection = new SqlConnection(cs.getConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"SELECT numtested AS 'Num Tested',numtoday as 'Num Cases',CONVERT(VARCHAR(15), selectedDate, 110) AS 'Date' from CovidData WHERE prname='{region}' AND selectedDate BETWEEN '{start}' AND '{end}' ORDER BY selectedDate;";
                cmd.Connection = connection;
                cmd.Connection.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }



        /*
         *  FUNCTION    :   removeAllSQLData()
         *  DESCRIPTION :   This function will remove all the SQL data found in the table
         */
        public void removeAllSQLData()
        {
            ConfigString cs = new ConfigString();
            using (SqlConnection connection = new SqlConnection(cs.getConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"DELETE * FROM CovidData";
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
    }
}
