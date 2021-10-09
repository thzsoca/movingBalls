using System;
using System.Threading;

namespace movingBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            balls a = new balls(10, 5, +1, +1); 
            Thread t1 = new Thread(a.moves);
            t1.Start();
            balls b = new balls(30, 2, -1, +1);
            Thread t2 = new Thread(b.moves);
            t2.Start();
            balls c = new balls(70, 10, -1, -1);
            Thread t3 = new Thread(c.moves);
            t3.Start();

            bool stop = false;
            while (!stop)
            {
                if (a.curposX == b.curposX && a.curposY == b.curposY || a.curposX == c.curposX && a.curposY == c.curposY || c.curposX == b.curposX && c.curposY == b.curposY)
                {
                    t1.Abort();
                    t2.Abort();
                    t3.Abort();
                    stop = true;
                }
            }
        }
    }
}
