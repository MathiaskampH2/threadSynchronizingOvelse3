using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threadSynchronizingOvelse3
{
    class Program
    {
        // shared variables that both threads can access and use
        private static int Counter = 0;
        private static object Lock = new object();
        private static char ch;

        private static void Main(string[] args)
        {
            // tStar thread that runs PrintStar method
            Thread tStar = new Thread(PrintStar);
            // tHashTag thread that runs PrintHashTag method
            Thread tHashTag = new Thread(PrintHashTag);
            // start tStar thread
            tStar.Start();
            // sleep main thread for 500ms
            Thread.Sleep(500);
            // start tHashTag thread
            tHashTag.Start();
        }

        // PrintStar method prints 60 stars and counts counter variable 1 up each time it writes a *
        public static void PrintStar()
        {
            while (true)
            {
                Monitor.Enter(Lock);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        ch = '*';
                        Console.Write(ch);

                        Counter++;
                    }

                    Console.Write(Counter + "\n");
                }
                finally
                {
                    Monitor.Exit(Lock);
                }

                Thread.Sleep(1000);
            }
        }

        // PrintHashTag method prints 60 stars and counts counter variable 1 up each time it writes a #
        public static void PrintHashTag()
        {
            while (true)
            {
                Monitor.Enter(Lock);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        ch = '#';
                        Console.Write(ch);

                        Counter++;
                    }

                    Console.Write(Counter + "\n");
                }
                finally
                {
                    Monitor.Exit(Lock);
                }

                Thread.Sleep(1000);
            }
        }
    }
}