using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankServer
{
    class Util
    {
        public static Accounts LoadAccounts(string pPath)
        {

            try
            {
                StreamReader reader = new StreamReader(pPath, Encoding.GetEncoding("iso-8859-1"));
                XmlSerializer prAcc = new XmlSerializer(typeof(Accounts));
                Accounts peerAccounts = (Accounts)prAcc.Deserialize(reader);
                return peerAccounts;
            }
            catch (SystemException ex)
            {
                frmServer.ShowMessageServer(ex.Message);
                return null;
            }
        }

        public static string GetFullPath(string pFile)
        {
            return Path.GetFullPath(pFile);
        }
    }
}
