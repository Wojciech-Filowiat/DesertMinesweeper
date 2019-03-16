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
    public partial class WonGame : Form
    {


        int graphicsStyle;
        const int FIELD_SIZE = 14;

        public WonGame(int style)
        {
            InitializeComponent();

            graphicsStyle = style;

            button1.BackColor = Color.FromArgb(255, 215, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.FromArgb(255, 140, 0);
            button1.FlatAppearance.BorderSize = 2;

            this.Text = "Congratulations";
            this.CenterToParent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

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
