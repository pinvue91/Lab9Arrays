using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;

            //Lists of Student Info
            List<string> studentName = new List<string>()
            {
                "Pin", "Bob", "Sue", "Lauren", "Phil", "Lindsey", "Juan", "Jim", "Shai",
                "Belle", "Lou", "LeBron", "Kobe", "Michael", "Brad", "William", "Smith", "Joey", "Shyu", "Kyrie"
            };

            List<string> homeTown = new List<string>()
            {
                "Lansing", "Detroit", "Pontiac", "Warren", "Waterloo", "Kansas City", "Austin", "Louisville",
                "Duluth", "Grand Haven", "Grand Rapids", "Muskegon", "Auburn Hills", "Rochester", "St. Clair", "St. Louis",
                "Los Angeles", "Dallas", "Houston", "Atlanta"
            };

            List<string> favoriteFoods = new List<string>()
            {
                "Fried Rice", "Pizza", "Yogurt", "Bannanas", "Apples", "Oranges", "Pears", "Burgers",
                "Sushi", "Lettuce", "Tacos", "Fries", "Cheese", "Chips", "Salads","Spinach", "Pancakes", "Cereal", "Waffles", "Pasta"
            };

            List<string> favoriteColor = new List<string>()
            {
                "red", "blue", "yellow", "green", "orange", "black", "white", "beige", "purple", "pink", "mauve",
                "navy blue", "forest green", "grey", "poop brown", "red", "red", "red", "black", "white"
            };

            List<string> favoriteSport = new List<string>()
            {
                 "basketball", "football", "hockey", "baseball", "soccer", "bowling", "swimming", "basketball",
                "football", "hockey", "baseball", "soccer", "bowling", "swimming", "basketball", "football", "hockey", "baseball", "soccer", "bowling"
            };

            
            
            Console.WriteLine("Welcome to our C# class!");

            while (runProgram)
            {
              
                //prompt user
                string inputChoice = GetUserInput("\nWould you like to: \n\n1)find out information about a student \n\nor \n\n2)add another student to the database \n\nPlease enter 1 or 2: ");
                inputChoice = ValidateUserChoice(inputChoice, "Sorry, that is not an option!\nPlease choose 1 or 2.");

                //learn about students
                if(inputChoice =="1")
                {
                    try
                    {
                        Console.Clear();
                        int numOfStudents = studentName.Count;
                        int inputNumber = int.Parse(GetUserInput($"Which student would you like to learn more about? (enter a number from 1-{numOfStudents}): "));

                        Console.WriteLine($"Student {inputNumber} is {studentName[inputNumber - 1]}. What would you like to know about {studentName[inputNumber - 1]}? (enter hometown, favorite food, favorite color, or favorite sport)? ");

                        string userInterst = Console.ReadLine().ToLower().Trim();
                        userInterst = ValidateUserInterest(userInterst, "\nSorry, that data doesn't exist. Enter hometown, favorite food, favorite color, or favorite sport.");

                        if (userInterst == "hometown")
                        {
                            Console.WriteLine($"\n{studentName[inputNumber - 1]}'s hometown is {homeTown[inputNumber - 1]}.");
                        }
                        else if (userInterst == "favorite food")
                        {
                            Console.WriteLine($"\n{studentName[inputNumber - 1]}'s favorite food is {favoriteFoods[inputNumber - 1]}.");
                        }
                        else if (userInterst == "favorite color")
                        {
                            Console.WriteLine($"\n{studentName[inputNumber - 1]}'s favorite color is {favoriteColor[inputNumber - 1]}.");
                        }
                        else if (userInterst == "favorite sport")
                        {
                            Console.WriteLine($"\n{studentName[inputNumber - 1]}'s favorite sport is {favoriteSport[inputNumber - 1]}.");
                        }

                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! Please enter a number next time!");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("\nSorry, that student does not exist.");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("\nSorry, that student does not exist.");
                    }

                }


                //create new student
                else if(inputChoice =="2")
                {
                    Console.Clear();
                    string newStudentName = GetUserInput("What is the name of the student you'd like to add? ");
                    newStudentName = ValidateNotEmptyAnswer(newStudentName, "You didn't enter a name!\nPlease enter a student name to add: ");
                    studentName.Add(newStudentName);

                    string newHomeTown = GetUserInput($"Where is {newStudentName}'s hometown? ");
                    newHomeTown = ValidateNotEmptyAnswer(newHomeTown, $"You didn't enter a hometown!\nPlease enter {newStudentName}'s hometown: ");
                    homeTown.Add(newHomeTown);

                    string newFavoriteFood = GetUserInput($"What is {newStudentName}'s favorite food? ");
                    newFavoriteFood = ValidateNotEmptyAnswer(newFavoriteFood, $"You didn't enter a food!\nPlease enter {newStudentName}'s favorite food: ");
                    favoriteFoods.Add(newFavoriteFood);

                    string newFavoriteColor = GetUserInput($"What is {newStudentName}'s favorite color? ");
                    newFavoriteColor = ValidateNotEmptyAnswer(newFavoriteColor, $"You didn't enter a color!\nPlease enter {newStudentName}'s favorite color: ");
                    favoriteColor.Add(newFavoriteColor);

                    string newFavoriteSport = GetUserInput($"What is {newStudentName}'s favorite sport? ");
                    newFavoriteSport = ValidateNotEmptyAnswer(newFavoriteSport, $"You didn't enter a sport!\nPlease enter {newStudentName}'s favorite sport: ");
                    favoriteSport.Add(newFavoriteSport);

                }

                runProgram = ValidateContinue("\nWould you like to continue? (y/n) ");
                Console.Clear();
            }

        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string UserInput = Console.ReadLine().ToLower().Trim();
            return UserInput;
        }

        public static string ValidateUserChoice(string UserChoice, string message)
        {
            while (UserChoice != "1" && UserChoice != "2")
            {
                Console.WriteLine(message);
                UserChoice = Console.ReadLine().ToLower().Trim();
            }
            return UserChoice;

        }

        public static string ValidateNotEmptyAnswer(string UserInput, string message)
        {
            while (UserInput == "" || UserInput == null || UserInput == " ")
            {
                Console.WriteLine(message);
                UserInput = Console.ReadLine().ToLower().Trim();
            }
            return UserInput;

        }

        public static string ValidateUserInterest(string UserInterest, string message)
        {
            while (UserInterest != "hometown" && UserInterest != "favorite food" && UserInterest != "favorite color" && UserInterest != "favorite sport")
            {
                Console.WriteLine(message);
                UserInterest = Console.ReadLine().ToLower().Trim();
            }
            return UserInterest;

        }


        public static bool ValidateContinue(string message)
        {
            Console.WriteLine(message);

            string userInput = Console.ReadLine().ToLower();

            while (userInput != "y" && userInput != "n")
            {
                Console.WriteLine($"Invalid answer!\n{message}");
                userInput = Console.ReadLine().ToLower();
            }

            if (userInput == "y")
            {
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thank you. Have a nice day!");
                return false;
            }

        }
    }
}
