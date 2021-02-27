using System;

namespace Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {

            string inputString = "prijitha";

            

            //Return a string of lowercase to uppercase.
            string outputString = ExtensionMethod.ConvertToUpperCase(inputString);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Lower String " + "\"" + inputString + "\"" + " to Upper Case : " + outputString);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(" ");


            //Return a string of uppercase to lowercase.
            inputString = "PRIJITHA";
            string output = ExtensionMethod.ConvertToLowerCase(inputString);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Upper String " + "\"" + inputString + "\"" + " to Lower Case : " + output);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(" ");

            //Return a string to titlecase.
            inputString = "prijitha ezhava";
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Upper String " + "\"" + inputString + "\"" + " to Lower Case : " + ExtensionMethod.ConvertToTitleCase(inputString));
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(" ");

            //Find if all the characters of a string is in Lower case.
            inputString = "prijitha";
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("The string " + "\"" + inputString + "\"" + " is in Lower Case : " + ExtensionMethod.HasAllLowerCase(inputString));
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(" ");


            //Return a capitalized version of given input string
            string result = ExtensionMethod.ConvertFirstLetterToUpper(inputString);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("First Letter of " + "\"" + inputString + "\"" + " to Upper Case : " + result);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(" ");

            //Find if all the characters of a string is in upper case.
            inputString = "PRIJITHA";
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("The string " + "\"" + inputString + "\"" + " is in Upper Case : " + ExtensionMethod.HasAllUpperCase(inputString));
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(" ");

            //Function to identify whether given input string can be converted to a valid numeric value or not.
            string num = "P249";
            Console.WriteLine("---------------------------------------------------------------");
            if (num.IsValidNumeric() == true)
                Console.WriteLine("\"" + num + "\" is a valid numeric value");
            else
                Console.WriteLine("\"" + num + "\" is not a valid numeric value");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(" ");

            //Function to remove the last character from given the string
            inputString = "Prijitha";
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("The string after removing the last character from " + "\"" + inputString + "\"" + " is : " + ExtensionMethod.RemoveLastCharacter(inputString));
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine(" ");

            //Get the word count from an input string
            inputString = "Prijitha Unnikrishnan Ezhava";
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("The number of words in  " + "\"" + inputString + "\"" + " are : " + ExtensionMethod.WordCount(inputString));
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine(" ");

            //Convert an input string to integer.
            Console.WriteLine("-------------------------------------------------------------------------------");
            if (num.ConvertStringToInteger() == null)
                Console.WriteLine("\"" + num + "\" can not be converted from String to Integer");
            else
                Console.WriteLine("The numeric value is : " + num.ConvertStringToInteger());
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine(" ");
        }
    }
}
