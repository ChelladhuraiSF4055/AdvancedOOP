using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteroCardManagement
{
    public class TicketFair
    {
        public static int s_ticketID=100;
        public string TicketID {get; set;}
        public string FromLocation {get;set;}
        public string ToLocation {get;set;}
        public int Fair {get;set;}
        public TicketFair(string fromLocation, string toLocation, int fair)
        {
            s_ticketID++;
            TicketID="MR"+s_ticketID;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            Fair=fair;
        }
        public TicketFair(string data)
        {
            string[]values=data.Split(",");
            s_ticketID=int.Parse(values[0].Remove(0,2));
            TicketID=values[0];
            FromLocation=values[1];
            ToLocation=values[2];
            Fair=int.Parse(values[3]);
        }
    }
}