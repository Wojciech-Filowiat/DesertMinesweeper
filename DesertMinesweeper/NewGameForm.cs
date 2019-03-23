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
    public partial class NewGameForm : Form
    {
        int graphicsStyle;
        const int FIELD_SIZE = 14;

        public NewGameForm(int wid, int hei, int bom, int style)
        {
            InitializeComponent();

            graphicsStyle = style;

            widthBox.Text = wid.ToString();
            heightBox.Text = hei.ToString();
            bombsBox.Text = bom.ToString();
           
            comboBox1.Items.Add("Desert");
            comboBox1.Items.Add("Icefield");
            comboBox1.Items.Add("Snowfield");
            comboBox1.Items.Add("Islands");
            comboBox1.Items.Add("Classic");
            comboBox1.Items.Add("Ocean");
            comboBox1.Items.Add("Meadow");
            comboBox1.SelectedIndex = style;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 2;
            SetGraphics();

            this.CenterToParent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public int GetWidth
        {
            get { return Convert.ToInt32(widthBox.Text); }
        }

        public int GetHeight
        {
            get { return Convert.ToInt32(heightBox.Text); }
        }

        public int GetBombs
        {
            get { return Convert.ToInt32(bombsBox.Text); }
        }

        public int GetGraphicsStyle
        {
            get { return comboBox1.SelectedIndex; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int errorID = -1;

            if (!IsWidthLegit())
            {
                errorID = 1;
            }
            else
            {
                if (!IsHeightLegit())
                {
                    errorID = 2;
                }
                else
                {
                    if (!IsBombsNumberLegit())
                    {
                        errorID = 3;
                    }
                }
            }

            if (errorID == -1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                using (NewGameInputError eform = new NewGameInputError(errorID, graphicsStyle))
                {
                    eform.ShowDialog();
                }
            }
        }

        private bool IsWidthLegit()
        {
            if (!(widthBox.Text).All(char.IsDigit))
            {
                return false;
            }
            int width = Convert.ToInt32(widthBox.Text);
            if (width < 1 || width > 150)
            {
                return false;
            }
            return true;
        }

        private bool IsHeightLegit()
        {
            if (!(heightBox.Text).All(char.IsDigit))
            {
                return false;
            }
            int height = Convert.ToInt32(heightBox.Text);
            if (height < 1 || height > 100)
            {
                return false;
            }
            return true;
        }

        private bool IsBombsNumberLegit()
        {
            if (!(bombsBox.Text).All(char.IsDigit))
            {
                return false;
            }
            int width = Convert.ToInt32(widthBox.Text);
            int height = Convert.ToInt32(heightBox.Text);
            int bombs = Convert.ToInt32(bombsBox.Text);

            if (bombs < 1 || bombs > (width * height - 2))
            {
                return false;
            }
            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphicsStyle = comboBox1.SelectedIndex;
            this.ActiveControl = null;
            SetGraphics();
        }

        private void SetGraphics()
        {
            button1.BackColor = ControlsColors.GetButtonColor(graphicsStyle);
            button1.FlatAppearance.BorderColor = ControlsColors.GetEdgeColor(graphicsStyle);
            widthBox.BackColor = ControlsColors.GetBackgroundColor(graphicsStyle);
            heightBox.BackColor = ControlsColors.GetBackgroundColor(graphicsStyle);
            bombsBox.BackColor = ControlsColors.GetBackgroundColor(graphicsStyle);
            comboBox1.BackColor = ControlsColors.GetBackgroundColor(graphicsStyle);
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
                case 6:
                    allImages = new Bitmap(Properties.Resources.meadow);
                    this.Icon = Properties.Resources.icon_6;
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
