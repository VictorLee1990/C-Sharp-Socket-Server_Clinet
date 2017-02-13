using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

using System.Threading;

namespace Socket_Server_Clinet
{ 
    public delegate void MyDelegate();
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        InCommunication communication;//通訊介面

        bool creatSC = false;

        Clinet clinet;//客戶
        Server server;//伺服器          
        MyDelegate receiveServer;
        MyDelegate receiveClinet;
        MyDelegate clinetExist;
        MyDelegate clinetServer;
          
        private void Form1_Load(object sender, EventArgs e)
        {   
             receiveServer = new MyDelegate(clinetTextBox);
             receiveClinet = new MyDelegate(ServerTextBox);            
             clinetExist = new MyDelegate(clinetexist);
             clinetServer = new MyDelegate(clinetserver);
        }

        private void clinetButton_Click(object sender, EventArgs e)
        {
            if (CreateClinet.Checked == true &&  creatSC == false)
            {
                clinet = new Clinet();
                clinet.receiveServer = new MyDelegate(textbox1);
                clinet.clinetServer = new MyDelegate(clinetServer1);
                communication = clinet;
                communication.connect();
                label1.Text = "已與Server連線";
                CreateServer.Enabled = false;
                CreateClinet.Enabled = false;
                creatSC = true;             
              
            }
            else if (creatSC == true)
            {
                MessageBox.Show("請先斷開連線");
            }
            else
            {
                MessageBox.Show("選擇錯誤");
            }
                           
        }

        private void serverButton_Click(object sender, EventArgs e)
        {
            if (CreateServer.Checked == true && creatSC == false)
            {

                server = new Server();
                server.receiveClinet = new MyDelegate(textbox2);
                server.clinetExist = new MyDelegate(clinetexist1);
                communication = server;
                textBox1.Enabled = true;

                server.myIP = textBox1.Text;
                communication.Listen();
                label1.Text = "等待客戶端連接";
                textBox1.Text = server.myIP;
             
                CreateServer.Enabled = false;
                CreateClinet.Enabled = false;
                creatSC = true;

            }
            else if(creatSC == true) 
            {
                MessageBox.Show("請先斷開連線");
            }
            else
            {
                textBox1.Enabled = false;
                MessageBox.Show("選擇錯誤");
            }
               
        }

        private void enterbutton_Click(object sender, EventArgs e)
        {
           if(communication != null)
            communication.SckSSend(textBox3.Text); 
           
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            CreateServer.Enabled = true;
            CreateClinet.Enabled = true;
            creatSC = false;
            communication.close();
            label1.Text = "連線狀態";
        }

      //----------------------mydelegate meath-----------------------------//
        public void textbox1()
        {
           this.Invoke(receiveServer);
        }
        public void textbox2()
        {
            this.Invoke(receiveClinet);
        }
        public void clinetTextBox()
        {

            textBox2.AppendText("\r\n[" + DateTime.Now.ToLongTimeString() + "]" + clinet.S + "\r\t");        
        }
        public void ServerTextBox()
        {
            textBox2.AppendText("\r\n[" + DateTime.Now.ToLongTimeString() + "]" + server.cText + "\r\t");
        }

        public void clinetexist1()
        {
            this.Invoke(clinetExist);
        }
        public void clinetexist()
        {
            if (server.connectExist == false)
            {
                textBox2.AppendText("\r\n[" + DateTime.Now.ToLongTimeString() + "]" + "第[" + Convert.ToString(server.Scki) + "]台Clinet失去連線");

            }
            else
            {
                textBox2.AppendText("\r\n\r\n[" + DateTime.Now.ToLongTimeString() + "]" + "第[" + Convert.ToString(server.Scki) + "]台Clinet連線");
                label1.Text = " 已建立連線";
            }
        }

        public void clinetServer1()
        {
            this.Invoke(clinetServer);
 
        }
        public void clinetserver()
        {
            if (clinet.ServerExist == true)
            {
                textBox2.AppendText("\r\n已與Server建立連線" + "\r\t");
            }
            else if (clinet.ServerExist == false)
            {
                textBox2.AppendText("\r\n已與Server失去連線" + "\r\t") ;         
            }
        }

     
        

        

       
    }
}
