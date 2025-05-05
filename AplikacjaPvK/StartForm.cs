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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            DodajWyglad();
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

            //przycisk
            Button startButton = new Button();
            startButton.Text = "START";
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
                WyborForm wyborForm = new WyborForm();
                wyborForm.Show();
                this.Hide();
            };
        }

    }
}
