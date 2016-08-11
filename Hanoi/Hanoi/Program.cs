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
        static int[] stickA = new int[diskCount];
        static int[] stickB = new int[diskCount];
        static int[] stickC = new int[diskCount];

        static void Main(string[] args)
        {           

            //stickC[7] = 3;
            int loops = 0;

            while (loops < diskCount)
            {

                if (diskCount - loops != 3 && diskCount - loops != 4)
                {
                    Gravity(stickA, diskCount - loops);
                }
                loops++;
            }

            DrawSticks(stickA, stickB, stickC);
            Sticks source = Sticks.A;


            DrawSticks(stickA, stickB, stickC);
            while (true) // GamingLoop
            {
                ConsoleKeyInfo s = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();

                switch (s.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("You have selected the first tower");
                        source = Sticks.A;
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("You have selected the second tower");
                        source = Sticks.B;
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("You have selected the third tower");
                        source = Sticks.C;
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("You have pushed the left Arrow");
                        MoveDisk(EnumToArray(source), EnumToArray(source - 1));
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("You have pushed the right Arrow");
                        MoveDisk(EnumToArray(source), EnumToArray(source + 1));
                        break;
                    default:
                        Console.WriteLine("Nespresso what else");
                        break;
                }

                DrawSticks(stickA, stickB, stickC);
            }
        }

        static void MoveDisk(int[] stickSource, int[] stickTarget)
        {
            for (int i = 0; i < stickSource.Length; i++)
            {
                if (stickSource[i] > 0)
                {
                    Gravity(stickTarget, stickSource[i]);
                    stickSource[i] = 0;
                    break;
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
            
            if (stick[stick.Length - 1] == 0)
            {
                stick[stick.Length - 1] = disc;
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

        static int[] EnumToArray(Sticks sticks)
        {
            sticks = ValidateSticks((int)sticks);
            switch (sticks)
            {
                case Sticks.A:
                    return stickA;
                case Sticks.B:
                    return stickB;
                case Sticks.C:
                    return stickC;
                default:
                    return new int[0];
            }
        }

        static Sticks ValidateSticks(int stick)
        {
            int last = Enum.GetValues(typeof(Sticks)).Cast<int>().Last();
            int first = Enum.GetValues(typeof(Sticks)).Cast<int>().First();

            if (stick < first)
            {
                return (Sticks)last;
            }
            else if (last < stick)
            {
                return (Sticks)first;
            }

            return (Sticks)stick;
        }

    }

    public enum Sticks
    {
        A,
        B,
        C
    }
}
