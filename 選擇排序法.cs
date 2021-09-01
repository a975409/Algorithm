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
            int minValue, tmp, minIdx;
            bool change;

            for (int i = 1; i < data.Length; i++)
            {
                minValue = data[i - 1];
                minIdx = i - 1;
                change = false;

                for (int j = i; j < data.Length; j++)
                {
                    if (data[j] < minValue)
                    {
                        minValue = data[j];
                        minIdx = j;
                        change = true;
                    }
                }

                if(change)
                {
                    tmp = data[i - 1];
                    data[i - 1] = data[minIdx];
                    data[minIdx] = tmp;
                }
            }
        }
    }
}
