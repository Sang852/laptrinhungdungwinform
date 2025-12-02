using Microsoft.VisualBasic.Logging;
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
    public partial class Bai7 : Form
    {
        public Bai7()
        {
            InitializeComponent();
        }

        //Khi Form hiện lên, Treeview hiển thị danh sách các lớp – sinh viên như hình, chưa có nút 
        //nào được chọn.Con trỏ đặt tại ô Nhập tên.
        void createTreeView()
        {
            trvKhoa.Nodes.Clear();

            TreeNode khoa = new TreeNode("Khoa Tin Học");

            TreeNode lopA = new TreeNode("THTH5A");
            lopA.Nodes.Add(new TreeNode("Nguyen van Tuan"));
            lopA.Nodes.Add(new TreeNode("Nguyen thi Lan"));
            lopA.Nodes.Add(new TreeNode("Nguyen van Luong"));

            TreeNode lopB = new TreeNode("THTH5B");
            lopB.Nodes.Add(new TreeNode("Le Nghiep"));
            lopB.Nodes.Add(new TreeNode("Tran Long"));
            lopB.Nodes.Add(new TreeNode("Ly Anh Tuyet"));

            TreeNode lopC = new TreeNode("THTH5C");
            lopC.Nodes.Add(new TreeNode("Le Trung"));
            lopC.Nodes.Add(new TreeNode("Ton Thi Mai"));
            lopC.Nodes.Add(new TreeNode("Tran Minh"));

            khoa.Nodes.Add(lopA);
            khoa.Nodes.Add(lopB);
            khoa.Nodes.Add(lopC);

            trvKhoa.Nodes.Add(khoa);
            trvKhoa.ExpandAll();

            txtTim.Focus();
        }
        void createListView()
        {
            lvwSinhVien.Columns.Add("Tên SV", 200);
            lvwSinhVien.Columns.Add("Lớp", 200);
            lvwSinhVien.View = View.Details;
            lvwSinhVien.GridLines = true;
        }

        private void Bai7_Load(object sender, EventArgs e)
        {
            createTreeView();
            createListView();
        }
        // Phương thức đổ dữ liệu vào listView
        private void ListView_Load(List<SinhVien> listSV)
        {
            lvwSinhVien.Items.Clear();
            foreach (var sinhvien in listSV)
            {
                ListViewItem item = new ListViewItem(new string[] { sinhvien.Ten, sinhvien.Lop });
                lvwSinhVien.Items.Add(item);
            }
        }

        // Lấy sinh viên trong trong khoa
        private List<SinhVien> LaySinhVienToanKhoa(TreeNode khoaNode)
        {
            List<SinhVien> dssv = new List<SinhVien>();
            foreach (TreeNode lopNode in khoaNode.Nodes)
            {
                dssv.AddRange(LaySinhVienTrongLop(lopNode));
            }
            return dssv;
        }
        // Lấy sinh viên trong lớp
        private List<SinhVien> LaySinhVienTrongLop(TreeNode lopNode)
        {
            List<SinhVien> dssv = new List<SinhVien>();
            foreach (TreeNode svNode in lopNode.Nodes)
            {
                dssv.Add(new SinhVien(svNode.Text, svNode.Parent.Text));
            }
            return dssv;
        }



        private void trvKhoa_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            List<SinhVien> ds = new List<SinhVien>();
            if (node.Level == 0)
            {
                ds = LaySinhVienToanKhoa(node);
                ListView_Load(ds);
                ds.Clear();
            }
            else if (node.Level == 1)
            {
                ds = LaySinhVienTrongLop(node);
                ListView_Load(ds);
                ds.Clear();
            }
            else if (node.Level == 2)
            {
                string ten = node.Text;
                string lop = node.Parent.Text;
                ds.Add(new SinhVien(ten, lop));
                ListView_Load(ds);
                ds.Clear();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string key = txtTim.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(key)) return;

            List<SinhVien> ds = new List<SinhVien>();
            TreeNode node = trvKhoa.SelectedNode;
            if (node.Level == 0) ds = LaySinhVienToanKhoa(node);
            else if (node.Level == 1) ds = LaySinhVienTrongLop(node);
            else if(node.Level == 2)
            {
                string ten = node.Text.ToLower();
                if (ten.Contains(key)) ds.Add(new SinhVien(ten, node.Parent.Text));
            }

            var kq = ds.Where(s => s.Ten.ToLower().Contains(key)).ToList();
            ListView_Load(kq);
            ds.Clear();

        }
    }
}
