using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DesertMinesweeper
{
    class ControlsColors
    {
        public static Color GetBackgroundColor(int graphicsStyle)
        {
            switch (graphicsStyle)
            {
                case 0:
                    return Color.FromArgb(255, 255, 215, 0);
                case 1:
                    return Color.FromArgb(255, 255, 255, 255);
                case 2:
                    return Color.FromArgb(255, 255, 255, 255);
                case 3:
                    return Color.FromArgb(255, 115, 194, 251);
                case 4:
                    return Color.FromArgb(255, 220, 220, 220);
                case 5:
                    return Color.FromArgb(255, 115, 194, 251);
                case 6:
                    return Color.FromArgb(255, 166, 213, 23);
                default:
                    return Color.FromArgb(255, 255, 215, 0);
            }
        }

        public static Color GetButtonColor(int graphicsStyle)
        {
            switch (graphicsStyle)
            {
                case 0:
                    return Color.FromArgb(255, 255, 215, 0);
                case 1:
                    return Color.FromArgb(255, 153, 217, 234);
                case 2:
                    return Color.FromArgb(255, 255, 255, 255);
                case 3:
                    return Color.FromArgb(255, 255, 242, 0);
                case 4:
                    return Color.FromArgb(255, 200, 200, 200);
                case 5:
                    return Color.FromArgb(255, 5, 138, 238);
                case 6:
                    return Color.FromArgb(255, 255, 242, 0);
                default:
                    return Color.FromArgb(255, 255, 215, 0);
            }
        }

        public static Color GetEdgeColor(int graphicsStyle)
        {
            switch (graphicsStyle)
            {
                case 0:
                    return Color.FromArgb(255, 255, 140, 0);
                case 1:
                    return Color.FromArgb(255, 0, 162, 232);
                case 2:
                    return Color.FromArgb(255, 163, 224, 239);
                case 3:
                    return Color.FromArgb(255, 255, 201, 14);
                case 4:
                    return Color.FromArgb(255, 150, 150, 150);
                case 5:
                    return Color.FromArgb(255, 4, 117, 200);
                case 6:
                    return Color.FromArgb(255, 255, 224, 16);
                default:
                    return Color.FromArgb(255, 255, 140, 0);
            }
        }


    }
}
