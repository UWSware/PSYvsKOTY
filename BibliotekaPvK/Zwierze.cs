using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public abstract class Zwierze
    {
		private bool _czyBot;

		public bool CzyBot
		{
			get { return _czyBot; }
			set { _czyBot = value; }
		}


		private int _maksymalneHp;

		public int MaksymalneHp
		{
			get { return _maksymalneHp; }
			set { _maksymalneHp = value; }
		}

		private int _pancerz;

		public int Pancerz
		{
			get { return _pancerz; }
			set { _pancerz = value; }
		}


		private int _hp;

		public int Hp
		{
			get { return _hp; }
			set { _hp = value; }
		}

		private string _nazwa;

		public string Nazwa
		{
			get { return _nazwa; }
			set { _nazwa = value; }
		}

		private int _obrazenia;

		public int Obrazenia
		{
			get { return _obrazenia; }
			set { _obrazenia = value; }
		}

		private int _szansaNaTrafienie;

		public int SzansaNaTrafienie
		{
			get { return _szansaNaTrafienie; }
			set { SzansaNaTrafienie = value; }
		}

        protected Zwierze(int maksymalneHp, int hp, string nazwa, int obrazenia, int szansaNaTrafienie)
        {
            _maksymalneHp = maksymalneHp;
            _pancerz = 0;
            _hp = hp;
            _nazwa = nazwa;
            _obrazenia = obrazenia;
            _szansaNaTrafienie = szansaNaTrafienie;
        }

        public virtual void Atakuj(ref Zwierze z, Smiec s) {
			int szansaKoncowa = (z.SzansaNaTrafienie + s.WartoscSzansy) / 2;
			przedAtakiem?.Invoke(z);
			if (CzyTrafi(szansaKoncowa))
			{ if(z.Pancerz == 0)
				{
                    z.Pancerz -= this.Obrazenia;
					if (z.Pancerz < 0)
					{
						z.Hp += z.Pancerz;
					}
				}
				else
				{
                    z.Hp -= this.Obrazenia;
                }
                if (z.Hp <= 0) throw new ZeroHpException("HP się skończyło! Koniec Gry");

            }
			poAtaku?.Invoke(z);
				
		}

		public bool CzyTrafi(int szansaNaTrafienie)
		{
			Random rng = new Random();
			int roll = rng.Next(0, 100);
			return roll<szansaNaTrafienie;
		}
		public delegate void bonus(Zwierze z);

		public event bonus przedAtakiem;
        public event bonus poAtaku;

    }
}
