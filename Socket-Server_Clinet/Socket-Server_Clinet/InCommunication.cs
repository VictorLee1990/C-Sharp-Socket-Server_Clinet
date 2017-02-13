using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket_Server_Clinet
{
    interface InCommunication
    {
        void Listen();
        void connect();
        void ScKSAcceptProc();
        void SckSReceiveProc();
        void SckSSend(string Send);
        void close();
        
    }
}
