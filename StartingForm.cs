using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetTruyen
{
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void btnWebTruyen_Click(object sender, EventArgs e)
        {
            fMain fMain = new fMain();
            fMain.Show();
            this.Hide();
        }

        private void btnFaceBook_Click(object sender, EventArgs e)
        {
            fFBDownloader fFBDownloader = new fFBDownloader();
            fFBDownloader.Show();
            this.Hide();
        }
    }
}
