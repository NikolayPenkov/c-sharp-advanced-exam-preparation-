using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._blackSmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            List<int> steelInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> carbonInput = Console.ReadLine().Split().Select(int.Parse).ToList();

            //Solving
            Queue<int> steelQueue = new Queue<int>(steelInput);
            Stack<int> carbonStack = new Stack<int>(carbonInput);

            SortedDictionary<string, int> forgeRecepi = new SortedDictionary<string, int>
            {
                {"Gladius", 0},
                {"Shamshir", 0},
                {"Katana", 0},
                {"Sabre", 0},
                { "Broadsword", 0}
            };
            int swordCount = 0;
            while (steelQueue.Count > 0 && carbonStack.Count > 0)
            {
                int steelIndex =steelQueue.Peek();
                int carbonIndex =carbonStack.Peek();
                int sum = steelIndex + carbonIndex;
                if (sum == 70)
                {
                    forgeRecepi["Gladius"]++;
                    steelQueue.Dequeue();
                    carbonStack.Pop();
                    swordCount++;
                }
                else if (sum == 80)
                {
                    forgeRecepi["Shamshir"]++;
                    steelQueue.Dequeue();
                    carbonStack.Pop();
                    swordCount++;
                }
                else if (sum == 90)
                {
                    forgeRecepi["Katana"]++;
                    steelQueue.Dequeue();
                    carbonStack.Pop(); 
                    swordCount++;
                }
                else if (sum == 110)
                {
                    forgeRecepi["Sabre"]++;
                    steelQueue.Dequeue();
                    carbonStack.Pop();
                    swordCount++;
                }
                else if (sum == 150)
                {
                    forgeRecepi["Broadsword"]++;
                    steelQueue.Dequeue();
                    carbonStack.Pop();
                    swordCount++;
                }
                else
                {
                    steelQueue.Dequeue();
                    carbonStack.Pop();
                    carbonIndex += 5;
                    carbonStack.Push(carbonIndex);
                }
                
            }


            //OUTPUT
            //•	On the first line of output depending on the result:
            if (swordCount>0)
            {
                Console.WriteLine($"You have forged {swordCount} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            //•	On the second line – print all steel you have left:
            if (steelQueue.Count>0)
            {
                //foreach (var steel in steelQueue)
               // {
                    Console.WriteLine("Steel left: " + string.Join(", ", steelQueue));
                //}
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbonStack.Count > 0)
            {
              //  foreach (var carbon in carbonStack)
             //  {
                    Console.WriteLine("Carbon left: " + string.Join(", ", carbonStack));
              //  }
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            //print all of the forged swords
            foreach (var sword in forgeRecepi)
            {
                if (sword.Value > 0)
                {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
