using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denso_ORM_PLC_Service.CommonClasses
{
 public class CommonVariable
    {
        #region Common_Variables
        public static string UserID = "";
        public static int RefNo = 0;
        public static string Result = "";
        public static string MachineGroup = "";
        public static string MachineName = "";
        public static string ModelName = "";
        public static string CycleTime = "0";
        public static string productionPlan = "0";
        public static string TransactioType = "";
        public static string TotalproductionPlan = "0";
        public static string ShiftName = "";
        public static string MachinePlane = "";
        public static string MachineStatus = "";
        public static string IP = "";
        public static string PORT = "";
        public static string Time = "";
        public static PLC_Connectivity obj_plc = null;
        public static PLC_Connectivity obj_plc1 = null;
        public static int PblCOunt = 0;
        public enum CustomStriing
        {
            YESNO,
            OKCancel,
            OK,
            Error,
            Successfull,
            Information,
            Question,
            Exclamatory,
        }
        #endregion
    }
}
