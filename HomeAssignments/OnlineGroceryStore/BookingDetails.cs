using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public enum Status{Select,Booked,Cancelled,Initiated}
    public class BookingDetails
    {
        private static int s_bookingID=3000;
        public string  BookingID { get; set; }
        public string CustomerID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateOfBooking { get; set; }
        public Status Status { get; set; }

        public BookingDetails(string customerID,int totalPrice,DateTime dateOfBooking,Status status)
        {
            s_bookingID++;
            BookingID="BID"+s_bookingID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfBooking=dateOfBooking;
            Status=status;
        }
        public BookingDetails(string data)
        {
            string []values=data.Split(",");
            s_bookingID=int.Parse(values[0].Remove(0,3));
            BookingID=values[0];
            CustomerID=values[1];
            TotalPrice=int.Parse(values[2]);
            DateOfBooking=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Status=Enum.Parse<Status>(values[4]);

        }
    }
}