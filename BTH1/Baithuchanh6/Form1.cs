namespace Baithuchanh6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.rtbNhap.ForeColor = Color.Blue;
        }

        private void radTimeNewRoman_CheckedChanged(object sender, EventArgs e)
        {
            rtbNhap.Font = new Font("Time New Roman", 16, FontStyle.Regular);
        }

        private void radArial_CheckedChanged(object sender, EventArgs e)
        {
            rtbNhap.Font = new Font("Arial", 16, FontStyle.Regular);
        }

        private void radTahoma_CheckedChanged(object sender, EventArgs e)
        {
            rtbNhap.Font = new Font("Tahoma", 16, FontStyle.Regular);
        }

        private void radCourierNew_CheckedChanged(object sender, EventArgs e)
        {
            rtbNhap.Font = new Font("Couner New", 16, FontStyle.Regular);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
