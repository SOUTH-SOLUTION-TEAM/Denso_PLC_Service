using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Denso_ORM_PLC_Service.CommonClasses
{
  public  class PLC_Connectivity
    {
        EasyModbus.ModbusClient Client = null;
        public delegate void DataArrivalHandler(string Message, string Client);
        public delegate void ScannerStatusChangeHandler(bool flag,string Client);
        public event DataArrivalHandler OnDataArrived;
        public event ScannerStatusChangeHandler OnScannerStatusChanged;
        bool Flag = false;
        bool DataReceived = false;
        bool Ping = false;
        public string IP; public int port; public int PLCAddress;
        Business_Layer.Transaction obj_Tran = new Business_Layer.Transaction();

        bool strData = false;

        public virtual void ScannerDataArrived(string Data, string Client)
        {
            if (!ReferenceEquals(this.OnDataArrived, null))
            {
                this.OnDataArrived(Data, Client);
            }
        }
        public virtual void ScannerStatusChanged(bool Data, string Client)
        {
            if (!ReferenceEquals(this.OnScannerStatusChanged, null))
            {
                this.OnScannerStatusChanged(Data,Client);
            }
        }
        private void Reconnect()
        {
            try
            {
                if (Client == null)
                    Client = new EasyModbus.ModbusClient();

                Client.Connect(IP, port);
                Flag = true;
                Thread.Sleep(15000);
                ScannerStatusChanged(true,IP);
                if (DataReceived == false)
                    Read();
            }
            catch (Exception ex)
            {
                Flag = false;
                try
                {
                    StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-CONNECTION-" + IP+"-"+ System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    str.WriteLine(ex.Message.ToString() + "-" + IP + "-" + System.DateTime.Now);
                    str.Close();
                }
                catch (Exception EX1)
                {
                }
            }

        }


        public bool Connect()
        {
            try
            {
                if (Client == null)
                    Client = new EasyModbus.ModbusClient();
                if (Client.Connected == false)
                {
                    //
                    //if(strData)
                    //{
                    CheckPinging();
                    Client.IPAddress = IP;
                    Client.Connect(IP, port);
                    Flag = true;
                    ScannerStatusChanged(true, IP);
                    Read();
                    // }


                }
                else
                    Flag = true;

            }
            catch (Exception ex)
            {
                Flag = false;
                try
                {
                    StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-CONNECTION-" + IP + "-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    str.WriteLine(ex.Message.ToString()+"-" +IP+ "-" + System.DateTime.Now);
                    str.Close();
                }
                catch (Exception EX1)
                {
                }
                // Dispose();
                //Connect();
            }
            return Flag;
        }

        public bool CheckPinging()
        {
            try
            {
                Thread th = new Thread(new ThreadStart(delegate
                {
                   
                    while (true)
                    {
                        try
                        {
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client = IP;
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData = "";
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress = "";
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type = "ProductionPlanUpdate";
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime = "";
                            Denso_ORM_PLC_Service.CommonClasses.CommonVariable.Result = obj_Tran.BL_OrMonitoringTransaction();

                            Thread.Sleep(5000);
                            Ping ping = new Ping();
                            PingReply reply = ping.Send(IP);
                            strData = reply.Status == IPStatus.Success;
                            if (strData == false)
                            {
                                Ping = true;
                                ScannerStatusChanged(false, IP);
                                StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-CONNECTION-" + IP + "-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                                str.WriteLine("Not connected" +"-"+IP+ "-" + System.DateTime.Now);
                                str.Close();
                            }
                            if (strData == true)
                            {
                                if (Ping == true)
                                {
                                    Dispose();
                                    Reconnect();
                                    ScannerStatusChanged(true, IP);
                                    Ping = false;
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            try
                            {

                                StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-CONNECTION-" + IP + "-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                                str.WriteLine(ex.Message.ToString() + "-" + IP + "-" + System.DateTime.Now);
                                str.Close();

                                ScannerStatusChanged(false, IP);

                            }
                            catch (Exception EX1)
                            {
                            }
                        }
                    }

                }));
                th.Start();
            }
            catch (Exception ex)
            {
                try
                {
                    StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-CONNECTION-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    str.WriteLine(ex.Message.ToString() + "-" + IP + "-" + System.DateTime.Now);
                    str.Close();
                    ScannerStatusChanged(false, IP);

                }
                catch (Exception EX1)
                {
                }
                //  Client.Disconnect();
                // Connect();
            }
            return strData;

        }


        public void Read()
        {
            //  string strData = "";
            StringBuilder sr = new StringBuilder();
            bool Data = false;
            DataReceived = true;
            bool[] Result1 = { false, false, false, false, false, false, false, false, false, false, false, false };
            try
            {
                Thread th = new Thread(new ThreadStart(delegate
                {
                    while (Flag)
                    {
                        //int K = 1;
                        //for (int L = 0; L < K; L++)
                        //{
                            try
                            {

                                bool[] Result = Client.ReadCoils(PLCAddress, 12);
                                for (int i = 0; i < Result.Length; i++)
                                {
                                    //    if (Result[i] == true)
                                    //    {
                                    //        StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "Testing-" + System.DateTime.Now.ToString("dd-MMM-YYYY"), true);
                                    //        str.WriteLine("True");
                                    //        str.Close();
                                    //    }
                                    //if (Result[i] == false)
                                    //    {
                                    //        StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "Testing-" + System.DateTime.Now.ToString("dd-MMM-YYYY"), true);
                                    //        str.WriteLine("False");
                                    //        str.Close();
                                    //    }
                                    if (Result[i] == true && Result1[i] == false)
                                    {
                                        Result1[i] = true;
                                        StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "Received-Data-" + IP + "-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                                        str.WriteLine("1");
                                        str.Close();
                                        ScannerDataArrived(IP, i.ToString());
                                    }
                                    if (Result[i] == false && Result1[i] == true)
                                    {
                                        Result1[i] = false;
                                        break;
                                    }
                                }
                               // break;

                            }
                            catch (Exception ex)
                            {
                                // Dispose();
                                //  Connect();
                                try
                                {
                                    StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-DATA-READ-Error" + IP + "-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                                    str.WriteLine(ex.Message.ToString() + "-" + IP + "-" + System.DateTime.Now);
                                    str.Close();
                                }
                                catch (Exception EX1)
                                {
                                }
                                //K++;//throw ex;
                                //if(K>8)
                                //{
                                //    break;
                                //}
                            }
                       // }

                    }
                }));
                th.Start();
            }
            catch (Exception ex)
            {
                // Dispose();
                //Connect();
                try
                {
                    StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-DATA-READ-Error" + IP + "-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    str.WriteLine(ex.Message.ToString() + "-" + IP + "-" + System.DateTime.Now);
                    str.Close();
                }
                catch (Exception EX1)
                {
                }
              
            }
            //return strData;
        }

        public void Write(bool ErrorCode, int Address)
        {
            try
            {
                Client.WriteSingleCoil(Address, ErrorCode);
            }
            catch (Exception ex)
            {
                try
                {
                    StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-WRITE-" + IP + "-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    str.WriteLine(ex.Message.ToString() + "-" + IP + "-" + System.DateTime.Now);
                    str.Close();
                }
                catch (Exception EX1)
                {
                }
             
            }
        }
        public void Dispose()
        {
            try
            {
                if (Client != null)
                {
                    if (Client.Connected)
                    {
                        Client.Disconnect();
                    }
                }
               // ScannerStatusChanged(false, IP);
                Client = null;
            }
            catch (Exception ex)
            {
                try
                {
                    StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "PLC-CONNECTION-" + IP + "-" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    str.WriteLine(ex.Message.ToString() + "-" + IP + "-" + System.DateTime.Now);
                    str.Close();
                }
                catch (Exception EX1)
                {
                }
            }
        }
    }
}
