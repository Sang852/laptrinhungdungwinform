namespace Baithuchanh4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private bool checkSo(string so1, string so2)
        {
            if (!so1.All(c => char.IsDigit(c)) || !so2.All(c => char.IsDigit(c)))
            { 
                return false;
            }
            return true;
        }
        private void rdCong_CheckedChanged(object sender, EventArgs e)
        {
            long result = 0;
            if (rdCong.Checked && checkSo(txtSo1.Text, txtSo2.Text))
                result = Convert.ToInt32(txtSo1.Text) + Convert.ToInt32(txtSo2.Text);
            txtKQ.Text = result.ToString();
        }

        private void rdTru_CheckedChanged(object sender, EventArgs e)
        {
            long result = 0;
            if (rdTru.Checked && checkSo(txtSo1.Text, txtSo2.Text))
                result = Convert.ToInt32(txtSo1.Text) - Convert.ToInt32(txtSo2.Text);
            txtKQ.Text = result.ToString();
        }

        private void rdNhan_CheckedChanged(object sender, EventArgs e)
        {
            long result = 0;
            if (rdNhan.Checked && checkSo(txtSo1.Text, txtSo2.Text))
                result = Convert.ToInt32(txtSo1.Text) * Convert.ToInt32(txtSo2.Text);
            txtKQ.Text = result.ToString();
        }

        private void rdChia_CheckedChanged(object sender, EventArgs e)
        {
            double result = 0;
            if (rdChia.Checked && checkSo(txtSo1.Text, txtSo2.Text))
                result = 1.0*Convert.ToInt32(txtSo1.Text)/Convert.ToInt32(txtSo2.Text);
            txtKQ.Text = result.ToString();
        }
    }
}
