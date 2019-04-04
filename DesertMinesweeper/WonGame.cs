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

        GraphicsStyle graphicsStyle;
        const int FIELD_SIZE = 14;

        public WonGame(GraphicsStyle style)
        {
            InitializeComponent();

            graphicsStyle = style;
            button1.FlatStyle = FlatStyle.Flat;
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
            button1.BackColor = GraphicsController.GetButtonColor(graphicsStyle);
            button1.FlatAppearance.BorderColor = GraphicsController.GetEdgeColor(graphicsStyle);
            this.BackColor = GraphicsController.GetBackgroundColor(graphicsStyle);
            this.Icon = GraphicsController.GetIcon(graphicsStyle);
            this.BackgroundImage = GraphicsController.GetBackground(graphicsStyle, FIELD_SIZE);
        }
    }
}

