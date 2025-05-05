using BibliotekaPvK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPvK
{
    public static class KlasaRozszerzeniowa
    {
        public static void PokazInformacjePrzedAtakiem(this Zwierze atakowany, Zwierze atakujacy, Smiec smiec)
        {
            var roleDane = new[]
            {
                new { Rola = "Atakujący", Nazwa = atakujacy.Nazwa, HP = atakujacy.Hp },
                new { Rola = "Cel", Nazwa = atakowany.Nazwa, HP = atakowany.Hp }
            };

            var roleInfo = roleDane
                .Select(d => $"{d.Rola}: {d.Nazwa} (HP: {d.HP} ❤️)");

            var smiecInfo = new[]
            {
                new { Nazwa = smiec.Nazwa, Typ = smiec.GetType().Name, Obrazenia = smiec.WartoscObrazen, Trafienie = smiec.WartoscSzansy }
            }
            .Select(s => $"Śmieć: {s.Nazwa}\n  • Obrażenia: +{s.Obrazenia}\n  • Trafienie +{s.Trafienie}%");

            string wiadomosc = string.Join(Environment.NewLine, roleInfo.Concat(smiecInfo));

            MessageBox.Show(wiadomosc, "🔥 Info po ataku 🔥", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
    }
}
