using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteroCardManagement
{
    public class TravelHistory
    {
        public static int s_travelID=100;
        public string TravelID { get; }
        public string CardNumber { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime Date {get; set;}
        public int TravelCost { get; set; }
        public TravelHistory(string cardNumber,string fromLocation, string toLocation,DateTime date,int travelCost)
        {
            s_travelID++;
            TravelID="TID"+s_travelID;
            CardNumber=cardNumber;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            Date=date;
            TravelCost=travelCost;
        }
        public TravelHistory(string data)
        {
            string[]values=data.Split(",");
            s_travelID=int.Parse(values[0].Remove(0,3));
            TravelID=values[0];
            CardNumber=values[1];
            FromLocation=values[2];
            ToLocation=values[3];
            Date=DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            TravelCost=int.Parse(values[5]);
        }
    }
}