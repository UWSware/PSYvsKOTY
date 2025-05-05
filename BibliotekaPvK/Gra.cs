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

		public Gra()
		{
			_kotek = new Kot(100, 100, "puszek", 8, 65);
			_piesek = new Pies(100,100, "burek", 10, 50);
		}
	}
}
