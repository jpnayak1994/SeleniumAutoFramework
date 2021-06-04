using ExcelDataReader;
using SeleniumAutoFramework.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumAutoFramework.Helpers
{
    public class ExcelHelpers
    {
        //  static List<DataCollection> _dataCol = new List<DataCollection>();

        private static Object myLock = new Object();
        public List<SheetDetails> SheetsName = new List<SheetDetails>();
        //storing all the excel value to the memory collections
        public List<DataCollection> PopulateInCollection(string FileName, string sheetName, DataTableCollection dataCollection)
        {
            List<DataCollection> _dataCol = new List<DataCollection>();
            _dataCol.Clear();

            // DataTableCollection dataCollection;
            // DataTable table=null;
            try
            {
                //dataCollection = ExcelToDataTable(FileName);
                DataTable resultTable1 = dataCollection[sheetName];

                if (dataCollection[sheetName].Rows.Count > 0)
                {
                    for (int row = 1; row <= resultTable1.Rows.Count; row++)
                    {
                        for (int col = 0; col < resultTable1.Columns.Count - 1; col++)
                        {
                            DataCollection dtTable = new DataCollection()
                            {
                                rowNumber = "Scenario"+row,
                                colName = resultTable1.Columns[col].ColumnName,
                                colvalue = resultTable1.Rows[row - 1][col].ToString(),
                                sheetname = resultTable1.TableName,
                                sheetexecutionFlag = resultTable1.Rows[row - 1][resultTable1.Columns.Count - 1].ToString()
                            };
                            //Add all the details to each row
                            _dataCol.Add(dtTable);
                        }
                    }
                }

                return _dataCol;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                _dataCol.Clear();
                return _dataCol;
            }




        }
        public DataTableCollection ExcelToDataTable(string fileName)
        {
            List<DataCollection> _dataCol = new List<DataCollection>();
            _dataCol.Clear();
            lock (myLock)
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                //open file and returns as stream
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });
                        //Get All the tables
                        DataTableCollection tablecollection = result.Tables;

                        //Get Sheet Details
                        SheetDetails st = new SheetDetails();
                        for (int i = 0; i < tablecollection.Count; i++)
                        {
                            st.Sheetname = tablecollection[i].TableName;
                            st.rowno = i + 1;
                            SheetsName.Add(st);
                        }
                        stream.Dispose();
                        return tablecollection;
                    }
                   
                }
            }
        }
        //Reading the single set of  data from ExcelCollection
        public string ReadData(string columnName, List<DataCollection> dataCol)
        {
            //List<DataCollection> _dataCol = new List<DataCollection>();
            try
            {
                string data = null;

                //Retrieving data using LINQ to reduce much of iterations
                data = (from colData in dataCol
                        where colData.colName == columnName && colData.sheetexecutionFlag == "y"
                        select colData.colvalue).FirstOrDefault();

                return data.ToString();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }

        }
        //Reading the single set of  data from ExcelCollection
        public string ReadDataUsingRowNo(string columnName, List<DataCollection> dataCol,string RowNo)
        {
            //List<DataCollection> _dataCol = new List<DataCollection>();
            try
            {
                string data = null;

                //Retrieving data using LINQ to reduce much of iterations
                data = (from colData in dataCol
                        where colData.colName == columnName && colData.rowNumber== RowNo
                        select colData.colvalue).FirstOrDefault();

                return data.ToString();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }

        }
        //Reading the single set of  data from ExcelCollection
        //public string ReadDataFromList(string columnName, DataTableCollection dataCollection, string SheetName)
        //{
        //    //List<DataCollection> _dataCol = new List<DataCollection>();
        //    try
        //    {
        //        var dt = dataCollection[SheetName];
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            // if(dr["ExecutionFlag"])
        //        }
        //        IEnumerable<DataRow> data = dt.AsEnumerable().Where(x => x.Field<string>("ExecutionFlag") == "y").ToList();
        //        // var dataValue=from dl in data where dl[columnName]== columnName

        //        // var data = dt.AsEnumerable().Where(x => x.Field<string>("ExecutionFlag") == "y").Select(x => x.Field<string>(columnName)).FirstOrDefault();
        //        //var data = (from row in dt.AsEnumerable() where row["ExecutionFlag"]=="y"  select new (row[columnName])).FirstOrDefault();
        //        // var columnValue = data.Table.AsEnumerable().Select(r => r.Field<string>("UserName")).SingleOrDefault();
        //        ////////////////
        //        return data.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = ex.Message;
        //        return null;
        //    }

        //}
    }
    public class DataCollection
    {
        public string rowNumber { get; set; }
        public string colName { get; set; }
        public string colvalue { get; set; }
        public string sheetname { get; set; }
        public string sheetexecutionFlag { get; set; }
    }
    public class SheetDetails
    {
        public int rowno { get; set; }
        public string Sheetname { get; set; }
        public string ExcelName { get; set; }

    }

}