using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mangement_With_Clsses
{
    class Guest
    {

        /// <summary>
        /// Enter Price of room
        /// </summary>
        private float _PriceOfRoom;
        public float PriceOfRoom
        {
            get { return _PriceOfRoom; }
            set { _PriceOfRoom = value; }
        }

        /// <summary>
        /// Name of guest
        /// </summary>
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Start date reservation
        /// </summary>
        private DateTime _StartReservation;
        public DateTime StartReservation
        {
            get { return _StartReservation; }
            set { _StartReservation = value; }
        }

        /// <summary>
        /// End Date REservation
        /// </summary>
        private DateTime _EndReservation;
        public DateTime EndReservation
        {
            get { return _EndReservation; }
            set { _EndReservation = value; }
        }

        /// <summary>
        /// Calc Number of days's reservation
        /// </summary>
        public int AllDays()
        {
            return Math.Abs(_StartReservation.DayOfYear - _EndReservation.Date.DayOfYear);
        }

        /// <summary>
        /// Extra Services
        /// </summary>
        private float _AdditionalServices;
        public float AdditionalServices
        {
            get { return _AdditionalServices; }
            set { _AdditionalServices = value; }
        }

        /// <summary>
        /// Calc Bill of guest
        /// </summary>
        private float _EndBill;
        public float EndBill
        {
            get { return _EndBill; }
            set { _EndBill = value; }
        }

        /// <summary>
        /// Enter Data for a guest
        /// </summary>
        public void EnterData()
        {
            Console.Write("Enter Your Name: ");
            Name = Console.ReadLine(); 
            Console.Write("Enter Date Start Reserve: ");
            StartReservation = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Date End Reserve: ");
            EndReservation = DateTime.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Show Bill of guest
        /// </summary>
        public void PrintBill()
        {
            Console.WriteLine($"name of guset : {_Name}\n" +
                              $"Total days    : {AllDays()}\n" +
                              $"Extra services: {_AdditionalServices}\n" +
                              $"Total cost    : {_EndBill}");
        }
    }
}
