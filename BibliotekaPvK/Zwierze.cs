using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public abstract class Zwierze
    {
		private int _hp;

		public int Hp
		{
			get { return _hp; }
			set { _hp = value; }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}


	}
}
