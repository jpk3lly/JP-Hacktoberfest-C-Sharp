using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    public class Combinations
    {
        /// <summary>
        /// This helper function is used to generate all possible combinations of words starting at the row and column
        /// It is called recursively in all 8 directions (North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest)
        /// Everytime it append the char at it's current location to the "currentWord", and if the word is valid, it is added to
        /// the prefixList. This function uses a BitMap of boolean values to keep track of the cells it has visited to avoid getting
        /// into infinite loop
        /// </summary>
        /// <param name="matrix">The input matrix</param>
        /// <param name="visited">The boolean bitmap that tracks the visited locations</param>
        /// <param name="currentPrefix">The current prefix</param>
        /// <param name="row">The current row on the board. The valid range is 0..N-1</param>
        /// <param name="column">The current column on the board. The valid range is 0..N-1</param>
        /// <param name="prefixList">The List of the valid words</param>
        /// <returns></returns>
        public static List<StringBuilder> CombinationsHelper(
            string[][] matrix,
            bool[][] visited,
            StringBuilder currentPrefix,
            int row,
            int column,
            List<StringBuilder> prefixList)
        {
            if (matrix == null)
                return prefixList;

            // if the row or column are not in valid range [0..N-1], exit out of the function
            if (row < 0 || row >= matrix.Length || column < 0 || column >= matrix.Length)
                return prefixList;

            // if we have already visited this cell before, exit out of the function
            if (visited[row][column])
                return prefixList;

            StringBuilder newWord = new StringBuilder(currentPrefix.ToString());
            newWord.Append(matrix[row][column]);
            if (RealWords.isValidWord(newWord))
            {
                // Only proceed with calling the function recursively (i.e. creating more layers on stack)
                // if the word is valid. It doesn't make sense to continue down "XWQ" prefix if there are
                // no valid words in the English dictionary that begin with that prefix

                prefixList.Add(newWord);
                visited[row][column] = true;
                CombinationsHelper(matrix, visited, newWord, row - 1, column, prefixList); // North
                CombinationsHelper(matrix, visited, newWord, row - 1, column + 1, prefixList); // NorthEast
                CombinationsHelper(matrix, visited, newWord, row, column + 1, prefixList); // East
                CombinationsHelper(matrix, visited, newWord, row + 1, column + 1, prefixList); // SouthEast
                CombinationsHelper(matrix, visited, newWord, row + 1, column, prefixList); // South
                CombinationsHelper(matrix, visited, newWord, row + 1, column - 1, prefixList); // SouthWest
                CombinationsHelper(matrix, visited, newWord, row, column - 1, prefixList); // West
                CombinationsHelper(matrix, visited, newWord, row - 1, column - 1, prefixList); // NorthWest
                visited[row][column] = false;
            }
            return prefixList;
        }

    }
}
