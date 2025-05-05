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
    public partial class WynikForm : Form
    {
        public WynikForm(String napis)
        {
            InitializeComponent();
            DodajWyglad(napis);
        }

        public void DodajWyglad(String napis)
        {
            this.Text = "PIES vs KOT";
            //tlo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Size = new Size(1270, 715);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //Label
            Label etykieta = new Label();
            etykieta.Text = napis;
            etykieta.Font = new Font("Comic Sans MS", 24, FontStyle.Bold);
            etykieta.ForeColor = Color.Red;
            etykieta.BackColor = Color.Transparent;
            etykieta.TextAlign = ContentAlignment.MiddleCenter;
            etykieta.Location = new Point(400, 200);
            etykieta.Dock = DockStyle.Top;
            this.Controls.Add(etykieta);

            //przycisk
            Button startButton = new Button();
            startButton.Text = "RESET GRY";
            startButton.Font = new Font("Comic Sans MS", 32, FontStyle.Bold);
            startButton.BackColor = ColorTranslator.FromHtml("#FF5722");
            startButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.Size = new Size(400, 100);
            startButton.Location = new Point(
                (this.ClientSize.Width - startButton.Width) / 2,
                (this.ClientSize.Height - startButton.Height) / 2
            );

            // Zaokrąglenie rogów
            int cornerRadius = 90;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(startButton.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(startButton.Width - cornerRadius, startButton.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, startButton.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            startButton.Region = new Region(path);

            this.Controls.Add(startButton);

            startButton.Click += (sender, e) =>
            {
                StartForm startForm = new StartForm();
                startForm.Show();
                this.Hide();
            };
        }


}
}
