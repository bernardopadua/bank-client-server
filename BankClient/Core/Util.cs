using BankServer;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BankClient
{
    public class Util
    {

        public static byte[] GetBytesBlock(byte[] data, int count)
        {
            return data.Take(count).ToArray();
        }

        public static string GetBytesToString(byte[] data, int count)
        {
           return Encoding.Unicode.GetString(data.Take(count).ToArray());
        }

        public static byte[] GetBytesSkiping(byte[] pData, int skip, int count)
        {
            return pData.Skip(skip).Take(pData.Length).ToArray();
        }

        public static Account GetAccountFromStream (byte[] pData)
        {
            XmlSerializer xmlDeserialize = new XmlSerializer(typeof(Account));
            StringReader strReader = new StringReader(Encoding.Unicode.GetString(pData));

            Account newAccount = (Account)xmlDeserialize.Deserialize(strReader);

            return newAccount;
        }
    }

    sealed class VersionAssembly : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;

            string assembName = Assembly.GetExecutingAssembly().FullName;
            string typName = "BankServer.Account";

            if (assemblyName == assembName.Replace("BankClient", "BankServer") && typeName == typName)
            {
                typName = "BankClient.Account";
            }

            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typName, assemblyName));

            return typeToDeserialize;
        }
    }
}
