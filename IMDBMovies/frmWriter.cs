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
    public partial class frmWriter : Form
    {
        public frmWriter()
        {
            InitializeComponent();
        }
        WriterBLL bll = new WriterBLL();
        WriterDTO dto=new WriterDTO();
        WriterDetailDTO detail = new WriterDetailDTO();
        bool IsUpdate=false;    
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
        private void RefreshForm()
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Writers;
            dataGridView1.ClearSelection();
            txtWriterName.Clear();
            IsUpdate = false;
        }

        private void frmWriter_Load(object sender, EventArgs e)
        {
            dto=bll.Select();
            dataGridView1.DataSource=dto.Writers;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Writer Name";
            RefreshForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtWriterName.Text.Trim()=="")
                MessageBox.Show("Writer Name is Empty");
            else
            {
                List<WriterDetailDTO> list = dto.Writers;
                list = list.Where(x => x.WriterName.Contains(txtWriterName.Text)).ToList();
                dataGridView1.DataSource = list;
            }
        }


        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new WriterDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.WriterName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtWriterName.Text = detail.WriterName;
            IsUpdate = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtWriterName.Text.Trim() == "")
                MessageBox.Show("Langage Name Is Empty");
            else
            {
                if (!IsUpdate)
                {
                    WriterDetailDTO writer = new WriterDetailDTO();
                    writer.WriterName = txtWriterName.Text;
                    if (bll.Insert(writer))
                    {
                        MessageBox.Show("Writer was added");
                        txtWriterName.Clear();
                    }
                }
                else if (IsUpdate)
                {
                    if (txtWriterName.Text.Trim() == detail.WriterName)
                        MessageBox.Show("there is no change");
                    else
                    {
                        detail.WriterName = txtWriterName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Writer was Updated");
                            txtWriterName.Clear();
                        }
                    }

                }
                RefreshForm();
            }
        }
    }
}
