using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
namespace Denso_ORM_PLC_Service.CommonClasses
{
    class CommonMethods
    {
        #region Common_Methods

        //public static DENSO_ORM_Service.Service1 objWS;
        //BUSINESS_LAYER.Masters.Masters obj_Masetr = new BUSINESS_LAYER.Masters.Masters();

        //public  bool WebServiceConnection()
        //{
        //    ENTITY_LAYER.Masters.Masters.Type = "GetDetails";
        //    DataTable dt = obj_Masetr.BL_APKMasterDetails().Tables[0];

        //    if (dt.Rows.Count>0)
        //    {
        //        objWS = new DENSO_ORM_Service.Service1();
        //        objWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //        objWS.Url = dt.Rows[2]["APKLink"].ToString();
        //        objWS.Timeout = 60000;
        //        return true;

        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        public static string DataTableToString(DataTable dt1)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    for (int k = 0; k < dt1.Columns.Count; k++)
                    {
                        str.AppendFormat("{0}:{1}$", dt1.Columns[k].ColumnName, dt1.Rows[j][k]);
                    }
                }
                return str.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

      
      

      
       

        public static void CreatLogDetails(string ErrorDescrription, string methodName, string ModuleName, string CreatedBy)
        {
            try
            {
                StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Log\\" + ModuleName + "-" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".txt", true);
                sw.WriteLine(ErrorDescrription + " , " + methodName + " , " + ModuleName + " , " + CreatedBy + " , " + System.DateTime.Now.ToString());
                sw.Dispose();
                sw.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void CreatDataBaseLogDetails(string DBServerName, string DBSarverID, string DBServerPassword, string DataBaseName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "DataBaseSetting.txt");
                sw.WriteLine("DBServerName" + "," + "DBSarverID" + "," + "DBServerPassword" + "," + "DataBaseName");
                sw.WriteLine(DBServerName + "," + DBSarverID + "," + DBServerPassword + "," + DataBaseName);
                sw.Dispose();
                sw.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string ReadFile(string Path)
        {
            try
            {
                string Result = "";
                if (File.Exists(Path))
                {
                    StreamReader SR = new StreamReader(Path);
                    Result = SR.ReadToEnd();
                    SR.Dispose();
                    SR.Close();
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string Encrypt_data(string str)
        {
            try
            {
                char[] arr = str.ToCharArray();
                Array.Reverse(arr);
                str = new string(arr);
                return Convert.ToBase64String(Encoding.Unicode.GetBytes(str));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string Decrypt_data(string str)
        {
            try
            {
                char[] arr = Encoding.Unicode.GetString(Convert.FromBase64String(str)).ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public static DataTable ReadExcelData(string fileName, string SheetName)
        {
            try
            {
                string conn = string.Empty;
                DataTable dtexcel = new DataTable();

                if (fileName.EndsWith(".xls"))
                    conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
                else
                    conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';"; //for above excel 2007  
                using (OleDbConnection con = new OleDbConnection(conn))
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from " + SheetName, con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                return dtexcel;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        #endregion
    }
}
