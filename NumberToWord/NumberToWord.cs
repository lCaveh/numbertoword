using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToWord
{
    public class NumberToWord
    {
        private string MainNumber;
        private char[] NumberArray;
        private string MainResult="";
        private char[] Zeroes={'0','0','0'};
        private char[] Thousands={'0','0','0'};
        private char[] Millions={'0','0','0'};
        private char[] Billions={'0','0','0'};
        private char[] ZeroArray={'0','0','0'};




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
            {'9', "nineteen"}
        };
         private Dictionary<char, string> TensDictionary = new Dictionary<char, string>()
        {
            {'0', ""},
            {'1', ""},
            {'2', "twenty "},
            {'3', "thirty "},
            {'4', "fourty "},
            {'5', "fifty "},
            {'6', "sixty "},
            {'7', "seventy "},
            {'8', "eighty "},
            {'9', "ninety "}
        };
        public NumberToWord(string userInput)
        {
            MainNumber=userInput;
        }

        public void FixMainNumber()
        {
          int zeroesNeeded= 12-MainNumber.Length;
          for (int i= 0;i<zeroesNeeded;i++)
          {
            MainNumber="0"+MainNumber;
          }
        }
        public void CreateArrays()
        {
          NumberArray= MainNumber.ToCharArray();
          for (int i=0;i<3;i++)
          {
            Billions[i]= NumberArray[i];
            Millions[i]= NumberArray[i+3];
            Thousands[i]= NumberArray[i+6];
            Zeroes[i]= NumberArray[i+9];
          }

          if (!Billions.SequenceEqual(ZeroArray))
          {
            ChangeToString(Billions);
            MainResult+=" Billion ";
          }
          if (!Millions.SequenceEqual(ZeroArray))
          {
            ChangeToString(Millions);
            MainResult+=" Million ";
          }
          if (!Thousands.SequenceEqual(ZeroArray))
          {
            ChangeToString(Thousands);
            MainResult+=" Thousand ";
          }
          if (!Zeroes.SequenceEqual(ZeroArray))
          {
            ChangeToString(Zeroes);
          }

        }
        public void ChangeToString(char[] threeDigits)
        {
            if (threeDigits[0]!='0')
            {
              MainResult+=OnesPlaceDictionary[threeDigits[0]]+" hundred ";
            }
            if (NumberArray[1]=='1')
            {
              MainResult+=TeensDictionary[threeDigits[2]];
            }
            else
            {
              MainResult+=TensDictionary[threeDigits[1]];
              MainResult+=OnesPlaceDictionary[threeDigits[2]];
            }
        }
        public  string GetResult()
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
            numberToWord.CreateArrays();
            Console.WriteLine(numberToWord.GetResult());
        }
    }

}
