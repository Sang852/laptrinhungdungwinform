namespace Baithuchanh3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private long num;
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string result = txtNhap.Text;
            if (!result.All(c => char.IsDigit(c)))
            {
                MessageBox.Show("Nội dung phải là chữ số!", "Thông báo");
                return;
            }
            num = long.Parse(result);
            cboCapNhat.Items.Add(num);
            this.txtNhap.Clear();
            this.txtNhap.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboCapNhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUocSo.Items.Clear();

            if (cboCapNhat.SelectedItem == null) return;

            if (!long.TryParse(cboCapNhat.SelectedItem.ToString(), out long selectedValue)) return;

            for (long i = 1; i <= selectedValue; i++)
            {
                if (selectedValue % i == 0)
                    lstUocSo.Items.Add(i);
            }
        }

        private void btnTongUocSo_Click(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < lstUocSo.Items.Count; i++)
            {
                tong += Convert.ToInt32(lstUocSo.Items[i]);
            }
            MessageBox.Show($"Tổng các ước số là: {tong}", "Thông báo");
        }

        private void btnSoLuongUocChan_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < lstUocSo.Items.Count; i++)
            {
                if (Convert.ToInt32(lstUocSo.Items[i]) % 2 == 0) ++count;
            }
            MessageBox.Show($"Tổng các ước số là: {count}", "Thông báo");
        }

        private bool isPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        private void btnSoLuongUocNguyenTo_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < lstUocSo.Items.Count; i++)
            {
                if (isPrime(Convert.ToInt32(lstUocSo.Items[i]))) ++count;
            }
            MessageBox.Show($"Số lượng các ước số nguyên tố là: {count}", "Thông báo");
        }
    }
}

