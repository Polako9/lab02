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
