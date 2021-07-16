using Denso_ORM_PLC_Service.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denso_ORM_PLC_Service.Business_Layer
{
    public class Transaction
    {
        #region Objects
        Denso_ORM_PLC_Service.Data_Layer.DatabaseConnections obj_DB = new DatabaseConnections();
        #endregion
        #region OrMonitoring
        public string BL_OrMonitoringTransaction()
        {
            try
            {
                return obj_DB.ExecuteProcedureParam("Proc_OrMonitoring",  Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData, Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client, Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type,  Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime, Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BL_OrMonitoringDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_OrMonitoring", Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData, Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client, Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type, Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime, Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region APKMASTER

        public DataSet BL_APKMasterDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_APKMaster", Entity_Layer.Transaction.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region SMSandCALLConfig

        public DataSet BL_SMSandCALLConfigDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_SMSandCALConfiguration", 0, Entity_Layer.Transaction.MachineGroup, Entity_Layer.Transaction.MachineName, Entity_Layer.Transaction.RecepientType, "", "","", Entity_Layer.Transaction.Type, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
                #region IPPORT Configuration
        public string BL_IPPortConfigurationTransaction()
        {
            try
            {
                return obj_DB.ExecuteProcedureParam("Proc_IPandPortConfiguration", 0, "", "", "", "", "", Entity_Layer.Transaction.Client, "0", "0", "", "", "", Entity_Layer.Transaction.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BL_IPPortConfigurationDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_IPandPortConfiguration", 0, "", "", "", "", "", "0", "0", "0", "", "", "", Entity_Layer.Transaction.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{

            //}
        }
        #endregion

    }
}
