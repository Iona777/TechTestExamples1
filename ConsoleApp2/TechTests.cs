using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    public class TechTests
    {
        public static void Main(string[] args)
        {
            int number;
            int x, y;
            int numberToReverse;

            Console.WriteLine("Enter a number");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("Factorial of given number is " + factorial(number));
            Console.WriteLine("Factorial of given number via recursion is " + factorialRecursion(number));
            Console.WriteLine("Factorial of given number via while loop is " + factorialWhile(number));

            Console.WriteLine("Enter first number to swap");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number to swap");
            y = int.Parse(Console.ReadLine());
            swapNumbers(x, y);

            Console.WriteLine("Enter value to reverse");
            numberToReverse = int.Parse( Console.ReadLine());
            Console.WriteLine("Reversed number is " + reverseNumber(numberToReverse));



            String input1 = "{()}";
            Console.WriteLine("Checking balanced paranthesis for input:" + input1);

            if (isBalanced(input1))
            {
                Console.WriteLine("Given String is balanced");
            }
            else
            {
                Console.WriteLine("Given String is not balanced");
            }


        }


        public static void swapNumbers(int x, int y)
        {
            Console.WriteLine("Values before swap " + x + " and " + y);

            //Swapping numbers without using a 3rd variable
            //First store the sum of the numbers in the first variable
            x = x + y;
            //Subtract second from sum, to get the first number and store in second numbeer
            y = x - y;
            //Subtract the first (now stored in second) from the sum to tget the second numer and store in first number
            x = x - y;

            Console.WriteLine("Value after swap is "+ x+ " and " +y);

        }


        //This is version from googling
        public static int reverseNo(int number)
        {
            int reversed = 0;

            while (number != 0)
            {
                int digit = number % 10; 
                reversed = reversed * 10 + digit;
                number /= 10;
            }
            return reversed;
        }

        //This is version I understand better
        public static int reverseNumber(int number)
        {
            String valueAsString = number.ToString();
            char[] charArray = valueAsString.ToCharArray();
            int[] intArray = new int[charArray.Length];
            int reversedNum;

            //Could just reverse the  charArray and return that
            //But if we want an actual integer returned, need to do more work

            for (int i = 0; i < charArray.Length; i++)
            {
                intArray[i] = int.Parse(charArray[i].ToString());
            }

            //Reverses the array
            Array.Reverse(intArray);


            if (Int32.TryParse(string.Join("", intArray), out reversedNum)) 
                    return reversedNum;
            else
                throw new Exception("Integer Conversion failed");

        }


        public static double factorial(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Negative nos can't have factorial");
                return -9999;
            }

            int fact = number;
            for (int i = number-1; i >= 1; i--)
            {
                fact = fact * i;
            }


            return fact;
        }

        public static double factorialRecursion(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Negative nos can't have factorial");
                return -9999;
            }

            if (number == 1)
                return 1;
            else
                return number * factorialRecursion(number - 1);
        }

        public static double factorialWhile(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Negative nos can't have factorial");
                return -9999;
            }

            double fact = 1;
            while(number !=1)
            {
                fact = fact * number;
                number--;
            }
            return fact;

        }


        public static Boolean isBalanced(String inputString)
        {
            Stack<Char> stack = new Stack<char>();

            for (int i = 0; i < inputString.Length; i++)
            {
                switch(inputString[i])
                {
                    case '[':
                    case '(':
                    case '{':
                        stack.Push(inputString[i]);
                        break;
                    case ']':
                        if (stack.Count==0 || !stack.Pop().Equals('['))
                        {
                            return false;
                        }
                        break;

                    case '}':
                        if (stack.Count == 0 || !stack.Pop().Equals('{'))
                        {
                            return false;
                        }
                        break;

                    case ')':
                        if (stack.Count == 0 || !stack.Pop().Equals('('))
                        {
                            return false;
                        }
                        break;
                }
            }
            return stack.Count == 0;
        }
    }
}
