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
            LinkedList<int> result = new LinkedList<int>();

            LinkedListNode<int> CurrentNode = null;

            foreach(int item in data)
            {
                if(result.Count==0)
                {
                    CurrentNode = result.AddFirst(item);
                }
                else
                {

                    while (CurrentNode != null)
                    {
                        if (item < CurrentNode.Value)
                        {
                            result.AddBefore(CurrentNode, item);
                            break;
                        }
                        else if(CurrentNode.Next==null)
                        {
                            result.AddAfter(CurrentNode, item);
                            break;
                        }
                        else
                            CurrentNode = CurrentNode.Next;
                    }
                }
                CurrentNode = result.First;
            }

            result.CopyTo(data, 0);
        }
    }
}
