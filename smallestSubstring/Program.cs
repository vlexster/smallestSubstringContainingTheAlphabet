using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smallestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the input string:");
            string inputString = Console.ReadLine();
            inputString = "abcdefghijklmn124345678!@#$%^&*opqrstuvwxyz!*abcdefghijklmn";
            List<string> substringsArray = new List<string>();
            substringsArray = getMatchingSubstrings(inputString);
        
            string result=substringsArray[0];
            int length=substringsArray[0].Length;
            int index;
            foreach (string option in substringsArray)
            {
                if (option.Length<length) {
                    length = option.Length;
                    result = option;
                }
            }
            switch (inputString.IndexOf(result)) {
                case 0:
                    Console.Write("[" + result + "]" + 
                        inputString.Substring(length));
                    break;
                default:
                    Console.Write(inputString.Substring(0,inputString.IndexOf(result[0]))+"["+result+"]"+inputString.Substring(inputString.IndexOf(result[0])+length));
                    break;
            }

            Console.ReadLine(); 
        }
        
        static List<string> getMatchingSubstrings(string inputStr)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < inputStr.Length; i++){
                for (int j = 0; j < inputStr.Length - i+1; j++)
                {
                    if (ContainMembers(inputStr.Substring(i, j))) results.Add(inputStr.Substring(i, j));
                }
            }
            return results;
        }
        static bool ContainMembers(string input)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            bool result = true;
            for (int i=0; i<alphabet.Length; i++)
            { 
                if (!input.Contains(alphabet[i])) result = false;
            }
            return result;
        }
    }
}
