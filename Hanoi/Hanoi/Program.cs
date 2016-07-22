using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Program
    {
        static int diskCount = 7;

        static void Main(string[] args)
        {
            int[] stickA = new int[diskCount];
            int[] stickB = new int[diskCount];
            int[] stickC = new int[diskCount];

            //stickC[7] = 3;
            int loops = 0;

            while (loops < diskCount)
            {

                if(diskCount - loops != 3 && diskCount - loops != 4)
                {
                    Gravity(stickA, diskCount - loops);
                }
                loops++;
            }
            DrawSticks(stickA, stickB, stickC);
            while (true) // GamingLoop
            {

                ConsoleKeyInfo s = Console.ReadKey();
                Console.Clear();
                DrawSticks(stickA, stickB, stickC);
                Console.ForegroundColor = ConsoleColor.White;
                if (s.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("You have selected the first tower");
                }
                else if(s.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("You have selected the second tower");
                }
                else if (s.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("You have selected the third tower");
                }
            }
        }

        static void DrawSticks(int[] stickA, int[] stickB, int[] stickC)
        {
            for (int i = 0; i < diskCount; i++)
            {
                DrawLine(stickA[i]);
                DrawLine(stickB[i]);
                DrawLine(stickC[i]);
                Console.WriteLine();
            }
        }

        static void DrawLine(int disc)
        {
            int maxspaces = diskCount - 1;
            int leftspacefromdisk = diskCount - disc;
            Console.CursorLeft += leftspacefromdisk + 2;

            Console.ForegroundColor = (ConsoleColor)disc;
            for (int i = 0; i < disc; i++)
            {
                Console.Write("##");
            }
            Console.CursorLeft += leftspacefromdisk;
        }

        static void Gravity(int[] stick, int disc)
        {
            if (stick[stick.Length-1] == 0)
            {
                stick[stick.Length-1] = disc;
            }
            else
            {
                for (int i = 0; i < stick.Length; i++)
                {
                    if (stick[i] > 0)
                    {
                        stick[i - 1] = disc;
                        break;
                    }
                }
            }
        }
    }
}
