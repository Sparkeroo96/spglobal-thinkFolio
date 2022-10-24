using HotelBooking.Exceptions;
using HotelBooking.Room;

namespace HotelBooking.Manager
{
    public class BookingManager : IBookingManager
    {
        private IDictionary<int, IRoom> _rooms = new Dictionary<int, IRoom>();

        public BookingManager(IList<int> roomNumbers)
        {
            foreach(int number in roomNumbers)
            {
                _rooms.Add(number, new Room.Room());
            }

        }

        public void AddBooking(string guest, int room, DateTime date)
        {
            IRoom requestedRoom = GetRoom(room);

            if(!requestedRoom.BookRoom(date, guest))
            {
                throw new RoomBookingClashException(
                    String.Format("There was a concurrency clash whilst booking room {0} at {1}", room, date)
                );
            }
        }

        public IEnumerable<int> getAvailableRooms(DateTime date)
        {
            return _rooms.Where(x => x.Value.IsRoomAvailable(date))
                .Select(kvp => kvp.Key)
                .ToList();

        }

        public bool IsRoomAvailable(int room, DateTime date)
        {
            IRoom checkRoom = GetRoom(room);
            return checkRoom.IsRoomAvailable(date);
        }

        private IRoom GetRoom(int room)
        {
            IRoom wantedRoom = _rooms[room];
            if (wantedRoom == null)
            {
                throw new KeyNotFoundException(String.Format("Room {0} not found", room));
            }
            return wantedRoom;
        }
    }
}
