using BibliotekaPvK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaPvK
{
    public partial class GraForm : Form
    {
        private TypPostaci _wybranaPostac;
        private Gra gra;
        private Panel pasekKota;
        private Panel pasekPsa;
        private PictureBox imgKot;
        private PictureBox imgPies;
        private Panel pasekKotaTlo;
        private Panel pasekPsaTlo;
        private PictureBox smiecImgKot;
        private PictureBox smiecImgPies;

        public TypPostaci WybranaPostac
        {
            get { return _wybranaPostac; }
            set { _wybranaPostac = value; }
        }

        public GraForm(TypPostaci postac)
        {
            InitializeComponent();
            this._wybranaPostac=postac;
            gra = new Gra();
            DodajWyglad();
            this.FormClosed += (s, e) => Application.Exit();
            Gra();
        }
        private void Gra()
        {
            gra.Kotek.poAtaku += UstawZdrowie;
            gra.Piesek.poAtaku += UstawZdrowie;
            gra.Kotek.przedAtakiem += Miganie;
            gra.Piesek.przedAtakiem += Miganie;
        }
        public void Miganie(Zwierze z)
        {
            Control kontrolka = null;

            if (z is Pies) kontrolka = imgPies;
            else if (z is Kot) kontrolka = imgKot;

            if (kontrolka != null)
            {
                Color oryginalny = kontrolka.BackColor;
                kontrolka.BackColor = Color.Red;

                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 150;
                timer.Tick += (s, e) =>
                {
                    kontrolka.BackColor = oryginalny;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        public void UstawZdrowie(Zwierze zwierze)
        {
            if (zwierze is Pies)
            {
                int szerokosc = (int)(pasekPsaTlo.Width * ((float)zwierze.Hp / zwierze.MaksymalneHp));
                pasekPsa.Width = szerokosc;
            }
            else if (zwierze is Kot)
            {
                int szerokosc = (int)(pasekKotaTlo.Width * ((float)zwierze.Hp / zwierze.MaksymalneHp));
                pasekKota.Width = szerokosc;
            }
        }
        public void PokazSmieciaNadPostacia(Smiec smiec, TypPostaci typ)
        {
            PictureBox targetBox = null;
            if (typ == TypPostaci.kot)
            {
                targetBox = smiecImgKot;
            }
            else if (typ == TypPostaci.pies)
            {
                targetBox = smiecImgPies;
            }

            switch (smiec.Nazwa.ToLower())
            {
                case "skorka po bananie":
                    targetBox.Image = Properties.Resources.Banan2x;
                    break;
                case "harnas":
                    targetBox.Image = Properties.Resources.Warstwa_32x;
                    break;
                case "zgnieciona puszka":
                    targetBox.Image = Properties.Resources.Warstwa_22x;
                    break;
                case "kosc":
                    targetBox.Image = Properties.Resources.Zasob_62x;
                    break;
                case "osci":
                    targetBox.Image = Properties.Resources.Zasob_72x;
                    break;
                default:
                    targetBox.Image = null;
                    break;
            }

            targetBox.Visible = true;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                targetBox.Visible = false;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        public async void Atakuj()
        {
            try
            {
                if (_wybranaPostac == TypPostaci.kot)
                {
                    Smiec smiec = gra.LosujSmiecia();
                    PokazSmieciaNadPostacia(smiec, TypPostaci.kot);
                    gra.Kotek.Atakuj(gra.Piesek, smiec);
                    gra.Piesek.PokazInformacjePrzedAtakiem(gra.Kotek, smiec);
                    await Task.Delay(500);

                    Smiec smiec2 = gra.LosujSmiecia();
                    PokazSmieciaNadPostacia(smiec2, TypPostaci.pies);
                    gra.Piesek.Atakuj(gra.Kotek, smiec2);
                    gra.Kotek.PokazInformacjePrzedAtakiem(gra.Piesek, smiec2);
                }
                else if (_wybranaPostac == TypPostaci.pies)
                {
                    Smiec smiec = gra.LosujSmiecia();
                    PokazSmieciaNadPostacia(smiec, TypPostaci.pies);
                    gra.Piesek.Atakuj(gra.Kotek, smiec);
                    gra.Kotek.PokazInformacjePrzedAtakiem(gra.Piesek, smiec);

                    await Task.Delay(500);

                    Smiec smiec2 = gra.LosujSmiecia();
                    PokazSmieciaNadPostacia(smiec2, TypPostaci.kot);
                    gra.Kotek.Atakuj(gra.Piesek, smiec2);
                    gra.Piesek.PokazInformacjePrzedAtakiem(gra.Kotek, smiec);
                }
            }
            catch (ZeroHpException ex)
            {
                PokazEkranKoncowy();
            }
        }
        private void PokazEkranKoncowy()
        {
            string wynik = "";
            if (_wybranaPostac == TypPostaci.kot)
            {
                if (gra.Kotek.Hp <= 0)
                {
                    wynik = "💀 PORAŻKA! 💀";
                    BibliotekaPvK.Gra.AktualizujWynik(false);
                }
                else
                {
                    wynik = "🏆 ZWYCIĘSTWO! 🏆";
                    BibliotekaPvK.Gra.AktualizujWynik(true);
                }
            }
            else if (_wybranaPostac == TypPostaci.pies)
            {
                if (gra.Piesek.Hp <= 0)
                {
                    wynik = "💀 PORAŻKA! 💀";
                    BibliotekaPvK.Gra.AktualizujWynik(true);
                }
                else
                {
                    wynik = "🏆 ZWYCIĘSTWO! 🏆";
                    BibliotekaPvK.Gra.AktualizujWynik(false);
                }
            }
            WynikForm wynikForm = new WynikForm(wynik);
            wynikForm.Show();
            this.Hide();
        }
        private void DodajWyglad()
        {
            this.Text = "PIES vs KOT";
            //tlo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Size = new Size(1270, 715);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //kot
            imgKot = new PictureBox();
            imgKot.Image = Properties.Resources.Kot;
            imgKot.SizeMode = PictureBoxSizeMode.StretchImage;
            imgKot.Size = new Size(180, 250);
            imgKot.Location = new Point(70, 370);
            imgKot.BackColor = Color.Transparent;
            this.Controls.Add(imgKot);

            //pies
            imgPies = new PictureBox();
            imgPies.Image = Properties.Resources.Pies__3_;
            imgPies.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPies.Size = new Size(180, 250);
            imgPies.Location = new Point(1000, 370);
            imgPies.BackColor = Color.Transparent;
            this.Controls.Add(imgPies);

            //smieci
            smiecImgKot = new PictureBox();
            smiecImgKot.SizeMode = PictureBoxSizeMode.Zoom;
            smiecImgKot.Size = new Size(70, 70);
            smiecImgKot.Location = new Point(150, 240);
            smiecImgKot.BackColor = Color.Transparent;
            this.Controls.Add(smiecImgKot);

            smiecImgPies = new PictureBox();
            smiecImgPies.SizeMode = PictureBoxSizeMode.Zoom;
            smiecImgPies.Size = new Size(50, 70);
            smiecImgPies.Location = new Point(1050, 240);
            smiecImgPies.BackColor = Color.Transparent;
            this.Controls.Add(smiecImgPies);

            //przycisk "Rzut"
            Button btnRzut = new Button();
            btnRzut.Text = "RZUT";
            btnRzut.Size = new Size(100, 40);
            if (_wybranaPostac == TypPostaci.kot)
            {
                btnRzut.Location = new Point(130, 330);
            }
            else if(_wybranaPostac == TypPostaci.pies)
            {
                btnRzut.Location = new Point(1030, 330);
            }

            btnRzut.Click += (sender, e) =>
            {
                Atakuj();
            };
            btnRzut.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
            btnRzut.BackColor = ColorTranslator.FromHtml("#FF0000");
            btnRzut.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            btnRzut.FlatStyle = FlatStyle.Flat;
            btnRzut.FlatAppearance.BorderSize = 0;
            // Zaokrąglenie rogów
            int cornerRadius = 40;
            GraphicsPath path2 = new GraphicsPath();
            path2.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path2.AddArc(btnRzut.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path2.AddArc(btnRzut.Width - cornerRadius, btnRzut.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path2.AddArc(0, btnRzut.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path2.CloseFigure();

            btnRzut.Region = new Region(path2);
            this.Controls.Add(btnRzut);

            //paski zdrowia --KOT
            pasekKotaTlo = new Panel();
            pasekKotaTlo.Size = new Size(450,50);
            pasekKotaTlo.Location = new Point(140, 50);
            pasekKotaTlo.BackColor = ColorTranslator.FromHtml("#eac276");
            pasekKotaTlo.BorderStyle = BorderStyle.None;
            cornerRadius = 40;
            GraphicsPath path3 = new GraphicsPath();
            path3.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path3.AddArc(pasekKotaTlo.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path3.AddArc(pasekKotaTlo.Width - cornerRadius, pasekKotaTlo.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path3.AddArc(0, pasekKotaTlo.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path3.CloseFigure();

            pasekKotaTlo.Region = new Region(path3);
            this.Controls.Add(pasekKotaTlo);
            pasekKota = new Panel();
            pasekKota.Size = new Size((int)(pasekKotaTlo.Width * ((float)gra.Kotek.Hp / gra.Kotek.MaksymalneHp)), pasekKotaTlo.Height);
            pasekKota.Location = new Point(0, 0);
            pasekKota.BackColor = ColorTranslator.FromHtml("#17bf17");
            pasekKotaTlo.Controls.Add(pasekKota);

            //paski zdrowia --PIES
            pasekPsaTlo = new Panel();
            pasekPsaTlo.Size = new Size(450, 50);
            pasekPsaTlo.Location = new Point(670, 50);
            pasekPsaTlo.BackColor = ColorTranslator.FromHtml("#eac276");
            pasekPsaTlo.BorderStyle = BorderStyle.None;
            pasekPsaTlo.Region = new Region(path3);
            this.Controls.Add(pasekPsaTlo);
            pasekPsa = new Panel();
            pasekPsa.Size = new Size((int)(pasekPsaTlo.Width * ((float)gra.Piesek.Hp / gra.Piesek.MaksymalneHp)), pasekPsaTlo.Height);
            pasekPsa.Location = new Point(0, 0);
            pasekPsa.BackColor = ColorTranslator.FromHtml("#17bf17");
            pasekPsaTlo.Controls.Add(pasekPsa);

            //panel po srodku -- dla wygladu tylko
            Panel kwadrat = new Panel();
            kwadrat.Size = new Size(1020, 70);
            kwadrat.Location = new Point(120, 40);
            kwadrat.BackColor = ColorTranslator.FromHtml("#e8bb62");
            kwadrat.BorderStyle = BorderStyle.None;

            GraphicsPath path4 = new GraphicsPath();
            path4.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path4.AddArc(kwadrat.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path4.AddArc(kwadrat.Width - cornerRadius, kwadrat.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path4.AddArc(0, kwadrat.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path4.CloseFigure();

            kwadrat.Region = new Region(path4);

            this.Controls.Add(kwadrat);

            Panel kwadrat2 = new Panel();
            kwadrat2.Size = new Size(1030, 80);
            kwadrat2.Location = new Point(115, 35);
            kwadrat2.BackColor = ColorTranslator.FromHtml("#000000");
            kwadrat2.BorderStyle = BorderStyle.None;

            GraphicsPath path5 = new GraphicsPath();
            path5.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path5.AddArc(kwadrat2.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path5.AddArc(kwadrat2.Width - cornerRadius, kwadrat2.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path5.AddArc(0, kwadrat2.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path5.CloseFigure();

            kwadrat2.Region = new Region(path5);

            this.Controls.Add(kwadrat2);
        }

    }
}
