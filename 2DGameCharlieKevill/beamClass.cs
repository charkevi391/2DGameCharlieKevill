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
    public class beamClass
    {
        public int x, y, width;
        public beamClass(int _x, int _y, int _width)

        {
            width = _width;
            x = _x;
            y = _y;
        }
       
    
        public bool Collision(playerClass newPlayer)
        {
            Rectangle playerRect = new Rectangle(newPlayer.x, newPlayer.y, newPlayer.width, newPlayer.height);
            Rectangle beamRect = new Rectangle(x, y, width, 500);
            //checking for collision
            return beamRect.IntersectsWith(playerRect);
        }
    }
}
