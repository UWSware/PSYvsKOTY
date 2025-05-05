using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public class Smiec
    {
		private string _nazwa;

		public string Nazwa
		{
			get { return _nazwa; }
			set { _nazwa = value; }
		}


		private int _wartoscObrazen;

		public int WartoscObrazen
		{
			get { return _wartoscObrazen; }
			set { _wartoscObrazen = value; }
		}

		private int _wartoscSzansy;

		public int WartoscSzansy
		{
			get { return _wartoscSzansy; }
			set { _wartoscSzansy = value; }
		}

        public Smiec(string nazwa, int wartoscObrazen, int wartoscSzansy)
        {
            _wartoscObrazen = wartoscObrazen;
            _wartoscSzansy = wartoscSzansy;
			_nazwa = nazwa;
        }
    }
}
