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
    public partial class Bai10 : Form
    {
        public Bai10()
        {
            InitializeComponent();
            this.mtxtPhone.Mask = "000-0000000";
            rtxtQualification.Lines = new string[] { "University", "Master", "Ph D" };
        }


        //Khi nhấn Submit sẽ có một Messagebox hiển thị đầy đủ thông tin vừa nhập. 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string hienThi = $"Employee Name: {txtEmployeeName.Text}\n" +
                $"Date of birth: {mtxtDateOfBirth.Text}\n" +
                $"Adress: {txtAdress.Text}\n" +
                $"City: {rtxtCity.Text}\n" +
                $"Country: {cboCountry.Text}\n" +
                $"Qualification: {rtxtQualification.Text}\n" +
                $"Phone: {mtxtPhone.Text}\n" +
                $"Email: {txtEmail.Text}\n" +
                $"Date of Joinning: {dateTimePicker1.Text}";
            MessageBox.Show(hienThi, "Thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboCountry.SelectedIndex)
            {
                case 0:
                    rtxtCity.Lines = new string[] { "Ho Chi Minh", "Nha Trang", "Ha Noi" };
                    break;
                case 1:
                    rtxtCity.Lines = new string[] { "Pattaya", "ChiengMai", "Bangkok" };
                    break;
            }
        }

        //Khi đang nhập 1 ô mà bỏ trống và focus đến ô khác thì sẽ có thông báo lỗi và cho focus về ô cần nhập.
        
    }
}
