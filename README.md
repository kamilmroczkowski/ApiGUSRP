# ApiGUSRP

ApiGUSRP is a library DotNet 4 C# for Polish state institution: GUS

## Usage

Code:
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiGUSRPLib;

namespace ApiGUSRPTests
{
    class Program
    {
        static void Main(string[] args)
        {
            GUSRP g = new GUSRP("twojapikey");
            Podmiot p = g.SzukajPoNIP("5861125071"); //US Gdynia
            Console.WriteLine(p.ToString());
            Console.WriteLine("Nazwa: " + p.Nazwa);
            Console.ReadLine();
        }
    }
}
```

Output:
```
Regon: 190515834
Nip: 5861125071
StatusNip:
Nazwa: PIERWSZY URZĄD SKARBOWY W GDYNI
Wojewodztwo: POMORSKIE
Powiat: Gdynia
Gmina: Gdynia
Miejscowosc: Gdynia
KodPocztowy: 81-353
Ulica: ul. Władysława IV
NrNieruchomosci: 2/4
NrLokalu:
Typ: P
SilosID: 6
DataZakonczeniaDzialalnosci: 2015-03-31

Nazwa: PIERWSZY URZĄD SKARBOWY W GDYNI
```
