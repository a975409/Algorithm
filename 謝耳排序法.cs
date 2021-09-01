using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp1
{

    class Program
    {
        static int size = 8;
        static int[] data = new int[size];

        static void Main(string[] args)
        {
            Inputarr();
            Write("您輸入的原始陣列是：");
            ShowArr();
            SortData();
            Write("排序後的陣列是：");
            ShowArr();
            ReadKey();
        }

        static void Inputarr()
        {
            for (int i = 0; i < size; i++)
            {
                int value;
                Write("請輸入第" + (i + 1) + "個元素：");

                while(!int.TryParse(ReadLine(), out value))
                {
                    WriteLine("輸入錯誤!!!請重新輸入");
                    Write("請輸入第" + (i + 1) + "個元素：");
                }
                data[i] = value;
            }
        }

        static void ShowArr()
        {
            foreach (int a in data)
                Write(a + " ");
            WriteLine();
        }

        static void SortData()
        {
            int spiltValue = size / 2;
            int j, tmp;

            while (spiltValue != 0)
            {
                for (int i = spiltValue; i < size; i++)
                {
                    j = i - spiltValue;
                    tmp = data[i];

                    while (j >= 0 && tmp < data[j])
                    {
                        data[j + spiltValue] = data[j];
                        j = j - spiltValue;
                    }

                    data[j + spiltValue] = tmp;
                }

                spiltValue = spiltValue / 2;
            }
        }
    }
}
