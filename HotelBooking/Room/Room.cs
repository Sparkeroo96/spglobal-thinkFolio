using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Room
{
    internal class Room : IRoom
    {
        IDictionary<DateTime, String> _availablity = new ConcurrentDictionary<DateTime, String>();

        /**
         * Add a date to the availabilty to show it has been used
         */
        public bool BookRoom(DateTime date, String guest)
        {
            return _availablity.TryAdd(date, guest);
        }

        /**
         * Check the availabilty to see if the date has been booked
         */
        public bool IsRoomAvailable(DateTime date)
        {
            return !_availablity.ContainsKey(date);
        }
    }
}
