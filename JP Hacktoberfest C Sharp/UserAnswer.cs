using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    public class UserAnswer
    {
        public String Answer;
        public List<String> Answers = new List<String>();
        public int WordScore = new int();
        public int Score = 0;
        public static DateTime startTime = DateTime.Now;
        public DateTime endTime = startTime.AddMinutes(1);

        public void UserInput()
        {
            while (DateTime.Now < endTime)
            { 
                Answer = Console.ReadLine();
                Answers.Add(Answer);
                WordScore = Answer.Length;
                Score = Score + WordScore;
            }

            Console.WriteLine($"You found {Answers.Count} words");
            Console.WriteLine($"Your score is: {Score}");
        }
    }
}