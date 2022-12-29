using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket
{
    public class ScreeningDetails
    {
        public string MovieID {get; set;}
        public string TheatreID { get; set; }
        public int TicketPrice {get; set;}
        public int SeatAvailability { get; set; }  
        public ScreeningDetails(string movieID,string theatreID,int ticketPrice, int seatAvailability)
        {
            MovieID=movieID;
            TheatreID=theatreID;
            TicketPrice=ticketPrice;
            SeatAvailability=seatAvailability;
        } 
        public float TotalAmount(int count)
        {
             return (TicketPrice*count)+0.18f*(TicketPrice*count);
        }
        public void DecreaseSeat(int count)
        {
            SeatAvailability-=count;
        }
        
    }
}