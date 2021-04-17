using System;
using System.Threading.Tasks;

namespace Assignment7
{
    public class Program
    {

        //if....else case 
        public string UserLogin(string email, string password)
        {
            if (email == "prijitha@gmail.com" && password == "Prijitha")
                return "Welcome User";
            else
            {
                return "Your credentials dont match our records!";
            }
        }

        //switch case
        public string SelectDay(int choiceNumber)
        {
            string day = "";
            switch (choiceNumber)
            {
                case 1:
                    day = "Sunday";
                    break;
                case 2:
                    day = "Monday";
                    break;
                case 3:
                    day = "Tuesday";
                    break;
                case 4:
                    day = "Wednesday";
                    break;
                case 5:
                    day = "Thursday";
                    break;
                case 6:
                    day = "Friday";
                    break;
                case 7:
                    day = "Saturday";
                    break;
                default:
                    day = "You have selected an invalid day";
                    break;
            }
            return day;
        }

        //foreach ....
        public int[] GenderCount()
        {
            char[] gender = { 'm', 'f', 'f', 'f', 'm', 'm', 'f', 'm','f','f' };
            int[] count = new int[2];
            int male = 0, female = 0;
           
            foreach(char g in gender)
            {
                if (g == 'm')
                    male++;
                else if (g == 'f')
                    female++;
            }
            count[0] = male;
            count[1] = female;
            return count;
        }

        //while loop.....
        public int SumOfNumbers(int n)
        {
            if (n >= 0)
            {
                int i = 1, sum = 0;
                while (i <= n)
                {
                    sum += i;
                    i++;
                }
                return sum;
            }
            else
                throw new NullReferenceException("Number is Negative");        //Exception is thrown
            
        }

        //for loop....
        public int FindCube(int n)
        {
            int i, cube =0 ;
            for (i = 1; i <= n; i++)
            {
                cube = i * i * i;
            }
            return cube;
        }

        //Divide by Zero Exception
        public int DivisionOfNumbers(int num1, int num2)
        {
            try
            {
                return num1 / num2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new DivideByZeroException("Divide By Zero Exception thrown");
            }
        }

        //Index Out Of Bound Exception 
        public int ArrayIndexOutOfBound()
        {
            try
            {
                int[] ar = { 1, 2, 3, 4, 5 };

                // causing exception
                for (int i = 0; i <= ar.Length; i++)
                    Console.WriteLine(ar[i]);
                return ar[5];
            }
            catch (Exception)
            {

                throw new IndexOutOfRangeException("Array Running Out of Index Bound");
            }
        }

        //Async Method
        public async Task<int> Addition(int num1, int num2)
        {
            return num1 + num2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}