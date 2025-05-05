using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public class Bonus2xSzansaTrafienia : BonusInterfejs
    {
        private string _nazwa;

        public string Nazwa
        {
            get { return _nazwa; }
            set { _nazwa = value; }
        }

        private bool _dostepne;

        public bool Dostepne
        {
            get { return _dostepne; }
            set { _dostepne = value; }
        }
        private TypBonusu _rodzajBonusu;

        public TypBonusu RodzajBonusu
        {
            get { return _rodzajBonusu; }
            set { _rodzajBonusu = value; }
        }


        public bool CzyUzyte => Dostepne;


        public void Zastosuj(Zwierze z)
        {
            z.SzansaNaTrafienie = z.SzansaNaTrafienie * 2;
            _dostepne = false;
        }

        public Bonus2xSzansaTrafienia()
        {
            _nazwa = "Bonus 2x Szansy Trafienia";
            _dostepne = true;
            _rodzajBonusu = TypBonusu.ofensywny;
        }
    }
}
