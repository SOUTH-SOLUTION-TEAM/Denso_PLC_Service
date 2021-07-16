using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denso_ORM_PLC_Service.Entity_Layer
{
    public class Transaction
    {

        #region Variables
        static string _PLCData ,_Client  ,_Type,_ProducedTime,_PLCAddress, _MachineGroup, _MachineName, _RecepientType;

        public static string Client
        {
            get
            {
                return _Client;
            }

            set
            {
                _Client = value;
            }
        }

        public static string MachineGroup
        {
            get
            {
                return _MachineGroup;
            }

            set
            {
                _MachineGroup = value;
            }
        }

        public static string MachineName
        {
            get
            {
                return _MachineName;
            }

            set
            {
                _MachineName = value;
            }
        }

        public static string PLCAddress
        {
            get
            {
                return _PLCAddress;
            }

            set
            {
                _PLCAddress = value;
            }
        }

        public static string PLCData
        {
            get
            {
                return _PLCData;
            }

            set
            {
                _PLCData = value;
            }
        }

        public static string ProducedTime
        {
            get
            {
                return _ProducedTime;
            }

            set
            {
                _ProducedTime = value;
            }
        }

        public static string RecepientType
        {
            get
            {
                return _RecepientType;
            }

            set
            {
                _RecepientType = value;
            }
        }

        public static string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }
        #endregion

        #region Properties

        //public static string PLCData { get => _PLCData; set => _PLCData = value; }
        //public static string Client { get => _Client; set => _Client = value; }
        //public static string Type { get => _Type; set => _Type = value; }

        //public static string ProducedTime { get => _ProducedTime; set => _ProducedTime = value; }
        //public static string PLCAddress { get => _PLCAddress; set => _PLCAddress = value; }
        //public static string MachineGroup { get => _MachineGroup; set => _MachineGroup = value; }
        //public static string MachineName { get => _MachineName; set => _MachineName = value; }
        //public static string RecepientType { get => _RecepientType; set => _RecepientType = value; }

        #endregion
    }
}
