using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySqlOperator
{
    public class DBHelper
    {
        private string sqlConnectString;

        public DBHelper(string connectionString)
        {
            this.sqlConnectString = connectionString;
        }

        public void InsertTimeOutInfo(string[] infos)
        {
            using (MySqlConnection DataConn = new MySqlConnection(this.sqlConnectString))
            {
                try
                {
                    // open data connection ..
                    if (DataConn.State != ConnectionState.Open)
                    {
                        DataConn.Open();
                    }

                    string CommandText = "insert into PPLMONITOR_DATA (State,Action,TimeSpan,Time,Envior)"
                      + " value ('" + infos[0] + "','" + infos[1] + "','" + infos[2] + "','" + infos[3] + "','" + infos[4] + "')";

                    // declare command, transaction object ..
                    MySqlCommand myCommand = new MySqlCommand(CommandText, DataConn);
                    //// executing 
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string ExceptionMsg = ex.Message + ex.StackTrace;
                }
                finally
                {
                    if (DataConn.State == ConnectionState.Open)
                    {
                        // close data connection ..
                        DataConn.Close();
                    }
                }
            }
        }


        public DataTable GetAllTimeOutInfo(DateTime startTime,double timeCost)
        {
            DataTable TimeOutInfo = new DataTable();
            using (MySqlConnection DataConn = new MySqlConnection(this.sqlConnectString))
            {
                try
                {
                    // open data connection ..
                    if (DataConn.State != ConnectionState.Open)
                    {
                        DataConn.Open();
                    }

                    string CommandText = "SELECT * FROM pplmonitor_data WHERE"
                        + " (Time > '" + startTime.ToString("yyyy/MM/dd HH:mm:ss") + "')"
                        + " AND (TimeSpan >" + timeCost.ToString() + ")";

                    // declare command, transaction object ..
                    MySqlCommand myCommand = new MySqlCommand(CommandText, DataConn);
                    //// executing query ..
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter(myCommand);
                    myCommand.ExecuteNonQuery();
                    myAdapter.Fill(TimeOutInfo);
                }
                catch (Exception ex)
                {
                    string ExceptionMsg = ex.Message + ex.StackTrace;
                }
                finally
                {
                    if (DataConn.State == ConnectionState.Open)
                    {
                        // close data connection ..
                        DataConn.Close();
                    }
                }
            }
            return TimeOutInfo; 
        }
    }
}
