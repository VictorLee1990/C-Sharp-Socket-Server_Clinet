using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Socket_Server_Clinet
{
    class Clinet :InCommunication
    {
        Socket SckSPort; // 先行宣告Socket

        string RmIp = "127.0.0.1";  // 其中 xxx.xxx.xxx.xxx 為Server端的IP

        int SPort = 6101;

        int RDataLen = 50;  // 此文Server端和Client端都是用固定長度5在傳送資料~ 可以針對自己的需要改長度 

        public string S;
        public bool ServerExist; // 判斷是否連上伺服器

        public MyDelegate clinetServer;  
        public MyDelegate receiveServer;
                
        // 連線
        public void connect()//ConnectServer()
        {

            try
            {

                SckSPort = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                SckSPort.Connect(new IPEndPoint(IPAddress.Parse(RmIp), SPort));

                // RmIp和SPort分別為string和int型態, 前者為Server端的IP, 後者為Server端的Port

                // 同 Server 端一樣要另外開一個執行緒用來等待接收來自 Server 端傳來的資料, 與Server概念同
                Thread SckSReceiveTd = new Thread(SckSReceiveProc);

                SckSReceiveTd.Start();
                SckSReceiveTd.IsBackground = true;

            }
            catch { }
        }

        /// <summary>
        /// clinet close
        /// </summary>
        public void close()
        {
            SckSPort.Shutdown(SocketShutdown.Both);
            SckSPort.Disconnect(false);
            SckSPort.Close();
            SckSPort.Dispose();
            ServerExist = false;
            clinetServer();
            
        }

        // SckSReceiveProc 是接受來自 Server 端的資料其函式內容幾乎同 Server 端的 SckSAcceptProc 接收資料的Code~  ,  只差在 Client 只有一個Socket. 
        public void SckSReceiveProc()
        {
            try
            {

                long IntAcceptData;

                ServerExist = true;
                clinetServer();   
             
                while (true)
                {
                    if (SckSPort.Poll(0, SelectMode.SelectRead) == true)
                    {
 
                    }
                    byte[] clientData = new byte[RDataLen];

                     clientData.Initialize();


                    // 程式會被 hand 在此, 等待接收來自 Server 端傳來的資料

                    IntAcceptData = SckSPort.Receive(clientData);

                    // 往下就自己寫接收到來自Server端的資料後要做什麼事唄~^^”

                     S = Encoding.Default.GetString(clientData);
                    //Console.WriteLine(S); 

                     receiveServer();                  
                }
            }

            catch(Exception ex)
            {

                S = "已經斷線";
                //MessageBox.Show(ex.Message);
                receiveServer();
              
            }
        }

       


        // 當然 Client 端也可以傳送資料給Server端~ 和 Server 端的SckSSend一樣, 只差在Client端只有一個Socket

        public void SckSSend(string clinetOut)
        {

           // int Scki=1;

            try
            {

                string SendS = clinetOut;

                SckSPort.Send(Encoding.UTF8.GetBytes(SendS));

            }

            catch
            {


            }


        }

        public void Listen() { }
        public void ScKSAcceptProc() { }
    }
}
