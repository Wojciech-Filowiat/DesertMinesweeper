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
    public partial class MainForm : Form
    {

        const int FIELD_SIZE = 14;
        int width;
        int height;
        int maxbombs;
        int bombs;
        bool[,] knownFields;
        bool[,] flags;
        int[,] fields;
        bool gameFinished;
        bool isFirstMove;

        int graphicsStyle;
        Image[] gameGraphics;
        /*Color backColor;
        Color buttonColor;
        Color edgeColor;*/

        public MainForm()
        {
            width = 40;
            height = 40;
            maxbombs = 200;
            bombs = maxbombs;
            gameGraphics = new Image[16];
            
            this.Text = "Minesweeper";
            InitializeComponent();
            
            bombsLabel.TextAlign = ContentAlignment.MiddleCenter;
            newGameButton.FlatStyle = FlatStyle.Flat;
            newGameButton.FlatAppearance.BorderSize = 2;
            restartButton.FlatStyle = FlatStyle.Flat;
            restartButton.FlatAppearance.BorderSize = 2;

            restartButton.TabStop = false;
            newGameButton.TabStop = false;
            ChangeGraphicsStyle(0);

            this.MaximizeBox = false;

            NewGame();
        }

        public void NewGame()
        {
            gameFinished = false;
            isFirstMove = true;
            bombs = maxbombs;
            fields = new int[width, height];
            flags = new bool[width, height];
            knownFields = new bool[width, height];
            Bitmap map = new Bitmap(width * FIELD_SIZE + 3, height * FIELD_SIZE + 3);
            mainBox.Width = width * FIELD_SIZE + 3;
            mainBox.Height = height * FIELD_SIZE + 3;
            panel1.Width = width * FIELD_SIZE + 6;
            panel1.Height = height * FIELD_SIZE + 6;
            if (width * FIELD_SIZE + 20 < 322) { this.Size = new Size(323, height * FIELD_SIZE + 84); }
            else { this.Size = new Size(width * FIELD_SIZE + 21, height * FIELD_SIZE + 84); }

            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(map))
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        g.DrawImage(gameGraphics[1], FIELD_SIZE * i + 3, FIELD_SIZE * j + 3, FIELD_SIZE, FIELD_SIZE);
                    }
                }
            }
            RefreshBombNumber();
            mainBox.Image = (Image)map;
        }

        public void RestartGame()
        {
            gameFinished = false;
            isFirstMove = true;
            bombs = maxbombs;
            Bitmap map = new Bitmap(mainBox.Image);

            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(map))
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (knownFields[i, j] || flags[i, j])
                        {
                            g.DrawImage(gameGraphics[1], FIELD_SIZE * i + 3, FIELD_SIZE * j + 3, FIELD_SIZE, FIELD_SIZE);
                            fields[i, j] = 0;
                        }
                    }
                }
            }
            fields = new int[width, height];
            flags = new bool[width, height];
            knownFields = new bool[width, height];
            RefreshBombNumber();
            mainBox.Image = (Image)map;
        }

        public void ClickedField(int x, int y)
        {
            if (!gameFinished && !flags[x, y])
            {
                if (isFirstMove)
                {
                    fields = Mechanics.GenerateMap(width, height, maxbombs, x, y);
                    isFirstMove = false;
                }
                if (!knownFields[x, y])
                {
                    //knownFields[x, y] = true;

                    if (fields[x, y] == -1)
                    {
                        ShowAllBombs(x, y, false);
                        gameFinished = true;
                    }
                    else
                    {
                        List<int> coords = AddCoords(x, y);
                        Bitmap drawingBitmap = new Bitmap(mainBox.Image);
                        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(drawingBitmap))
                        {
                            for (int i = 0; i < coords.Count(); i += 2)
                            {
                                RedrawField(coords[i], coords[i + 1], g);
                            }
                        }
                        mainBox.Image = (Image)drawingBitmap;
                    }
                }
                if (IsGameWon(x, y))
                {
                    gameFinished = true;
                    ShowAllBombs(-1, -1, true);

                    using (WonGame wform = new WonGame(graphicsStyle))
                    {
                        wform.ShowDialog();
                    }
                }
            }
        }

        public List<int> AddCoords(int x, int y)
        {
            List<int> coords = new List<int>();

            if (!knownFields[x, y])
            {
                coords.Add(x);
                coords.Add(y);

                knownFields[x, y] = true;
                if (fields[x, y] == 0)
                {
                    if (x > 0 && !knownFields[x - 1, y]) { coords.AddRange(AddCoords(x - 1, y)); }
                    if (x < (width - 1) && !knownFields[x + 1, y]) { coords.AddRange(AddCoords(x + 1, y)); }
                    if (y > 0 && !knownFields[x, y - 1]) { coords.AddRange(AddCoords(x, y - 1)); }
                    if (y < (height - 1) && !knownFields[x, y + 1]) { coords.AddRange(AddCoords(x, y + 1)); }
                    if (x > 0 && y > 0 && !knownFields[x - 1, y - 1]) { coords.AddRange(AddCoords(x - 1, y - 1)); }
                    if (x > 0 && y < (height - 1) && !knownFields[x - 1, y + 1]) { coords.AddRange(AddCoords(x - 1, y + 1)); }
                    if (x < (width - 1) && y > 0 && !knownFields[x + 1, y - 1]) { coords.AddRange(AddCoords(x + 1, y - 1)); }
                    if (x < (width - 1) && y < (height - 1) && !knownFields[x + 1, y + 1]) { coords.AddRange(AddCoords(x + 1, y + 1)); }
                }

            }

            return coords;
        }

        public void ClickedFlag(int x, int y)
        {
            if (!gameFinished && !knownFields[x, y])
            {
                if (flags[x, y])
                {
                    bombs++;
                    RefreshBombNumber();
                    flags[x, y] = !flags[x, y];

                    Bitmap drawingBitmap = new Bitmap(mainBox.Image);
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(drawingBitmap))
                    {
                        RedrawField(x, y, g);
                    }
                    mainBox.Image = (Image)drawingBitmap;

                }
                else
                {
                    if (bombs > 0)
                    {
                        bombs--;
                        RefreshBombNumber();
                        flags[x, y] = !flags[x, y];

                        Bitmap drawingBitmap = new Bitmap(mainBox.Image);
                        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(drawingBitmap))
                        {
                            RedrawField(x, y, g);
                        }
                        mainBox.Image = (Image)drawingBitmap;
                    }
                }
            }
        }

        private void mainBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = MouseCoordsToFieldCoords(me.Location);
            if (coordinates.X >= 0 && coordinates.Y >= 0 && coordinates.X < width && coordinates.Y < height)
            {
                if (me.Button == MouseButtons.Left && !gameFinished)
                {
                    ClickedField(coordinates.X, coordinates.Y);
                }
                if (me.Button == MouseButtons.Right && !gameFinished)
                {
                    ClickedFlag(coordinates.X, coordinates.Y);
                }
            }
        }

        private Point MouseCoordsToFieldCoords(Point mouseCoords)
        {
            return new Point(mouseCoords.X / FIELD_SIZE, mouseCoords.Y / FIELD_SIZE);
        }

        private void RedrawField(int x, int y, System.Drawing.Graphics g)
        {
            {
                if (!knownFields[x, y])
                {
                    if (flags[x, y])
                    {
                        g.DrawImage(gameGraphics[4], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);

                    }
                    else
                    {
                        g.DrawImage(gameGraphics[1], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                    }
                }
                else
                {
                    switch (fields[x, y])
                    {
                        case 0:
                            g.DrawImage(gameGraphics[7], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case 1:
                            g.DrawImage(gameGraphics[8], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case 2:
                            g.DrawImage(gameGraphics[9], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case 3:
                            g.DrawImage(gameGraphics[10], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case 4:
                            g.DrawImage(gameGraphics[11], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case 5:
                            g.DrawImage(gameGraphics[12], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case 6:
                            g.DrawImage(gameGraphics[13], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case 7:
                            g.DrawImage(gameGraphics[14], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case 8:
                            g.DrawImage(gameGraphics[15], FIELD_SIZE * x + 3, FIELD_SIZE * y + 3, FIELD_SIZE, FIELD_SIZE);
                            break;
                    }

                }
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            using (NewGameForm lform = new NewGameForm(width, height, maxbombs, graphicsStyle))
            {
                if (lform.ShowDialog() == DialogResult.OK)
                {
                    width = lform.GetWidth;
                    height = lform.GetHeight;
                    maxbombs = lform.GetBombs;
                    int style = lform.GetGraphicsStyle;
                    
                    ChangeGraphicsStyle(style);
                    NewGame();
                }
            }
        }

        private void ShowAllBombs(int x, int y, bool gameFinished)
        {
            Bitmap drawingBitmap = new Bitmap(mainBox.Image);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(drawingBitmap))
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (fields[i, j] == -1)
                        {
                            knownFields[i, j] = true;
                            if (flags[i, j])
                            {
                                g.DrawImage(gameGraphics[3], FIELD_SIZE * i + 3, FIELD_SIZE * j + 3, FIELD_SIZE, FIELD_SIZE); // bomb defused
                            }
                            else
                            {
                                if (x == i && y == j)
                                {
                                    g.DrawImage(gameGraphics[6], FIELD_SIZE * i + 3, FIELD_SIZE * j + 3, FIELD_SIZE, FIELD_SIZE); // bomb red
                                }
                                else
                                {
                                    if (gameFinished)
                                    {
                                        g.DrawImage(gameGraphics[3], FIELD_SIZE * i + 3, FIELD_SIZE * j + 3, FIELD_SIZE, FIELD_SIZE); // bomb defused
                                    }
                                    else
                                    {
                                        g.DrawImage(gameGraphics[2], FIELD_SIZE * i + 3, FIELD_SIZE * j + 3, FIELD_SIZE, FIELD_SIZE); // bomb normal
                                    }

                                }
                            }
                        }
                        else if (flags[i, j])
                        {
                            g.DrawImage(gameGraphics[5], FIELD_SIZE * i + 3, FIELD_SIZE * j + 3, FIELD_SIZE, FIELD_SIZE); // absent bomb at flag
                        }
                    }
                }
            }
            mainBox.Image = (Image)drawingBitmap;
        }

        private void RefreshBombNumber()
        {
            bombsLabel.Text = "Bombs:  " + bombs + "/" + maxbombs;
        }

        private bool IsGameWon(int x, int y)
        {
            if (fields[x, y] == -1)
            {
                return false;
            }
            else
            {
                int unknownField = 0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (!knownFields[i, j]) { unknownField++; }
                    }
                }
                if (unknownField == maxbombs)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ChangeGraphicsStyle(int style)
        {
            graphicsStyle = style;
            Bitmap allImages;
            
            switch (style)
            {
                case 0:
                    allImages = new Bitmap(Properties.Resources.desert);
                    this.Text = "Desert Minesweeper";
                    break;
                case 1:
                    allImages = new Bitmap(Properties.Resources.icefield);
                    this.Text = "Icefield Minesweeper";
                    break;
                case 2:
                    allImages = new Bitmap(Properties.Resources.snowfield);
                    this.Text = "Snowfield Minesweeper";
                    break;
                case 3:
                    allImages = new Bitmap(Properties.Resources.islands);
                    this.Text = "Islands Minesweeper";
                    break;
                case 4:
                    allImages = new Bitmap(Properties.Resources.classic);
                    this.Text = "Classic Minesweeper";
                    break;
                case 5:
                    allImages = new Bitmap(Properties.Resources.ocean);
                    this.Text = "Ocean Minesweeper";
                    break;
                default:
                    allImages = new Bitmap(Properties.Resources.desert);
                break;
            }
            for (int i = 0; i < 4; i++ )
            {
                for (int j = 0; j < 4; j++)
                {
                    gameGraphics[4 * i + j] = allImages.Clone(new Rectangle(j * FIELD_SIZE, i * FIELD_SIZE, FIELD_SIZE, FIELD_SIZE), allImages.PixelFormat);
                }
            }
            this.BackgroundImage = gameGraphics[0];
            RefreshControlsGraphics();


        }

        private void RefreshControlsGraphics()
        {
            switch (graphicsStyle)
            {
                case 0:
                    this.Icon = Properties.Resources.icon_0;
                    break;
                case 1:
                    this.Icon = Properties.Resources.icon_1;
                    break;
                case 2:
                    this.Icon = Properties.Resources.icon_2;
                    break;
                case 3:
                    this.Icon = Properties.Resources.icon_3;
                    break;
                case 4:
                    this.Icon = Properties.Resources.icon_4;
                    break;
                case 5:
                    this.Icon = Properties.Resources.icon_5;
                    break;
            }

            newGameButton.BackColor = ControlsColors.GetButtonColor(graphicsStyle);
            newGameButton.FlatAppearance.BorderColor = ControlsColors.GetEdgeColor(graphicsStyle);
            restartButton.BackColor = ControlsColors.GetButtonColor(graphicsStyle);
            restartButton.FlatAppearance.BorderColor = ControlsColors.GetEdgeColor(graphicsStyle);
            this.BackColor = ControlsColors.GetBackgroundColor(graphicsStyle);
            this.BackgroundImage = gameGraphics[0];


        }


    }
}
