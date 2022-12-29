using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket
{
    public class MovieDetails
    {
       public static int s_movieID=500;
       public string MovieID { get; set; } 
       public string MovieName { get; set; }
       public string Language { get; set; }
       public MovieDetails(string movieName,string language)
       {
        s_movieID++;
        MovieID="MID"+s_movieID;
        MovieName=movieName;
        Language=language;
       }
    }
}