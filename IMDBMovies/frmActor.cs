using IMDBMovies.BLL;
using IMDBMovies.DAL;
using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using Image = System.Drawing.Image;

namespace IMDBMovies
{
    public partial class frmActor : Form
    {
        public frmActor()
        {
            InitializeComponent();
        }
        ActorBLL bll = new ActorBLL();
        ActorDTO dto = new ActorDTO();
        ActorDetailDTO detail = new ActorDetailDTO();
        bool IsUpdate = false;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Select a Photo";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbActor.ImageLocation = ofd.FileName;

            }
        }

        private void frmActor_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbBirthPlace.DataSource = dto.Countries;
            cmbBirthPlace.DisplayMember = "CountryName";
            cmbBirthPlace.ValueMember = "ID";
            cmbBirthPlace.SelectedIndex = -1;

            dataGridView1.DataSource = dto.Actores;
            dataGridView1.Columns[0].HeaderText = "Image";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Last Name";
            dataGridView1.Columns[4].HeaderText = "BirthDate";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "BirthPlace Name";
            dataGridView1.Columns[7].HeaderText = "Biography";
            dataGridView1.Columns[8].Visible = false;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtName.Text.Trim() == "")
                MessageBox.Show("Name Is Empty");
            else if (txtLastName.Text.Trim() == "")
                MessageBox.Show("LastName Is Empty");
            else if (txtBiograph.Text.Trim() == "")
                MessageBox.Show("Biography Is Empty");
            else if (cmbBirthPlace.SelectedIndex == -1)
                MessageBox.Show("BirthPlace Is Empty");
            else
            {
                if (!IsUpdate)
                {
                    ActorDetailDTO actor = new ActorDetailDTO();
                    actor.Name = txtName.Text;
                    actor.LastName = txtLastName.Text;
                    actor.BirthDate = dpBirthDate.Value;
                    actor.BirthPlace = Convert.ToInt32(cmbBirthPlace.SelectedValue);
                    actor.Biography = txtBiograph.Text;
                    actor.Image = File.ReadAllBytes(pbActor.ImageLocation);
                    if (bll.Insert(actor))
                    {
                        MessageBox.Show("Actor was added");
                        txtName.Clear();
                        txtLastName.Clear();
                        txtBiograph.Clear();
                        pbActor.Image = null;
                        dpBirthDate.Value = DateTime.Today;
                        cmbBirthPlace.SelectedIndex = -1;

                    }
                }
                else if (IsUpdate)
                {
                    detail.Name = txtName.Text;
                    detail.LastName = txtLastName.Text;
                    detail.BirthDate = dpBirthDate.Value;
                    detail.BirthPlace = Convert.ToInt32(cmbBirthPlace.SelectedValue);
                    detail.Biography = txtBiograph.Text;
                    
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("Actor was Updated");
                        txtName.Clear();
                        txtLastName.Clear();
                        txtBiograph.Clear();
                        pbActor.Image = null;
                        dpBirthDate.Value = DateTime.Today;
                        cmbBirthPlace.SelectedIndex = -1;

                    }
                }

                dto = bll.Select();
                dataGridView1.DataSource = dto.Actores;

            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.LastName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.BirthDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.BirthPlace = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.BirthPlaceName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.Biography = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            
            byte[] imgData = (byte[])(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            MemoryStream ms = new MemoryStream(imgData);
            pbActor.Image = Image.FromStream(ms);
            detail.Image = (byte[])(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

            txtName.Text = detail.Name;
            txtLastName.Text = detail.LastName;
            dpBirthDate.Value = (DateTime)detail.BirthDate;
            cmbBirthPlace.SelectedValue = detail.BirthPlace;
            txtBiograph.Text = detail.Biography;
            IsUpdate = true;



        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Actores;
            dataGridView1.ClearSelection();
            txtName.Clear();
            txtLastName.Clear();
            dpBirthDate.Value = DateTime.Today;
            cmbBirthPlace.SelectedIndex = -1;
            txtBiograph.Clear();
            pbActor.Image = null;
            IsUpdate = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ActorDetailDTO> list = dto.Actores;
            if (txtNameSearch.Text.Trim() != "")
                list = list.Where(x => x.Name.Contains(txtNameSearch.Text)).ToList();
            if (txtLastNameSearch.Text.Trim() != "")
                list = list.Where(x => x.LastName.Contains(txtLastNameSearch.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNameSearch.Clear();
            txtLastNameSearch.Clear();
            dto = bll.Select();
            dataGridView1.DataSource = dto.Actores;

        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            frmCountry frm = new frmCountry();
            frm.ShowDialog();
            dto = bll.Select();
            cmbBirthPlace.DataSource = dto.Countries;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var grid_view = (DataGridView)sender;
            var image_column = (DataGridViewImageColumn)grid_view.Columns[0];
            image_column.ImageLayout = DataGridViewImageCellLayout.Stretch;
            image_column.Width = 60;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 70;
            }
        }
    }
}
