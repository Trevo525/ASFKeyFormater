using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice = 0;
            String accountName = "main";

            while (userChoice != -1)
            {
                Console.WriteLine(PrintOptions());
                userChoice = Convert.ToInt32(Console.ReadLine());
                accountName = performLoop(userChoice, accountName);
            }
            
        }

        static String performLoop(int choice, String accountName)
        {
            switch (choice)
            {
                case -1://Exit.
                    Console.WriteLine("GoodBye!");
                    break;
                case 1://Add a list of keys.
                    Console.WriteLine(ListOfKeys(accountName));
                    break;
                case 2://Add key's one by one.
                    Console.WriteLine(OneKeyAtATime(accountName));
                    break;
                case 3://Remove Spaces from Unused Keys.
                    Console.WriteLine(RemoveSpaces(accountName));
                    break;
                case 4://Change account.
                    accountName = ChangeAccount(accountName);
                    break;
                default://Wrong Input
                    Console.WriteLine("Wrong Input! Try again.");
                    break;
            }
            return accountName;
        }

        static string ChangeAccount(String nameOfAccount)
        {
            Console.WriteLine("Your account name currently is " + nameOfAccount + ".");
            Console.WriteLine("To change your account the options are as follows:");
            Console.WriteLine("-1: custom name\n0: main\nx>= 1: botx");
            int accountChoice = Convert.ToInt32(Console.ReadLine());
            if(accountChoice < -1)
            {
                Console.WriteLine("Wrong input! Value not changed!");
            }
            else
            {
                switch (accountChoice)
                {
                    case -1:
                        Console.Write("Enter your custom name: ");
                        nameOfAccount = Console.ReadLine();
                        break;
                    case 0:
                        nameOfAccount = "main";
                        break;
                    default:
                        nameOfAccount = ("bot" + accountChoice);
                        break;
                }
                Console.WriteLine("Your account name is " + nameOfAccount);
            }

            return nameOfAccount;
        }

        static string RemoveSpaces(String nameOfAccount)
        {
            string keysOutput = "!r " + nameOfAccount + " ";
            Console.Write("Enter the codes to remove the spaces:");
            string keysInput = Console.ReadLine();
            char[] toRemoveSpaces = keysInput.ToCharArray();
            for (int i = 0; i < toRemoveSpaces.Length; i++)
            {
                if (toRemoveSpaces[i] != ' ')
                    keysOutput += toRemoveSpaces[i];
            }
            return keysOutput;
        }

        static string ListOfKeys(String nameOfAccount)
        {
            string keysOutput = "!r " + nameOfAccount + " ";
            Console.Write("Enter your list of keys (leave blank to exit): ");
            string keyInput = Console.ReadLine();
            keysOutput += keyInput;

            while (keyInput != "")
            {
                keyInput = Console.ReadLine();
                if (keyInput != "")
                {
                    keysOutput += "," + keyInput;
                }
            }

            return keysOutput;
        }

        static string OneKeyAtATime(String nameOfAccount)
        {
            string keysOutput = "!r " + nameOfAccount + " ";
            Console.Write("Enter your first key (leave blank to exit): ");
            string keyInput = Console.ReadLine();
            keysOutput += keyInput;

            while (keyInput != "")
            {
                Console.Write("Enter your next key (leave blank to exit): ");
                keyInput = Console.ReadLine();
                if (keyInput != "")
                {
                    keysOutput += "," + keyInput;
                }
            }

            return keysOutput;
        }

        static string PrintOptions()
        {
            //Creates the String to get input from user.
            string menuOptions = "";
            menuOptions = "1. Add a list of keys.\n";
            menuOptions += "2. Add key's one by one.\n";
            menuOptions += "3. Remove Spaces from Unused Keys.\n";
            menuOptions += "4. Change account.\n";
            menuOptions += "-1. Exit.\n";
            menuOptions += "Make a choice: ";
            return menuOptions;//doesn't actually print it out. just returns to caller.
        }
    }
}
