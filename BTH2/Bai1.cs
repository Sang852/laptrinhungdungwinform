namespace BTH2
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private int i = 20;
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblDongHo.Text = i.ToString();
            --i;
            if (i < 0)
            {
                this.timer1.Enabled = false;
                this.lblDongHo.Text = "Hết giờ!";
            }
        }
    }
}
