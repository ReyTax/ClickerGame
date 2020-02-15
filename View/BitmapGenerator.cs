using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame.View
{
    class BitmapGenerator
    {
        bool disposed = false;

        Bitmap bitmap;
        private int x;
        private int y;

        public int getX()
        {
            return x;
        }
        public void setX(int _x)
        {
            x = _x;
        }
        public int getY()
        {
            return y;
        }
        public void setY(int _y)
        {
            y = _y;
        }
        public BitmapGenerator(Bitmap resources)
        {
            bitmap = new Bitmap(resources);
        }
        public void DrawImage(Graphics g)
        {
            g.DrawImage(bitmap, x, y);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                bitmap.Dispose();
            }
            disposed = true;
        }
    }
}
