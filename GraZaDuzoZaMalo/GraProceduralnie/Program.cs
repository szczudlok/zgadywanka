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
        /// Wczytuje dane (liczba całkowita) z konsoli. Jeśli 'x' zgłasza wyjątek
        /// </summary>
        /// <param name="prompt">Tekst zachęty wyświetlany uzytkownikowi</param>
        /// <returns>liczba odczytana ze standardowego wejscia</returns>
        /// <exception cref="InvalidOperationException">gdy użytkownik poda znak X</exception>
        private static int WczytajDane(string prompt = "Podaj liczbę lub X jeśli koniec: ")
        {
            int propozycja = 0;
            do
            {
                Console.Write(prompt);
                string tekst = Console.ReadLine();
                if (tekst.ToLower() == "x")
                    throw new InvalidOperationException();
                try
                {
                    propozycja = Convert.ToInt32(tekst); // int.Parse(tekst)
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie podano liczby! Spróbuj jeszcze raz.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Liczba nie mieści się w rejestrze! Spróbuj jeszcze raz.");
                }
            }
            while (true);

            return propozycja;
        }

        private static int Losuj(int min = 1, int max = 100)
        {
            Random generator = new Random();
            int wylosowana = generator.Next(min, max + 1);
            return wylosowana;
        }

        private static int wylosowana = 0;

        private static string Ocena(int propozycja)
        {
            if (propozycja < wylosowana)
                return "za mało";
            else if (propozycja > wylosowana)
                return "za dużo";
            else
            {
                return "trafiono";
            }
        }

        public static void Main(string[] args)
        {
            // 1. Komputer losuje liczbę
            wylosowana = Losuj(); // może być zgłoszony wyjatek, gdy min > max
            Console.WriteLine("Wylosowałem liczbę od 1 do 100. \n Odgadnij ją");

#if(DEBUG)
            Console.WriteLine(wylosowana);
#endif

            //wykonuj
            int propozycja = 0;
            do
            {
                try
                {
                    propozycja = WczytajDane("Podaj swoją propozycję (X - gdy koniec)");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Szkoda, że kończymy. Do widzenia.");
                    return;
                }

                Console.WriteLine($"Przyjąłem wartość {propozycja}");

                string ocena = Ocena(propozycja);
                Console.WriteLine(ocena);
                if (ocena == "trafiono")
                    break;
            }
            while (true);
            //do momentu trafienia

            Console.WriteLine("Koniec gry");
        }
    }
}