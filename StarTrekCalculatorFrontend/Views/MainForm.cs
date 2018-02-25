using System;
using System.Windows.Forms;

namespace DoenaSoft.STC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnWarpButtonClick(Object sender
            , EventArgs e)
        {
            using (Warp warp = new Warp())
            {
                warp.ShowDialog();
            }
        }

        private void OnStardateButtonClick(Object sender
            , EventArgs e)
        {
            using (Stardate stardate = new Stardate())
            {
                stardate.ShowDialog();
            }
        }
    }
}