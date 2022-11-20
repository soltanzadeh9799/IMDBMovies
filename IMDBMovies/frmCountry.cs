using IMDBMovies.BLL;
using IMDBMovies.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDBMovies
{
    public partial class frmCountry : Form
    {
        public frmCountry()
        {
            InitializeComponent();
        }
        CountryBLL bll = new CountryBLL();
        CountryDTO dto = new CountryDTO();
        CountryDetailDTO detail = new CountryDetailDTO();
        bool IsUpdate = false;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCountry_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Countries;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Country Name";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCountryName.Text.Trim() == "")
                MessageBox.Show("Country Name Is Empty");
            else
            {
                if (!IsUpdate)
                {
                    CountryDetailDTO country = new CountryDetailDTO();
                    country.CountryName = txtCountryName.Text;
                    if (bll.Insert(country))
                    {
                        MessageBox.Show("Country was Added");
                        txtCountryName.Clear();

                    }
                }
                else if (IsUpdate)
                {
                    if (txtCountryName.Text.Trim() == detail.CountryName)
                        MessageBox.Show("there is no change");
                    else
                    {
                        detail.CountryName = txtCountryName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Country was updated");
                            txtCountryName.Clear();
                        }

                    }

                }
                dto = bll.Select();
                dataGridView1.DataSource = dto.Countries;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new CountryDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.CountryName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCountryName.Text = detail.CountryName;
            IsUpdate = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            dto = bll.Select();
            dataGridView1.DataSource = dto.Countries;
            dataGridView1.ClearSelection();
            txtCountryName.Clear();
            IsUpdate = false;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCountryName.Text.Trim() == "")
                MessageBox.Show("Country Name Is Empty");
            else
            {
                List<CountryDetailDTO> list = dto.Countries;
                list = list.Where(x => x.CountryName.Contains(txtCountryName.Text)).ToList();
                dataGridView1.DataSource = list;
            }



        }
    }
}
