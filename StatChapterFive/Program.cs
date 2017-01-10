using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StatChapterFive
{
    public class Program
    {

        private static int[] singles = { 0, 30 };
        private static int[] doubles = { 30, 38 };
        private static int[] triples = { 38, 39 };

        //variables in this region are used for advanced statistics
        private static int hits;
        private static ulong iterations; //unsigned long cannot be negative and has a max value of 18,446,744,073,709,551,615 so it will be pretty much exact.
        private static int singleHomeTotal;
        private static int doubleHomeTotal;
        private static int octupleHomeTotal;
        private static int total;

        public static void Main(string[] args)
        {
            Console.WriteLine("How many iterations would you like to run?");
            iterations = Convert.ToUInt64(Console.ReadLine());

            List<int> hit = new List<int>();
            Random random = new Random();

            int number;
            int units;
            for (ulong i = 0; i < iterations; i++)
            {
                hit.Clear();
                units = 10;
                while (units > 0)
                {
                    number = random.Next(39);
                    int unitVal = GetValue(number);
                    if (hit.Contains(number) || units - unitVal < 0) continue;
                    if (number == 0) hits++;
                    hit.Add(number);
                    units -= unitVal;
                    total++;
                    switch (unitVal)
                    {
                        case 1:
                            singleHomeTotal++;
                            break;
                        case 2:
                            doubleHomeTotal++;
                            break;
                        case 8:
                            octupleHomeTotal++;
                            break;
                    }
                }
            }
            Console.WriteLine(((float)hits / (float)iterations) * 100f + "%");
            Console.WriteLine("Would you like to see advanced the advanced stats? (Y/N)");
            if (Console.Read() == 'y' || Console.Read() == 'Y')
                PrintTable();
            Console.ReadKey();
        }

        private static int GetValue(int id)
        {
            return (id >= singles[0] && id < singles[1]) ? 1 : ((id >= doubles[0] && id < doubles[1]) ? 2 : 8);
        }

        private static void PrintTable()
        {
            Console.WriteLine("Your unit was chosen " + hits + " times out of " + iterations + " iterations.");
            Console.WriteLine("Total Single Unit Hits: " + singleHomeTotal);
            Console.WriteLine("Total Double Unit Hits: " + doubleHomeTotal);
            Console.WriteLine("Total Octuple Unit Hits: " + octupleHomeTotal);
            Console.WriteLine("Proportion of Single Unit Hits: " + ((float)singleHomeTotal / (float)total * 100f) + "%");
            Console.WriteLine("Proportion of Double Unit Hits: " + ((float)doubleHomeTotal / (float)total * 100f) + "%");
            Console.WriteLine("Proportion of Octuple Unit Hits: " + ((float)octupleHomeTotal / (float)total * 100f) + "%");
        }

    }
}