using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceEnvader.HelpClasses
{
    public struct Size
    {
        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

         int width;
        public int Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    width = 0;
                }
                else
                    width = value;
            }
        }

        int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    height = 0;
                }
                else
                    height = value;
            }
        }

        
    }
}
