using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finalc_
{
    public partial class ButtonWorkPls : PictureBox
    {
        public ButtonWorkPls() //whole hover over pic feature 
        {
            InitializeComponent();
        }

        private Image NormalImage;
        private Image HoverImage;

        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }
        }

        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }

        private void ButtonWorkPls_MouseHover(object sender, EventArgs e)
        {
            this.Image = HoverImage; //hover image func
        }

        private void ButtonWorkPls_MouseLeave(object sender, EventArgs e)
        {
            this.Image = NormalImage;
        }
    }
}
