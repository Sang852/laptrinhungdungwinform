using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTH2
{
    public partial class Bai8 : Form
    {
        public Bai8()
        {
            InitializeComponent();
        }

        //Khi Form hiện lên, đã có sẵn 1 số lớp trong danh sách lớp ở Treeview.
        private void createTreeView()
        {

            trvSinhVien.Nodes.Clear();
            //trvSinhVien.Nodes.Add("Danh sách lớp");
            //trvSinhVien.Nodes[0].Nodes.Add("ncth3ka", "NCTH3KA");
            //trvSinhVien.Nodes[0].Nodes["ncth3ka"].Nodes.Add("9912578-Nguyen van A").Nodes.Add("Đồng Nai");
            //trvSinhVien.Nodes[0].Nodes.Add("ncth3kb", "NCTH3KB");
            //trvSinhVien.Nodes[0].Nodes.Add("cdth11k", "CDTH11K");
            trvSinhVien.Nodes.Add("Danh sách lớp");
            TreeNode lopNCTH3KA = new TreeNode("NCTH3KA");
            ThongTinSinhVien sv = new ThongTinSinhVien("9912578", "Nguyen van A", "Đồng Nai");
            TreeNode nodeSV = new TreeNode(sv.ToString());
            nodeSV.Tag = sv;
            TreeNode queQuan = new TreeNode(sv.QueQuan);
            nodeSV.Nodes.Add(queQuan);
            lopNCTH3KA.Nodes.Add(nodeSV);

            TreeNode lopNCTH3KB = new TreeNode("NCTH3KB");
            TreeNode lopCDTH11K = new TreeNode("CDTH11K");

            trvSinhVien.Nodes.Add(lopNCTH3KA);
            trvSinhVien.Nodes.Add(lopNCTH3KB);
            trvSinhVien.Nodes.Add(lopCDTH11K);
           

            trvSinhVien.ExpandAll();
            txtMaSV.Focus();
        }
        private void Bai8_Load(object sender, EventArgs e)
        {
            createTreeView();
        }




        /* Nút Cập Nhật: Thêm 1 SV vào lớp đang chọn trên Treeview với nội dung các nút như
         hình.Trước khi thêm phải kiểm tra thông tin nhập gồm: các ô nhập không được để trống, không
         được trùng mã SV.Ngoài ra còn phải kiểm tra nút chọn trên Treeview có phải là nút lớp không
         (chỉ được thêm vào nút lớp).*/



        // Phương thức kiểm tra tính duy nhất của mã sinh viên
        //private bool KiemTraMaSV(string maSV)
        //{
        //    if (maSV == "") return false;
        //    for (int i = 0; i < trvSinhVien.Nodes[0].Nodes.Count; i++) // duyệt lớp
        //    {
        //        for (int j = 0; j < trvSinhVien.Nodes[0].Nodes[i].Nodes.Count; j++) // duyệt sinh viên
        //        {
        //            // lấy chuỗi text của node sinhvien
        //            string[] masv = trvSinhVien.Nodes[0].Nodes[i].Nodes[j].Text.Split('-');
        //            if (masv[0] == maSV) return false;
        //        }
        //    }
        //    return true;
        //}

        private bool MaSVTonTai(string maSV)
        {
            foreach (TreeNode lopNode in trvSinhVien.Nodes[0].Nodes)
            {
                foreach (TreeNode svNode in lopNode.Nodes)
                {
                    ThongTinSinhVien sv = svNode.Tag as ThongTinSinhVien;
                    if (sv != null && sv.MaSV == maSV) return true;
                }
            }
            return false;
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Thêm 1 sinh viên vào lớp đang chọn
            // kiểm tra trc khi thêm: các ô nhập != rỗng && mã sinh viên là duy nhất && nút chọn có bằng nút lớp hay không
            if (trvSinhVien.SelectedNode.Level != 1)
            {
                MessageBox.Show("Vui lòng chọn lớp cần thêm thông tin sinh viên!", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information
                   );
                return;
            }
            if ((txtQueQuan.Text == "" || txtMaSV.Text == "" || txtHoTen.Text == ""))
            {
                MessageBox.Show("Thông tin sinh viên không được để trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                return;
            }

            if (MaSVTonTai(txtMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning
                   );
                return;
            }
            //else
            //{

            //    for (int i = 0; i < trvSinhVien.Nodes[0].Nodes.Count; i++) // lớp
            //    {
            //        TreeNode nodeLop = trvSinhVien.Nodes[0].Nodes[i]; // các lớp
            //        if (nodeLop.IsSelected) // lớp được chọn
            //        {
            //            TreeNode nodeSV = new TreeNode(txtMaSV.Text + "-" + txtHoTen.Text);
            //            nodeSV.Nodes.Add(txtQueQuan.Text);
            //            trvSinhVien.Nodes[0].Nodes[i].Nodes.Add(nodeSV);
            //            break;
            //        }
            //    }
            //    txtMaSV.Clear();
            //    txtHoTen.Clear();
            //    txtQueQuan.Clear();
            //    txtMaSV.Focus();
            //}
            ThongTinSinhVien sv = new ThongTinSinhVien(txtMaSV.Text, txtHoTen.Text, txtQueQuan.Text);

            TreeNode nodeSV = new TreeNode(sv.ToString());
            nodeSV.Tag = sv;
            nodeSV.Nodes.Add(new TreeNode(txtQueQuan.Text));

            trvSinhVien.SelectedNode.Nodes.Add(nodeSV);
            trvSinhVien.SelectedNode.Expand();

            txtMaSV.Clear();
            txtHoTen.Clear();
            txtQueQuan.Clear();
            txtMaSV.Focus();

        }

        //Nút Xóa: cho phép xóa nút đang chọn trong Treeview, phải xác nhận lại trước khi xoá và chỉ được xoá khi chọn nút chứa mã SV.
        private void btnXoa_Click(object sender, EventArgs e)
        {
            TreeNode node = trvSinhVien.SelectedNode;
            if (trvSinhVien.SelectedNode.Level != 2)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning
                  );
                return;
            }
            //for(int i = 0; i < trvSinhVien.Nodes[0].Nodes.Count; i++)
            //{
            //    TreeNode nodeLop = trvSinhVien.Nodes[0].Nodes[i];
            //    for(int j = 0; j < trvSinhVien.Nodes[0].Nodes[i].Nodes.Count; j++)
            //    {
            //        string[] masv = nodeLop.Nodes[j].Text.Split('-');
            //        if (nodeLop.Nodes[j].IsSelected && !KiemTraMaSV(masv[0]))
            //        {
            //            nodeLop.Nodes.Remove(nodeLop.Nodes[j]);
            //            return;
            //        }
            //    }
            //}
            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                node.Remove();
            }
        }

        // Khi click chọn nút mã SV hoặc địa chỉ thì hiện thông tin sv đó qua các Textbox. 
        private void trvSinhVien_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ThongTinSinhVien sv = e.Node.Tag as ThongTinSinhVien;

            if (sv != null)
            {
                txtMaSV.Text = sv.MaSV;
                txtHoTen.Text = sv.HoTen;
                txtQueQuan.Text = sv.QueQuan;
            }
            else
            {
                // Nếu chọn node lớp, hoặc node không phải sinh viên thì xóa xoá textbox
                txtMaSV.Clear();
                txtHoTen.Clear();
                txtQueQuan.Clear();
            }
        }
    }
}
