﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public class Pies : Zwierze
    {
        public Pies(int maksymalneHp, int hp, string nazwa, int obrazenia, int szansaNaTrafienie) : base(maksymalneHp, hp, nazwa, obrazenia, szansaNaTrafienie)
        {
        }

        public override string ToString()
        {
            return $"Pies {Nazwa}, Maksymalne HP: {MaksymalneHp}, Obecne Hp: {Hp}, Obrazenia: {Obrazenia}, Szansa na trafienie: {SzansaNaTrafienie}";
        }


    }
}
