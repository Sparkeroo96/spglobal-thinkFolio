using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Exceptions
{
    public class RoomBookingClashException : Exception
    {
        public RoomBookingClashException(String message) : base(message)
        {
        }
    }
}
