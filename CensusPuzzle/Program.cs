using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace CensusPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            //   The 2010 Census puts populations of 26 largest US metro areas at
            //   18897109, 12828837, 9461105, 6371773, 5965343, 5946800, 5582170, 5564635, 5268860,
            //   4552402, 4335391, 4296250, 4224851, 4192887, 3439809, 3279833, 3095313, 2812896,
            //   2783243, 2710489, 2543482, 2356285, 2226009, 2149127, 2142508, and 2134411.
            //   Can you find a subset of these areas where a total of exactly 100,000,000 people live,
            //   assuming the census estimates are exactly right?

            List<int> populations = new List<int> {
                18897109, 12828837, 9461105,
                6371773, 5965343, 5946800, 5582170, 5564635,
                5268860, 4552402, 4335391, 4296250, 4224851,
                4192887, 3439809, 3279833, 3095313, 2812896,
                2783243, 2710489, 2543482, 2356285, 2226009,
                2149127, 2142508, 2134411
            };

            SubSets(populations); 
        }

        public static void RecursiveFindSum(List<int> arr, int p, int r, int sum, List<int> subsets)
        {
            
            if (p > r)
            {
                if (sum == 100000000)
                {
                    StringBuilder sb = new StringBuilder(sum + " ");
                    foreach (int s in subsets)
                    {
                        sb.Append(", " + s);
                    }
                    WriteLine(sb.ToString());
                    Console.ReadKey();
                }
                    return;
            }

            RecursiveFindSum(arr, p + 1, r, sum + arr[p], subsets);
            RecursiveFindSum(arr, p + 1, r, sum, subsets);
            subsets.Clear();
        }

        public static void SubSets(List<int> arr)
        {
            long total = 1 << arr.Count;
            for (long i = 0; i < total; i++)
            {
                List<int> populations = new List<int>();
                long sum = 0;
                for(int j = 0; j < arr.Count; j++)
                {
                    long c = i & (1 << j);
                    if(c > 0)
                    {
                        populations.Add(arr[j]);
                        sum += arr[j];
                        if (sum == 100000000)
                        {
                            WriteLine("FOUND IT");
                            string output = "";
                            foreach (int pop in populations)
                            {
                                output = output + " " + pop;
                            }
                            WriteLine(output);
                            return;
                        }
                    }
                }
            }
        }
    }
}
