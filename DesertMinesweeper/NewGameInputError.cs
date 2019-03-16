using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesertMinesweeper
{
    public partial class NewGameInputError : Form
    {
        int graphicsStyle;
        const int FIELD_SIZE = 14;

        public NewGameInputError(int errorID, int style)
        {
            InitializeComponent();

            graphicsStyle = style;

            //button1.BackColor = Color.FromArgb(255, 215, 0);
            button1.FlatStyle = FlatStyle.Flat;
            //button1.FlatAppearance.BorderColor = Color.FromArgb(255, 140, 0);
            button1.FlatAppearance.BorderSize = 2;

            this.CenterToParent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            if (errorID == 1)
            {
                label3.Text = "Check field with width.";
                label4.Text = "Only numbers between 2 and 150 allowed.";
            }
            if (errorID == 2)
            {
                label3.Text = "Check field with height.";
                label4.Text = "Only numbers between 2 and 100 allowed.";
            }
            if (errorID == 3)
            {
                label3.Text = "Check field with number of bombs.";
                label4.Text = "Only numbers between 1 and (area-2).";
            }
            SetGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetGraphics()
        {
            button1.BackColor = ControlsColors.GetButtonColor(graphicsStyle);
            button1.FlatAppearance.BorderColor = ControlsColors.GetEdgeColor(graphicsStyle);
            this.BackColor = ControlsColors.GetBackgroundColor(graphicsStyle);

            Bitmap allImages;
            switch (graphicsStyle)
            {
                case 0:
                    allImages = new Bitmap(Properties.Resources.desert);
                    this.Icon = Properties.Resources.icon_0;
                    break;
                case 1:
                    allImages = new Bitmap(Properties.Resources.icefield);
                    this.Icon = Properties.Resources.icon_1;
                    break;
                case 2:
                    allImages = new Bitmap(Properties.Resources.snowfield);
                    this.Icon = Properties.Resources.icon_2;
                    break;
                case 3:
                    allImages = new Bitmap(Properties.Resources.islands);
                    this.Icon = Properties.Resources.icon_3;
                    break;
                case 4:
                    allImages = new Bitmap(Properties.Resources.classic);
                    this.Icon = Properties.Resources.icon_4;
                    break;
                case 5:
                    allImages = new Bitmap(Properties.Resources.ocean);
                    this.Icon = Properties.Resources.icon_5;
                    break;
                default:
                    allImages = new Bitmap(Properties.Resources.desert);
                    this.Icon = Properties.Resources.icon_0;
                    break;
            }
            this.BackgroundImage = allImages.Clone(new Rectangle(0, 0, FIELD_SIZE, FIELD_SIZE), allImages.PixelFormat);
        }
    }
}
