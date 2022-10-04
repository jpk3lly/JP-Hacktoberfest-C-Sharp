using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    public class CalculateAnswers
    {
        public static List<StringBuilder> GetAllPossibleCombinations(string[][] matrix)
        {
            AllPossibleCombinations.PrintMatrix(matrix);
            bool[][] visited;
            List<StringBuilder> retVal = new List<StringBuilder>();
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    visited = BitMap.InitBitMap(matrix);
                    retVal.InsertRange(retVal.Count, Combinations.CombinationsHelper(matrix, visited, new StringBuilder(), i, j, new List<StringBuilder>()));
                }
            }
            //ValidStrings.PrintList(retVal);
            return retVal;
        }
    }
}
