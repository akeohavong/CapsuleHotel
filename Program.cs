﻿using System;

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
                        ExitMenu();
                        displayMenu = false;
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
            Console.Write(@"Guest Check In
==============
Guest Name: ");
            string newGuest = Console.ReadLine();

            bool checking = true;
            while (checking)
            {
                Console.Write($"Capsule #[1 - {guestList.Length}]: ");
                int capsuleNum = int.Parse(Console.ReadLine());

                if (guestList[capsuleNum - 1] == null)
                {
                    guestList[capsuleNum - 1] = newGuest;
                    Console.WriteLine("Success :)");
                    Console.WriteLine($"{newGuest} is booked in Capsule #{capsuleNum}.");
                    checking = false;
                }
                else
                {
                    Console.WriteLine("Error :(");
                    Console.WriteLine($"Capsule #{capsuleNum} is occupied");
                }
            }

            return guestList;
        }

        static string[] CheckOut(string[] guestList)
        {
            //TODO check if array is empty, if empty exit else
            //continue to check out.

            Console.WriteLine(@"Guest Check Out
===============");
            Console.Write($"Capsule #[1-{guestList.Length}]:");
            
            bool checking = true;
            while (checking)
            {
                int capsuleNum = int.Parse(Console.ReadLine());
                if(guestList[capsuleNum - 1 ] == null)
                {
                    Console.WriteLine("Error :(");
                    Console.WriteLine($"Capsule #{capsuleNum} is unoccupied");
                    Console.Write($"Capsule #[1 - {guestList.Length}]: ");
                }
                else
                {
                    Console.WriteLine("Success :)");
                    Console.WriteLine($"{guestList[capsuleNum - 1]} checked out from capsule #{capsuleNum}.");
                    guestList[capsuleNum - 1] = null;
                    checking = false;
                }

            }

            return guestList;
        }

        static void ViewGuests(string[] guestList)
        {
            //TODO implement feature to show 5 smaller and 5 larger than given number
            //EX: capsule 26 show 21 -31.
            for (int i = 0; i < guestList.Length; i++)
            {
                if(guestList[i] != null)
                {
                    Console.WriteLine($"{i + 1}: {guestList[i]}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}: [unoccupied]");
                }

            }
        }


        static void ExitMenu()
        {
            Console.Clear();
            Console.Write(@"Exit
====
Are you sure you want to exit?
All data will be lost.
Exit [y/n]: ");

            string option = Console.ReadLine().ToLower();
            if(option == "y")
            {
                Console.WriteLine();
                Console.WriteLine("Goodbye!");
            } else
            {
                MainMenu();
            }

        }

    }
}
