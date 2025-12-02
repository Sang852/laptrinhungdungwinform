using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTH2
{
    public partial class Bai9 : Form
    {
        public Bai9()
        {
            InitializeComponent();
        }
        void createListView()
        {
            lvDanhSachKH.Columns.Add("Họ tên", 150);
            lvDanhSachKH.Columns.Add("Khu vực", 100);
            lvDanhSachKH.Columns.Add("Định mức", 100);
            lvDanhSachKH.Columns.Add("Tiêu thụ", 150);
            lvDanhSachKH.Columns.Add("Thành tiền", 150);
            lvDanhSachKH.View = View.Details;
            lvDanhSachKH.GridLines = true;
            lvDanhSachKH.MultiSelect = true;
        }
        void createComboBox()
        {
            cboKhuVuc.Items.Add("Khu vực 1");
            cboKhuVuc.Items.Add("Khu vực 2");
            cboKhuVuc.Items.Add("Khu vực 3");
        }
        private void Bai9_Load(object sender, EventArgs e)
        {
            createListView();
            createComboBox();
            txtHoTenKH.Focus();
            lblTongTien.Text = "0";
        }

        /*Combobox có 3 khu vực: Khu vực 1 (định mức là 50), khu vực 2 (định mức là 100), khu
        vực 3 (định mức là 150). Khi chọn khu vực nào thì hiện định mức tương ứng*/
        private void cboKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboKhuVuc.SelectedIndex)
            {
                case 0: lblDinhMuc.Text = "50"; break;
                case 1: lblDinhMuc.Text = "100"; break;
                case 2: lblDinhMuc.Text = "150"; break;
            }
        }

        /*Nút TÍNH TIỀN (hoặc Enter trên các textbox): kiểm tra dữ liệu nhập, nếu hợp lệ thì tính 
        và xuất kết quả ra ô Tiêu thụ và Thành tiền, đồng thời thêm một dòng tương ứng vào Listview 
        và cập nhật ô tổng tiền. */

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTenKH.Text))
            {
                MessageBox.Show("Họ tên không được để trống!",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!txtHoTenKH.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Họ tên không chứa kí tự đặc biệt!",
                 "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(txtSoCu.Text, out double soCu) ||
                !int.TryParse(txtSoMoi.Text, out int soMoi))
            {
                MessageBox.Show("Vui lòng nhập đúng số!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soMoi < soCu)
            {
                MessageBox.Show("Số mới phải lớn hơn số cũ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(lblDinhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn khu vực!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị ra tiêu thụ và thành tiền

            double tieuThu = Math.Abs(soMoi - soCu);
            int dinhMuc = int.Parse(lblDinhMuc.Text);
            lblTieuThu.Text = tieuThu.ToString();
            double thanhTien = 0;
            if (tieuThu <= dinhMuc)
            {
                thanhTien = tieuThu * 500;
            }
            else
            {
                thanhTien = (tieuThu * 500) + (tieuThu - dinhMuc) * 1000;
            }
            lblThanhTien.Text = thanhTien.ToString();

            // Thêm khách hàng vào listView
            ListViewItem khachHang = new ListViewItem();
            khachHang.Text = txtHoTenKH.Text;
            khachHang.SubItems.Add(cboKhuVuc.Text);
            khachHang.SubItems.Add(lblDinhMuc.Text);
            khachHang.SubItems.Add(lblTieuThu.Text);
            khachHang.SubItems.Add(lblThanhTien.Text);

            lvDanhSachKH.Items.Add(khachHang);

            int tong = 0;
            foreach (ListViewItem it in lvDanhSachKH.Items)
            {
                tong += int.Parse(it.SubItems[4].Text); // cột Thành tiền
            }
            lblTongTien.Text = tong.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhSachKH.SelectedItems.Count > 0)
            {
                double tongTien = double.Parse(lblTongTien.Text);
                for (int i = lvDanhSachKH.SelectedItems.Count - 1; i >= 0; i--)
                {
                    tongTien -= double.Parse(lvDanhSachKH.SelectedItems[i].SubItems[4].Text);
                    lvDanhSachKH.Items.Remove(lvDanhSachKH.SelectedItems[i]);
                }
                // Cập nhật tổng tiền
                lblTongTien.Text = tongTien.ToString();

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtHoTenKH.Clear();
            cboKhuVuc.SelectedIndex = -1;
            txtSoCu.Clear();
            txtSoMoi.Clear();
            lblDinhMuc.Text = "";
            lblTieuThu.Text = "";
            lblThanhTien.Text = "";
        }
    }
}
