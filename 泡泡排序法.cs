using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp1
{

    class Program
    {
        static int process = 0;
        static int[] data = { 59, 95, 7, 34, 60, 168, 171, 259, 372, 45, 88, 133 };

        static void Main(string[] args)
        {
            WriteLine("原始資料：");
            Showdata();
            SortData(data);
            WriteLine("排序後資料：");
            Showdata();
            ReadKey();
        }

        static void Showdata()
        {
            foreach (int i in data)
                Write(i + " ");
            WriteLine();
        }

        static void SortData(int[] data)
        {
            bool change;

            do
            {
                change = false;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    int temp = data[i];

                    if (temp > data[i + 1])
                    {
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        change = true;
                    }
                }
                Write($"第{++process}次排序：");
                Showdata();
            } while (change);
        }
    }
}
