using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;

namespace Socket_Server_Clinet
{
    class Server:InCommunication
    {
        public Socket[] SckSs; 
        public string cText;
        public bool connectExist; // 判斷是否連線存在
        public int Scki;

        int SckCIndex;    // 定義一個指標用來判斷現下有哪一個空的 Socket 可以分配給 Client 端連線;
        int SPort = 6101;
        private string LocalIP = "127.0.0.1"; // 其中 xxx.xxx.xxx.xxx 為本機IP   
        int RDataLen = 20; // 這裡的RDataLen為要傳送資料的長度, 這裡我隨用5個長度, 傳送 "ABCDE" 給Client端

        Thread[] tids = new Thread[30];
        Thread SckSAcceptTd;
        public MyDelegate receiveClinet;
        public MyDelegate clinetExist;

        /// <summary>
        /// 取得或設置sever IP
        /// </summary>
        public string myIP
        { 
            get
            {
                return LocalIP;                               
            }
            set
            {
                LocalIP = value;
            }           
        }

        public void Listen()
        {
            Array.Resize(ref SckSs, 1);

            SckSs[0] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SckSs[0].Bind(new IPEndPoint(IPAddress.Parse(LocalIP), SPort));

            SckSs[0].Listen(10);
            
            connect();
        }

        /// <summary>
        /// server close
        /// </summary>
        public void close()
        {
       
            for (int i = 0; i <= SckSs.Length - 1; i++)
            {
                if (SckSs[i] != null)
                {
                    SckSs[i].Shutdown(SocketShutdown.Both);
                    SckSs[i].Close();
                    SckSs[i].Dispose();
                }
            }
                
        }


        public void connect() //ScksWaitAccept()
        {
            // 判斷目前是否有空的 Socket 可以提供給Client端連線
            
            bool FlagFinded = false;

            for (int i = 1; i <= SckSs.Length - 1; i++)
            {
                // SckSs[i] 若不為 null 表示已被實作過, 判斷是否有 Client 端連線
               
                if (SckSs[i] != null)
                {                
                    // 如果目前第 i 個 Socket 若沒有人連線, 便可提供給下一個 Client 進行連線
                    if (SckSs[i].Connected == false)
                    {
                        SckCIndex = i;
                        FlagFinded = true;
                        break;
                    }
                }
            }

            // 如果 FlagFinded 為 false 表示目前並沒有多餘的 Socket 可供 Client 連線
            if (FlagFinded == false)
            {
                // 增加 Socket 的數目以供下一個 Client 端進行連線
                SckCIndex = SckSs.Length;
                Array.Resize(ref SckSs, SckCIndex + 1);
            }



            tids[Scki] = new Thread(ScKSAcceptProc);
            tids[Scki].Name = "執行緒" + Scki;
            tids[Scki].Start();
            tids[Scki].IsBackground = true;


            //SckSAcceptTd = new Thread(ScKSAcceptProc);
            //SckSAcceptTd.Start();
            //SckSAcceptTd.IsBackground = true;
        }

        public void ScKSAcceptProc()
        {
            try
            {
                string name = this.tids[Scki].Name;
                connectExist = false;
                SckSs[SckCIndex] = SckSs[0].Accept();
                Scki = SckCIndex;

                 connect();
                long IntAcceptData;
                connectExist = true;
                clinetExist();  

                while (true)
                {

                    int threadID = Thread.CurrentThread.ManagedThreadId;
                    
                    Scki = threadID - 9;
                    //Thread.Sleep(5000);
                    //判斷clinet是否斷線
                    if (SckSs[Scki].Poll(0, SelectMode.SelectRead) == true && SckSs[Scki].Available == 0)
                    {
                        connectExist = false;
                        if (connectExist == false)
                            clinetExist();
                        break;
                    }

                    byte[] clienData = new byte[RDataLen];

                    IntAcceptData = SckSs[Scki].Receive(clienData);

                    cText = Encoding.UTF8.GetString(clienData);

                    receiveClinet();
                   
                }
            }
            catch(Exception ex) 
            {
                cText = "已經斷線";
                receiveClinet();
            }
          
        }

        public void SckSSend(string ServerSend)
        {

            for (int Scki = 0;  Scki <= SckSs.Length - 1; Scki++)
            {

                if (null != SckSs[Scki] && SckSs[Scki].Connected == true)
                {

                    try
                    {

                        string SendS = ServerSend;      // SendS 在這裡為 string 型態, 為 Server 要傳給 Client 的字串, 我測試傳送 字串 "ABCDE" 給Client端

                        SckSs[Scki].Send(Encoding.ASCII.GetBytes(SendS));

                    }

                    catch
                    {

                        // 這裡出錯, 主要是出在 SckSs[Scki] 出問題, 自己加判斷吧~

                    }

                }
            }
        }

       public void SckSReceiveProc() { }
    }
  
}
