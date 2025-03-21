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
