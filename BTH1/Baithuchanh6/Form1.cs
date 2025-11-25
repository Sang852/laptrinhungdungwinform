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
            if(radTimeNewRoman.Checked)
                rtbNhap.Font = new Font(radTimeNewRoman.Text, 16, FontStyle.Regular);
        }

        private void radArial_CheckedChanged(object sender, EventArgs e)
        {
            if(radArial.Checked)
                rtbNhap.Font = new Font(radArial.Text, 16, FontStyle.Regular);
        }

        private void radTahoma_CheckedChanged(object sender, EventArgs e)
        {
            if(radTahoma.Checked)
            rtbNhap.Font = new Font(radTahoma.Text, 16, FontStyle.Regular);
        }

        private void radCourierNew_CheckedChanged(object sender, EventArgs e)
        {
            if(radCourierNew.Checked)
                rtbNhap.Font = new Font(radCourierNew.Text, 16, FontStyle.Regular);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
