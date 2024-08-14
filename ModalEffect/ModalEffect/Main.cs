using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModalEffect
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        public static int parentX, parentY, parentWidth, parentHeight;
        private void button1_Click(object sender, EventArgs e)
        {
            Form modalsettings = new Form();
            modalsettings.StartPosition = FormStartPosition.Manual;
            modalsettings.FormBorderStyle = FormBorderStyle.None;
            modalsettings.Opacity = 0.5;
            modalsettings.BackColor = Color.Black;
            modalsettings.Size = this.Size;
            modalsettings.Location = this.Location;
            modalsettings.ShowInTaskbar = false;

            parentX = this.Location.X;
            parentY = this.Location.Y;
            parentWidth = this.Width;
            parentHeight = this.Height;
            modalsettings.Show();

            using (Modal modal = new Modal())
            {
                modal.Owner = modalsettings;
                modal.ShowDialog();
            }

            modalsettings.Dispose();
        }
    }
}
