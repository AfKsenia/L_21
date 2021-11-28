using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace L_21
{
    class Program
    {
         static int length;
         static int width;
         static int[,] garden;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину поля" );
            length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ширину поля");
            width = Convert.ToInt32(Console.ReadLine());
            garden = new int[length, width];

            ThreadStart threadGardener1 = new ThreadStart(Gardener1);
            Thread gardener1 = new Thread(threadGardener1);

            ThreadStart threadGardener2 = new ThreadStart(Gardener2);
            Thread gardener2 = new Thread(threadGardener2);

            gardener1.Start();
            gardener2.Start();

            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write($"{garden[i, j],2}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
         public static void Gardener1()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (garden[i, j] == 0)
                    {
                        garden[i, j] = 1;
                    }
                    Thread.Sleep(1);
                }
            }
            Console.WriteLine();
        }
        public static void Gardener2()
        {
            for (int i = width - 1; i > 0; i--)
            {
                for (int j = length - 1; j > 0; j--)
                {
                    if (garden[j,i] == 0)
                    {
                        garden[j,i] = 2;
                    }
                    Thread.Sleep(1);
                }
            }
            Console.WriteLine();
        }
    }
}
