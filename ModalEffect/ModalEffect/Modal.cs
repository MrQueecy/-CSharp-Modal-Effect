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
    public partial class Modal : Form
    {
        public Modal()
        {
            InitializeComponent();

             this.Activated += new EventHandler(this.ModalLR_Deactivate);
        }

        int targetY;
        private void Modal_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            int centerX = Main.parentX + (Main.parentWidth - this.Width) / 2;
            targetY = Main.parentY + (Main.parentHeight - this.Height) / 2;
            this.Location = new Point(centerX, Main.parentY - this.Height);
            modaleffect.Start();
        }
        
         private void ModalLR_Deactivate(object sender, EventArgs e)
         {
             this.TopMost = true; 
         }
        
        private void modalEffect_Timer_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                Opacity += .03;
            }

            int currentY = this.Location.Y + 3;
            if (currentY >= targetY)
            {
                currentY = targetY;
                modaleffect.Stop();
            }
            this.Location = new Point(this.Location.X, currentY);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
