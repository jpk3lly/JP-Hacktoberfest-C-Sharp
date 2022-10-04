using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    /// <summary>
    /// Create a new Boggle board game
    /// </summary>
    /// <returns>N*N size matrix of characters</returns>
    public class NewBoggleBoard
    {
        public static string[][] CreateNewBoard()
        {
            string[][] board = new string[Constants.MaxBoardSize][];
            for (int i = 0; i < board.Length; ++i)
            {
                board[i] = new string[board.Length];
            }

            for (int j = 0; j < board.Length; ++j)
            {
                for (int k = 0; k < board.Length; ++k)
                {
                    board[j][k] = GenerateRandomChar().ToString();
                }
            }
            return board;
        }

        private static char GenerateRandomChar()
        {
            // Without a sleep timeout, the value of rnd.Next(0, 26) was returning the same. I guess calling the function really fast
            // without a break would do that?
            int sleepTimeOut = 200;
            System.Threading.Thread.Sleep(sleepTimeOut);
            Random rnd = new Random();
            int seed = 65 + rnd.Next(0, 26);
            return (char)seed;
        }
    }
}
