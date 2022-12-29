using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket
{
    public class PersonalDetails
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
        public PersonalDetails()
        {
            
        }
        public PersonalDetails(string name,int age,long phone)
        {
            Name=name;
            Age=age;
            Phone=phone;
        }
    }
}