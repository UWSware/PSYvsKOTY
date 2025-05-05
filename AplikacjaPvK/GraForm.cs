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

        public TypPostaci WybranaPostac
        {
            get { return _wybranaPostac; }
            set { _wybranaPostac = value; }
        }

        public GraForm(TypPostaci postac)
        {
            InitializeComponent();
            this._wybranaPostac=postac;
            DodajWyglad();
            this.FormClosed += (s, e) => Application.Exit();
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
            PictureBox imgKot = new PictureBox();
            imgKot.Image = Properties.Resources.Kot;
            imgKot.SizeMode = PictureBoxSizeMode.StretchImage;
            imgKot.Size = new Size(180, 250);
            imgKot.Location = new Point(70, 370);
            imgKot.BackColor = Color.Transparent;
            this.Controls.Add(imgKot);

            //pies
            PictureBox imgPies = new PictureBox();
            imgPies.Image = Properties.Resources.Pies__3_;
            imgPies.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPies.Size = new Size(180, 250);
            imgPies.Location = new Point(1000, 370);
            imgPies.BackColor = Color.Transparent;
            this.Controls.Add(imgPies);

            //przycisk "Rzut"
            Button btnRzut = new Button();
            btnRzut.Text = "RZUT";
            btnRzut.Size = new Size(100, 40);
            if (_wybranaPostac == TypPostaci.kot)
            {
                btnRzut.Location = new Point(130, 330);
            }else if(_wybranaPostac == TypPostaci.pies)
            {
                btnRzut.Location = new Point(1030, 330);
            }

            btnRzut.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
            btnRzut.BackColor = ColorTranslator.FromHtml("#FF5722");
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
        }

    }
}
