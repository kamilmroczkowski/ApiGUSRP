using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApiGUSRPLib
{
    public class Podmiot
    {
        private string regon;
        private string nip;
        private string statusNip;
        private string nazwa;
        private string wojewodztwo;
        private string powiat;
        private string gmina;
        private string miejscowosc;
        private string kodPocztowy;
        private string ulica;
        private string nrNieruchomosci;
        private string nrLokalu;
        private string typ;
        private string silosID;
        private string dataZakonczeniaDzialalnosci;

        public string Regon { get => regon; set => regon = value; }
        public string Nip { get => nip; set => nip = value; }
        public string StatusNip { get => statusNip; set => statusNip = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Wojewodztwo { get => wojewodztwo; set => wojewodztwo = value; }
        public string Powiat { get => powiat; set => powiat = value; }
        public string Gmina { get => gmina; set => gmina = value; }
        public string Miejscowosc { get => miejscowosc; set => miejscowosc = value; }
        public string KodPocztowy { get => kodPocztowy; set => kodPocztowy = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public string NrNieruchomosci { get => nrNieruchomosci; set => nrNieruchomosci = value; }
        public string NrLokalu { get => nrLokalu; set => nrLokalu = value; }
        public string Typ { get => typ; set => typ = value; }
        public string SilosID { get => silosID; set => silosID = value; }
        public string DataZakonczeniaDzialalnosci { get => dataZakonczeniaDzialalnosci; set => dataZakonczeniaDzialalnosci = value; }

        public override string ToString()
        {
            string r = "";
            foreach (var prop in this.GetType().GetProperties())
            {
                r += prop.Name + ": " + prop.GetValue(this, null) + "\n";
            }
            return r;
        }
    }
}
