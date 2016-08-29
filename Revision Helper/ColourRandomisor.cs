using System.Drawing;
using System;

namespace Revision_Helper
{
    class ColourRandomisor
    {
        public Color colour;

        public ColourRandomisor()
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 6))
            {
                case 1: colour = Color.IndianRed; break;
                case 2: colour = Color.SandyBrown; break;
                case 3: colour = Color.LawnGreen; break;
                case 4: colour = Color.Cyan; break;
                case 5: colour = Color.Violet; break;
                default: break;
            }
        }
    }
}
