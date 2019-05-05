using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        const char CHAR = '1';
        static void Star() => Console.Write(CHAR);
        static void StarLn() => Console.WriteLine(CHAR);
        static void Space() => Console.Write(" ");
        static void SpaceLn() => Console.WriteLine(" ");
        static void NewLine() => Console.WriteLine();
        static void LiteraX(int n)
        {
            if (n < 3) throw new ArgumentException("zbyt mały rozmiar");
            if (n % 2 == 0) n = n + 1;

            //górna połówka
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < i; j++)
                    Space();
                Star();
                for (int j = 0; j < n - 2 - 2 * i; j++)
                    Space();
                StarLn();
            }

           
          

        }
        static void LiteraY(int n)
        {
            if (n < 3) throw new ArgumentException("zbyt mały rozmiar");
            if (n % 2 == 0) n = n + 1;

            //górna połówka
            for (int i = 0; i < n / 2 ; i++)
            {
                for (int j = 0; j < n - 2 - 2 -2 -2*i; j++)

                    Space();
                StarLn();

                


            }




        }
        /*
        public static void Prostokat(int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                Star();
            }
            NewLine();

            for (int j = 1; j < m - 1; j++)
            {
                Star();
                for (int i = 1; i < n - 1; i++)
                    Space();

                StarLn();
            }

            for (int i = 0; i < n; i++)
            {
                Star();
            }
            NewLine();
        }
        */
        public static void Main(string[] args)
        {
            LiteraX(8);
  
            LiteraY(8);
        }
    }
}
snake
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            int deadStars = 0;
            int starLen = 25;
            int[] star_x = new int[starLen];
            int[] star_y = new int[starLen];
            bool[] starAlive = new bool[starLen];

            Random rand = new Random();
            for (int i = 0; i < starLen; i++)
            {
                starAlive[i] = true;
                star_x[i] = 1 + rand.Next(Console.WindowWidth - 1);
                star_y[i] = 1 + rand.Next(Console.WindowHeight - 1);
                Console.SetCursorPosition(star_x[i], star_y[i]);
                Console.ForegroundColor = (ConsoleColor)1 + rand.Next(15);
                Console.Write('*');
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.CursorVisible = false;
            char snakeElement = '+';
            char snakeHead = 'O';


            int dim = 10;
            int[] snake_x = new int[dim];
            int[] snake_y = new int[dim];

            for (int i = 0; i < dim; i++) //<snake_x.Length
            {
                snake_x[i] = i + 1;
                snake_y[i] = 10;
                Console.SetCursorPosition(snake_x[i], snake_y[i]);
                Console.Write(snakeElement);
            }

            int head_x = snake_x[snake_x.Length - 1];//głowa węża
            int head_y = snake_y[snake_y.Length - 1];

            ConsoleKey znak = ConsoleKey.RightArrow;
            bool isNotEnd = true;
            while (isNotEnd)
            {
                if (Console.KeyAvailable)
                    znak = Console.ReadKey(true).Key;

                switch (znak)
                {
                    case ConsoleKey.LeftArrow: if (head_x > 1) head_x--; break; //head_x-- = head_x=head_x-1
                    case ConsoleKey.RightArrow: if (head_x < Console.WindowWidth - 1) head_x++; break;
                    case ConsoleKey.UpArrow: if (head_y > 1) head_y--; break;
                    case ConsoleKey.DownArrow: if (head_y < Console.WindowHeight - 1) head_y++; break;
                    default: isNotEnd = false; break;
                }

                for (int i = 0; i < starLen; i++)
                    if (head_x == star_x[i] &&
                        head_y == star_y[i] &&
                        starAlive[i] /*== true*/)
                    {
                        starAlive[i] = false;
                        deadStars++;
                        Console.SetCursorPosition(1, Console.WindowHeight - 1);
                        Console.Write("Dead stars -> {0}", deadStars);
                        Console.Beep(2000, 10);
                    }

                if (deadStars == starLen)
                    isNotEnd = false;

                Console.SetCursorPosition(snake_x[0], snake_y[0]);//ogon weza
                Console.Write(' ');//zamazujemy ogon weza

                for (int i = 0; i < snake_x.Length - 1; i++)
                {
                    snake_x[i] = snake_x[i + 1];
                    snake_y[i] = snake_y[i + 1];
                }

                snake_x[snake_x.Length - 1] = head_x;
                snake_y[snake_y.Length - 1] = head_y;

                for (int i = 0; i < snake_x.Length - 1; i++)
                {
                    Console.SetCursorPosition(snake_x[i], snake_y[i]);
                    Console.Write(snakeElement);

                }

                Console.SetCursorPosition(snake_x[snake_x.Length - 1],
                                          snake_y[snake_y.Length - 1]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(snakeHead);
                Console.ForegroundColor = ConsoleColor.Gray;

                System.Threading.Thread.Sleep(25 + (starLen - deadStars) * 20);//1/2 sekundy
            }//while
            string napisKoniec = "K O N I E C";
            Console.SetCursorPosition(Console.WindowWidth / 2 - napisKoniec.Length / 2, Console.WindowHeight / 2);
            Console.Write(napisKoniec);
        }
    }
}
