using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public class Kot : Zwierze
    {

        public override string ToString()
        {
            return $"Kot {Nazwa}, Maksymalne HP: {MaksymalneHp}, Obecne Hp: {Hp}, Obrazenia: {Obrazenia}, Szansa na trafienie: {SzansaNaTrafienie}";
        }
    }
}
