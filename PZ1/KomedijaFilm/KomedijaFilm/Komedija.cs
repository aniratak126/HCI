using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomedijaFilm
{
    public class Komedija
    {
        private string naziv;
        private string produkcijskaKuca;
        private int trajanjeMin;
        private DateTime datumPremijere;
        private string rtf;
        private string putanjaSlike;

        public Komedija() { }

        public Komedija(string naziv, string produkcijskaKuca, int trajanjeMin,  DateTime datumPremijere, string rtf, string putanjaSlike)
        {
            this.naziv = naziv;
            this.produkcijskaKuca = produkcijskaKuca;
            this.trajanjeMin = trajanjeMin;
            this.datumPremijere = datumPremijere;
            this.rtf = rtf;
            this.putanjaSlike = putanjaSlike;
        }
        public string Naziv { get => naziv; set => naziv = value; }
        public string ProdukcijskaKuca { get => produkcijskaKuca; set => produkcijskaKuca = value; }
        public int TrajanjeMin { get => trajanjeMin; set => trajanjeMin = value; }
        public DateTime DatumPremijere { get => datumPremijere; set => datumPremijere = value; }
        public string Rtf { get => rtf; set => rtf = value; }
        public string PutanjaSlike { get => putanjaSlike; set => putanjaSlike = value; }

    }
}
