using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    public class ValidStrings
    {
        /// <summary>
        /// Print the list of valid StringBuilder objects
        /// </summary>
        /// <param name="input">The input list of StringBuilder objects</param>
        public static void PrintList(List<StringBuilder> input)
        {
            if (input != null)
            {
                Console.WriteLine(String.Format("Total number of Generated Words: {0}", input.Count));
                Console.ReadLine();
                foreach (StringBuilder sb in input)
                {
                    Console.WriteLine(sb.ToString());
                }
            }
        }

    }
}
