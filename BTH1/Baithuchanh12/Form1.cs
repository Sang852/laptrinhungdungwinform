using System.Globalization;
using System.Security.Cryptography.Pkcs;

namespace Baithuchanh12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtManHinh.ReadOnly = true;
            txtManHinh.TextAlign = HorizontalAlignment.Right;
            txtManHinh.Text = "0";
        }

        double result = 0;
        string operation = "";
        bool enter_value = false;
        private void button_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            string numText = num.Text;
            if (enter_value || txtManHinh.Text == "0")
            {
                txtManHinh.Text = "";
            }

            if (numText == ".")
            {
                if (enter_value)
                {
                    txtManHinh.Text = "0";
                }
                if (!txtManHinh.Text.Contains("."))
                {
                    if (txtManHinh.Text == "") txtManHinh.Text = "0";
                    txtManHinh.Text = txtManHinh.Text + numText;
                }
            }
            else
            {
                txtManHinh.Text = txtManHinh.Text + numText;
            }

            enter_value = false;
        }

        private void btnAmDuong_Click(object sender, EventArgs e)
        {
            double a;
            a = double.Parse(txtManHinh.Text) * (-1.0);
            txtManHinh.Text = a.ToString();
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (!enter_value)
            {
                if (!string.IsNullOrEmpty(operation))
                {
                    ComputeResult();
                }
                else
                {
                    double.TryParse(txtManHinh.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
                }
            }

            operation = num.Text;
            enter_value = true;
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(operation))
            {
                return;
            }

            ComputeResult();
            operation = "";
            enter_value = true;
        }
        private void ComputeResult()
        {
            if (!double.TryParse(txtManHinh.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double second))
            {
                second = 0;
            }

            double computation = result;

            switch (operation)
            {
                case "+":
                    computation = result + second;
                    break;
                case "-":
                    computation = result - second;
                    break;
                case "*":
                    computation = result * second;
                    break;
                case "/":
                    if (second == 0)
                    {
                        MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtManHinh.Text = "0";
                        result = 0;
                        operation = "";
                        enter_value = true;
                        return;
                    }
                    computation = result / second;
                    break;
            }

            result = computation;
            txtManHinh.Text = result.ToString(CultureInfo.InvariantCulture);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtManHinh.Text = "0";
            result = 0;
            operation = "";
            enter_value = false;
        }
    }
}

