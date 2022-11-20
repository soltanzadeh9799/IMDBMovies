using IMDBMovies.BLL;
using IMDBMovies.DAL;
using IMDBMovies.DAL.DTO;
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
    public partial class frmGenre : Form
    {
        public frmGenre()
        {
            InitializeComponent();
        }

        GenreBLL bll = new GenreBLL();
        GenreDetailDTO detail = new GenreDetailDTO();
        GenreDTO dto = new GenreDTO();
        bool IsUpdate = false;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void frmGenre_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Genres;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Genre Name";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Genres;
            dataGridView1.ClearSelection();
            txtGenreName.Clear();
            IsUpdate = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtGenreName.Text.Trim() == "")
                MessageBox.Show("Genre Name Is Empty");
            else
            {
                List<GenreDetailDTO> list = dto.Genres;
                list = list.Where(x => x.GenreName.Contains(txtGenreName.Text)).ToList();
                dataGridView1.DataSource = list;
            }

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new GenreDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.GenreName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGenreName.Text = detail.GenreName;
            IsUpdate = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtGenreName.Text.Trim() == "")
                MessageBox.Show("Genre Name Is Empty");
            else
            {
                if (!IsUpdate)
                {
                    GenreDetailDTO genre = new GenreDetailDTO();
                    genre.GenreName = txtGenreName.Text;
                    if (bll.Insert(genre))
                    {
                        MessageBox.Show("Genre was Added");
                        txtGenreName.Clear();

                    }
                }
                else if (IsUpdate)
                {
                    if (txtGenreName.Text.Trim() == detail.GenreName)
                        MessageBox.Show("there is no change");
                    else
                    {
                        detail.GenreName = txtGenreName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Genre was updated");
                            txtGenreName.Clear();
                        }

                    }

                }
                dto = bll.Select();
                dataGridView1.DataSource = dto.Genres;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
