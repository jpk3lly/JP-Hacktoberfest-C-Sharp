using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    public class RealWords
    {
        public static bool isValidWord(StringBuilder inputWord)
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
    }
}
