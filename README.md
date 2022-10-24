# spglobal-thinkFolio

Visual Studio project using C# with .Net6.0

To see the code in action please run the available unit tests

## Threadsafe
To enable the code to be threadsafe when booking a room, I used the concurrent dictionary and tryAdd() to stop bookings being overwritten.
I did think about trying to implement a lock on the room objects when booking rooms, but decided against it as I felt tryAdd() did the same thing and why reinvent the wheel.
