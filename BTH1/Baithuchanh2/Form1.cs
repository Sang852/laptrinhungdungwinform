namespace Baithuchanh2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnKQ_Click(object sender, EventArgs e)
        {
            string hoTen = this.txtHoTen.Text.Trim();
            if (radChuThuong.Checked)
                txtKQ.Text = hoTen.ToLower();
            else if (radChuInHoa.Checked)
                txtKQ.Text = hoTen.ToUpper();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.txtHoTen.Clear();
            this.txtKQ.Clear();
            this.radChuThuong.Checked = true;
            this.txtHoTen.Focus();
        }
    }
}
