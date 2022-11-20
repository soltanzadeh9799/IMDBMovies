using IMDBMovies.BLL;
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
    public partial class frmLanguage : Form
    {
        public frmLanguage()
        {
            InitializeComponent();
        }
        LanguageBLL bll = new LanguageBLL();
        LanguageDTO dto = new LanguageDTO();
        LanguageDetailDTO detail = new LanguageDetailDTO();
        bool IsUpdate = false;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLanguage_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.languages;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Language Name";
            RefreshForm();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void RefreshForm()
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.languages;
            dataGridView1.ClearSelection();
            txtLanguageName.Clear();
            IsUpdate = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLanguageName.Text.Trim() == "")
                MessageBox.Show("Langage Name Is Empty");
            else
            {
                if (!IsUpdate)
                {
                    LanguageDetailDTO language = new LanguageDetailDTO();
                    language.LanguageName = txtLanguageName.Text;
                    if (bll.Insert(language))
                    {
                        MessageBox.Show("Language was added");
                        txtLanguageName.Clear();
                    }
                }
                else if (IsUpdate)
                {
                    if (txtLanguageName.Text.Trim() == detail.LanguageName)
                        MessageBox.Show("there is no change");
                    else
                    {
                        detail.LanguageName = txtLanguageName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Language was Updated");
                            txtLanguageName.Clear();
                        }
                    }

                }
                RefreshForm();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtLanguageName.Text.Trim() == "")
                MessageBox.Show("Language Name Is Empty");
            else
            {
                List<LanguageDetailDTO> list = dto.languages;
                list = list.Where(x => x.LanguageName.Contains(txtLanguageName.Text)).ToList();
                dataGridView1.DataSource = list;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            detail = new LanguageDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.LanguageName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLanguageName.Text = detail.LanguageName;
            IsUpdate = true;
        }
    }
}
