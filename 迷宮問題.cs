using System;
using static System.Console;

namespace ConsoleApp1
{
    public class Node
    {
        public int x { get; set; }
        public int y { get; set; }
        public Node Next { get; set; }

        public Node(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class TraceRecord
    {
        public Node firstToEnd { get; set; }
        public Node currentNode { get; set; }

        private bool IsEmpty()
        {
            return firstToEnd == null;
        }

        public void Insert(int x,int y)
        {
            Node newNode = new Node(x, y);
            if(IsEmpty())
            {
                firstToEnd = newNode;
                currentNode = newNode;
            }
            else
            {
                currentNode.Next = newNode;
                currentNode = newNode;
            }
        }

        public void Back()
        {
            Node newNode = firstToEnd;

            if (IsEmpty())
                return;

            while (newNode.Next != currentNode)
                newNode = newNode.Next;

            currentNode = newNode;
        }
    }

    class Program
    {
        public static int ExitX = 8;
        public static int ExitY = 10;
        public static int[,] MAZE = { { 1,1,1,1,1,1,1,1,1,1,1,1},
            { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1 },
            { 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1 },
            { 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};

        static void Main(string[] args)
        {
            int x = 1, y = 1;//入口節點
            TraceRecord trace = new TraceRecord();

            Console.WriteLine("[ 迷宮的路徑(0的部分) ]");
            for (int i=0;i< MAZE.GetLength(0);i++)
            {
                for (int j = 0; j < MAZE.GetLength(1); j++)
                    Write(MAZE[i, j]);
                WriteLine();
            }

            while (x <= ExitX && y <= ExitY)
            {
                MAZE[x, y] = 2;
                if (MAZE[(x - 1), y] == 0)
                {
                    x -= 1;
                    trace.Insert(x, y);
                }
                else if(MAZE[(x+1),y]==0)
                {
                    x += 1;
                    trace.Insert(x, y);
                }
                else if(MAZE[x,(y-1)]==0)
                {
                    y -= 1;
                    trace.Insert(x, y);
                }
                else if(MAZE[x,(y+1)]==0)
                {
                    y += 1;
                    trace.Insert(x, y);
                }
                else if(x==ExitX&&y==ExitY)
                {
                    break;
                }
                else
                {
                    trace.Back();
                    x = trace.currentNode.x;
                    y = trace.currentNode.y;
                }
            }

            Console.WriteLine("[ 老鼠走過的路徑(2的部分) ]");

            for (int n = 0; n < 10; n++)
            {
                for (int k = 0; k < 12; k++)
                    Console.Write(MAZE[n, k]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
