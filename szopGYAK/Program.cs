using System;
using System.Threading;

namespace szopGYAK
{
    class Program
    {
        const int N = 1000000;
        static int[] adatok = new int[N];
        static int osszeg = 0;
        static void elj1()
        {
            int osszeg1 = 0;
            for (int i = 0; i < N/2; i++)
            {
                osszeg1 += adatok[i];
            }
            lock (adatok)
            {
                osszeg += osszeg1;
            }
        }
        static void elj2()
        {
            int osszeg2 = 0;
            for (int i = N/2; i < N; i++)
            {
                osszeg2 += adatok[i];
            }
            lock (adatok)
            {
                osszeg += osszeg2;
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < adatok.Length; i++)
                adatok[i] = i;
            Thread t1 = new Thread(elj1);   t1.Priority = ThreadPriority.Highest;
            Thread t2 = new Thread(elj2);   t2.Priority = ThreadPriority.Lowest;
            t1.Start(); t2.Start();
            t1.Join();  t2.Join();
            Console.WriteLine(osszeg);
            //elj1();
            //elj2();
            Console.ReadKey();
        }
    }
}
