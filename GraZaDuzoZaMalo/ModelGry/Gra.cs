using System;

namespace ModelGry
{
    public class Gra
    {
        public enum Odp { ZaMalo=-1, Trafiono=0, ZaDuzo=+1};

        // pola
        private readonly int wylosowana;
        public readonly int ZakresOd, ZakresDo;

        public int LicznikRuchow { get; private set; } = 0;
        
        //ToDo: historia rozgrywki
        public Gra(int min, int max)
        {
            ZakresOd = min;
            ZakresDo = max;
            wylosowana = Losuj(ZakresOd, ZakresDo);
        }
        private int Losuj(int min = 1, int max = 100)
        {
            Random generator = new Random();
            int los = generator.Next(min, max + 1);
            return los;
        }


        public Odp Ocena(int propozycja)
        {
            LicznikRuchow++;
            if (propozycja < wylosowana)
                return Odp.ZaMalo;
            else if (propozycja > wylosowana)
                return Odp.ZaDuzo;
            else // ==
                return Odp.Trafiono;
        }

    }

}
