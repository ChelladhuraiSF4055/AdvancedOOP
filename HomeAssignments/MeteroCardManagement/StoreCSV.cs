using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace MeteroCardManagement
{
    public static class StoreCSV
    {
        public static void Create()
        {
            if(!Directory.Exists("MeteroCard"));
            {
                Directory.CreateDirectory("MeteroCard");
            }
            if(!File.Exists("MeteroCard/UserDetails.csv"))
            {
                File.Create("MeteroCard/UserDetails.csv").Close();
            }
            if(!File.Exists("MeteroCard/TravelHistory.csv"))
            {
                File.Create("MeteroCard/TravelHistory.csv").Close();
            }
            if(!File.Exists("MeteroCard/TicketFairs.csv"))
            {
                File.Create("MeteroCard/TicketFairs.csv").Close();
            }
        }
        public static void WriteToCSV()
        {
            string[] userDetails=new string[Operations.userList.Count];
            for(int i=0;i<Operations.userList.Count;i++)
            {
                userDetails[i]=Operations.userList[i].CardNumber+","+Operations.userList[i].UserName+","+Operations.userList[i].PhoneNumber+","+Operations.userList[i].Balance;
            }
            File.WriteAllLines("MeteroCard/UserDetails.csv",userDetails);
            string [] ticketDetails=new string [Operations.ticketFairList.Count];
            for(int i=0;i<Operations.ticketFairList.Count;i++)
            {
                ticketDetails[i]=Operations.ticketFairList[i].TicketID+","+Operations.ticketFairList[i].FromLocation+","+Operations.ticketFairList[i].ToLocation+","+Operations.ticketFairList[i].Fair;
            }
            File.WriteAllLines("MeteroCard/TicketFairs.csv",ticketDetails);
            string []travelDetatils=new string[Operations.travelList.Count];
            for(int i=0;i<Operations.travelList.Count;i++)
            {
                travelDetatils[i]=Operations.travelList[i].TravelID+","+Operations.travelList[i].CardNumber+","+Operations.travelList[i].FromLocation+","+Operations.travelList[i].ToLocation+","+Operations.travelList[i].Date.ToString("dd/MM/yyyy")+","+Operations.travelList[i].TravelCost;
            }
            File.WriteAllLines("MeteroCard/TravelHistory.csv",travelDetatils);
        }
        public static void ReadFromCSV()
        {
            string[]text1=File.ReadAllLines("MeteroCard/UserDetails.csv");
            foreach(string data in text1)
            {
                UserDetails user=new UserDetails(data);
                Operations.userList.Add(user);
            }
            string []text2=File.ReadAllLines("MeteroCard/TicketFairs.csv");
            foreach(string data in text2)
            {
                TicketFair ticket=new TicketFair(data);
                Operations.ticketFairList.Add(ticket);
            }
            string []text3=File.ReadAllLines("MeteroCard/TravelHistory.csv");
            foreach(string data in text3)
            {
                TravelHistory travel=new TravelHistory(data);
                Operations.travelList.Add(travel);
            }
        }
    }
}