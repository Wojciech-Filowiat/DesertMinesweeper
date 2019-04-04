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
        GraphicsStyle graphicsStyle;
        const int FIELD_SIZE = 14;

        public NewGameInputError(int errorID, GraphicsStyle style)
        {
            InitializeComponent();

            graphicsStyle = style;
            button1.FlatStyle = FlatStyle.Flat;
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
            button1.BackColor = GraphicsController.GetButtonColor(graphicsStyle);
            button1.FlatAppearance.BorderColor = GraphicsController.GetEdgeColor(graphicsStyle);
            this.BackColor = GraphicsController.GetBackgroundColor(graphicsStyle);
            this.Icon = GraphicsController.GetIcon(graphicsStyle);
            this.BackgroundImage = GraphicsController.GetBackground(graphicsStyle, FIELD_SIZE);
        }
    }
}
