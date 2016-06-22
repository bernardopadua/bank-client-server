using BankServer.Peer;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BankServer
{
    public class ServerAction
    {
        private Accounts peerAccounts;

        public Account GetAccount(string pAccount)
        {
            return Array.Find(peerAccounts.Account, delegate (Account acc) { return acc.ID == pAccount; });
        }

        public void ParseAction(string pAction, PeerAction pPeer)
        {
            string[] action = pAction.Split('|');
            string[] parameters = action[1].Split('#');

            switch (action[0])
            {
                default:
                    break;
                case "LOGIN":
                    ExecuteLogin(parameters[0], parameters[1], pPeer);
                    break;
                case "TRNSF":
                    decimal amount;
                    if (decimal.TryParse(parameters[1], out amount))
                    {
                        pPeer.Transfer(parameters[0], amount);
                    }
                    break;
            }
        }

        public void LoadAccounts()
        {
            peerAccounts = Util.LoadAccounts(@Util.GetFullPath(@"DB/Accounts.xml"));
        }

        private void ExecuteLogin(string pAccount, string pPassword, PeerAction pPeer)
        {
            Account loginValidated = Array.Find(peerAccounts.Account, delegate (Account acc) { return (acc.ID == pAccount && acc.PASS == pPassword); });

            if (loginValidated != null)
            {
                pPeer.SetAccount(loginValidated);

                XmlSerializer xmlSerialization = new XmlSerializer(typeof(Account));
                StringWriter xmlString = new StringWriter();

                xmlSerialization.Serialize(xmlString, loginValidated);
                byte[] xmlAccString = Encoding.Unicode.GetBytes(xmlString.ToString());

                MemoryStream toSend = new MemoryStream();
                byte[] loginEnc = Encoding.Unicode.GetBytes("LOGIN");
                toSend.Write(loginEnc, 0, loginEnc.Length);
                toSend.Write(xmlAccString, 0, xmlAccString.Length);
                SocketConnect.SendToPeer(pPeer.GetPeerSocket(), toSend.GetBuffer());
            }
            else
            {
                frmServer.ShowMessageServer("Login rejeitado.");
            }
        }
    }
}
