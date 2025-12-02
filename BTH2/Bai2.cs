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
    public partial class Bai2 : Form
    {
        /*
            Normal – Ảnh gốc, không thay đổi
            StretchImage – Co giãn cho vừa khung
            Zoom – Giữ tỷ lệ ảnh, không méo (⭐ dùng nhiều)
            CenterImage – Căn giữa
            AutoSize – PictureBox tự phóng to theo ảnh
         */
        public Bai2()
        {
            InitializeComponent();
            picCo.SizeMode = PictureBoxSizeMode.StretchImage; // kéo vừa khung
        }

        private void radVietNam_CheckedChanged(object sender, EventArgs e)
        {
            picCo.ImageLocation = @"C:\GitHubRepoWinform\BTH2\bin\Debug\Co\radVietNam.png";
            picCo.Load();
        }

        private void radUSA_CheckedChanged(object sender, EventArgs e)
        {
            picCo.ImageLocation = @"C:\GitHubRepoWinform\BTH2\bin\Debug\Co\radUSA.png";
            picCo.Load();
        }

        private void radItalian_CheckedChanged(object sender, EventArgs e)
        {
            picCo.ImageLocation = @"C:\GitHubRepoWinform\BTH2\bin\Debug\Co\radItalian.png";
            picCo.Load();
        }

        private void rad_CheckedChanged(object sender, EventArgs e)
        {
            picCo.ImageLocation = @"C:\GitHubRepoWinform\BTH2\bin\Debug\Co\radPhilippine.png";
            picCo.Load();
        }
    }
}
