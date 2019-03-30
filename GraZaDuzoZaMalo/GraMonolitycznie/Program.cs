using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMonolitycznie
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.Write("witaj!");
            Console.Write("Podaj swoje imię: ");
            string x = Console.ReadLine();
            Console.WriteLine($"Witaj, {x}");
            */
            //1.Komputer losuje liczbę
            Random generator = new Random();
            int wylosowana = generator.Next(1, 101);
            Console.WriteLine("Wylosowałem liczbę od 1 do 100. \n Odgadnij ją");
#if(DEBUG)
            Console.WriteLine(wylosowana);
#endif
            //2.Człowiek proponuje rozwiązanie 
            Console.Write("Podaj swoją propozycje: ");
            string tekst = Console.ReadLine();
            int propozycja = Convert.ToInt32(tekst);
            Console.WriteLine($"Przyjąłem wartość {propozycja}");
            //3.Komputer ocenia propozycje 
            if(propozycja < wylosowana)
                Console.WriteLine("za mało");
            else if(propozycja > wylosowana)
                Console.WriteLine("za dużo");
            else 
                Console.WriteLine("trafiono");
            Console.WriteLine("Koniec Gry");
        }
    }
}
