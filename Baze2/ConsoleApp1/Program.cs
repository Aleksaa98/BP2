using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baze2;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1Container m = new Model1Container();
            Aerodrom a = new Aerodrom()
            {
                Naziv = "Nikola Tesla",
                Adresa = "Beograd 14"
            };
            m.Aerodromi.Add(a);
            m.SaveChanges();
            Centrala c = new Centrala()
            {
                Naziv="Centrala1"
            };
            m.Centrale.Add(c);
            m.SaveChanges();
            Avion av = new Avion()
            {
                Naziv = "F29",
                BrojMesta = "120",
                AerodromId = 1,
                CentralaId = 1              
            };
            m.Avioni.Add(av);
            m.SaveChanges();

        }
    }
}
