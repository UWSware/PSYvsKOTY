using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public class BonusPancerza : BonusInterfejs
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
            z.Pancerz += 50;
            _dostepne = false;
        }

        public BonusPancerza()
        {
            _nazwa = "Pancerz";
            _dostepne = true;
            _rodzajBonusu = TypBonusu.defensywny;
        }
    }
}
