using System.Windows.Forms;

namespace Baithuchanh10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                lstLopA.Items.Add(txtHoTen.Text);
                this.errorProvider1.SetError(txtHoTen, "");
            }
            else this.errorProvider1.SetError(txtHoTen, "Họ và tên không được để trống!");
            txtHoTen.Clear();
            txtHoTen.Focus();
        }


        // chuyển các tên đang chọn từ Lisxtbox trái sang Listbox phải và ngược lại.
        private void btnChuyenTenAB_Click(object sender, EventArgs e)
        {
            if (lstLopA.Focus())
            {
                for (int i = 0; i < lstLopA.SelectedItems.Count; i++)
                {
                    lstLopB.Items.Add(lstLopA.SelectedItems[i]);
                }
                for (int i = lstLopA.SelectedItems.Count - 1; i >= 0; i--)
                {
                    lstLopA.Items.Remove(lstLopA.SelectedItems[i]);
                }
            }

        }

        private void btnChuyenTenBA_Click(object sender, EventArgs e)
        {
            if (lstLopB.Focus())
            {
                for (int i = 0; i < lstLopB.SelectedItems.Count; i++)
                {
                    lstLopA.Items.Add(lstLopB.SelectedItems[i]);
                }
                for (int i = lstLopB.SelectedItems.Count - 1; i >= 0; i--)
                {
                    lstLopB.Items.Remove(lstLopB.SelectedItems[i]);
                }
            }
        }

        // chuyển hết toàn bộ các tên từ Listbox trái sang Listbox phải và ngược lại.
        private void btnChuyenTatCaAB_Click(object sender, EventArgs e)
        {
            // Chọn tất cả các phần tử trong listbox A
            for(int i = 0; i < lstLopA.Items.Count; i++)
            {
                lstLopA.SetSelected(i, true);
            }
            // Di chuyển toàn bộ phần tử sang list box B
            for(int i = 0; i < lstLopA.SelectedItems.Count; i++)
            {
                lstLopB.Items.Add(lstLopA.SelectedItems[i]);
            }
            //Xóa phần tử đang chọn ở list box A
            for(int i = lstLopA.SelectedItems.Count - 1; i >= 0; i--)
            {
                lstLopA.Items.Remove(lstLopA.SelectedItems[i]);
            }

        }
        private void btnChuyenTatCaTenBA_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLopB.Items.Count; i++)
            {
                lstLopB.SetSelected(i, true);
            }
            for (int i = 0; i < lstLopB.SelectedItems.Count; i++)
            {
                lstLopA.Items.Add(lstLopB.SelectedItems[i]);
            }
            for (int i = lstLopB.SelectedItems.Count - 1; i >= 0; i--)
            {
                lstLopB.Items.Remove(lstLopB.SelectedItems[i]);
            }

        }

        //Nút Xóa: cho phép xóa các tên đang chọn trong danh sách lớp A.
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstLopA.Focus())
            {
                for (int i = lstLopA.SelectedItems.Count - 1; i >= 0; --i)
                {
                    lstLopA.Items.Remove(lstLopA.SelectedItems[i]);
                }
                return;
            }
            MessageBox.Show("Hãy chọn tên cần xóa trong Lớp A!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
