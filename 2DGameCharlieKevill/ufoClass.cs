//Charlie Kevill
//ICS4U
//Mr.T
//Oct 7t, 2021
//2D Game Submission

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DGameCharlieKevill

{
    public class ufoClass
    {
        public int width, x, y, speed;

        public ufoClass(int _width, int _x, int _y, int _speed)

        {
            width = _width;
            x = _x;
            y = _y;
            speed = _speed;
        }

        public void Move(string direction)
        {
            //making the ufos move up and down
            if (direction == "up")
            {
                y -= speed;
            }

            if (direction == "down")
            {
                y += speed;
            }

        }
    }
}
