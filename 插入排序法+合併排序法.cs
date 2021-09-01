using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp1
{

    class Program
    {
        static int process = 0;
        static int[] data = { 38, 16, 41, 72, 52, 98, 63, 25 };

        static void Main(string[] args)
        {
            WriteLine("原始資料：");
            Showdata();
            MergeSort(data);
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
        //合併排序法
        static void MergeSort(int[] data)
        {
            int spiltValue = 2;
            
            while(spiltValue<=data.Length)
            {
                for (int i = 0; i < data.Length; i += spiltValue)
                {
                    int[] temp = new int[spiltValue];

                    for (int j = 0; j < spiltValue; j++)
                        temp[j] = data[j + i];

                    LinkSort(temp, 0, spiltValue);

                    temp.CopyTo(data, i);
                }

                Write($"第{++process}次排序：");
                Showdata();

                spiltValue = spiltValue * 2;
            }
        }
        //插入排序法
        static void LinkSort(int[] sourcedata,int firstNode,int size)
        {
            LinkedList<int> lindData = new LinkedList<int>();
            LinkedListNode<int> node = null;

            for (int i = firstNode; i < size; i++)
            {

                if (lindData.Count == 0)
                    node = lindData.AddFirst(sourcedata[firstNode]);
                else
                {
                    while (node != null)
                    {
                        if (sourcedata[i] < node.Value)
                        {
                            lindData.AddBefore(node, sourcedata[i]);
                            break;
                        }
                        else
                        {
                            if (node.Next == null)
                            {
                                lindData.AddAfter(node, sourcedata[i]);
                                break;
                            }
                            else
                                node = node.Next;
                        }
                    }
                }
                node = lindData.First;
            }

            lindData.CopyTo(sourcedata, 0);
        }
    }
}
