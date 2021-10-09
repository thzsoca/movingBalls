using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace movingBalls
{
    class balls
    {
        public int curposX, curposY, intx, inty;
        public balls(int curposX, int curposY, int intx, int inty)
        {
            this.curposX = curposX; this.curposY = curposY; this.intx = intx; this.inty = inty;
        }  

        public void moves()
        {
            while (true)
            {
                lock (typeof(Program))
                {
                    Console.SetCursorPosition(curposX, curposY);
                    Console.Write(' ');
                }
                if (curposX < 80 && curposX > 0 && curposY < 25 && curposY > 0)
                {
                    curposX += intx;
                    curposY += inty;
                }
                if (curposX == 0 || curposX == 80)
                {
                    intx *= -1;
                    curposX += intx;
                }
                if (curposY == 0 || curposY == 25)
                {
                    intx *= -1;
                    curposY += inty;
                }

                lock (typeof(Program))
                {
                    Console.SetCursorPosition(curposX, curposY);
                    Console.Write('o');
                }
                Thread.Sleep(100);
            }
        }
    }
}
