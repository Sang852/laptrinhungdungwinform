namespace Baithuchanh11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            string hocky = "";
            if (radHocKy1.Checked) hocky = radHocKy1.Text;
            else if (radHocKy2.Checked) hocky = radHocKy2.Text;
            else if (radHocKy3.Checked) hocky = radHocKy3.Text;
            else if (radHocKy4.Checked) hocky = radHocKy4.Text;

            // Lấy ra những môn học đã được chọn
            List<string> dsmonhoc = clbMonHoc.CheckedItems
                                            .Cast<object>()
                                            .Select(x => x.ToString()).ToList();
            string monhoc;
            if (dsmonhoc.Count > 0)
            {
                monhoc = string.Join(Environment.NewLine, dsmonhoc.Select((s, i) => $"{i + 1}. {s}"));
            }
            else
            {
                monhoc = "(không có)";
            }
            // Lấy ra niên khóa
            MessageBox.Show(
                    $"Sinh viên: {txtHoVaTen.Text}\n" +
                    $"Lớp: {cboLop.Text}\n" +
                    $"Niên khóa: {cboNienKhoa.Text}\n" +
                    $"Đã đăng ký học: Học kỳ " + hocky + " Các môn học sau:\n" +
                    $"{monhoc}",
                    "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information
                );   
        }

        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtHoVaTen.Clear();
            cboLop.SelectedIndex = -1;
            cboNienKhoa.SelectedIndex = -1;
            cboLop.Text = string.Empty;
            cboNienKhoa.Text = string.Empty;
            radHocKy1.Checked = false;
            radHocKy2.Checked = false;
            radHocKy3.Checked = false;
            radHocKy4.Checked = false;
            for(int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                clbMonHoc.SetItemChecked(i, false);
            }
            txtMSSV.Focus();
        }
    }
}
