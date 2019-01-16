//Created by Kent Butler
//Created on 1/16/2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Guess a Number Game!");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++");
            Console.WriteLine(" ");
            do
            {
                int pcValue, timesGuessed, userValue;
                Random rand = new Random();
                pcValue = rand.Next(101);
                timesGuessed = 0;
                Console.WriteLine("I'm thinking of a number between 1 and 100");
                do
                {
                    timesGuessed++;
                    userValue = ValidInteger();
                    PCResponse(pcValue, userValue);

                } while (pcValue!=userValue);

                WinResponse(timesGuessed);

            } while (RunAgain());

        }

        private static void WinResponse(int timesGuessed)
        {
            if (timesGuessed < 5)
            {
                Console.WriteLine("Woah! Great job! You got the answer in "
                    + timesGuessed + " tries.");
            }
            else if (timesGuessed < 10)
            {
                Console.WriteLine("Acceptable job, but it took you " + timesGuessed + " tries.");
            }
            else if (timesGuessed < 15)
            {
                Console.WriteLine("Better luck next time. It took you " + timesGuessed + " tries.");
            }
            else
            {
                Console.WriteLine("Are you even trying? It took you " + timesGuessed + " tries.");
            }
        }

        private static void PCResponse(int pcValue, int userValue)
        {
            int difference = Math.Abs(pcValue - userValue);
            if (difference == 0)
            {
                Console.WriteLine("Congrats! You got it!");
            }
            else if (difference > 10)
            {
                if ((pcValue - userValue) < 0)
                {
                    Console.WriteLine("You are way too high!");
                }
                else
                {
                    Console.WriteLine("You are way too low!");
                }

            }
            else
            {
                if ((pcValue - userValue) < 0)
                {
                    Console.WriteLine("Close but you are a little too high.");
                }
                else
                {
                    Console.WriteLine("Close but you are a little too low!");
                }
            }
        }

        public static int ValidInteger()
        {
            String input;
            bool validInput;
            int inputNum;

            Console.Write("Please Enter a number: ");

            do
            {
                input = Console.ReadLine();
                validInput = int.TryParse(input, out inputNum);
                if (!validInput)
                {
                    Console.WriteLine("Please type a valid Number");
                    validInput = false;
                }
                else if (inputNum > 100)
                {
                    Console.WriteLine("Please type a number less than a hundred.");
                    validInput = false;
                }
                else if (inputNum < 1)
                {
                    Console.WriteLine("Please type a number greater than zero.");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);

            return inputNum;
        }

        private static bool RunAgain()
        {
            string input;
            bool correctRespone = true;
            while (correctRespone)
            {
                Console.Write("Would you like to run the application again? (y/n):");
                input = Console.ReadLine().ToLower();
                if (String.Equals("n", input))
                {
                    correctRespone = false;
                    Console.WriteLine("Goodbye.");
                    return false;
                }
                else if (String.Equals("y", input))
                {
                    Console.WriteLine("Starting Over.");
                    correctRespone = false;
                    return true;
                }
                else
                {
                    Console.WriteLine("That is an invalid entry!");
                    continue;
                }
            }
            return false; //should never get hit needed to make it happy.
        }
    }
}
