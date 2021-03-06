using System;

namespace CapsuleHotel
{
    class MainClass
    {
        static void Main()
        {
            string[] capsules = SetCapacity();
            bool displayMenu = true;

            while (displayMenu)
            {

                switch (MainMenu())
                {
                    case "1":
                        capsules = CheckIn(capsules);
                        break;
                    case "2":
                        capsules = CheckOut(capsules);
                        break;
                    case "3":
                        ViewGuests(capsules);
                        break;
                    case "4":
                        displayMenu = ExitMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Choose an option [1-4]");
                        Console.WriteLine();
                        break;

                }
            }

        }

        static string MainMenu()
        {
            Console.Write(@"Guest Menu
==========
1. Check In
2. Check Out
3. View Guests
4. Exit
 Choose an option [1-4]: ");

            return Console.ReadLine();

        }

        static string[] SetCapacity()
        {
            Console.Write(@"Welcome to Capsule-Capsule.
===========================
Enter the number of capsules available: ");

            int capacity = int.Parse(Console.ReadLine());
            string[] capsules = new string[capacity];
            Console.WriteLine($"There are {capacity} unoccupied capsules ready to be booked.");
            Console.WriteLine();
            return capsules;
        }

        static string[] CheckIn(string[] guestList)
        {
            Console.Clear();
            Console.Write(@"Guest Check In
==============
Guest Name: ");
            string newGuest = Console.ReadLine();

            bool checking = true;
            while (checking)
            {

                Console.Write($"Capsule #[1 - {guestList.Length}]: ");
                int capsuleNum = int.Parse(Console.ReadLine());

                if (capsuleNum <= 0 || capsuleNum > guestList.Length)
                {
                    Console.WriteLine("Invalid capsule number.");
                }
                else if (guestList[capsuleNum - 1] == null)
                {
                    guestList[capsuleNum - 1] = newGuest;
                    Console.WriteLine("Success :)");
                    Console.WriteLine($"{newGuest} is booked in Capsule #{capsuleNum}.");
                    checking = false;
                }
                else
                {
                    Console.WriteLine("Error :(");
                    Console.WriteLine($"Capsule #{capsuleNum} is occupied.");
                }
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return guestList;
        }

        static string[] CheckOut(string[] guestList)
        {
            Console.Clear();
            //if all capsules are empty, then exit check out menu
            if (CheckIfEmpty(guestList))
            {
                Console.WriteLine(@"Guest Check Out
===============");
                

                bool checking = true;
                while (checking)
                {
                    Console.Write($"Capsule #[1-{guestList.Length}]: ");
                    int capsuleNum = int.Parse(Console.ReadLine());

                    if(capsuleNum <= 0 || capsuleNum > guestList.Length)
                    {
                        Console.WriteLine("Invalid capsule number.");
                    }
                    else if (guestList[capsuleNum - 1] == null)
                    {
                        Console.WriteLine("Error :(");
                        Console.WriteLine($"Capsule #{capsuleNum} is unoccupied");
                    }
                    else
                    {
                        Console.WriteLine("Success :)");
                        Console.WriteLine($"{guestList[capsuleNum - 1]} checked out from capsule #{capsuleNum}.");
                        guestList[capsuleNum - 1] = null;
                        checking = false;
                    }

                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return guestList;
            }
            else
            {
                Console.WriteLine("All capsules are unoccupied.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return guestList;
            }


        }

        static void ViewGuests(string[] guestList)
        {
            Console.Clear();
            Console.WriteLine(@"View Guests
===========");

            bool checking = true;
            while (checking)
            {
                Console.Write($"Capsule #[1 - {guestList.Length}]: ");
                int capNumber = int.Parse(Console.ReadLine());

        
                if (capNumber <= 0 || capNumber > guestList.Length)
                {
                    Console.WriteLine("Invalid capsule number.");
                }
                else if(guestList.Length < 10)
                {
                    for(int i = 0; i < guestList.Length; i++)
                    {

                        if (guestList[i] != null)
                        {
                            Console.WriteLine(i + 1 + " : " + guestList[i]);
                        }
                        else
                        {
                            Console.WriteLine(i + 1 + " : [unoccupied]");
                        }
                    }
                    checking = false;
                }

                else
                {
                    int lower = capNumber - 5, higher = capNumber + 5;
                    //following while loops adjust range to account for edge cases
                    //will add amount lower than 0 to the upper bound
                    //will subtract higher than array length to lower bound
                    while (lower < 0)
                    {
                        lower++;
                        higher++;
                    }
                    while (higher > guestList.Length)
                    {
                        lower--;
                        higher--;
                    }
                    //iterate through 5 smaller and 5 larger indices given new range
                    for (int i = lower; i < higher; i++)
                    {


                        if (guestList[i] != null)
                        {
                            Console.WriteLine(i + 1 + " : " + guestList[i]);
                        }
                        else
                        {
                            Console.WriteLine(i + 1 + " : [unoccupied]");
                        }
                    }
                    checking = false;
                }
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }

        static bool CheckIfEmpty(string[] guestList)
        {
            for (int i = 0; i < guestList.Length; i++)
            {
                if (guestList[i] != null)
                {
                    return true;
                }
            }
            return false;
        }


        static bool ExitMenu()
        {
            Console.Clear();
            Console.Write(@"Exit
====
Are you sure you want to exit?
All data will be lost.
Exit [y/n]: ");

            string option = Console.ReadLine().ToLower();
            if (option == "y")
            {
                Console.WriteLine();
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.Clear();
                return true;
            }
        }
    }
}
