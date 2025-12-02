using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH2
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
        }

        private void Xoa()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            dateTimePicker1.Text = ""; // đặt mặc định trống như text box
            cboLop.SelectedIndex = -1;
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(new string[]
            {
                txtMaSV.Text,
                txtHoTen.Text,
                txtDiaChi.Text,
                dateTimePicker1.Text,
                cboLop.Items[cboLop.SelectedIndex].ToString()
            });
            lvwDSSinhVien.Items.Add(item);
            // Sau khi thêm thông tin sẽ xóa thông tin được nhập liệu ở ô nhập liệu và đưa con trỏ chuột về ô mã sinh viên
            Xoa();
        }


        private void btnCapNhatItem_Click(object sender, EventArgs e)
        {

            if (lvwDSSinhVien.SelectedItems.Count == -1) return;
            lvwDSSinhVien.Items[0].SubItems[0].Text = txtMaSV.Text;
            lvwDSSinhVien.Items[0].SubItems[1].Text = txtHoTen.Text;
            lvwDSSinhVien.Items[0].SubItems[2].Text = txtDiaChi.Text;
            lvwDSSinhVien.Items[0].SubItems[3].Text = dateTimePicker1.Text;
            lvwDSSinhVien.Items[0].SubItems[4].Text = cboLop.Items[cboLop.SelectedIndex].ToString();
            Xoa();
        }


        private void btnXoaItem_Click(object sender, EventArgs e)
        {
            if (lvwDSSinhVien.SelectedItems.Count > 0)
            {
                for (int i = lvwDSSinhVien.SelectedItems.Count - 1; i >= 0; i--)
                {
                    // duyệt các subItem xóa các subitem của Item
                    for (int j = lvwDSSinhVien.SelectedItems[i].IndentCount - 1; j >= 0; j--)
                    {
                        lvwDSSinhVien.Items[i].SubItems.Remove(lvwDSSinhVien.SelectedItems[i].SubItems[j]);
                    }
                    lvwDSSinhVien.Items.Remove(lvwDSSinhVien.Items[i]);
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void lvwDSSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// lấy thông tin của người dùng trở lại ô nhập liệu để dễ dàng chỉnh sửa
            txtMaSV.Text = lvwDSSinhVien.SelectedItems[0].SubItems[0].Text;
            txtHoTen.Text = lvwDSSinhVien.SelectedItems[0].SubItems[1].Text;
            txtDiaChi.Text = lvwDSSinhVien.SelectedItems[0].SubItems[2].Text;
            dateTimePicker1.Text = lvwDSSinhVien.SelectedItems[0].SubItems[3].Text;
            cboLop.Text = lvwDSSinhVien.SelectedItems[0].SubItems[4].Text;
        }
    }
}

