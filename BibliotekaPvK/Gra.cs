using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

		public Smiec LosujSmiecia()
		{
			Random rng = new Random();
			int roll = rng.Next(0, 4);
			return ListaSmieci[roll];

		}


		public Gra()
		{
			_kotek = new Kot{ Hp = 100, MaksymalneHp = 100, Nazwa = "puszek", Obrazenia = 13, SzansaNaTrafienie = 95 }; 
				//(100, 100, "puszek", 13, 95);
			_piesek = new Pies(100,100, "burek", 15, 80);
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

        public static void AktualizujWynik(bool czyKotWygral)
        {
            string plik = "wynik.json";
            WynikiGry wynik;

            if (File.Exists(plik))
            {
                string json = File.ReadAllText(plik);
                wynik = JsonSerializer.Deserialize<WynikiGry>(json) ?? new WynikiGry();
            }
            else
            {
                wynik = new WynikiGry();
            }

            if (czyKotWygral)
                wynik.WygraneKota++;
            else
                wynik.WygranePsa++;

            string wynikJson = JsonSerializer.Serialize(wynik, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(plik, wynikJson);
        }
        public static string PokazWynik()
        {
            if (File.Exists("wynik.json"))
            {
                var json = File.ReadAllText("wynik.json");
                var wynik = JsonSerializer.Deserialize<WynikiGry>(json);

                return $"Kot: {wynik.WygraneKota} | Pies: {wynik.WygranePsa}";
            }
            else
            {
                return "Brak wyników.";
            }
        }
    }
}
