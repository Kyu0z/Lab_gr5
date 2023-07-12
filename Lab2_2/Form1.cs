using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCN.SelectedIndex = 2;
          
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void btThemsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMSV.Text == "" || txtName.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ các thông tin");
                int selectedRow = GetSelectedRow(txtMSV.Text);
                if (selectedRow == -1)
                {
                    selectedRow = dgvStudent.Rows.Add();
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK);

                }
                else
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void InsertUpdate (int selectedRow)
        {
            dgvStudent.Rows[selectedRow].Cells[0].Value = txtName.Text;
            dgvStudent.Rows[selectedRow].Cells[1].Value = txtMSV.Text;
 
            dgvStudent.Rows[selectedRow].Cells[2].Value = cmbCN.Text;
            dgvStudent.Rows[selectedRow].Cells[3].Value = txtDate.Text;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int GetSelectedRow(string MasoSV)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value != null)
                {
                    if (dgvStudent.Rows[i].Cells[0].Value.ToString() == MasoSV)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvStudent.CurrentRow.Selected = true;
                    txtMSV.Text = dgvStudent.Rows[e.RowIndex].Cells["MSSV"].FormattedValue.ToString();
                    txtName.Text = dgvStudent.Rows[e.RowIndex].Cells["Tên"].FormattedValue.ToString();

                    txtDate.Text = dgvStudent.Rows[e.RowIndex].Cells["Date"].FormattedValue.ToString();
                    cmbCN.Text = dgvStudent.Rows[e.RowIndex].Cells["colFaculty"].FormattedValue.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = GetSelectedRow(txtMSV.Text);
                if(selectedRow ==-1)
                {
                    throw new Exception("Không tìm thấy MSSV cần xóa!!");

                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to delete?", "YES or NO ", MessageBoxButtons.YesNo);
                    if(dr == DialogResult.Yes)
                    {
                        dgvStudent.Rows.RemoveAt(selectedRow);
                        MessageBox.Show("Xóa thành công!!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMSV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

