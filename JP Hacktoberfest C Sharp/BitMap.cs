using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    public class BitMap
    {
        /// <summary>
        /// Creates a BitMap of boolean values of N*N size
        /// </summary>
        /// <param name="board">The input board</param>
        /// <returns>The boolean BitMap</returns>
        public static bool[][] InitBitMap(string[][] board)
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

    }
}
