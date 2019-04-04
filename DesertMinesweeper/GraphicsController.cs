using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DesertMinesweeper
{
    class GraphicsController
    {
        public static Icon GetIcon (GraphicsStyle graphicsStyle)
        {
            switch (graphicsStyle)
            {
                case GraphicsStyle.Desert:
                    return Properties.Resources.icon_0;
                case GraphicsStyle.Icefield:
                    return Properties.Resources.icon_1;
                case GraphicsStyle.Snowfield:
                    return Properties.Resources.icon_2;
                case GraphicsStyle.Islands:
                    return Properties.Resources.icon_3;
                case GraphicsStyle.Classic:
                    return Properties.Resources.icon_4;
                case GraphicsStyle.Ocean:
                    return Properties.Resources.icon_5;
                case GraphicsStyle.Meadow:
                    return Properties.Resources.icon_6;
                default:
                    return Properties.Resources.icon_0;
            }
        }


        public static Image GetBackground(GraphicsStyle graphicsStyle, int fieldSize)
        {
            Bitmap allImages;

            switch (graphicsStyle)
            {
                case GraphicsStyle.Desert:
                    allImages = new Bitmap(Properties.Resources.desert);
                    break;
                case GraphicsStyle.Icefield:
                    allImages = new Bitmap(Properties.Resources.icefield);
                    break;
                case GraphicsStyle.Snowfield:
                    allImages = new Bitmap(Properties.Resources.snowfield);
                    break;
                case GraphicsStyle.Islands:
                    allImages = new Bitmap(Properties.Resources.islands);
                    break;
                case GraphicsStyle.Classic:
                    allImages = new Bitmap(Properties.Resources.classic);
                    break;
                case GraphicsStyle.Ocean:
                    allImages = new Bitmap(Properties.Resources.ocean);
                    break;
                case GraphicsStyle.Meadow:
                    allImages = new Bitmap(Properties.Resources.meadow);
                    break;
                default:
                    allImages = new Bitmap(Properties.Resources.desert);
                    break;
            }
            return allImages.Clone(new Rectangle(0, 0, fieldSize, fieldSize), allImages.PixelFormat);
        }


        public static string GetTitle(GraphicsStyle graphicsStyle)
        {
            return graphicsStyle.ToString() + " Minesweeper";
        }

        public static Bitmap GetAllImages(GraphicsStyle graphicsStyle)
        {
            switch (graphicsStyle)
            {
                case GraphicsStyle.Desert:
                    return new Bitmap(Properties.Resources.desert);
                case GraphicsStyle.Icefield:
                    return new Bitmap(Properties.Resources.icefield);
                case GraphicsStyle.Snowfield:
                    return new Bitmap(Properties.Resources.snowfield);
                case GraphicsStyle.Islands:
                    return new Bitmap(Properties.Resources.islands);
                case GraphicsStyle.Classic:
                    return new Bitmap(Properties.Resources.classic);
                case GraphicsStyle.Ocean:
                    return new Bitmap(Properties.Resources.ocean);
                case GraphicsStyle.Meadow:
                    return new Bitmap(Properties.Resources.meadow);
                default:
                    return new Bitmap(Properties.Resources.desert);
            }
        }

        public static Color GetBackgroundColor(GraphicsStyle graphicsStyle)
        {
            switch (graphicsStyle)
            {
                case GraphicsStyle.Desert:
                    return Color.FromArgb(255, 255, 215, 0);
                case GraphicsStyle.Icefield:
                    return Color.FromArgb(255, 255, 255, 255);
                case GraphicsStyle.Snowfield:
                    return Color.FromArgb(255, 255, 255, 255);
                case GraphicsStyle.Islands:
                    return Color.FromArgb(255, 67, 210, 249);
                case GraphicsStyle.Classic:
                    return Color.FromArgb(255, 230, 230, 230);
                case GraphicsStyle.Ocean:
                    return Color.FromArgb(255, 67, 210, 249);
                case GraphicsStyle.Meadow:
                    return Color.FromArgb(255, 158, 202, 22);
                default:
                    return Color.FromArgb(255, 255, 215, 0);
            }
        }

        public static Color GetButtonColor(GraphicsStyle graphicsStyle)
        {
            switch (graphicsStyle)
            {
                case GraphicsStyle.Desert:
                    return Color.FromArgb(255, 255, 215, 0);
                case GraphicsStyle.Icefield:
                    return Color.FromArgb(255, 153, 217, 234);
                case GraphicsStyle.Snowfield:
                    return Color.FromArgb(255, 255, 255, 255);
                case GraphicsStyle.Islands:
                    return Color.FromArgb(255, 60, 188, 223);
                case GraphicsStyle.Classic:
                    return Color.FromArgb(255, 200, 200, 200);
                case GraphicsStyle.Ocean:
                    return Color.FromArgb(255, 60, 188, 223);
                case GraphicsStyle.Meadow:
                    return Color.FromArgb(255, 158, 202, 22);
                default:
                    return Color.FromArgb(255, 255, 215, 0);
            }
        }

        public static Color GetEdgeColor(GraphicsStyle graphicsStyle)
        {
            switch (graphicsStyle)
            {
                case GraphicsStyle.Desert:
                    return Color.FromArgb(255, 255, 140, 0);
                case GraphicsStyle.Icefield:
                    return Color.FromArgb(255, 0, 162, 232);
                case GraphicsStyle.Snowfield:
                    return Color.FromArgb(255, 163, 224, 239);
                case GraphicsStyle.Islands:
                    return Color.FromArgb(255, 56, 175, 208);
                case GraphicsStyle.Classic:
                    return Color.FromArgb(255, 150, 150, 150);
                case GraphicsStyle.Ocean:
                    return Color.FromArgb(255, 56, 175, 208);
                case GraphicsStyle.Meadow:
                    return Color.FromArgb(255, 127, 163, 18);
                default:
                    return Color.FromArgb(255, 255, 140, 0);
            }
        }
    }
}
