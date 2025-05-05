using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public abstract class Zwierze
    {
		private int _maksymalneHp;

		public int MaksymalneHp
		{
			get { return _maksymalneHp; }
			set { _maksymalneHp = value; }
		}

		private int _pancerze;

		public int Pancerz
		{
			get { return _pancerze; }
			set { _pancerze = value; }
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

		private int myVar;

		public int MyProperty
		{
			get { return myVar; }
			set { myVar = value; }
		}

		public abstract void Atakuj(Zwierze z);

		public delegate void bonus();


	}
}
