using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public class BonusZdrowia : BonusInterfejs
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
            if (z.MaksymalneHp - z.Hp >= 50) z.Hp += 50;
            else z.Hp = z.MaksymalneHp;
            _dostepne = false;
        }

        public BonusZdrowia()
        {
            _nazwa = "Uleczenie";
            _dostepne = true;
            _rodzajBonusu = TypBonusu.defensywny;
        }
    }
}
