using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraProceduralnie
{
    class Program
    {
        /// <summary>
        /// Wczytuje dane(liczba całkowita) z konsoli.Jeśli 'x' zgłasza wyjątek
        /// </summary>
        /// <param name="prompt">Tekst zachęty wyświetlany uzytkownikowi</param>
        /// <returns>gdy użytkownik poda x</returns>
        private static int WczytajDane(string prompt)
        {
             
            do
            {
                Console.WriteLine(prompt);
                string tekst = Console.ReadLine();
                if (tekst.ToLower() == "x")
                    throw new InvalidOperationException(); //todo 
                int propozycja = 0;

                try
                {
                    propozycja = Convert.ToInt32(tekst); // int.Parse(tekst)
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie podano liczby!");

                }
                catch (OverflowException)
                {
                    Console.WriteLine("Liczba nie mieści się w rejestrze! Spróbuj jeszcze raz! ");

                }
            }

            while (true);
            return propozycja;
        }

        static int Losuj(int min, int max)
        {
            Random generator = new Random();
            int wylosowana = generator.Next(min, max + 1);
            return wylosowana;
        }

        private static int Wylosowana = 0;

        private static string Ocena(int propozycja)
        {
            if (propozycja < Wylosowana)
                Console.WriteLine("za mało");
            else if (propozycja > Wylosowana)
                Console.WriteLine("za dużo");
            else
            {
                Console.WriteLine("trafiono");
                trafiono = true;
            }
        }
       
      

        static void Main(string[] args)
        {


            // 1. Komputer losuje liczbę
            Wylosowana = Losuj(1, 100); // może być zgłoszony wyjątek, gdy min > max
            Console.WriteLine("Wylosowałem liczbę od 1 do 100. \n Odgadnij ją");

#if(DEBUG)
            Console.WriteLine(Wylosowana);
#endif

            //wykonuj
            int propozycja = 0;
            do
            {
                try
                {
                    int propozycja = WczytajDane("Podaj swoją propozycję (x - gdy koniec");
                }
                catch(InvalidOperationException);
                {
                    Console.WriteLine("Szkoda że kończymy");
                    return;
                }

                Console.WriteLine($"Przyjąłem wartość {propozycja}");

                string ocena = Ocena(propozycja);
                Console.WriteLine(ocena);
                if (ocena == "trafiono")
                    break;

                }
            while (!trafiono);
            //do momentu trafienia

            Console.WriteLine("Koniec gry");
        }
    }
}
