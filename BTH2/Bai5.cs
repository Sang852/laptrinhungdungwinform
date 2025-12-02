using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH2
{
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
            dgvDanhSachSinhVien.MultiSelect = false;
        }
        // Yêu cầu đề bài 5

        // Thêm vào các cột cho điều khiển DataGridView khi FormLoad
        private void Bai5_Load(object sender, EventArgs e)
        {
            dgvDanhSachSinhVien.Columns.Add("colMaSinhVien", "Mã sinh viên");
            dgvDanhSachSinhVien.Columns.Add("colHoTen", "Họ tên");
            dgvDanhSachSinhVien.Columns.Add("colQueQuan", "Quê quán");
        }


        // Khi người dùng nhập giá trị vào các điều khiển và nhấn vào button Nhập, đưa thông tin của sinh viên nhập vào trên các
        private void btnNhap_Click(object sender, EventArgs e)
        {
            // Buộc người dùng phải nhập thông tin thì mới có thể thêm dòng
            if (txtHoTen.Text == "" && txtHoTen.Text == "" && txtQueQuan.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            // Thêm dòng
            dgvDanhSachSinhVien.Rows.Add(new string[] { txtMaSinhVien.Text, txtHoTen.Text, txtQueQuan.Text });
            // sau khi thêm dòng thông tin xóa text khỏi textbox
            txtMaSinhVien.Clear();
            txtHoTen.Clear();
            txtQueQuan.Clear();
            txtMaSinhVien.Focus();
        }

        //  Khi người sử dụng chọn một SV trên DataGridView hiển thị thông tin lên các điều khiển tương ứng.
        int hangchon = 0, cotchon = 0;
        private void dgvDanhSachSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hangchon = e.RowIndex;
            cotchon = e.ColumnIndex;
            txtMaSinhVien.Text = dgvDanhSachSinhVien[0, hangchon].Value.ToString();
            txtHoTen.Text = dgvDanhSachSinhVien[1, hangchon].Value.ToString();
            txtQueQuan.Text = dgvDanhSachSinhVien[2, hangchon].Value.ToString();
        }

        //Khi người sử dụng nhấn nút Sửa, sửa thông tin của SV có mã SV bằng mã sinh viên trong điều khiển txtMaSV
        //với các giá trị mới bằng giá trị nhập vào trên các điều khiển textBox.
        private void btnSua_Click(object sender, EventArgs e)
        {
            // mã sinh viên được sửa phải giống với mã sinh viên được chọn
            if (txtMaSinhVien.Text != "")
            {
                for (int row = 0; row < dgvDanhSachSinhVien.Rows.Count - 1; row++)
                {
                    if (txtMaSinhVien.Text == dgvDanhSachSinhVien[0, row].Value.ToString() &&
                        txtHoTen.Text != "" && txtQueQuan.Text != "")
                    {
                        dgvDanhSachSinhVien[1, row].Value = txtHoTen.Text;
                        dgvDanhSachSinhVien[2, row].Value = txtQueQuan.Text;
                        return;
                    }
                }
                //Không tồn tại mã sinh viên
                MessageBox.Show("Mã sinh viên không tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information
                         );

            }
            else
            {
                MessageBox.Show("Mã sinh viên không được để trống!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Khi người sử dụng nhấn button Xoa, xóa SV có mã sinh viên nhập vào điều khiển txtMa
        // trên điều khiển DataGridView.
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSinhVien.Text != "")
            {
                for (int row = 0; row < dgvDanhSachSinhVien.Rows.Count - 1; row++)
                {
                    // tìm mã sinh viên trong cột đầu tiền của datagridview
                    if (txtMaSinhVien.Text == dgvDanhSachSinhVien[0, row].Value.ToString())
                    {
                        dgvDanhSachSinhVien.Rows.RemoveAt(row);
                        return;
                    }
                }
                MessageBox.Show("Mã sinh viên cần xóa không tồn tại!",
                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Mã sinh viên cần xóa không được để trống!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Khi người sử dụng nhấn button Tìm, di truyển con trỏ trong điều khiển DataGridView 
        //đến dòng có mã sinh viên bằng mã sinh viên nhập vào trên điều khiển txtMaSV nếu
        //tìm thấy.
        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtMaSinhVien.Text != "")
            {
                for (int row = 0; row < dgvDanhSachSinhVien.Rows.Count; row++)
                {
                    // tìm mã sinh viên trong cột đầu tiền của datagridview
                    if (txtMaSinhVien.Text == dgvDanhSachSinhVien[0, row].Value.ToString())
                    {
                        dgvDanhSachSinhVien[0, row].Selected = true;
                        return;
                    }
                }
                MessageBox.Show("Mã sinh viên cần tìm không tồn tại",
                           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Mã sinh viên không được để trống!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
