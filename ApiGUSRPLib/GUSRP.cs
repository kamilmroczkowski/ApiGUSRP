using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

//When writing the library I used the code from the website: https://stackoverflow.com/questions/4791794/client-to-send-soap-request-and-receive-response

namespace ApiGUSRPLib
{
    public class GUSRP
    {
        private string apiKey = "";
        private string sid = "";

        public string ApiKey { get => apiKey; set => apiKey = value; }

        public GUSRP(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        private void Zaloguj()
        {
            string uuid = Guid.NewGuid().ToString();
            string xml = Properties.Resources.Zaloguj;
            xml = xml.Replace("%uuid%", uuid);
            xml = xml.Replace("%apikey%", this.ApiKey);
            string respond = SOAPGUSClient.Get("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc",
                "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Zaloguj", xml);
            this.sid = this.SearchBTags(respond, "<ZalogujResult>", "</ZalogujResult>");
        }

        private void Wyloguj()
        {
            string uuid = Guid.NewGuid().ToString();
            string xml = Properties.Resources.Wyloguj;
            xml = xml.Replace("%uuid%", uuid);
            xml = xml.Replace("%sid%", this.sid);
            SOAPGUSClient.Get("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc",
                "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Wyloguj", xml);
            this.sid = "";
        }

        private string SearchBTags(string text, string tag1, string tag2)
        {
            string r = "";
            int begin = text.IndexOf(tag1);
            int end = text.IndexOf(tag2, begin + 1);
            if (end > begin)
            {
                r = text.Substring(begin + tag1.Length, end - begin - tag2.Length + 1);
            }
            return r;
        }

        public Podmiot SzukajPoNIP(string nip)
        {
            Podmiot p = new Podmiot();
            this.Zaloguj();
            if (this.sid != "")
            {
                string uuid = Guid.NewGuid().ToString();
                string xml = Properties.Resources.Szukaj;
                xml = xml.Replace("%uuid%", uuid);
                xml = xml.Replace("%nip%", nip);
                string respond = SOAPGUSClient.Get("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc",
                    "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajPodmioty", xml, this.sid);
                this.Wyloguj();
                PropertyInfo[] properties = typeof(Podmiot).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    property.SetValue(p, this.SearchBTags(respond, "&lt;" + property.Name + "&gt;", "&lt;/" + property.Name + "&gt;"), null);
                }
            }
            return p;
        }
    }
}
