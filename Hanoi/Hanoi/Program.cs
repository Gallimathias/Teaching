using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int diskCount = 14;

            int[] stickA = new int[diskCount];
            int[] stickB = new int[diskCount];
            int[] stickC = new int[diskCount];

            //stickC[7] = 3;

            int loops = 0;
            while (loops < diskCount)
            {
                
                    stickA[loops] = loops + 1;

                loops++;
            }

            int maxspaces = diskCount - 1;
            
            for (int loopcount = 0; loopcount < diskCount; loopcount++)
            {

                Console.ForegroundColor = (ConsoleColor)stickA[loopcount];
                for (int i = 0; i < maxspaces; i++)
                {
                    Console.Write(" ");
                }

                if (0 < stickA[loopcount])
                {
                    for (int i = 0; i < stickA[loopcount]; i++)
                    {
                        Console.Write("##");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < loopcount +1; i++)
                    {
                        Console.Write("  ");
                    }
                }

                
                for (int i = 0; i < maxspaces + 1; i++)
                {
                    Console.Write(" ");
                }

                for (int i = 0; i < maxspaces; i++)
                {
                    Console.Write(" ");
                }
                for (int i = 0; i < stickB[loopcount]; i++)
                {
                    Console.Write("##");
                }
                for (int i = 0; i < maxspaces; i++)
                {
                    Console.Write(" ");
                }

                for (int i = 0; i < maxspaces; i++)
                {
                    Console.Write(" ");
                }
                for (int i = 0; i < stickC[loopcount]; i++)
                {
                    Console.Write("##");
                }
                for (int i = 0; i < maxspaces; i++)
                {
                    Console.Write(" ");
                }
                maxspaces--;
                
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
