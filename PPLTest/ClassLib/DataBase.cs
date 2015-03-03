using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace PPLTest.ClassLib
{
    public class DataBase
    {
        private string connectionString = null;

        public DataBase()
        {
            //connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
        }

        #region DataBaseQuery Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="pKey">The primary key of current table</param>
        /// <param name="pKValue">The identity value</param>
        /// <returns></returns>
        public bool isExist(string tableName, string pKey, string pKValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from " + tableName);
            strSql.Append(" where " + pKey);
            strSql.Append("='" + pKValue + "'");

            //check wether the record is exist in table 
            if (GetCount(strSql.ToString()) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region DataBaseOperate Method

        ///// <summary>
        ///// get the primary key of newly added record
        ///// </summary>
        ///// <returns></returns>
        //private string GetNewlyAddedPK(string TableName)
        //{


        //INSERT INTO dd (asd, sdf, asdf, sdfasdf) VALUES ('1212', 'asd', 'ds', 'we')
        //SELECT ident_current('dd') AS Expr1
        //SELECT IDENT_CURRENT('dd') AS Expr1
        //SELECT SCOPE_IDENTITY() AS Expr1


        //    return "";
        //}

        //private int GetRecordCount(string TableName)
        //{
        //    return 1;
        //}

        //private string GetEditValue(string TableName, string ColumnName, string Filter)
        //{
        //    //get the changed value by PK
        //    string sqlstring = "select " + ColumnName + " from " + TableName + " where " + Filter;


        //    return "";
        //}

        //private string GetAddValue(string TableName)
        //{
        //    //get the primary key of newly added record

        //    //get the changed value by PK

        //    return "";
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Filter"></param>
        /// <param name="ColumnName"></param>
        /// <param name="NewData"></param>
        private void UpdateData(string TableName, string Filter, string ColumnName, string NewData)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE " + TableName + " SET ");
            strSql.Append(ColumnName + " = " + NewData);
            strSql.Append(" WHERE " + Filter);
            Execute(strSql.ToString());
        }

        private void TableBackup(string TableName, string xmlfileName)
        {
            //read, backup to xml
            dataTable2XML(TableName, xmlfileName);
        }

        private void TableRestoration(string TableName, string xmlfileName)
        {
            //clear
            clearTable(TableName);
            //restore
            XML2dataTable(TableName, xmlfileName);
        }

        #endregion

        #region ExecuteMethod


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        public void dataTable2XML(string tableName, string xmlPath)
        {
            //read data
            string CommandString = "SELECT * FROM " + tableName;
            //string CommandString = "SELECT * FROM  MEMBER ";
            //string CommandString = "SELECT * FROM  ssn for xml auto";
            //string CommandString = "SELECT * FROM  ssn for xml raw ('users')";
            //string CommandString = "select socialserver 'user/id', name 'user/name' from ssn for xml path";
            //string CommandString = "select * from ssn for xml auto , root ('info')";
            SqlDataAdapter da = new SqlDataAdapter(CommandString, connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //ds.WriteXml(@"D:\ssn.xml");
            ds.WriteXml(xmlPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        public void clearTable(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("TRUNCATE TABLE " + tableName, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        public void XML2dataTable(string tableName, string xmlPath)
        {

            string strSql = "Select * from " + tableName;
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(strSql, connection);
                adapter.Fill(dataSet);
                dataSet.Tables[0].Clear();
                dataSet.ReadXml(xmlPath, XmlReadMode.Auto);//dataSet.ReadXml(@"D:\ssn.xml", XmlReadMode.Auto);

                //set the primary key
                dataSet.Tables[0].PrimaryKey = new DataColumn[] { dataSet.Tables[0].Columns[0] };
                //其次，用SqlCommandBuilder为SqlDataAdapter生成用于添加、删除、更新的Command。
                SqlCommandBuilder cmdb = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = cmdb.GetUpdateCommand();
                adapter.Update(dataSet);
                dataSet.AcceptChanges();
            }
            //fro large xml file
            //foreach (DataTable t in ds.Tables)
            //    t.BeginLoadData();
            //ds.ReadXml("file.xml");
            //foreach (DataTable t in ds.Tables)
            //    t.EndLoadData();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandString"></param>
        private void Execute(string commandString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandString, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string ErrorResult = ex.Message;
                }
            }
        }

        private int GetCount(string commandString)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandString, connection);
                try
                {
                    connection.Open();
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                { string ErrorResult = ex.Message; }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StoredProcedureName"></param>
        private void executeStoredProcedure(string StoredProcedureName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                { string ErrorResult = ex.Message; }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandString"></param>
        /// <param name="parameters"></param>
        private void executeSqlTransaction(string commandString, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandString, connection);
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    command.Transaction = transaction;
                    try
                    {
                        command.ExecuteNonQuery();
                        // Attempt to commit the transaction.
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        string ErrorResult = ex.Message;
                        //Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                        //Console.WriteLine("  Message: {0}", ex.Message);
                        try
                        {
                            //Attempt to roll back the transaction.
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            string ErrorResult2 = ex2.Message;
                            // This catch block will handle any errors that may have occurred
                            // on the server that would cause the rollback to fail, such as
                            // a closed connection.
                            //Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                            //Console.WriteLine("  Message: {0}", ex2.Message);
                        }
                    }
                }
            }
        }


        //private void ExecuteSqlTransaction(string connectionString, string commandString, SqlParameter[] parameters)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {

        //        // Start a local transaction.
        //        SqlTransaction transaction = connection.BeginTransaction();

        //        SqlCommand command = connection.CreateCommand();
        //        //SqlCommand command = new SqlCommand(commandString, connection, transaction);

        //        connection.Open();

        //        // Must assign both transaction object and connection
        //        // to Command object for a pending local transaction
        //        //command.Connection = connection;
        //        //command.Transaction = transaction;
        //        //command.CommandText = commandString;

        //        try
        //        {

        //            if (parameters != null)
        //            {
        //                foreach (SqlParameter parameter in parameters)
        //                    command.Parameters.Add(parameter);
        //            }

        //                //"Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
        //            command.ExecuteNonQuery();
        //            //command.CommandText =
        //            //    "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
        //            //command.ExecuteNonQuery();

        //            // Attempt to commit the transaction.
        //            transaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            // Attempt to roll back the transaction.
        //            Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
        //            Console.WriteLine("  Message: {0}", ex.Message);
        //            try
        //            {
        //                transaction.Rollback();
        //            }
        //            catch (Exception ex2)
        //            {
        //                // This catch block will handle any errors that may have occurred
        //                // on the server that would cause the rollback to fail, such as
        //                // a closed connection.
        //                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
        //                Console.WriteLine("  Message: {0}", ex2.Message);
        //            }
        //        }
        //    }
        //}




        #endregion
    }
}
