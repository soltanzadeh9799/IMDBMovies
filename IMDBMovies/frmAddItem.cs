using IMDBMovies.BLL;
using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDBMovies
{
    public partial class frmAddItem : Form
    {
        public frmAddItem()
        {
            InitializeComponent();

        }
        
        MovieBLL bll = new MovieBLL();
        MovieDTO dto = new MovieDTO();

        public string BtnName = "";
        private void frmAddItem_Load(object sender, EventArgs e)
        {
            if (BtnName == "Actors")
            {
                label1.Text = "Actors";
                label3.Text = "Actors Name";
                dto = bll.Select();
                dataGridView1.DataSource = dto.Actores;
                dataGridView1.Columns[0].HeaderText = "Image";
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Name";
                dataGridView1.Columns[3].HeaderText = "Last Name";
                dataGridView1.Columns[4].HeaderText = "BirthDate";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "BirthPlace Name";
                dataGridView1.Columns[7].HeaderText = "Biography";
                //dataGridView1.Columns[8].HeaderText = "IsCheck";
            }
            else if (BtnName == "Writers")
            {
                label1.Text = "Writers";
                label3.Text = "Writers Name";
                dto = bll.Select();
                dataGridView1.DataSource = dto.Writers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Name";

            }
            else if (BtnName == "Genre")
            {
                label1.Text = "Genre";
                label3.Text = "Genre Name";
                dto = bll.Select();
                dataGridView1.DataSource = dto.Genres;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Name";

            }
            else if (BtnName == "Language")
            {
                label1.Text = "Language";
                label3.Text = "Language Name";
                dto = bll.Select();
                dataGridView1.DataSource = dto.languages;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Name";

            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public List<ActorDetailDTO> actorDetailList = new List<ActorDetailDTO>();
        public List<WriterDetailDTO> writerDetailList = new List<WriterDetailDTO>();
        public List<LanguageDetailDTO> languageDetailDTO = new List<LanguageDetailDTO>();
        public List<GenreDetailDTO> genreDetailDTO = new List<GenreDetailDTO>();
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BtnName == "Actors")
            {
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[8].FormattedValue)
                    {
                        ActorDetailDTO actorDetail = new ActorDetailDTO();
                        actorDetail.Image = (byte[])(dataGridView1.Rows[i].Cells[0].Value);
                        actorDetail.ID = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                        actorDetail.Name = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        actorDetail.LastName = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        actorDetail.BirthDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value);
                        actorDetail.BirthPlace = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                        actorDetail.BirthPlaceName = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        actorDetail.Biography = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        actorDetailList.Add(actorDetail);
                    }
                }



                this.Close();

            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (BtnName == "Actors")
            {

                var grid_view = (DataGridView)sender;
                var image_column = (DataGridViewImageColumn)grid_view.Columns[0];
                image_column.ImageLayout = DataGridViewImageCellLayout.Stretch;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = 40;
                }
            }
        }
        public delegate void AddItemToGridActors(ActorDetailDTO detail);
        public event AddItemToGridActors addItemToGridActor_Event; 

        public delegate void AddItemToGridGenre(GenreDetailDTO detail);
        public event AddItemToGridGenre addItemToGridGenre_Event;

        public delegate void AddItemToGridWriter(WriterDetailDTO detail);
        public event AddItemToGridWriter addItemToGridWriter_Event;

        public delegate void AddItemToGridLanguage(LanguageDetailDTO detail);
        public event AddItemToGridLanguage addItemToGridLanguage_Event;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (BtnName == "Actors")
            {
                ActorDetailDTO ActorDetail = new ActorDetailDTO();
                var RowsIndex = dataGridView1.CurrentRow.Index;
                ActorDetail.ID = Convert.ToInt32(dataGridView1.Rows[RowsIndex].Cells[1].Value);
                ActorDetail.Name = dataGridView1.Rows[RowsIndex].Cells[2].Value.ToString();
                ActorDetail.LastName= dataGridView1.Rows[RowsIndex].Cells[3].Value.ToString();
                ActorDetail.BirthDate=Convert.ToDateTime(dataGridView1.Rows[RowsIndex].Cells[4].Value);
                ActorDetail.BirthPlace= Convert.ToInt32(dataGridView1.Rows[RowsIndex].Cells[5].Value);
                ActorDetail.BirthPlaceName = dataGridView1.Rows[RowsIndex].Cells[6].Value.ToString();
                ActorDetail.Biography=dataGridView1.Rows[RowsIndex].Cells[7].Value.ToString();
                ActorDetail.Image = (byte[])(dataGridView1.Rows[RowsIndex].Cells[0].Value);
                if (addItemToGridActor_Event != null)
                    addItemToGridActor_Event(ActorDetail);
            }
            if (BtnName == "Genre")
            {
                GenreDetailDTO GenreDetail = new GenreDetailDTO();
                var RowsIndex = dataGridView1.CurrentRow.Index;
                GenreDetail.ID = Convert.ToInt32(dataGridView1.Rows[RowsIndex].Cells[0].Value);
                GenreDetail.GenreName = dataGridView1.Rows[RowsIndex].Cells[1].Value.ToString();
                if (addItemToGridGenre_Event != null)
                    addItemToGridGenre_Event(GenreDetail);
             }

            if (BtnName == "Writers")
            {
                WriterDetailDTO WriterDetail = new WriterDetailDTO();
                var RowsIndex = dataGridView1.CurrentRow.Index;
                WriterDetail.ID = Convert.ToInt32(dataGridView1.Rows[RowsIndex].Cells[0].Value);
                WriterDetail.WriterName = dataGridView1.Rows[RowsIndex].Cells[1].Value.ToString();
                if (addItemToGridWriter_Event != null)
                    addItemToGridWriter_Event(WriterDetail);
            }
            if (BtnName == "Language")
            {
                LanguageDetailDTO LanguageDetail = new LanguageDetailDTO();
                var RowsIndex = dataGridView1.CurrentRow.Index;
                LanguageDetail.ID = Convert.ToInt32(dataGridView1.Rows[RowsIndex].Cells[0].Value);
                LanguageDetail.LanguageName = dataGridView1.Rows[RowsIndex].Cells[1].Value.ToString();
                if (addItemToGridLanguage_Event != null)
                    addItemToGridLanguage_Event(LanguageDetail);
            }
        }
    }
}
