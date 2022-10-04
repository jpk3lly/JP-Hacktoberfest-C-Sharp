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
            List<StringBuilder> list = CalculateAnswers.GetAllPossibleCombinations(testInput);
            UserAnswer answer = new UserAnswer();
            answer.UserInput();
            
        }    
    }
}
