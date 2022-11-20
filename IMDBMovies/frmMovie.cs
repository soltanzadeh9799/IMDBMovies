using IMDBMovies.BLL;
using IMDBMovies.DAL;
using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IMDBMovies.frmAddItem;
using File = System.IO.File;
using Image = System.Drawing.Image;

namespace IMDBMovies
{
    public partial class frmMovie : Form
    {
        public frmMovie()
        {
            InitializeComponent();
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        MovieBLL bll = new MovieBLL();
        MovieImageBLL imageBLL = new MovieImageBLL();
        MovieWriterBLL writerBLL = new MovieWriterBLL();
        MovieWriterDTO MovieWriterDTO = new MovieWriterDTO();
        MoviesDetailDTO detail = new MoviesDetailDTO();
        ActorDetailDTO actorDetail = new ActorDetailDTO();
        ActorDTO actorDTO = new ActorDTO();
        MovieDTO dto = new MovieDTO();
        MovieImagesDTO movieImagesdto = new MovieImagesDTO();
        bool IsUpdate = false;
        frmAddItem frm = new frmAddItem();

        private void frmMovie_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCountry.DataSource = dto.Countries;
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "ID";
            cmbCountry.SelectedIndex = -1;
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            frmCountry frm = new frmCountry();
            frm.ShowDialog();
            dto = bll.Select();
            cmbCountry.DataSource = dto.Countries;
        }

        private void btnActors_Click(object sender, EventArgs e)
        {

            frm.BtnName = "Actors";
            frm.addItemToGridActor_Event += detailfillGrid;
            frm.ShowDialog();
            //fillGrid(frm.actorDetailList, dgActors);
            //frm.Dispose();
            //dgActors.Columns[0].HeaderText = "Image";
            //dgActors.Columns[1].Visible = false;
            //dgActors.Columns[2].HeaderText = "Name";
            //dgActors.Columns[3].HeaderText = "Last Name";
            //dgActors.Columns[4].HeaderText = "BirthDate";
            //dgActors.Columns[5].Visible = false;
            //dgActors.Columns[6].HeaderText = "BirthPlace Name";
            //dgActors.Columns[7].HeaderText = "Biography";
            //dgActors.Columns[8].Visible = false;

        }
        private DataGridViewButtonColumn addDeleteButton()
        {
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.InheritedStyle.BackColor = Color.Red;
            return deleteButton;
        }
        private void btnWriters_Click(object sender, EventArgs e)
        {
            frm.BtnName = "Writers";
            frm.addItemToGridWriter_Event += detailfillGrid;
            frm.ShowDialog();
            //frm.Dispose();
            //dgWriters.Columns[0].Visible = false;
            //dgWriters.Columns[1].HeaderText = "Writer Name";
            //if(!dgWriters.Columns.Contains("dataGridViewDeleteButton"))
            //dgWriters.Columns.Add(addDeleteButton());



        }
        private void btnGenre_Click(object sender, EventArgs e)
        {
            frm.BtnName = "Genre";
            frm.addItemToGridGenre_Event += detailfillGrid;
            frm.ShowDialog();
            // frm.Dispose();
            //if (dgGenre.Rows.Count > 0)
            //{
            //    dgGenre.Columns[0].Visible = false;
            //    dgGenre.Columns[1].HeaderText = "Genre Name";
            //}
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {

            frm.BtnName = "Language";
            frm.addItemToGridLanguage_Event += detailfillGrid;
            frm.ShowDialog();
            // frm.Dispose();

            //dgLanguage.Columns[0].Visible = false;
            //dgLanguage.Columns[1].HeaderText = "Language Name";
        }
        //******************************************************************************************************
        //Method For Fill Grid with Checked Items
        //public void fillGrid<T>(List<T> detail, DataGridView dataGrid)
        //{
        //    List<T> DetailDTO = (List<T>)dataGrid.DataSource;
        //    if (DetailDTO != null)
        //    {

        //        DetailDTO.AddRange(detail);
        //        var DetailDTONew =
        //        // DetailDTO.Select(e => e).Distinct().ToList();
        //        DetailDTO.GroupBy(p => p).Select(g => g.First()).ToList();
        //        dataGrid.DataSource = DetailDTONew;

        //    }
        //    else
        //    {
        //        dataGrid.DataSource = detail;
        //    }
        //}

        //******************************************************************************************************
        //Method For Fill Grid with Delegate And Event
        public void detailfillGrid<T>(T detail)
        {
            DataGridView dataGrid = null;

            if (frm.BtnName == "Genre")
                dataGrid = dgGenre;
            else if (frm.BtnName == "Writers")
                dataGrid = dgWriters;
            else if (frm.BtnName == "Language")
                dataGrid = dgLanguage;
            else if (frm.BtnName == "Actors")
                dataGrid = dgActors;

            List<T> DetailDTO = (List<T>)dataGrid.DataSource;
            if (DetailDTO != null)
            {

                DetailDTO.Add(detail);
                var DetailDTONew =
                // DetailDTO.Select(e => e).Distinct().ToList();
                DetailDTO.GroupBy(p => p).Select(g => g.First()).ToList();
                dataGrid.DataSource = DetailDTONew;
                
            }
            else
            {
                List<T> detailDTO = new List<T>();
                detailDTO.Add(detail);
                dataGrid.DataSource = detailDTO;

            }
             
            if (!dataGrid.Columns.Contains("dataGridViewDeleteButton"))
                dataGrid.Columns.Add(addDeleteButton());
            
        }


        private void dgActors_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //var grid_view = (DataGridView)sender;
            //var image_column = (DataGridViewImageColumn)grid_view.Columns[0];
            //image_column.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //image_column.Width = 30;
            foreach (DataGridViewRow row in dgActors.Rows)
            {
                row.Height = 40;
            }
        }

