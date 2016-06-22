using BankServer.Peer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BankServer
{
    //That class handle the new peer connected to the system.
    public class PeerConnected
    {
        protected Socket peerSocket;
        protected frmServer parentClass;
        protected Account peerAccount { get; set; }
        public int listBoxSelectedIndex { get; set; }

        public const int totalByteRead = 256; 
        public const int totalByteSend = 1024;

        protected byte[] DataRead;
        protected byte[] DataSend = new byte[totalByteSend];

        public Socket GetPeerSocket()
        {
            return peerSocket;
        }

        public void RemoveMe()
        {
            parentClass.RemovePeerFromServer(this);
        }
        public void StartToListenPeer(PeerAction pAction)
        {
            SocketConnect.ReceiveNewData(pAction);
        }

    }
}
