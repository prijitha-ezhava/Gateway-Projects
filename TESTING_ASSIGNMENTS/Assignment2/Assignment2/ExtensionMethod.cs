using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Assignment2
{
    public static class ExtensionMethod
    {

        //Return a string of lowercase to uppercase.
        public static string ConvertToUpperCase(this string inputString)
        {
            if (inputString.Length > 0)
            {
                return inputString.ToUpper();
            }
            return inputString;
        }

        //Return a string of uppercase to lowercase.
        public static string ConvertToLowerCase(this string inputString)
        {
            if (inputString.Length > 0)
            {
                return inputString.ToLower();
            }
            return inputString;
        }

        //Return a string to titlecase.
        public static string ConvertToTitleCase(this string inputString)
        {
            if (inputString.Length > 0)
            {
                TextInfo text = new CultureInfo("en-US", false).TextInfo;
                inputString = text.ToTitleCase(inputString.ToLower());
                return new string(inputString);
            }
            return inputString;
        }

        //Find if all the characters of a string is in Lower case.
        public static bool HasAllLowerCase(this string inputString)
        {
            string Mystring = inputString;
            char[] chars;
            char ch;
            int length = Mystring.Length;
            int i;
            int totalCntLower = 0;

            chars = Mystring.ToCharArray(0, length);
            for (i = 0; i < length; i++)
            {
                ch = chars[i];
                if (char.IsLower(ch))
                {
                    totalCntLower++;
                }
            }
            if (totalCntLower == length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Return a capitalized version of given input string.
      /*  public static string ConvertFirstLetterToUpper(this string inputString)
        {
            if (inputString.Length > 0)
            {
                char[] charArray = inputString.ToCharArray();
                charArray[0] = char.IsUpper(charArray[0]) ? char.ToLower(charArray[0]) : char.ToUpper(charArray[0]);
                return new string(charArray);
            }
            return inputString;
        }*/

        public static string CapitalizeString(this string inputString)
        {
            //return string.ToUpper(inputString[0]) + inputString.Substring(1);
            return inputString.First().ToString().ToUpper() + inputString.Substring(1).ToLower();
        }


        //Find if all the characters of a string is in upper case.
        public static bool HasAllUpperCase(this string inputString)
        {
            string Mystring = inputString;
            char[] chars;
            char ch;
            int length = Mystring.Length;
            int cnt;
            int totalcntupper = 0;

            chars = Mystring.ToCharArray(0, length);
            for (cnt = 0; cnt < length; cnt++)
            {
                ch = chars[cnt];
                if (char.IsUpper(ch))
                {
                    totalcntupper++;
                }
            }
            if (totalcntupper == length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Function to identify whether given input string can be converted to a valid numeric value or not.
        public static bool IsValidNumeric(this string inputString)
        {
            int num = 0;
            return int.TryParse(inputString, out num);
        }


        //Function to remove the last character from given the string
        public static string RemoveLastCharacter(this string inputString)
        {
            return inputString.Remove(inputString.Length - 1, 1);
        }

        //Get the word count from an input string
        public static int WordCount(this string inputString)
        {
            int i = 0, wordCount = 1;
            while (i <= inputString.Length - 1)
            {
                if(inputString[i] == ' '|| inputString[i]=='\n' || inputString[i] == '\t')
                {
                    wordCount++;
                }
                i++;
            }
            return wordCount;
        }

        //Convert an input string to integer.
        public static int ConvertStringToInteger(this string inputString)
        {
            int result;
            if (!int.TryParse(inputString,out result))
            {
                return result = 0 ;
            }
            else
                return result;

        }
    }
}
