using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace scanner
{
    public partial class Form1 : Form
    {
        CommBar commBar;

        bool buttonBool = false;//指示按钮是开还是关

        public Form1()
        {
            InitializeComponent();
            commBar = new CommBar();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox_Com.Items.Clear();
            this.comboBox_Com.Items.Add("请选择COM口");
            string[] comNames = commBar.GetComName();
            for (int i = 0; i < comNames.Length; i++)
            {
                this.comboBox_Com.Items.Add(comNames[i]);
            }
            this.comboBox_Com.SelectedIndex = 0;
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            //关闭
            if (buttonBool)
            {
                buttonBool = false;

                commBar.Close();
                this.button_Test.Text = "点击测试";
            }
            //开始
            else if (!buttonBool)
            {
                buttonBool = true;
                this.button_Test.Text = "正在测试……";

                int dataBits = 8;
                int stopBits = 1;
                int parity = 0;

                //注册一该串口
                commBar.SerialPortValue(this.comboBox_Com.Text, Convert.ToInt32(this.comboBox_comPl.Text), dataBits, stopBits, parity);
                //打开串口
                if (commBar.Open())
                    //关联事件处理程序
                    commBar.serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
        }

        //用来为文本框赋值
        string barcode;
        private void CodeText(CommBar commBar)
        {
            barcode += commBar.Code.ToString();

            if (barcode.Length > 300)
            {
                barcode = "";
            }

            if (barcode.IndexOf("\r") > 0 || barcode.IndexOf("\n") > 0)
            { 
                barcode = barcode.Replace("\n", "");
                barcode = barcode.Replace("\r", "");
                this.textBox_TestTxt.Text = "";
                this.textBox_TestTxt.Text = barcode;
                //SendKeys.SendWait(119);
                Thread.Sleep(100);
                SendKeys.SendWait("{F8}");
                Thread.Sleep(500);
                SendKeys.SendWait(barcode);
                SendKeys.SendWait("{ENTER}");
               
                barcode = "";
            }
        }

        //委托，指向CodeText方法
        private delegate void ModifyButton_dg(CommBar commBar);

        //串口接收接收事件处理程序
        //每当串口讲到数据后激发
        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            commBar.getCode(sender, e);
            this.Invoke(new ModifyButton_dg(CodeText), commBar);//调用委托，将值传给文本框
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            commBar.Close();
            commBar.serialPort.Dispose();
        }
    }
}
