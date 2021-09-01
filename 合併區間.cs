using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。
             * 请你合并所有重叠的区间，并返回一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间。
             
             示例 1：
                输入：intervals = [[1,3],[2,6],[8,10],[15,18]]
                输出：[[1,6],[8,10],[15,18]]
                解释：区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].

             示例 2：
                输入：intervals = [[1,4],[4,5]]
                输出：[[1,5]]
                解释：区间 [1,4] 和 [4,5] 可被视为重叠区间。*/

            int[][] one = { new int[] { 8, 10 },
                            new int[] { 15, 18 }, 
                            new int[] { 1, 3 },
                            new int[] { 2, 6 } };
            one=Merge(one);

            foreach (var item in one)
            {
                Console.WriteLine("{0} - {1}", item[0], item[1]);
            }

            Console.ReadKey();
        }


        static int[][] Merge(int[][] intervals)
        {
            if (intervals.GetLength(0) == 0)
                return new int[][] { new int[] { 0, 0 } };

            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            int left = intervals[0][0];
            int right = intervals[0][1];

            if (intervals.GetLength(0) == 1)
                return new int[][] { new int[] { left, right } };

            List<int[]> result = new List<int[]>();
            for (int i = 1; i < intervals.GetLength(0); i++)
            {
                if (intervals[i][0] <= right)
                {
                    if (intervals[i][1] > right)
                    {
                        right = intervals[i][1];
                    }
                }
                else
                {
                    result.Add(new int[] { left, right });
                    left = intervals[i][0];
                    right = intervals[i][1];
                }

                if (i == intervals.GetLength(0) - 1)
                {
                    result.Add(new int[] { left, right });
                }
            }

            return result.ToArray();
        }
    }
}