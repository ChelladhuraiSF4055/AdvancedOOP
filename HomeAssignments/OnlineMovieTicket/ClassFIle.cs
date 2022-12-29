using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket
{
    public class ClassFIle
    {
        public static void Create()
        {
            if(!Directory.Exists("OnlineMovieBooking"))
            {
                Directory.CreateDirectory("OnlineMovieBooking");
                Console.WriteLine("Folder Created.");
            }
            else
            {
                Console.WriteLine("Folder Found");
            }
            if(!File.Exists("OnlineMovieBooking/ScreeningList.csv"))
            {
                File.Create("OnlineMovieBooking/ScreeningList.csv").Close();
                System.Console.WriteLine("Screening File Created");
            }
            else
            {
                System.Console.WriteLine("Screening File Found");
            }
            if(!File.Exists("OnlineMovieBooking/TheatreDetails.csv"))
            {
                File.Create("OnlineMovieBooking/TheatreDetails.csv").Close();
                System.Console.WriteLine("TheatreDetails File Created");
            }
            else
            {
                System.Console.WriteLine("TheatreDetails File Found");
            }
            if(!File.Exists("OnlineMovieBooking/BookingDetails.csv"))
            {
                File.Create("OnlineMovieBooking/BookingDetails.csv").Close();
                System.Console.WriteLine("UserDetails File Created");
            }
            else
            {
                System.Console.WriteLine("BookingDetails File Found");
            }
        }
        public static void WriteToCSV()
        {
            string []theatreDetails=new string [Operations.theatreList.Count];
            for(int i=0;i<Operations.theatreList.Count;i++)
            {
                theatreDetails[i]=Operations.theatreList[i].TheatreID+","+Operations.theatreList[i].TheatreName+","+Operations.theatreList[i].TheatreLocation;
            }
            File.WriteAllLines("OnlineMovieBooking/TheatreDetails.csv",theatreDetails);
            string []screeningDetails=new string[Operations.screenList.Count];
            for(int i=0;i<Operations.screenList.Count;i++)
            {
                screeningDetails[i]=Operations.screenList[i].TheatreID+","+Operations.screenList[i].TicketPrice+","+Operations.screenList[i].SeatAvailability;
            }
            File.WriteAllLines("OnlineMovieBooking/ScreeningList.csv",screeningDetails);
            string []bookingDetails=new string [Operations.bookList.Count];
            for(int i=0;i<Operations.bookList.Count;i++)
            {
                bookingDetails[i]=Operations.bookList[i].BookingID+","+Operations.bookList[i].MovieID+","+Operations.bookList[i].TheatreID+","+Operations.bookList[i].SeatCount+","+Operations.bookList[i].TotalAmount+","+Operations.bookList[i].BookStatus;
            }
            File.WriteAllLines("OnlineMovieBooking/BookingDetails.csv",bookingDetails);
        }
        public static void ReadFromCSV()
        {
            string []screeningDetails=File.ReadAllLines("OnlineMovieBooking/ScreeningList.csv");
            foreach(string text in screeningDetails)
            {
                Console.WriteLine(text);
            }
        }

    }
}