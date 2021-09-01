using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp1
{

    class Program
    {
        static int process = 0;
        static int[] data = { 0, 5, 6, 4, 8, 3, 2, 7, 1 };

        static void Main(string[] args)
        {
            WriteLine("原始資料：");
            Showdata();
            Heep(data);
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

        static void Heep(int[] data)
        {
            int size = data.Length;
            int tmp;

            for (int i = size / 2; i >= 0; i--)
                Ad_Heap(data, i, data.Length);

            for (int i = size - 2; i >= 0; i--)
            {
                //樹根(最大值)與最末端樹葉(最小值)互換
                tmp = data[i + 1];
                data[i + 1] = data[0];
                data[0] = tmp;

                //移除最末端樹葉，重建最大堆積樹
                Ad_Heap(data, 0, i + 1);
            }

            WriteLine("堆積陣列：");
            Showdata();
        }

        static void Ad_Heap(int[] data, int i, int size)
        {
            int left = i * 2 + 1;//左子節點的Index
            int tmp = data[i];//i為父節點的Index
            
            while (left < size - 1)
            {
                if (data[left] < data[left + 1])//判斷左子節點是否比右子節點小
                    left++;

                if (tmp > data[left])//父節點是否比由上一個case取得較大的子節點大
                    break;
                else//子節點與父節點交換
                {
                    if (left % 2 == 0)//判斷是否為右子節點
                        data[left / 2 - 1] = data[left];
                    else
                        data[left / 2] = data[left];

                    left = left * 2 + 1;//設定下一個左子節點為父節點，繼續執行
                }
            }
            if (left % 2 == 0)
                data[left / 2 - 1] = tmp;
            else
                data[left / 2] = tmp;
        }
    }
}
