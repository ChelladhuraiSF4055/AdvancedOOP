using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket
{
    public enum Status { Select,Booked,Cancelled }
    public class BookingDetails
    {
        public static int s_bookingID=7001;
        public string BookingID{get; set;}
        public string UserID { get; set; }
        public string MovieID { get; set; }
        public string TheatreID { get; set; }
        public int SeatCount {get; set;}
        public double TotalAmount {get; set;}
        public Status BookStatus {get; set;}

        public BookingDetails(string userID,string movieID,string theatreID,int seatCount,double totalAmount,Status status)
        {
            s_bookingID++;
            BookingID="BID"+s_bookingID;
            UserID=userID;
            MovieID=movieID;
            TheatreID=theatreID;
            SeatCount=seatCount;
            TotalAmount=totalAmount;
            BookStatus=status;
        }
    }
}