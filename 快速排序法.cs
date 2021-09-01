using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp1
{

    class Program
    {
        static int process = 0;
        static int size;
        static int[] data = new int[10];

        static void Main(string[] args)
        {
            Write("請輸入陣列大小(10以下)：");


            if (int.TryParse(ReadLine(), out size))
            {
                Inputarr();
                Write("原始資料是：");
                Showdata(size);
                Quick(data, 0, size - 1);
                Write("排序後資料是：");
                Showdata(size);
            }
            else
                WriteLine("請輸入正確數值!!");
            
            ReadKey();
        }

        static void Inputarr()
        {
            Random rand = new Random();

            for (int i = 0; i < size; i++)
                data[i] = Math.Abs(rand.Next(1, 100));

            //data = new int[] { 45, 76, 43, 6, 21, 15, 44, 72, 20, 95 };
        }

        static void Showdata(int size)
        {
            for (int i = 0; i < size; i++)
                Write(data[i] + " ");
            WriteLine();
        }

        static void Quick(int[] data, int left, int right)
        {
            int temp;
            int left_idx;
            int right_idx;

            if (left >= right)
                return;

            while(true)
            {
                left_idx = left + 1;
                right_idx = right;

                for (int i = left + 1; i <= right; i++)
                {
                    if (data[i] > data[left])
                    {
                        left_idx = i;
                        break;
                    }
                    left_idx++;
                }

                for (int j = right; j >= left + 1; j--)
                {
                    if(data[j]< data[left])
                    {
                        right_idx = j;
                        break;
                    }
                    right_idx--;
                }

                if (left_idx < right_idx)
                {
                    temp = data[left_idx];
                    data[left_idx] = data[right_idx];
                    data[right_idx] = temp;
                }
                else
                    break;
            }

            temp = data[left];
            data[left] = data[right_idx];
            data[right_idx] = temp;

            Quick(data, left, right_idx - 1);
            Quick(data, right_idx + 1, right);
        }
    }
}
