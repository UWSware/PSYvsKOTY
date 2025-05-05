using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public class Gra
    {
		private Pies _piesek;

		public Pies Piesek
		{
			get { return _piesek; }
			set { _piesek = value; }
		}

		private Kot _kotek;

		public Kot Kotek
		{
			get { return _kotek; }
			set { _kotek = value; }
		}

		private List<Smiec> _listaSmieci;

		public List<Smiec> ListaSmieci
		{
			get { return _listaSmieci; }
			set { _listaSmieci = value; }
		}

		private ListaBonusow _bonusy;

		public ListaBonusow Bonusy
		{
			get { return _bonusy; }
			set { _bonusy = value; }
		}




		public Gra()
		{
			_kotek = new Kot(100, 100, "puszek", 8, 65);
			_piesek = new Pies(100,100, "burek", 10, 50);
			_listaSmieci = new List<Smiec>();
			_listaSmieci.Add(new Smiec("Harnas", 10, 40));
            _listaSmieci.Add(new Smiec("Osci", 5, 50));
            _listaSmieci.Add(new Smiec("Kosc", 5, 50));
            _listaSmieci.Add(new Smiec("Zgnieciona Puszka", 4, 60));
            _listaSmieci.Add(new Smiec("Skorka po bananie", 4, 30));
			Bonusy = new ListaBonusow();
			Bonusy.Add(new Bonus2xObrazen());
            Bonusy.Add(new Bonus2xSzansaTrafienia());
            Bonusy.Add(new BonusZdrowia());
            Bonusy.Add(new BonusPancerza());


        }
	}
}
