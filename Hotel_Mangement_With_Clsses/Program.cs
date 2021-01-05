using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mangement_With_Clsses
{
    class Program
    {
        static byte Choice;                    // TO choose from men
        static int NumOfRoom;                  // Number of room
        static bool[] Reserve = new bool[10];  // check reserved room or not
        static Guest[] guests = new Guest[10];
        static Guest guest;
        static bool[] enterdprice = new bool[10]; // check entered price befor or not


        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Reserve[i] = false;
                guests[i] = new Guest();
            }
            do
            {
                Menu();
                New_choose();
            } while (Choice != 8);
            Console.WriteLine("Thanks for using Application.");
        }

        /// <summary>
        /// Main Menu
        /// </summary>
        static byte Menu()
        {
            Console.Write("Hello Manger,Chosse from the following:\n" +
                              "\t\t\t1- Enter Day Price for A room.          (press 1)\n" +
                              "\t\t\t2- Make A guset reservation for a room. (Press 2)\n" +
                              "\t\t\t3- Add Extra Service for a guset.       (Press 3)\n" +
                              "\t\t\t4- Show Bill for a guest.               (Press 4)\n" +
                              "\t\t\t5- End Reservation for a room.          (Press 5)\n" +
                              "\t\t\t6- Make A report of all rooms.          (Press 6)\n" +
                              "\t\t\t7- Show Total income.                   (Press 7)\n" +
                              "\t\t\t8- End Program.                         (Press 8)\n" +
                              "Enter your choice Please: ");

            do { Choice = byte.Parse(Console.ReadLine()); } while (Choice < 1 && Choice > 8);
            return Choice;
        }

        /// <summary>
        /// Choose from Menu
        /// </summary>
        static void New_choose()
        {
            if (Choice == 1) One();
            else if (Choice == 2) Two();
            else if (Choice == 3) Three();
            else if (Choice == 4) Four();
            else if (Choice == 5) Five();
            else if (Choice == 6) Six();
            else if (Choice == 7) Seven();
        }

        /// <summary>
        /// Check with guest
        /// </summary>
        static Guest choise(int number)
        {
            guest = guests[number - 1];
            return guest;
        }

        /// <summary>
        /// Choose Room
        /// </summary>
        static void ChooseRoom()
        {
            do
            {
                Console.Write("Enter number of room: ");
                NumOfRoom = byte.Parse(Console.ReadLine());
                choise(NumOfRoom);
            } while (NumOfRoom < 1 && NumOfRoom > 10);
        }

        /// <summary>
        /// Enter Price of room
        /// </summary>
        static void EnterPrice()
        {
            do
            {
                Console.Write("Enter Price of room: ");
                guest.PriceOfRoom = float.Parse(Console.ReadLine());
                enterdprice[NumOfRoom - 1] = true;
            } while (guest.PriceOfRoom <= 0);
        }

        /// <summary>
        /// Enter Day Price for A room
        /// </summary>
        static void One()
        {
            ChooseRoom();
            EnterPrice();
        }

        /// <summary>
        /// Make A guset reservation for a room
        /// </summary>
        static void Two()
        {
            ChooseRoom();
            if (Reserve[NumOfRoom - 1] == true)
            {
                do
                {
                    Console.Write("Sorry, This Room is unvaliable:  \n" +
                                  "1- To Reserve onther room.      (Press 1)\n" +
                                  "2- To cacel and return to Menu. (Press 2)\n" +
                                   "Enter Choose: ");
                    byte c = byte.Parse(Console.ReadLine());
                    if (c == 2) return;
                    else ChooseRoom();
                } while (Reserve[NumOfRoom - 1] == true);
                Reservation();
            }
            else Reservation();
        }

        /// <summary>
        /// guset reservation
        /// </summary>
        static void Reservation()
        {
            if (enterdprice[NumOfRoom - 1] == false) EnterPrice();
            guest.EnterData();
            Reserve[NumOfRoom - 1] = true;
            guest.EndBill = guest.AllDays() * guest.PriceOfRoom;
        }

        /// <summary>
        /// Add Extra Service for a guset
        /// </summary>
        static void Three()
        {
            ChooseRoom();
            if (Reserve[NumOfRoom - 1] == false)
            {
                Console.WriteLine("This Room is Empty!!");
                return;
            }
            else
            {
                Console.Write("1- meals\n" +
                              "2- extra phone Calls\n" +
                              "3- transportation\n" +
                              "4- deaning\n");
                int c;
                do
                {
                    Console.Write("choose Number of Extra Service: ");
                    c = int.Parse(Console.ReadLine());
                } while (c < 1 || c > 4);
                Console.Write("Enter Price: ");
                guest.AdditionalServices = float.Parse(Console.ReadLine());
                guest.EndBill += guest.AdditionalServices;
            }
        }

        /// <summary>
        /// Show Bill for a guest
        /// </summary>
        static void Four()
        {
            ChooseRoom();
            if (Reserve[NumOfRoom - 1] == false)
            {
                Console.WriteLine("This Room is Empty!!");
                return;
            }
            else
                guest.PrintBill();
        }

        /// <summary>
        /// End Reservation for a room
        /// </summary>
        static void Five()
        {
            Four();
            Reserve[NumOfRoom - 1] = false;
            guest.AdditionalServices = 0;
            guest.Name = "";
            guest.EndBill = 0;
        }

        /// <summary>
        ///  Make A report of all rooms.
        /// </summary>
        static void Six()
        {
            Console.WriteLine("Room Number\t\t\tStatus\t\t\tEnd of reservation");
            for (int i = 0; i < 10; i++)
            {
                choise(i+1);
                Console.Write($"    {i+1}\t\t\t\t{Reserve[i]}\t\t\t\t");
                if (Reserve[i] == false) Console.WriteLine("0");
                else Console.WriteLine(guest.EndReservation);
            }
        }

        /// <summary>
        /// Show Total income
        /// </summary>
        static void Seven()
        {
            Console.WriteLine("Number of room\t\tTotal financiais");
            for (int i = 0; i < 10; i++)
            {
                choise(i+1);
                Console.WriteLine($"\t{i+1}\t\t\t{guest.EndBill}");
            }

        }
    }
}
