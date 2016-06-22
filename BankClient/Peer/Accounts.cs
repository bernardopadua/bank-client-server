using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankServer
{
    [Serializable()]
    public class Account
    {
        [XmlElement("Name")]
        public string Name;
        [XmlElement("Tel")]
        public string Tel;
        [XmlElement("Balance")]
        public decimal Balance;

        [XmlAttribute("ID")]
        public string ID { get; set; }
        [XmlAttribute("PASS")]
        public string PASS { get; set; }
    }

    [Serializable()]
    [XmlRoot("Accounts")]
    public class Accounts
    {
        [XmlElement("Account")]
        public Account[] Account { get; set; }
    }

}
