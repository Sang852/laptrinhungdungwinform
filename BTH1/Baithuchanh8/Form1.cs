using System.Diagnostics.Eventing.Reader;

namespace Baithuchanh8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtNhapA.TextChanged += checkInput;
            txtNhapB.TextChanged += checkInput;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No) e.Cancel = true;
        }
        public void checkInput(object sender, EventArgs e)
        {
            bool ok = true;
            double a, b;
            /*
                Nếu số không rỗng -> kiểm tra có phải là số không -> đúng thì không có lỗi và tắt nút giải
                                                                 -> Sai thì cảnh báo lỗi
                Nếu số rỗng (cũng có thể là xóa thủ công bằng nút Backspace) -> không cảnh báo lỗi và tắt nút giải
             */
            if (!string.IsNullOrWhiteSpace(txtNhapA.Text))
            {
                if (!double.TryParse(txtNhapA.Text, out a))
                {
                    this.errorProvider1.SetError(txtNhapA, "Lỗi: A phải là số!");
                    ok = false;
                }
                else this.errorProvider1.SetError(txtNhapA, "");
            }
            else
            {
                this.errorProvider1.SetError(txtNhapA, "");
                ok = false;
            }

            if (!string.IsNullOrWhiteSpace(txtNhapB.Text))
            {
                if (!double.TryParse(txtNhapB.Text, out a))
                {
                    this.errorProvider1.SetError(txtNhapB, "Lỗi: B phải là số!");
                    ok = false;
                }
                else this.errorProvider1.SetError(txtNhapB, "");
            }
            else
            {
                this.errorProvider1.SetError(txtNhapB, "");
                ok = false;
            }

            // bật khi a và b hợp lệ -> bật nút giải
            btnGiai.Enabled = ok;


            // bật khi a hoặc b rỗng rỗng -> bật nút xóa
            btnXoa.Enabled = !string.IsNullOrWhiteSpace(txtNhapA.Text) || !string.IsNullOrEmpty(txtNhapB.Text);

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNhapA.Clear();
            txtNhapB.Clear();
            txtNghiemPhuongTrinh.Clear();

            btnGiai.Enabled = false;
            btnXoa.Enabled = false;
            txtNhapA.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGiai_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(txtNhapA.Text);
            double b = Convert.ToDouble(txtNhapB.Text);
            if (a == 0)
            {
                if (b == 0)
                {
                    MessageBox.Show("Phương trình vô số nghiệm!", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Lỗi: A phải khác 0!", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                txtNghiemPhuongTrinh.Text = (-b / a).ToString();
            }
            btnGiai.Enabled = false;
            btnXoa.Enabled = true;
        }
    }
}
