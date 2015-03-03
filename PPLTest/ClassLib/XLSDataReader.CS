using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Reflection;
using System.Threading;

namespace PPLTest.ClassLib
{
    public class XLSDataReader
    {
        #region Declare the global variables
        //
        private string myExcelPath;//
        //
        private Log mylog = new Log();
        //
        private object missing = Missing.Value;
        private Microsoft.Office.Interop.Excel.Application ExcelRS;
        private Microsoft.Office.Interop.Excel.Workbook RSbook;
        private Microsoft.Office.Interop.Excel.Worksheet RSsheet;

        #endregion

        #region Constructor of XLSDataReader
        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public XLSDataReader()
        {
            this.myExcelPath = MyExcelPath;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelPath"></param>
        public XLSDataReader(string excelPath)
        {
            this.myExcelPath = excelPath;
        }

        /// <summary>
        /// set the excel path
        /// </summary>
        public string MyExcelPath
        {
            get { return myExcelPath; }
            set { myExcelPath = value; }
        }
        #endregion

        #region Public methods to provide the needed data
        /// <summary>
        /// get all the data
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            return ReadData(myExcelPath).Tables[0];
        }

        /// <summary>
        /// get the list of column name
        /// </summary>
        /// <returns></returns>
        public List<string> GetALLFiledName()
        {
            List<string> MyFiledNamelist = new List<string>();
            foreach (DataColumn dc in this.GetData().Columns)
            {
                MyFiledNamelist.Add(dc.ColumnName);
            }
            return MyFiledNamelist;
        }

        /// <summary>
        /// get a whole column's value by column name
        /// </summary>
        /// <param name="ColumnName">column name</param>
        /// <returns></returns>
        public List<string> GetDataByFiledName(string ColumnName)
        {
            List<string> Mydatalist = new List<string>();
            foreach (DataRow dr in this.GetData().Rows)
            {
                Mydatalist.Add(dr[ColumnName].ToString());
            }
            return Mydatalist;
        }

        /// <summary>
        ///get a row by row No.
        /// </summary>
        /// <param name="rowID"></param>
        /// <returns></returns>
        public DataRow GetValueByRowNum(int rowID)
        {
            DataRow myRow = null;
            if (rowID >= 0 && rowID < this.GetData().Rows.Count)
            {
                myRow = this.GetData().Rows[rowID];
            }
            return myRow;
        }

        /// <summary>
        /// get data from a cell
        /// </summary>
        /// <param name="columnName">column name</param>
        /// <param name="rowID">index of the row</param>
        /// <returns></returns>
        public string GetSingleData(string columnName, int rowID)
        {
            return this.GetData().Rows[rowID][columnName].ToString();
        }

        #endregion

        #region Read data from the excel files

        private DataSet ReadData(string dataPath)
        {
            bool canBeRead;
            Mutex m = new Mutex(true, "AnyName", out canBeRead);
            if (!canBeRead)
            {
                m.WaitOne();
            }
            DataSet MyDataSet = new DataSet();
            //creat the connection string
            string strConn = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + dataPath + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                //select the sheet
                strExcel = "select * from [sheet1$]";

                conn.Open();
                //read data from the excel and write them into the dataset
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                myCommand.Fill(MyDataSet, "dtSource");
            }
            catch (Exception ex)
            {
                mylog.WriteLog("ExcelDataReader Error : " + dataPath, ex.Message + ex.StackTrace);
                return MyDataSet;
            }
            finally
            {
                //close the connection
                conn.Close();
                conn.Dispose();
                m.ReleaseMutex();
            }
            return MyDataSet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataPath">full name of the excel</param>
        /// <returns></returns>
        //private DataSet ReadData(string dataPath)
        //{
        //    DataSet MyDataSet = new DataSet();

           
        //    if (!IsFileExist(dataPath))
        //    {
        //        return MyDataSet;
        //    }
        //    //creat the connection string
        //    string strConn = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + dataPath + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
        //    OleDbConnection conn = new OleDbConnection(strConn);
        //    try
        //    {
        //        string strExcel = "";
        //        OleDbDataAdapter myCommand = null;
        //        //select the sheet
        //        strExcel = "select * from [sheet1$]";

        //        conn.Open();
        //        //read data from the excel and write them into the dataset
        //        myCommand = new OleDbDataAdapter(strExcel, strConn);
        //        myCommand.Fill(MyDataSet, "dtSource");
        //    }
        //    catch (Exception ex)
        //    {
        //        mylog.WriteLog("ExcelDataReader Error : " + dataPath, ex.Message + ex.StackTrace);
        //        return MyDataSet;
        //    }
        //    finally
        //    {
        //        //close the connection
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //    return MyDataSet;
        //}
        #endregion

        #region Write data into the excel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataPath">saving path of the excel</param>
        /// <param name="cellRowID">RowID</param>
        /// <param name="cellColumnName">column name</param>
        /// <param name="cellvalue">value</param>
        /// <returns></returns>
        public bool WriteData(string dataPath, string cellRowID, string cellColumnName, string cellvalue)
        {
            bool writeSuucceed = false;
            
            int cellRow = 0;
            int cellColumn = 0;
            //get the data of the excel
            this.myExcelPath = dataPath;
            DataTable CurrentTable = this.GetData();

            #region convert the RowID and ColumnName to roe No. and column No.
            //get the column number
            for (int i = 0; i < CurrentTable.Columns.Count; i++)
            {
                if (cellColumnName == CurrentTable.Columns[i].ColumnName.ToString())
                {
                    cellColumn = i;
                    break;
                }
            }
            //get the row number
            for (int i = 0; i < CurrentTable.Rows.Count; i++)
            {
                if (cellRowID == CurrentTable.Rows[i][0].ToString())
                {
                    cellRow = i;
                    break;
                }
            }
            #endregion

            //write data into the cell
            if (WriteData(dataPath, cellRow+2, cellColumn+1, cellvalue))
            {
                writeSuucceed = true;
            }
            return writeSuucceed;
        }

        private bool WriteData(string dataPath, int cellRow, int cellColumn, string cellvalue)
        {
            bool writeSuucceed = false;
            object missing = Missing.Value;

            if (IsFileExist(dataPath))
            {
                 ExcelRS = null;
                //creat an instances of the MS Excel
                ExcelRS = new Microsoft.Office.Interop.Excel.ApplicationClass();
                //open the excel file
                RSbook = ExcelRS.Workbooks.Open(dataPath, missing, missing, missing, missing, missing,
                    missing, missing, missing, missing, missing, missing, missing, missing, missing);
                //set the first sheet as the working sheet 
                RSsheet = (Microsoft.Office.Interop.Excel.Worksheet)RSbook.Sheets.get_Item(1);
                //active the sheet
                RSsheet.Activate();

                try
                {
                    //write data into the excel
                    RSsheet.Cells[cellRow, cellColumn] = cellvalue;
                    //save the change and close the excel
                    RSbook.Save();
                    RSbook.Close(false, missing,missing);
                    writeSuucceed = true;
                }
                catch
                {
                    writeSuucceed = false;
                }
                finally
                {
                    //relaese the resource
                    RSsheet = null;
                    RSbook = null;
                    ExcelRS = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            return writeSuucceed;
        }

        #endregion

        //wether the file is exist
        protected bool IsFileExist(string FilePath)
        {
            bool FileExist = false;
            //
            if (File.Exists(FilePath))
            {
                FileExist = true;
            }
            return FileExist;
        }

    }
}