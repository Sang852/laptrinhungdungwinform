using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH2
{
    public partial class Bai6 : Form
    {
        public Bai6()
        {
            InitializeComponent();
        }

        // Khi chương trình vừa hiển thị, Treeview chứa tất cả các chữ cái từ A->Z.
        private void Bai6_Load(object sender, EventArgs e)
        {
            for (int i = 65; i <= 90; i++)
            {
                string kt = ((char)i).ToString();
                trvChuCai.Nodes.Add(kt, kt);
            }
        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            string key = txtLastName.Text.Trim()[0].ToString();
            trvChuCai.Nodes[key].Nodes.Add(txtFirstName.Text + ", " + txtLastName.Text);

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }
    }
}
