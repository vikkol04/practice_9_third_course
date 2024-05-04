using System;
namespace ConsoleApp1
{
    internal class KolokolnikovVar4
    {
        public class InvalidNameException : Exception
        {
            private static int count = 0;

            public static int GetCount()
            {
                return count;
            }

            public InvalidNameException(string message) : base(message)
            {
                count++;
            }
        }

        static void ValidateName(string name)
        {
            string message = "";
            if (char.IsLower(name[0]))
            {
                message += "Names are capitalized. ";
            }
            if (name.Substring(1).ToLower() != name.Substring(1))
            {
                message += "All letters of the name except the first letter must be small. ";
            }
            if (message != "")
            {   
                throw new InvalidNameException(message);
            }
        }

        static void Main (string[] args)
        {
            Console.WriteLine($"\n\nKolokolnikov. --------------------------------------------------------\n");
            Console.ReadLine();
            while (true)
            {
                try 
                {
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine().Trim();
                    if (name == "") break;
                    ValidateName(name);
                }
                catch (InvalidNameException ex)
                {
                    Console.WriteLine($"InvalidNameException: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"To finish, press enter. You have {InvalidNameException.GetCount()} error.");
                }
            }
            Console.ReadLine();

        }
    }
}
