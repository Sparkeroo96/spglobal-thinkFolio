using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Room
{
    internal interface IRoom
    {
        bool BookRoom(DateTime date, String guest);

        bool IsRoomAvailable(DateTime date);

    }
}
