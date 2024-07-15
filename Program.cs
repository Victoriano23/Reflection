using System;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                // Clear the console screen
                Console.Clear();
                // Display selection menu

                Console.WriteLine("***********************************");
                Console.WriteLine("*     KNOW MORE ABOUT YOURSELF    *");
                Console.WriteLine("***********************************");
                Console.WriteLine("*  1. WHATS YOUR ZODIAC SIGN      *");
                Console.WriteLine("*  2. PERSONALITY TEST            *");
                Console.WriteLine("*  3. EQ TEST                     *");
                Console.WriteLine("*  4. EXIT                        *");
                Console.WriteLine("***********************************");
                Console.Write("Enter your choice: ");

                // Read user choice from the console and convert it to an integer
                int choice = int.Parse(Console.ReadLine());

                // Switch statement to handle user's choice
                switch (choice)
                {
                    case 1:
                        zodiacsign(); // Call method to run Zodiac Sign
                        break;
                    case 2:
                        personalitytest(); // Call method to ru personality test
                        break;
                    case 3:
                        EQTEST(); // Call method to run EQ Test
                        break;
                    case 4:
                        Console.Clear(); // Clear the console and exit the program
                        return;
                    default:
                        Console.WriteLine("INVALID CHOICE.");
                        break;
                }
            }

            // Method to run zodiac sign
            static void zodiacsign()
            {
                Console.Clear();
                Console.WriteLine("Enter your birthdate (YYYY-MM-DD):");

                DateTime birthdate;
                if (!DateTime.TryParse(Console.ReadLine(), out birthdate))
                {
                    Console.WriteLine("Invalid date format.");
                    Console.ReadLine();
                    return;
                }

                int age = CalculateAge(birthdate);
                string zodiacSign = GetZodiacSign(birthdate.Month, birthdate.Day);

                Console.WriteLine($"Your age is: {age}");
                Console.WriteLine($"Your zodiac sign is: {zodiacSign}");
                Console.ReadLine();
            }

            static int CalculateAge(DateTime birthdate)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthdate.Year;
                if (birthdate > today.AddYears(-age))
                    age--;
                return age;
            }

            // Function to determine zodiac sign based on month and day
            static string GetZodiacSign(int month, int day)
            {
                if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                    return "Aries";
                else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                    return "Taurus";
                else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                    return "Gemini";
                else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                    return "Cancer";
                else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                    return "Leo";
                else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                    return "Virgo";
                else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                    return "Libra";
                else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                    return "Scorpio";
                else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                    return "Sagittarius";
                else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                    return "Capricorn";
                else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                    return "Aquarius";
                else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
                    return "Pisces";
                else
                    return "Unknown";
            }


            // Method to play personality test
            static void personalitytest()
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Personality Type Quiz!");
                Console.WriteLine("For each statement, enter a number from 1 to 5 based on how well it describes you.");
                Console.WriteLine("1: Strongly Disagree");
                Console.WriteLine("2: Disagree");
                Console.WriteLine("3: Neutral");
                Console.WriteLine("4: Agree");
                Console.WriteLine("5: Strongly Agree");

                string[] Questions = {
            "Do You feel energized after spending time with a large group of people.",
            "Do You prefer one-on-one conversations over group activities.",
            "Do You enjoy spending time alone to recharge.",
            "Do You feel comfortable being the center of attention in social situations.",
            "Do You find it easy to strike up a conversation with new people.",
            "Do You prefer a few close friends over many acquaintances.",
            "Do You tend to think before I speak.",
            "Do You often feel lonely if I don't have social interaction for a while.",
            "Do You enjoy participating in group activities and events.",
            "Do You find it exhausting to be in social settings for long periods of time."
        };

                int[] responses = new int[Questions.Length];

                // Ask Questions
                for (int i = 0; i < Questions.Length; i++)
                {
                    Console.WriteLine($"\nQuestion {i + 1}: {Questions[i]}");
                    responses[i] = GetValidResponse();
                }

                // Calculate total score
                int totalScore = CalculateTotalScore(responses);

                // Determine personality type based on score
                string personalityType = DeterminePersonalityType(totalScore);

                // Displays Personanlity Description
                string personalityDescription = ExplainPersonalityDescription(totalScore);

                // Output results
                Console.Clear();
                Console.WriteLine("\nPersonality Type Quiz Results:");
                Console.WriteLine($"Total Score: {totalScore}");
                Console.WriteLine($"Personality Type: {personalityType}");
                Console.WriteLine($"Personality Description: {personalityDescription}");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine(); // Keep console open until user input
            }

            // Function to ensure valid response (1-5)
            static int GetValidResponse()
            {
                int response;
                while (!int.TryParse(Console.ReadLine(), out response) || response < 1 || response > 5)
                {
                    Console.WriteLine("Please enter a number between 1 and 5.");
                }
                return response;
            }

            // Function to calculate total score
            static int CalculateTotalScore(int[] responses)
            {
                int totalScore = 0;
                foreach (int response in responses)
                {
                    totalScore += response;
                }
                return totalScore;
            }

            // Function to determine personality type score
            static string DeterminePersonalityType(int totalScore)
            {
                if (totalScore >= 10 && totalScore <= 24)
                {
                    return "Introvert";
                }
                else if (totalScore >= 25 && totalScore <= 34)
                {
                    return "Ambivert";
                }
                else if (totalScore >= 35 && totalScore <= 50)
                {
                    return "Extrovert";
                }
                else
                {
                    return "Unknown";
                }
            }

            // Function to explain personality description based on total score
            static string ExplainPersonalityDescription(int totalScore)
            {
                if (totalScore >= 10 && totalScore <= 24)
                {
                    return "You are someone who feels energized by the external world and social interactions.";
                }
                else if (totalScore >= 25 && totalScore <= 34)
                {
                    return "You are a flexible individual who thrives both in solitude and company, and you make a great communicator and listener.";
                }
                else if (totalScore >= 35 && totalScore <= 50)
                {
                    return "You are very talkative, sociable, active, and warm.";
                }
                else
                {
                    return "Personality type cannot be determined with provided answers.";
                }
            }

            // Method to start EQ test
            static void EQTEST()
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Emotional Intelligence Test!");
                Console.WriteLine("Answer each question to scale how good is your emotional quotient.");
                Console.WriteLine("Please enter 1, 2, 3, 4, or 5 based on how well you think each statement applies to you.");
                Console.WriteLine("1: Strongly Disagree");
                Console.WriteLine("2: Disagree");
                Console.WriteLine("3: Neutral");
                Console.WriteLine("4: Agree");
                Console.WriteLine("5: Strongly Agree");

                string[] questions = {
                "I can recognize my own emotions as they happen.",
                "I am able to control my temper and not let anger get the best of me.",
                "I am good at understanding how others are feeling based on their body language and tone of voice.",
                "I am able to effectively manage stress and bounce back from setbacks.",
                "I find it easy to build and maintain positive relationships with others.",
                "I am able to empathize with others and understand their perspective.",
                "I am good at motivating myself to achieve goals, even when faced with obstacles.",
                "I am comfortable expressing my emotions in a healthy manner.",
                "I can handle criticism and feedback constructively.",
                "I am good at resolving conflicts with others."
            };

                int[] responses = new int[questions.Length];

                // Ask questions
                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine($"\nQuestion {i + 1}: {questions[i]}");
                    responses[i] = GetValidResponse();
                }

                // Calculate total score
                int totalScore = CalculateTotalScore(responses);

                // Determine EQ level based on score
                string eqLevel = DetermineEQLevel(totalScore);

                // Display EQ description
                string eqDescription = ExplainEQDescription(totalScore);

                // Output results
                Console.Clear();
                Console.WriteLine("\nEmotional Intelligence Test Results:");
                Console.WriteLine($"Total Score: {totalScore}");
                Console.WriteLine($"EQ Level: {eqLevel}");
                Console.WriteLine($"EQ Description: {eqDescription}");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine(); // Keep console open until user input
            }

            // Function to determine EQ level based on score
            static string DetermineEQLevel(int totalScore)
            {
                if (totalScore >= 40 && totalScore <= 50)
                {
                    return "High";
                }
                else if (totalScore >= 30 && totalScore <= 39)
                {
                    return "Moderate";
                }
                else if (totalScore >= 20 && totalScore <= 29)
                {
                    return "Below Average";
                }
                else if (totalScore >= 10 && totalScore <= 19)
                {
                    return "Low";
                }
                else
                {
                    return "Unknown";
                }
            }

            // Function to explain EQ description based on total score
            static string ExplainEQDescription(int totalScore)
            {
                if (totalScore >= 40 && totalScore <= 50)
                {
                    return "You have a high level of emotional intelligence.";
                }
                else if (totalScore >= 30 && totalScore <= 39)
                {
                    return "You have a moderate level of emotional intelligence.";
                }
                else if (totalScore >= 20 && totalScore <= 29)
                {
                    return "You have a below average level of emotional intelligence.";
                }
                else if (totalScore >= 10 && totalScore <= 19)
                {
                    return "You have a very low level of emotional intelligence.";
                }
                else
                {
                    return "Emotional intelligence level cannot be determined with provided answers.";
                }
            }
        }
    }
}
