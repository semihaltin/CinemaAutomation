using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
namespace SinemaOtomasyon
{
    public partial class frmYaziciGonder : Form
    {
        public frmYaziciGonder()
        {
            InitializeComponent();
        }

        private void frmYaziciGonder_Load(object sender, EventArgs e)
        {

        }

        private void pdYazici_PrintPage(object sender, PrintPageEventArgs e)
        {
           
            int tepe = 30; int sol = 30;
            Font fn = new Font("Arial", 10, FontStyle.Bold);
            e.Graphics.DrawString("adas", fn, Brushes.Black, sol, tepe);
            tepe = tepe + fn.Height;
        }
    }
}
