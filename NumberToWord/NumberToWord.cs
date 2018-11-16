using System;
using System.Collections.Generic;

namespace NumberToWord
{
    public class NumberToWord
    {
        private string MainNumber;
        private char[] NumberArray;
        private string MainResult="";
        private Dictionary<char, string> OnesPlaceDictionary = new Dictionary<char, string>()
        {
            {'0', ""},
            {'1', "one"},
            {'2', "two"},
            {'3', "three"},
            {'4', "four"},
            {'5', "five"},
            {'6', "six"},
            {'7', "seven"},
            {'8', "eight"},
            {'9', "nine"}
        };
        private Dictionary<char, string> TeensDictionary = new Dictionary<char, string>()
        {
            {'0', "ten"},
            {'1', "eleven"},
            {'2', "twelve"},
            {'3', "thirteen"},
            {'4', "fourteen"},
            {'5', "fifteen"},
            {'6', "sixteen"},
            {'7', "seventen"},
            {'8', "eighteen"},
            {'9', "nineteen"};
        };
         private Dictionary<char, string> TensDictionary = new Dictionary<char, string>()
        {
            {'0', ""},
            {'1', ""},
            {'2', "twenty"},
            {'3', "thirty"},
            {'4', "fourty"},
            {'5', "fifty"},
            {'6', "sixty"},
            {'7', "seventy"},
            {'8', "eighty"},
            {'9', "ninety"};
        };
        public NumberToWord(string userInput)
        {
            MainNumber=userInput;
        }

        public void FixMainNumber()
        {
            if (MainNumber.Count%3=1)
            {
                MainNumber="00"+MainNumber;
            }
            else if (MainNumber.Count%3=2)
            {
                MainNumber="0"+MainNumber;
            }
        }
        public void ChangeToString()
        {
            string resultPart="";
            char[] NumberArray= MainNumber.ToCharArray();
            resultPart+=OnesPlaceDictionary[NumberArray[0]]+"hundred";
            resultPart+=TensDictionary[NumberArray[1]];
            if (NumberArray[1]=='1')
            {
                resultPart+=TeensDictionary[NumberArray[2]];
            }
            else
            {
                resultPart+=OnesPlaceDictionary[NumberArray[2]];
            }
            MainResult= resultPart;
        }
        public GetResult()
        {
            return MainResult;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("please Enter a Number");
            string userInput= Console.ReadLine();
            NumberToWord numberToWord=new NumberToWord(userInput);
            numberToWord.FixMainNumber();
            numberToWord.ChangeToString();
            Console.WriteLine(numberToWord.GetResult());
        }
    }

}