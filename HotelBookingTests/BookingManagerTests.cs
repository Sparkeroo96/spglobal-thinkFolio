using HotelBooking.Manager;
using HotelBooking.Exceptions;

namespace HotelBookingTests
{
    [TestClass]
    public class BookingManagerTests
    {
        IList<int> roomNumbers = new List<int>()
        {
            101,102,201,203
        };

        [TestMethod]
        public void exampleTest()
        {
            IBookingManager bm = new BookingManager(roomNumbers);// create your manager here;
            var today = new DateTime(2012, 3, 28);

            Console.WriteLine(bm.IsRoomAvailable(101, today)); // outputs true
            bm.AddBooking("Patel", 101, today);
            Console.WriteLine(bm.IsRoomAvailable(101, today)); // outputs false
            Assert.ThrowsException<RoomBookingClashException>(() => bm.AddBooking("Li", 101, today)); // throws an exception
        }

        [TestMethod]
        public void TestIsRoomAvailableKeyNotFoundException()
        {
            IBookingManager bm = new BookingManager(roomNumbers);
            var today = new DateTime(2012, 3, 28);

            Assert.ThrowsException<KeyNotFoundException>(() => bm.IsRoomAvailable(1, today));
        }

        [TestMethod]
        public void TestAddBookingKeyNotFoundException()
        {
            IBookingManager bm = new BookingManager(roomNumbers);
            var today = new DateTime(2012, 3, 28);

            Assert.ThrowsException<KeyNotFoundException>(() => bm.AddBooking("Anomander Rake", 1, today));
        }

        [TestMethod]
        public void TestGetAvailableRooms()
        {
            IBookingManager bm = new BookingManager(roomNumbers);
            var today = new DateTime(2012, 3, 28);
            var tomorrow = new DateTime(2012, 3, 30);

            IEnumerable<int> resultsNoBookings = bm.getAvailableRooms(today);
            Console.WriteLine("Availble Rooms for today: " + resultsNoBookings.Count());
            Console.WriteLine(String.Join(", ", resultsNoBookings));

            bm.AddBooking("Caladan Brood", 102, today);
            bm.AddBooking("Onos T'oolan", 101, today);
            bm.AddBooking("Onos T'oolan", 101, tomorrow);

            IEnumerable<int> resultsTodayBookings = bm.getAvailableRooms(today); //Two Rooms are booked, expected 2 
            IEnumerable<int> resultsTomorrowBookings = bm.getAvailableRooms(tomorrow); //One Room is booked, expected 3

            Console.WriteLine("Availble Rooms for today with bookings: " + resultsTodayBookings.Count());
            Console.WriteLine(String.Join(", ", resultsTodayBookings));

            Console.WriteLine("Availble Rooms for tomorrow: " + resultsTomorrowBookings.Count());
            Console.WriteLine(String.Join(", ", resultsTomorrowBookings));

            Assert.AreEqual(4, resultsNoBookings.Count());
            Assert.AreEqual(2, resultsTodayBookings.Count());
            Assert.AreEqual(3, resultsTomorrowBookings.Count());
        }
    }
}