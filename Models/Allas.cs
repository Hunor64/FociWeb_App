using Microsoft.CodeAnalysis;

namespace FociWeb_App.Models
{
    public class Allas
    {
        public int Helyezes{ get; set; } = 0;
        public string Nev { get; set; }
        public int Gyozelmek { get; set; }
        public int Dontetlenek { get; set; }
        public int Veresegek { get; set; }
        public int LottGolok { get; set; }
        public int KapottGolok { get; set; }
        public int Pontok { get; set; } = 0;

        public Allas(string nev, int gyozelmek, int dontetlenek, int veresegek, int lottGolok, int kapottGolok, int pontok)
        {
            this.Nev = nev;
            this.Gyozelmek = gyozelmek;
            this.Dontetlenek = dontetlenek;
            this.Veresegek = veresegek;
            this.LottGolok = lottGolok;
            this.KapottGolok = kapottGolok;
            this.Pontok = pontok;
        }
        public Allas(int helyezes)
        {
            this.Helyezes = helyezes;
        }
    }
}
