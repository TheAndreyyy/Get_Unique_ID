using System;
using System.Management;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Get_Unique_ID
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> ids =
            new Dictionary<string, string>();

            ManagementObjectSearcher searcher;

            //процессор
            searcher = new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM Win32_Processor");
            foreach (ManagementObject queryObj in searcher.Get())
                ids.Add("1", queryObj["ProcessorId"].ToString());

            //мать
            searcher = new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM CIM_Card");
            foreach (ManagementObject queryObj in searcher.Get())
                ids.Add("2", queryObj["SerialNumber"].ToString());

            //ОС
            searcher = new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM CIM_OperatingSystem");
            foreach (ManagementObject queryObj in searcher.Get())
                ids.Add("3", queryObj["SerialNumber"].ToString());

            //мышь
            searcher = new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM Win32_PointingDevice");
            foreach (ManagementObject queryObj in searcher.Get())
                ids.Add("4", queryObj["DeviceID"].ToString());

            //UUID
            searcher = new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT UUID FROM Win32_ComputerSystemProduct");
            foreach (ManagementObject queryObj in searcher.Get())
                ids.Add("5", queryObj["UUID"].ToString());

            foreach (var x in ids)
                textBox1.Text += x.Key+ x.Value + "\r\n";
        }
    }
}
