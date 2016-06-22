using BankServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class PeerClient
    {
        protected Account accClient;

        public const int totalByteRead = 1024;
        public const int totalByteSend = 256;

        protected byte[] dataRead = new byte[totalByteRead];
        protected byte[] dataSend = new byte[totalByteSend];

        protected Socket clientSocket;

        public Socket GetClientSocket()
        {
            return clientSocket;
        }

        public void SetDataSend(byte[] pData)
        {
            dataSend = pData;
        }

        public byte[] GetDataSend()
        {
            return dataSend;
        }

        public void DisconnectMe()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Disconnect(false);
        }
    }
}
