using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BankServer.Peer
{
    //Extesion from PeerConnected to manage actions
    public class PeerAction : PeerConnected
    {
        //Constructor receives the socket from the new peer.
        public PeerAction(Socket pPeerSocket, frmServer pParentClass)
        {
            this.peerSocket = pPeerSocket;
            this.parentClass = pParentClass;
        }

        public void SetDataRead(byte[] pData)
        {
            this.DataRead = pData;
            this.parentClass.GetServerAction().ParseAction(Encoding.ASCII.GetString(DataRead), this);
        }

        public void SetAccount(Account pAccount)
        {
            pAccount.peerAction = this;
            this.peerAccount = pAccount;
        }

        public void Transfer(string pAccount, decimal pAmount)
        {
            Account toTransferAccount = this.parentClass.GetServerAction().GetAccount(pAccount);

            if (toTransferAccount == null)
            {
                SocketConnect.SendToPeer(this.GetPeerSocket(), Encoding.Unicode.GetBytes("MSGGG|Account informed isn't exists!"));
                return;
            }

            if (this.peerAccount.Balance >= pAmount)
            {
                this.peerAccount.Balance -= pAmount;
                toTransferAccount.Balance += pAmount;

                //If the peer is connected, send the new balance.
                if (toTransferAccount.peerAction != null)
                {
                    toTransferAccount.peerAction.SendBalance();
                }

                SocketConnect.SendToPeer(this.GetPeerSocket(), Encoding.Unicode.GetBytes("TRNSF|"+this.peerAccount.Balance.ToString()));
            }
            else
            {
                SocketConnect.SendToPeer(this.GetPeerSocket(), Encoding.Unicode.GetBytes("MSGGG|Insufficient balance!"));
            }
        }

        public void SendBalance()
        {
            SocketConnect.SendToPeer(this.GetPeerSocket(), Encoding.Unicode.GetBytes("TRNSF|" + this.peerAccount.Balance.ToString()));
        }
    }
}
