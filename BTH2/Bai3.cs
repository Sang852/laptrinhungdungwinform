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
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(new string[] { txtLastName.Text, txtFirstName.Text, txtPhone.Text });
            lvDetail.Items.Add(item);
        }

        

        private void bậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lvDetail.GridLines = true;
        }

        private void tắtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lvDetail.GridLines = false;
        }
    }
}
