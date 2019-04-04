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
        GraphicsStyle graphicsStyle;
        const int FIELD_SIZE = 14;

        public NewGameForm(int wid, int hei, int bom, GraphicsStyle style)
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
            comboBox1.SelectedIndex = (int)style;
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

        public GraphicsStyle GetGraphicsStyle
        {
            get { return (GraphicsStyle)comboBox1.SelectedIndex; }
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
            graphicsStyle = (GraphicsStyle)comboBox1.SelectedIndex;
            this.ActiveControl = null;
            SetGraphics();
        }

        private void SetGraphics()
        {
            button1.BackColor = GraphicsController.GetButtonColor(graphicsStyle);
            button1.FlatAppearance.BorderColor = GraphicsController.GetEdgeColor(graphicsStyle);
            widthBox.BackColor = GraphicsController.GetBackgroundColor(graphicsStyle);
            heightBox.BackColor = GraphicsController.GetBackgroundColor(graphicsStyle);
            bombsBox.BackColor = GraphicsController.GetBackgroundColor(graphicsStyle);
            comboBox1.BackColor = GraphicsController.GetBackgroundColor(graphicsStyle);
            this.BackColor = GraphicsController.GetBackgroundColor(graphicsStyle);
            this.Icon = GraphicsController.GetIcon(graphicsStyle);
            this.BackgroundImage = GraphicsController.GetBackground(graphicsStyle, FIELD_SIZE);
        }
    }
}
