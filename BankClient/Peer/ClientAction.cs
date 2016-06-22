using BankServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class ClientAction : PeerClient
    {

        private frmClient mainThread;

        public ClientAction(Socket pSocket, frmClient frmPrinc)
        {
            this.clientSocket = pSocket;
            mainThread = frmPrinc;
        }

        public void SetDataRead(byte[] pData)
        {
            this.dataRead = pData;
            ParseAction(dataRead);
        }

        public void Transfer(string pAcc, string pValue)
        {
            byte[] toSend = Encoding.ASCII.GetBytes("TRNSF|" + pAcc + "#" + pValue);
            this.SetDataSend(toSend);
            SocketConnect.SendToServer(this);
        }

        public void LoginAccount(string pAccount, string pPassword)
        {
            byte[] toSend = Encoding.ASCII.GetBytes("LOGIN|" + pAccount + "#" + pPassword);
            this.SetDataSend(toSend);
            SocketConnect.SendToServer(this);
        }
        
        public void FinishLogin(byte[] pData)
        {
            this.accClient = Util.GetAccountFromStream(pData);
            mainThread.SetAccountClient(this.accClient.Name, this.accClient.Balance.ToString());
        }

        public void ParseAction(byte[] pData)
        {
            string action = Util.GetBytesToString(pData, 10);

            switch (action)
            {
                default:
                    break;
                case "LOGIN":
                    FinishLogin(Util.GetBytesSkiping(pData, 10, pData.Length));
                    break;
                case "MSGGG":
                    string msg = Encoding.Unicode.GetString(Util.GetBytesSkiping(pData, 10, pData.Length));
                    frmClient.ShowMessageClient(msg);
                    break;
                case "TRNSF":
                    mainThread.RefreshBalance(Encoding.Unicode.GetString(Util.GetBytesSkiping(pData, 12, pData.Length)));
                    break;
            }
        }
    }
}
