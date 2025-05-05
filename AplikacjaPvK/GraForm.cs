using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaPvK
{
    public partial class GraForm : Form
    {
        private string _wybranaPostac;

        public string WybranaPostac
        {
            get { return _wybranaPostac; }
            set { _wybranaPostac = value; }
        }

        public GraForm(string postac)
        {
            InitializeComponent();
            this._wybranaPostac=postac;
            this.FormClosed += (s, e) => Application.Exit();
        }
    }
}
