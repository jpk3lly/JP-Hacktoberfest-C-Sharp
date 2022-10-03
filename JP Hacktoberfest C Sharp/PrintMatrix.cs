using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    public class AllPossibleCombinations
    {
        /// <summary>
        /// Prints the matrix for viewing
        /// </summary>
        /// <param name="input">The N*N matrix to be printed</param>
        public static void PrintMatrix(string[][] input)
        {
            if (input != null)
            {
                Console.WriteLine("Printing Martix");
                for (int i = 0; i < input.Length; ++i)
                {
                    for (int k = 0; k < input[i].Length; ++k)
                    {
                        Console.Write(input[i][k].ToString());
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
