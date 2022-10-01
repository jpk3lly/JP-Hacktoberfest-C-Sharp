namespace JP_Hacktoberfest_C_Sharp
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Boggle
    {

        static void Main(string[] args)
        {
            string[][] testInput = NewBoggleBoard.CreateNewBoard();
            List<StringBuilder> list = Boggle.GetAllPossibleCombinations(testInput);
        }


        NewBoggleBoard newGame = new NewBoggleBoard();

        /// <summary>
        /// Get all possible combination of words on the board
        /// </summary>
        /// <param name="matrix">The input matrix</param>
        /// <returns>List of valid StringBuilder objects</returns>
        static List<StringBuilder> GetAllPossibleCombinations(string[][] matrix)
        {
            PrintMatrix(matrix);
            bool[][] visited;
            List<StringBuilder> retVal = new List<StringBuilder>();
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    visited = InitBitMap(matrix);
                    retVal.InsertRange(retVal.Count, CombinationsHelper(matrix, visited, new StringBuilder(), i, j, new List<StringBuilder>()));
                }
            }
            PrintList(retVal);
            return retVal;
        }

            /// <summary>
            /// Prints the matrix for viewing
            /// </summary>
            /// <param name="input">The N*N matrix to be printed</param>
            static void PrintMatrix(string[][] input)
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

        /// <summary>
        /// Print the list of valid StringBuilder objects
        /// </summary>
        /// <param name="input">The input list of StringBuilder objects</param>
        static void PrintList(List<StringBuilder> input)
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

        /// <summary>
        /// Creates a BitMap of boolean values of N*N size
        /// </summary>
        /// <param name="board">The input board</param>
        /// <returns>The boolean BitMap</returns>
        static bool[][] InitBitMap(string[][] board)
        {
            if (board == null)
                return null;

            bool[][] output = new bool[board.Length][];
            for (int i = 0; i < board.Length; ++i)
            {
                output[i] = new bool[board[i].Length];
            }

            for (int j = 0; j < board.Length; ++j)
            {
                for (int k = 0; k < board.Length; ++k)
                {
                    output[j][k] = false;
                }
            }

            return output;
        }

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
        static List<StringBuilder> CombinationsHelper(
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
            if (isValidWord(newWord))
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

        static bool isValidWord(StringBuilder inputWord)
        {
            bool retVal = true;

            // In order to avoid getting the stack level too deep, we limit the length of the word to MaxWordSize.
            // In other words, our function will not be called recursively after the word has reached the MaxLength

            // When I called this function on 10*10 board without limiting the word size or trie match, 
            // the program crashed after consuming 1.8 GB of memory
            if (inputWord.Length > Constants.MaxWordSize)
                retVal = false;
            else
            {
                // This is just hardcoded values for now. If we have access to all the words in the English Dictionary
                // we will create a trie (prefix tree) of all the words. If our prefix has a match with any trie, we
                // will continue down that function call. As soon as our trie returns no match, we will exit out of 
                // that function since there are no more valid words
                string input = inputWord.ToString().ToUpper();
                if ((input.StartsWith("V")) ||
                    (input.StartsWith("U")) ||
                    (input.StartsWith("C")) ||
                    (input.StartsWith("D")) ||
                    (input.StartsWith("Q")) ||
                    (input.StartsWith("F")) ||
                    (input.StartsWith("G")) ||
                    (input.StartsWith("X")) ||
                    (input.StartsWith("Y")) ||
                    (input.StartsWith("Z")) ||
                    (input.StartsWith("J")))
                    retVal = false;
            }
            return retVal;
        }

        /// <summary>
        /// Random Char generator used to populate the board at random
        /// </summary>
        /// <returns>A randomly generated character</returns>
    }
}
