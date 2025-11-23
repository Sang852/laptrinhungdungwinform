namespace Baitapthuchanh9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
                 );
            if (r == DialogResult.No) e.Cancel = true;
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            lstDanhSach.Items.Add(Convert.ToInt32(txtNhap.Text));
            txtNhap.Clear();
            txtNhap.Focus();
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnTongPhanTu_Click(object sender, EventArgs e)
        {
            long tong = 0;
            foreach (var num in lstDanhSach.Items)
                tong += (int)num;
            MessageBox.Show($"Tổng phần tử trong ListBox là: {tong}", "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information
            );
        }

        private void btnXoaPhanTuDauCuoi_Click(object sender, EventArgs e)
        {
            int phanTuDau = (int)lstDanhSach.Items[0];
            int phanTuCuoi = (int)lstDanhSach.Items[lstDanhSach.Items.Count - 1];
            lstDanhSach.Items.RemoveAt(0);
            lstDanhSach.Items.RemoveAt(lstDanhSach.Items.Count - 1);
            MessageBox.Show($"Đã xóa phần tử đầu {phanTuDau} và phần tử cuối {phanTuCuoi} trong listbox", "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information
                );
        }

        // Xóa phần tử đang chọn
        private void btnXoaPhanTuChon_Click(object sender, EventArgs e)
        {
            // Nếu danh sách số ta được focus thì mới thực hiện xóa phần tử
            if (lstDanhSach.SelectedItems.Count > 0)
            {
                // Nếu danh sách số ta đã chọn mà còn thì xóa cho đến khi nào hết thì thôi
                int i = lstDanhSach.SelectedItems.Count - 1;
                while (i >= 0)
                {
                    lstDanhSach.Items.Remove(lstDanhSach.SelectedItems[i]);
                    --i;
                }
            }
        }

        private void btnTangPhanTu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDanhSach.Items.Count; i++)
                lstDanhSach.Items[i] = (int)lstDanhSach.Items[i] + 2;
        }


        private void btnChonSoChan_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDanhSach.Items.Count; i++)
            {
                if ((int)lstDanhSach.Items[i] % 2 == 0)
                    lstDanhSach.SetSelected(i, true);
            }
        }

        private void btnChonSoLe_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDanhSach.Items.Count; i++)
            {
                if ((int)lstDanhSach.Items[i] % 2 != 0)
                    lstDanhSach.SetSelected(i, true);
            }
        }

        private void btnThayBinhPhuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDanhSach.Items.Count; i++)
            {
                lstDanhSach.Items[i] = (int)lstDanhSach.Items[i] * (int)lstDanhSach.Items[i];
            }
        }
    }
}
