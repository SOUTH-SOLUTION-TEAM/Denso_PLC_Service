using Denso_ORM_PLC_Service.Entity_Layer;
using Denso_ORM_PLC_Service.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denso_ORM_PLC_Service
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool Flag = false;
        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                string str = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                if (!(str != ""))
                    return;
                string[] strArray = str.Split(',');
                if ((uint)strArray.Length > 0U)
                {
                    DatabaseSettings.SqldbServer = strArray[0].ToString();
                    DatabaseSettings.SqlDBUserID = strArray[1].ToString();
                    DatabaseSettings.SqlDBPassword = strArray[2].ToString();
                    DatabaseSettings.SqlDBName = strArray[3].ToString();
                }
                Denso_ORM_PLC_Service.Entity_Layer.Transaction.Type = "GetIPDetails";
                Denso_ORM_PLC_Service.Entity_Layer.Transaction.ProducedTime = DateTime.Now.ToString("HH:mm:ss");
                DataSet dataSet = new Denso_ORM_PLC_Service.Business_Layer.Transaction().BL_OrMonitoringDetails();
                for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
                {
                    if (index == 0)
                    {
                        Panel_1 panel1 = new Panel_1();
                        panel1.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel1.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel1.TopLevel = false;
                        this.panel1.Controls.Add((Control)panel1);
                        panel1.Show();
                    }
                    if (index == 1)
                    {
                        Panel_2 panel2 = new Panel_2();
                        panel2.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel2.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel2.TopLevel = false;
                        this.panel2.Controls.Add((Control)panel2);
                        panel2.Show();
                    }
                    if (index == 2)
                    {
                        Panel_3 panel3 = new Panel_3();
                        panel3.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel3.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel3.TopLevel = false;
                        this.panel3.Controls.Add((Control)panel3);
                        panel3.Show();
                    }
                    if (index == 3)
                    {
                        Panel_4 panel4 = new Panel_4();
                        panel4.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel4.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel4.TopLevel = false;
                        this.panel4.Controls.Add((Control)panel4);
                        panel4.Show();
                    }
                    if (index == 4)
                    {
                        Panel_5 panel5 = new Panel_5();
                        panel5.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel5.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel5.TopLevel = false;
                        this.panel5.Controls.Add((Control)panel5);
                        panel5.Show();
                    }
                    if (index == 5)
                    {
                        Panel_6 panel6 = new Panel_6();
                        panel6.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel6.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel6.TopLevel = false;
                        this.panel6.Controls.Add((Control)panel6);
                        panel6.Show();
                    }
                    if (index == 6)
                    {
                        Panel_7 panel7 = new Panel_7();
                        panel7.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel7.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel7.TopLevel = false;
                        this.panel7.Controls.Add((Control)panel7);
                        panel7.Show();
                    }
                    if (index == 7)
                    {
                        Panel_8 panel8 = new Panel_8();
                        panel8.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel8.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel8.TopLevel = false;
                        this.panel8.Controls.Add((Control)panel8);
                        panel8.Show();
                    }
                    if (index == 8)
                    {
                        Panel_9 panel9 = new Panel_9();
                        panel9.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel9.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel9.TopLevel = false;
                        this.panel9.Controls.Add((Control)panel9);
                        panel9.Show();
                    }
                    if (index == 9)
                    {
                        Panel_10 panel10 = new Panel_10();
                        panel10.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel10.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel10.TopLevel = false;
                        this.panel10.Controls.Add((Control)panel10);
                        panel10.Show();
                    }
                    if (index == 10)
                    {
                        Panel_11 panel11 = new Panel_11();
                        panel11.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel11.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel11.TopLevel = false;
                        this.panel11.Controls.Add((Control)panel11);
                        panel11.Show();
                    }
                    if (index == 11)
                    {
                        Panel_12 panel12 = new Panel_12();
                        panel12.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel12.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel12.TopLevel = false;
                        this.panel12.Controls.Add((Control)panel12);
                        panel12.Show();
                    }
                    if (index == 12)
                    {
                        Panel_13 panel13 = new Panel_13();
                        panel13.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel13.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel13.TopLevel = false;
                        this.panel13.Controls.Add((Control)panel13);
                        panel13.Show();
                    }
                    if (index == 13)
                    {
                        Panel_14 panel14 = new Panel_14();
                        panel14.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel14.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel14.TopLevel = false;
                        this.panel14.Controls.Add((Control)panel14);
                        panel14.Show();
                    }
                    if (index == 14)
                    {
                        Panel_15 panel15 = new Panel_15();
                        panel15.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel15.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel15.TopLevel = false;
                        this.panel15.Controls.Add((Control)panel15);
                        panel15.Show();
                    }
                    if (index == 15)
                    {
                        Panel_16 panel16 = new Panel_16();
                        panel16.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel16.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel16.TopLevel = false;
                        this.panel16.Controls.Add((Control)panel16);
                        panel16.Show();
                    }
                    if (index == 16)
                    {
                        Panel_17 panel17 = new Panel_17();
                        panel17.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel17.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel17.TopLevel = false;
                        this.panel17.Controls.Add((Control)panel17);
                        panel17.Show();
                    }
                    if (index == 17)
                    {
                        Panel_18 panel18 = new Panel_18();
                        panel18.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel18.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel18.TopLevel = false;
                        this.panel18.Controls.Add((Control)panel18);
                        panel18.Show();
                    }
                    if (index == 18)
                    {
                        Panel_19 panel19 = new Panel_19();
                        panel19.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel19.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel19.TopLevel = false;
                        this.panel19.Controls.Add((Control)panel19);
                        panel19.Show();
                    }
                    if (index == 19)
                    {
                        Panel_20 panel20 = new Panel_20();
                        panel20.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel20.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel20.TopLevel = false;
                        this.panel20.Controls.Add((Control)panel20);
                        panel20.Show();
                    }
                    if (index == 20)
                    {
                        Panel_21 panel21 = new Panel_21();
                        panel21.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel21.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel21.TopLevel = false;
                        this.panel21.Controls.Add((Control)panel21);
                        panel21.Show();
                    }
                    if (index == 21)
                    {
                        Panel_22 panel22 = new Panel_22();
                        panel22.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel22.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel22.TopLevel = false;
                        this.panel22.Controls.Add((Control)panel22);
                        panel22.Show();
                    }
                    if (index == 22)
                    {
                        Panel_23 panel23 = new Panel_23();
                        panel23.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel23.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel23.TopLevel = false;
                        this.panel23.Controls.Add((Control)panel23);
                        panel23.Show();
                    }
                    if (index == 23)
                    {
                        Panel_24 panel24 = new Panel_24();
                        panel24.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel24.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel24.TopLevel = false;
                        this.panel24.Controls.Add((Control)panel24);
                        panel24.Show();
                    }
                    if (index == 24)
                    {
                        Panel_25 panel25 = new Panel_25();
                        panel25.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel25.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel25.TopLevel = false;
                        this.panel25.Controls.Add((Control)panel25);
                        panel25.Show();
                    }
                    if (index == 25)
                    {
                        Panel_26 panel26 = new Panel_26();
                        panel26.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel26.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel26.TopLevel = false;
                        this.panel26.Controls.Add((Control)panel26);
                        panel26.Show();
                    }
                    if (index == 26)
                    {
                        Panel_27 panel27 = new Panel_27();
                        panel27.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel27.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel27.TopLevel = false;
                        this.panel27.Controls.Add((Control)panel27);
                        panel27.Show();
                    }
                    if (index == 27)
                    {
                        Panel_28 panel28 = new Panel_28();
                        panel28.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel28.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel28.TopLevel = false;
                        this.panel28.Controls.Add((Control)panel28);
                        panel28.Show();
                    }
                    if (index == 28)
                    {
                        Panel_29 panel29 = new Panel_29();
                        panel29.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel29.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel29.TopLevel = false;
                        this.panel29.Controls.Add((Control)panel29);
                        panel29.Show();
                    }
                    if (index == 29)
                    {
                        Panel_30 panel30 = new Panel_30();
                        panel30.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel30.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel30.TopLevel = false;
                        this.panel30.Controls.Add((Control)panel30);
                        panel30.Show();
                    }
                    if (index == 30)
                    {
                        Panel_31 panel31 = new Panel_31();
                        panel31.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel31.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel31.TopLevel = false;
                        this.panel31.Controls.Add((Control)panel31);
                        panel31.Show();
                    }
                    if (index == 31)
                    {
                        Panel_32 panel32 = new Panel_32();
                        panel32.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel32.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel32.TopLevel = false;
                        this.panel32.Controls.Add((Control)panel32);
                        panel32.Show();
                    }
                    if (index == 32)
                    {
                        Panel_33 panel33 = new Panel_33();
                        panel33.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel33.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel33.TopLevel = false;
                        this.panel33.Controls.Add((Control)panel33);
                        panel33.Show();
                    }
                    if (index == 33)
                    {
                        Panel_34 panel34 = new Panel_34();
                        panel34.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel34.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel34.TopLevel = false;
                        this.panel34.Controls.Add((Control)panel34);
                        panel34.Show();
                    }
                    if (index == 34)
                    {
                        Panel_35 panel35 = new Panel_35();
                        panel35.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel35.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel35.TopLevel = false;
                        this.panel35.Controls.Add((Control)panel35);
                        panel35.Show();
                    }
                    if (index == 35)
                    {
                        Panel_36 panel36 = new Panel_36();
                        panel36.IP = dataSet.Tables[0].Rows[index]["IPAddress"].ToString();
                        panel36.LineName = dataSet.Tables[0].Rows[index]["MachineName"].ToString();
                        panel36.TopLevel = false;
                        this.panel36.Controls.Add((Control)panel36);
                        panel36.Show();
                    }
                }
                Refresh();
            }
            catch (Exception ex1)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Error-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + " " + (object)DateTime.Now);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) => Process.GetCurrentProcess().Kill();

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState != FormWindowState.Minimized)
                    return;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            catch (Exception ex1)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Error-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + " " + (object)DateTime.Now);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                }
            }
        }

        private void MainWindow_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.WindowState != FormWindowState.Normal)
                    return;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            catch (Exception ex1)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Error-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + " " + (object)DateTime.Now);
                    streamWriter.Close();
                }
                catch (Exception ex2)
                {
                }
            }
        }

        public void Refresh()
        {
            try
            {
                new Thread((ThreadStart)(() =>
                {
                    while (true)
                    {
                        try
                        {
                            DateTime now = DateTime.Now;
                            string str = now.ToString("HH:mm");
                            if (str == "06:28" || str == "14:58" || str == "23:28")
                            {
                                Thread.Sleep(50000);
                                System.Diagnostics.Process.GetCurrentProcess().Kill();
                            }
                            
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                // chekping = false;
                                StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Refresh_Error-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                                streamWriter.WriteLine(ex1.Message.ToString() + "-" + (object)DateTime.Now);
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
                    // chekping = false;
                    StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Refresh_Error-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    streamWriter.WriteLine(ex1.Message.ToString() + "-" + (object)DateTime.Now);
                    streamWriter.Close();

                }
                catch (Exception ex2)
                {
                }
            }
        }
    }
}
