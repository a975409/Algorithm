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
            SortData(data, 0);
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

        static void SortData(int[] data, int digit)
        {
            int size = 10;
            LinkedList<int>[] linkArray = new LinkedList<int>[size];

            foreach (int i in data)
            {
                string valueToStr = i.ToString();
                int subIndex = valueToStr.Length - 1 - digit;
                int index = -1;

                if (subIndex >= 0)
                    index = int.Parse(valueToStr.Substring(subIndex, 1));
                else
                    index = 0;

                if (linkArray[index] == null)
                {
                    linkArray[index] = new LinkedList<int>();
                    linkArray[index].AddFirst(i);
                }
                else
                {
                    linkArray[index].AddLast(i);
                }
            }

            if (linkArray.Count(m => m == null) == size - 1)
                return;

            List<int> list = new List<int>();

            foreach (var item in linkArray)
            {
                if (item != null)
                {
                    LinkedListNode<int> node = item.First;

                    do
                    {
                        list.Add(node.Value);
                        node = node.Next;
                    } while (node != null);
                }
            }

            list.CopyTo(data);
            Write($"第{++process}次排序：");
            Showdata();
            SortData(data, ++digit);
        }
    }
}
