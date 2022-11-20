using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDBMovies
{
    public partial class frmMovieList : Form
    {
        public frmMovieList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMovie frm = new frmMovie();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void ActorLable_Click(object sender, EventArgs e)
        {
            frmActor frm = new frmActor();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void Genrelabel_Click(object sender, EventArgs e)
        {
            frmGenre frm = new frmGenre();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void Writerlabel_Click(object sender, EventArgs e)
        {
            frmWriter frm = new frmWriter();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void Countrylabel_Click(object sender, EventArgs e)
        {
            frmCountry frm = new frmCountry();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void Languagelabel_Click(object sender, EventArgs e)
        {
            frmLanguage frm = new frmLanguage();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
