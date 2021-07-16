// Decompiled with JetBrains decompiler
// Type: Denso_ORM_PLC_Service.Pages.Panel_25
// Assembly: Denso_ORM_PLC_Service, Version=1.0.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 8A177D66-9BFF-466E-88A5-E35B804D44AF
// Assembly location: D:\Projects\DENSO\17-06-2021\PLC_Service_AutoStart\Denso_ORM_PLC_Service.exe

using Denso_ORM_PLC_Service.CommonClasses;
using Denso_ORM_PLC_Service.Data_Layer;
using EasyModbus;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Denso_ORM_PLC_Service.Pages
{
    public partial class Panel_25 : Form
    {
        private ModbusClient Client = (ModbusClient)null;
        private bool Flag = false;
        private bool DataReceived = false;
        private bool Ping = false;
        public string IP;
        public string LineName;
        private int port = 502;
        private int PLCAddress;
        private int count = 0;
        private Denso_ORM_PLC_Service.Business_Layer.Transaction obj_Tran = new Denso_ORM_PLC_Service.Business_Layer.Transaction();
        private bool strData = false;
       
        public Panel_25() => this.InitializeComponent();

        private bool chekping = false;
        private void Reconnect()
        {
            try
            {
                //if (this.Client == null)
                //  this.Client = new ModbusClient();
                //this.Client.Connect(this.IP, this.port);
                Connect();
                //this.Flag = true;
                //this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.BackColor = Color.Green));
                //this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.Text = "CONNECTED " + this.IP));
            }
            catch (Exception ex1)
            {
                //this.Flag = false;
                try
                {
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\PLC-CONNECTION-" + this.IP + "-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + "-" + this.IP + "-" + (object)DateTime.Now);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                }
            }
        }

        public bool Connect()
        {
            try
            {
                if (this.Client == null)
                    this.Client = new ModbusClient();
                //if (!this.Client.Connected)
                //{
                if (chekping == false)
                {
                    this.CheckPinging();
                }
                this.Client.IPAddress = this.IP;
                Client.ConnectionTimeout = 1000;
                this.Client.Connect(this.IP, this.port);
                this.Flag = true;
                this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.BackColor = Color.Green));
                this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.Text = "CONNECTED " + this.IP));
                if (DataReceived == false)
                    this.Read();
                //}
                //else
                //    this.Flag = true;
            }
            catch (Exception ex1)
            {
                // this.Flag = false;
                try
                {
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\PLC-CONNECTION-" + this.IP + "-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + "-" + this.IP + "-" + (object)DateTime.Now);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                }
            }
            return this.Flag;
        }

        private void rEFRESHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Read();
                this.Dispose();
                this.Reconnect();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        public bool CheckPinging()
        {
            try
            {
                new Thread((ThreadStart)(() =>
                {
                    while (true)
                    {
                        try
                        {
                            chekping = true;
                            Thread.Sleep(5000);
                            DatabaseConnections databaseConnections = new DatabaseConnections();
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client = this.IP;
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData = "";
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress = "";
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type = "ProductionPlanUpdate";
                            Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime = "";
                            databaseConnections.ExecuteProcedureParam("Proc_OrMonitoring", (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress);
                            DateTime now = DateTime.Now;
                            //string str = now.ToString("HH:mm");
                            //if (str == "06:30" || str == "15:00" || str == "23:30")
                            //{
                            //    this.count = 0;
                            //    this.lblCount.Invoke((MethodInvoker)(() => this.lblCount.Text = "0"));
                            //    this.Dispose();
                            //    this.Reconnect();
                            //}
                            this.strData = new System.Net.NetworkInformation.Ping().Send(this.IP).Status == IPStatus.Success;
                            if (!this.strData)
                            {
                                this.Ping = true;
                                this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.BackColor = Color.Red));
                                this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.Text = "NOT CONNECTED " + this.IP));
                                string[] strArray = new string[6]
                                {
                                    AppDomain.CurrentDomain.BaseDirectory,  "\\Logs\\PLC-CONNECTION-", this.IP,  "-",null, null
                                };
                                now = DateTime.Now;
                                strArray[4] = now.ToString("dd-MMM-yyyy");
                                strArray[5] = ".txt";
                                StreamWriter streamWriter = new StreamWriter(string.Concat(strArray), true);
                                streamWriter.WriteLine("Not connected-" + this.IP + "-" + (object)DateTime.Now);
                                streamWriter.Close();
                            }
                            if (this.strData)
                            {
                                if (this.Ping)
                                {
                                    this.Dispose();
                                    this.Reconnect();
                                    this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.BackColor = Color.Green));
                                    this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.Text = "CONNECTED " + this.IP));
                                    this.Ping = false;
                                }
                                this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.BackColor = Color.Green));
                                this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.Text = "CONNECTED " + this.IP));
                            }
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                // chekping = false;
                                this.Dispose();
                                this.Reconnect();
                                StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\PLC-CONNECTION-" + this.IP + "-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                                streamWriter.WriteLine(ex1.Message.ToString() + "-" + this.IP + "-" + (object)DateTime.Now);
                                streamWriter.Close();
                                this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.BackColor = Color.Red));
                                this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.Text = "NOT CONNECTED " + this.IP));
                            }
                            catch (Exception ex2)
                            {
                            }
                        }
                    }
                })).Start();
            }
            catch (Exception ex1)
            {
                try
                {
                    // chekping = false;
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\PLC-CONNECTION-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + "-" + this.IP + "-" + (object)DateTime.Now);
                    streamWriter.Close();
                    this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.BackColor = Color.Green));
                    this.lblPLCStatus.Invoke((MethodInvoker)(() => this.lblPLCStatus.Text = "NOT CONNECTED " + this.IP));
                }
                catch (Exception ex2)
                {
                }
            }
            return this.strData;
        }

        public void Read()
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool[] Result1 = new bool[12];
            try
            {
                new Thread((ThreadStart)(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(25);
                        this.DataReceived = true;
                        try
                        {
                            bool[] flagArray = this.Client.ReadCoils(this.PLCAddress, 12);
                            for (int index = 0; index < flagArray.Length; ++index)
                            {
                                if (flagArray[index] && !Result1[index])
                                {
                                    Result1[index] = true;
                                    ++this.count;
                                    this.lblCount.Invoke((MethodInvoker)(() => this.lblCount.Text = this.count.ToString()));
                                    DatabaseConnections databaseConnections = new DatabaseConnections();
                                    CommonVariable.Result = "";
                                    Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client = this.IP;
                                    Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData = "1";
                                    Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress = index.ToString();
                                    Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type = "Save";
                                    DateTime now = DateTime.Now;
                                    Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime = now.ToString("HH:mm:ss");
                                    CommonVariable.Result = databaseConnections.ExecuteProcedureParam("Proc_OrMonitoring", (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress);
                                    if (!CommonVariable.Result.Contains("Saved"))
                                    {
                                        Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client = this.IP;
                                        Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData = "1";
                                        Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress = index.ToString();
                                        Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type = "Save";
                                        now = DateTime.Now;
                                        Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime = now.ToString("HH:mm:ss");
                                        CommonVariable.Result = databaseConnections.ExecuteProcedureParam("Proc_OrMonitoring", (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCData, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.Client, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime, (object)Denso_ORM_PLC_Service.Entity_Layer.Transaction.PLCAddress);
                                        if (!CommonVariable.Result.Contains("Saved"))
                                        {
                                            object[] objArray = new object[6]
                                            {
                                                 (object) AppDomain.CurrentDomain.BaseDirectory,
                                                (object) "\\Logs\\DATA-SAVE-Error-", null, null, null, null
                                            };
                                            now = DateTime.Now;
                                            objArray[2] = (object)now.ToString("dd-MMM-yyyy");
                                            objArray[3] = (object)"-";
                                            objArray[4] = (object)this.Client;
                                            objArray[5] = (object)".txt";
                                            StreamWriter streamWriter = new StreamWriter(string.Concat(objArray), true);
                                            streamWriter.WriteLine(CommonVariable.Result + " " + (object)DateTime.Now);
                                            streamWriter.Close();
                                        }
                                    }
                                    //else if (CommonVariable.Result == "Saved")
                                    //{
                                    //                  string[] strArray = new string[6]
                                    //                  {
                                    //AppDomain.CurrentDomain.BaseDirectory,
                                    //"\\Logs\\DATA-SAVE-",
                                    //null,
                                    //null,
                                    //null,
                                    //null
                                    //                  };
                                    //                  now = DateTime.Now;
                                    //                  strArray[2] = now.ToString("dd-MMM-yyyy");
                                    //                  strArray[3] = "-";
                                    //                  strArray[4] = this.IP;
                                    //                  strArray[5] = ".csv";
                                    //                  StreamWriter streamWriter = new StreamWriter(string.Concat(strArray), true);
                                    //                  streamWriter.WriteLine(CommonVariable.Result + " " + (object)DateTime.Now);
                                    //                  streamWriter.Close();
                                    // }
                                }
                                if (!flagArray[index] && Result1[index])
                                {
                                    Result1[index] = false;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                // DataReceived = false;
                                Dispose();
                                Reconnect();
                                StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\PLC-DATA-READ-Error" + this.IP + "-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                                streamWriter.WriteLine(ex1.Message.ToString() + "-" + this.IP + "-" + (object)DateTime.Now);
                                streamWriter.Close();
                            }
                            catch (Exception ex2)
                            {
                            }
                        }
                    }
                })).Start();
            }
            catch (Exception ex1)
            {
                try
                {
                    // DataReceived = false;
                    Dispose();
                    Reconnect();
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\PLC-DATA-READ-Error" + this.IP + "-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + "-" + this.IP + "-" + (object)DateTime.Now);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                }
            }
        }

        public void Write(bool ErrorCode, int Address)
        {
            try
            {
                this.Client.WriteSingleCoil(Address, ErrorCode);
            }
            catch (Exception ex1)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\PLC-WRITE-" + this.IP + "-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + "-" + this.IP + "-" + (object)DateTime.Now);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                }
            }
        }

        private void Panel_25_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblLineName.Text = "(P-25) " + this.LineName;
                this.Connect();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message.ToString(), "PANEL_25");
            }
        }

        private void Panel_25_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right)
                    return;
                this.contextMenuStrip1.Show(this.PointToScreen(e.Location));
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        public new void Dispose()
        {
            try
            {
               // if (this.Client != null && this.Client.Connected)
                    this.Client.Disconnect();
                this.Client = (ModbusClient)null;
            }
            catch (Exception ex1)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\PLC-CONNECTION-" + this.IP + "-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + "-" + this.IP + "-" + (object)DateTime.Now);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                }
            }
        }

        
    }
}
