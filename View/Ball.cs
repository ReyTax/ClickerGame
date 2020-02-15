using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Properties;

namespace ClickerGame.View
{
    class Ball : BitmapGenerator
    {
        public Rectangle ball = new Rectangle();
        public Ball(int _x,int _y) : base(Resources.ballgame)
        {
            
            setX(_x);
            setY(_y);
            ball.X = _x;
            ball.Y = _y;
            ball.Width = 50;
            ball.Height = 50;
            
        }
         

        public void Update(int x,int y)
        {
            setX(x);
            setY(y);
            ball.X = getX();
            ball.Y = getY();
        }
        public bool HitDetection(int x,int y)
        {
            Rectangle c = new Rectangle(x, y, 1,1);
            if (ball.Contains(c))
            {
                return true;
            }
            return false;
        }
    }
}
