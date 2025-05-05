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
    public partial class WyborForm : Form
    {
        public WyborForm()
        {
            InitializeComponent();
            DodajWyglad();
            this.FormClosed += (s, e) => Application.Exit();
        }

        public void DodajWyglad()
        {
            this.Text = "PIES vs KOT";
            //tlo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Size = new Size(1270, 715);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //panel na srodku
            Panel panel = new Panel();
            panel.Size = new Size(800, 500);
            panel.Location = new Point(
                (this.ClientSize.Width - panel.Width) / 2,
                (this.ClientSize.Height - panel.Height) / 2
            );
            panel.BackColor = ColorTranslator.FromHtml("#eac276");

            // Zaokrąglenie rogów
            int cornerRadius = 90;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
            this.Controls.Add(panel);

            //napis
            Label label = new Label();
            label.Text = "Wybierz postać:";
            label.Font = new Font("Comic Sans MS", 20, FontStyle.Bold);
            label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = true;
            label.Location = new Point(
                    (panel.Width - label.PreferredWidth) / 2, 40 );
            panel.Controls.Add(label);


            //kot
            PictureBox imgKot = new PictureBox();
            imgKot.Image = Properties.Resources.Kot;
            imgKot.SizeMode = PictureBoxSizeMode.StretchImage;
            imgKot.Size = new Size(180, 250);
            imgKot.Location = new Point(100, 130);
            panel.Controls.Add(imgKot);

            Button btnKot = new Button();
            btnKot.Text = "KOT";
            btnKot.Size = new Size(200, 60);
            btnKot.Location = new Point(85, 400);
            btnKot.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
            btnKot.BackColor = ColorTranslator.FromHtml("#FF5722");
            btnKot.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            btnKot.FlatStyle = FlatStyle.Flat;
            btnKot.FlatAppearance.BorderSize = 0;
            // Zaokrąglenie rogów
            cornerRadius = 60;
            GraphicsPath path2 = new GraphicsPath();
            path2.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path2.AddArc(btnKot.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path2.AddArc(btnKot.Width - cornerRadius, btnKot.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path2.AddArc(0, btnKot.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path2.CloseFigure();

            btnKot.Region = new Region(path2);
            panel.Controls.Add(btnKot);

            btnKot.Click += (sender, e) =>
            {
                GraForm graForm = new GraForm(TypPostaci.kot);
                graForm.Show();
                this.Hide();
            };

            //pies
            PictureBox imgPies = new PictureBox();
            imgPies.Image = Properties.Resources.Pies__3_;
            imgPies.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPies.Size = new Size(180, 250);
            imgPies.Location = new Point(510, 130);
            panel.Controls.Add(imgPies);

            Button btnPies = new Button();
            btnPies.Text = "PIES";
            btnPies.Size = new Size(200, 60);
            btnPies.Location = new Point(520, 400);
            btnPies.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
            btnPies.BackColor = ColorTranslator.FromHtml("#FF5722");
            btnPies.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            btnPies.FlatStyle = FlatStyle.Flat;
            btnPies.FlatAppearance.BorderSize = 0;
            // Zaokrąglenie rogów
            cornerRadius = 60;
            GraphicsPath path3 = new GraphicsPath();
            path3.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path3.AddArc(btnPies.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path3.AddArc(btnPies.Width - cornerRadius, btnPies.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path3.AddArc(0, btnPies.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path3.CloseFigure();

            btnPies.Region = new Region(path3);
            panel.Controls.Add(btnPies);

            btnPies.Click += (sender, e) =>
            {
                GraForm graForm = new GraForm(TypPostaci.pies);
                graForm.Show();
                this.Hide();
            };
        }
    }
}
