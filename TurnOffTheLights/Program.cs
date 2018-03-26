using System;
using System.Collections.Generic;

namespace TurnOffTheLights
{
    class Solution
    {
        static void Main()
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

            long[] line1 = Array.ConvertAll(Console.ReadLine().Split(' '), x => long.Parse(x));
            long nodeCount = line1[0];
            long distance = line1[1];
            long[] nodeCosts = Array.ConvertAll(Console.ReadLine().Split(' '), x => long.Parse(x));

            Console.WriteLine(FindCheapestPath(nodeCount, nodeCosts, distance));
        }

        //Parameters
        //nodeCount: The total number of nodes
        //nodeCosts: The cost to include the current node in a path
        //distance: The distance that can be traveled from one node to another
        static long FindCheapestPath(long nodeCount, long[] nodeCosts, long distance)
        {
            long result = -1;
            //The maximum distance that can seperate two nodes
            long range = (distance * 2) + 1;
            //The number of passes through nodeCosts required to find all cheapest nodes
            long nodeGroups = Math.Min(nodeCount, distance + 1);
            for (long i = 0; i < nodeGroups; i++)
            {
                //Are we still checking nodes?
                long nodesToTheRight = nodeCount - distance - i - 1;
                long remaining = nodesToTheRight % range;
                if (remaining <= 0 || remaining > distance)
                {
                    //Loop through the nodes, get the cheapest ones
                    long cost = 0;
                    List<long> selectedCosts = new List<long>();
                    for (long j = i; j < nodeCount; j += range)
                        cost += nodeCosts[j];

                    if (result == -1 || result > cost)
                        result = cost;
                }
            }

            return result;
        }
    }
}
