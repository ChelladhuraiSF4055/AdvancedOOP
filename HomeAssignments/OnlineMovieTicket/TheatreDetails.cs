using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket
{
    public class TheatreDetails
    {
        public static int s_theatreID=300;
        public string TheatreID { get; set; }
        public string TheatreName {get; set;}
        public string TheatreLocation { get; set; }

        public TheatreDetails(string theatreName,string theatreLocation)
        {
            s_theatreID++;
            TheatreID="TID"+s_theatreID;
            TheatreName=theatreName;
            TheatreLocation=theatreLocation;
        }
    }
}