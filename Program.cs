using System;
using System.Text.RegularExpressions;

namespace testBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Create By CxzLabel");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please input mode  (encrypt or decrypt)");
            Console.ForegroundColor = ConsoleColor.Gray;
            string type = Console.ReadLine();
            if (type == "encrypt")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("enter ENCRYPT Mode");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter the context");
                Console.ForegroundColor = ConsoleColor.Gray;
                string context = Console.ReadLine();
                if (context.Length % 2 != 0)
                {
                    Console.WriteLine("The length of context can not be an odd number");
                    return;
                }
                if (Regex.IsMatch(context, @"^(?![^0-9]+$).+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The cipherText cannot contain numbers");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter the key1");
                Console.ForegroundColor = ConsoleColor.Gray;
                string key1 = Console.ReadLine();
                if (Regex.IsMatch(key1, @"^(?![^0-9]+$).+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The key1 cannot contain numbers");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter the key2");
                Console.ForegroundColor = ConsoleColor.Gray;
                string key2 = Console.ReadLine();
                if (Regex.IsMatch(key2, @"^(?![^0-9]+$).+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The key2 cannot contain numbers");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter the limit char");
                Console.ForegroundColor = ConsoleColor.Gray;
                string tempChar = Console.ReadLine();
                char deleteChar;
                if (tempChar.Length == 1)
                {
                    deleteChar = Convert.ToChar(tempChar);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Limit the letter must be one");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                Console.WriteLine();
                binaryConverter.ENCRYPT(context, key1, key2, deleteChar);
            }
            else if (type == "decrypt")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("enter DECRYPT Mode");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter the cipherText");
                Console.ForegroundColor = ConsoleColor.Gray;
                string cipherText = Console.ReadLine();
                if (cipherText.Length % 2 != 0)
                {
                    Console.WriteLine("The length of encrypted content can not be an odd number");
                    return;
                }
                if (Regex.IsMatch(cipherText, @"^(?![^0-9]+$).+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The cipherText cannot contain numbers");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter the key1");
                Console.ForegroundColor = ConsoleColor.Gray;
                string key1 = Console.ReadLine();
                if (Regex.IsMatch(key1, @"^(?![^0-9]+$).+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The key1 cannot contain numbers");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter the key2");
                Console.ForegroundColor = ConsoleColor.Gray;
                string key2 = Console.ReadLine();
                if (Regex.IsMatch(key2, @"^(?![^0-9]+$).+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The key2 cannot contain numbers");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please enter the limit char");
                Console.ForegroundColor = ConsoleColor.Gray;

                string tempChar = Console.ReadLine();
                char deleteChar;
                if (tempChar.Length == 1)
                {
                    deleteChar = Convert.ToChar(tempChar);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Limit the letter must be one");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                Console.WriteLine();
                binaryConverter.DECRYPT(cipherText, key1, key2, deleteChar);
            }
        }
    }
}