        private void dgActors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Delete)
            {
                List<ActorDetailDTO> actorDetailDTO = (List<ActorDetailDTO>)dgActors.DataSource;

                foreach (DataGridViewRow item in this.dgActors.SelectedRows)
                {
                    actorDetailDTO.RemoveAt(item.Index);
                }
                dgActors.DataSource = actorDetailDTO;
                
            }
        }
        int num = 0;
        private void btnPhotos_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Select a Photo";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                num += 1;
                var picture = AddPictureBox(num);
                picture.ImageLocation = ofd.FileName;

                if (General.MovieID != 0)
                {
                    MovieImageDetailDTO movieImageDetail = new MovieImageDetailDTO();
                    movieImageDetail.MovieID = General.MovieID;
                    movieImageDetail.Images = File.ReadAllBytes(picture.ImageLocation);
                    if (imageBLL.Insert(movieImageDetail))
                    {
                        Button.Tag = General.ImageID;
                    }
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
                MessageBox.Show("Name is Empty");
            if (txtDiector.Text.Trim() == "")
                MessageBox.Show("Director Is Empty");
            if (pbPoster.Image == null)
                MessageBox.Show("Please select a poster for movie");
            else
            {
                MoviesDetailDTO moviesDetail = new MoviesDetailDTO();
                moviesDetail.FilmName = txtName.Text;
                moviesDetail.Director = txtDiector.Text;
                moviesDetail.Rank = Convert.ToInt32(txtRank.Text);
                //  moviesDetail.Rating=Convert.ToDecimal(txtRating.Text);
                moviesDetail.CountryID = Convert.ToInt32(cmbCountry.SelectedValue);
                moviesDetail.Poster = File.ReadAllBytes(pbPoster.ImageLocation);
                moviesDetail.StoryLine = txtStoryLine.Text;
                moviesDetail.ReleaseDate = dpReleaseDate.Value;
                if (bll.Insert(moviesDetail))
                {
                    if (General.MovieID != 0)
                    {
                        MessageBox.Show("Movie was added");
                        btnPhotos.Enabled = true;
                        btnActors.Enabled = true;
                        btnWriters.Enabled = true;
                        btnGenre.Enabled = true;
                        btnLanguage.Enabled = true;
                    }
                    //txtName.Clear();
                    //txtDiector.Clear();
                    //txtRank.Clear();
                    //txtRating.Clear();
                    //txtStoryLine.Clear();
                    //pbPoster.Image = null;
                    //dpReleaseDate.Value = DateTime.Today;
                    //cmbCountry.SelectedIndex = -1;

                }




            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Select a Photo";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbPoster.ImageLocation = ofd.FileName;

            }
        }

        private void txtRank_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var btn = sender as Button;
                int Id = (int)btn.Tag;
                MovieImageDetailDTO movieImageDetailDTO = new MovieImageDetailDTO();
                movieImageDetailDTO.ID = Id;

                if (imageBLL.Delete(movieImageDetailDTO))
                {
                    MessageBox.Show("Image was deleted");
                    RefreshPanelPhotos();

                }

            }
        }

        private void RefreshPanelPhotos()
        {
            panelPhotos.Controls.Clear();
            panelPhotos.Invalidate();
            movieImagesdto = imageBLL.Select();
            var list = movieImagesdto.movieImageDetailDTOs;
            foreach (var item in list)
            {
                int i = 1;
                byte[] imgData = (byte[])(item.Images);
                MemoryStream ms = new MemoryStream(imgData);

                var picture = AddPictureBox(i);
                picture.Image = Image.FromStream(ms);
                Button.Tag = item.ID;
                i++;

            }
            panelPhotos.Invalidate();
        }

        public Button Button;
        private PictureBox AddPictureBox(int num)
        {
            string numStr = "";
            numStr = num.ToString();
            ///Add Panel
            Panel panel = new Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Left;
            panel.Location = new System.Drawing.Point(0, 0);
            panel.Name = "panel" + numStr;
            panel.Size = new System.Drawing.Size(132, 111);
            panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //////
            panelPhotos.Controls.Add(panel);
            /// Add Picture Box
            var picture = new PictureBox
            {
                Name = "pictureBox" + numStr,
                Location = new Point(0, 0),
                Dock = System.Windows.Forms.DockStyle.Fill,
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
            };
            ///// 
            panel.Controls.Add(picture);
            ////Add Button
            Button button = new Button();
            button.BackgroundImage = global::IMDBMovies.Properties.Resources.icons8_close_48;
            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button.Location = new System.Drawing.Point(110, 0);
            button.Name = "button" + numStr;
            button.Size = new System.Drawing.Size(20, 20);

            button.Click += new System.EventHandler(button_Click);
            // ///
            panel.Controls.Add(button);
            button.BringToFront();
            Button = button;
            return picture;
        }

        private void dgWriters_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dgWriters.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgWriters.Columns["dataGridViewDeleteButton"].Index)
            {
                var image = Properties.Resources.icons8_close_16__1_; //An image
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var x = e.CellBounds.Left + (e.CellBounds.Width - image.Width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - image.Height) / 2;
                e.Graphics.DrawImage(image, new Point(x, y));

                e.Handled = true;
            }
        }

        private void dgGenre_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dgGenre.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgGenre.Columns["dataGridViewDeleteButton"].Index)
            {
                var image = Properties.Resources.icons8_close_16__1_; //An image
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var x = e.CellBounds.Left + (e.CellBounds.Width - image.Width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - image.Height) / 2;
                e.Graphics.DrawImage(image, new Point(x, y));

                e.Handled = true;
            }
        }

        private void dgLanguage_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dgLanguage.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgLanguage.Columns["dataGridViewDeleteButton"].Index)
            {
                var image = Properties.Resources.icons8_close_16__1_; //An image
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var x = e.CellBounds.Left + (e.CellBounds.Width - image.Width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - image.Height) / 2;
                e.Graphics.DrawImage(image, new Point(x, y));

                e.Handled = true;
            }
        }


        private void dgWriters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgWriters.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgWriters.Columns["dataGridViewDeleteButton"].Index)
            {
                //dgWriters.Rows.RemoveAt(e.RowIndex);
                //dgWriters.Refresh();

            }
            
        }

        private void btnWriterSave_Click(object sender, EventArgs e)
        {
            if (General.MovieID != 0)
            {

                List<WriterDetailDTO> WriterDetail = (List<WriterDetailDTO>)dgWriters.DataSource;
                if(WriterDetail.Count > 0)
                {
                    foreach (var item in WriterDetail)
                    {
                        MovieWriterDetailDTO dto = new MovieWriterDetailDTO();
                        dto.WriterID = item.ID;
                        dto.MovieID = General.MovieID;
                        if (writerBLL.Insert(dto))
                        {
                            MovieWriterDTO=writerBLL.Select();
                            dgWriters.DataSource= MovieWriterDTO.movieWriterDetails;

                        }
                    }
                 }
                MessageBox.Show("WriterMovie saved");
            }
        }

    }
}
