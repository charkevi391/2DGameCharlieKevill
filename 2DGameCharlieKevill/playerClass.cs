using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameCharlieKevill
{
    public class playerClass
    {
        public int x, y, width, height, speed;

        public playerClass(int _x, int _y, int _width, int _height, int _speed)
            
        {
            x = _x;
            y = _y;  
            width = _width;
            height = _height;
            speed = _speed;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= speed;
            }

            if (direction == "right")
            {
                x += speed; 
            }

        }
    }
}
