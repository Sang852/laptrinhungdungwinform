namespace Baithuchanh5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.rdRed.Checked = true;
        }

        // Khi gõ vào ô txtNhapten thì Label lblLapTrinhchạy song song cùng nội dung.
        private void txtNhap_TextChanged(object sender, EventArgs e)
        {
            lblLapTrinh.Text = txtNhap.Text;
        }

        
        private void rdRed_CheckedChanged(object sender, EventArgs e)
        {
            txtNhap.ForeColor = Color.Red;
            lblLapTrinh.ForeColor = Color.Red;
        }


        private void rdGreen_CheckedChanged(object sender, EventArgs e)
        {
            txtNhap.ForeColor = lblLapTrinh.ForeColor = Color.Green;
        }

        private void rdBlue_CheckedChanged(object sender, EventArgs e)
        {
            txtNhap.ForeColor = lblLapTrinh.ForeColor = Color.Blue;
        }

        private void rdBlack_CheckedChanged(object sender, EventArgs e)
        {
            txtNhap.ForeColor = lblLapTrinh.ForeColor = Color.Black;
        }

       /* Nhấn các checkbox chữ đậm, nghiêng, gạch chân thì đổi style chữ trong ô
        lblLapTrinh và ô txtNhap tương ứng.*/
        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            txtNhap.Font = lblLapTrinh.Font = new Font(lblLapTrinh.Font.Name,
            lblLapTrinh.Font.Size,
                lblLapTrinh.Font.Style ^ FontStyle.Italic);
        }

        private void chkUnderline_CheckedChanged(object sender, EventArgs e)
        {
            txtNhap.Font = lblLapTrinh.Font = new Font(lblLapTrinh.Font.Name,
            lblLapTrinh.Font.Size,
                lblLapTrinh.Font.Style ^ FontStyle.Underline);
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            txtNhap.Font = lblLapTrinh.Font = new Font(lblLapTrinh.Font.Name,
            lblLapTrinh.Font.Size,
                lblLapTrinh.Font.Style ^ FontStyle.Bold);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
