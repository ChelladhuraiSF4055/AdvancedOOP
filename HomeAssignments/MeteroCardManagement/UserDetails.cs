using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteroCardManagement
{
    public class UserDetails
    {
        public static int s_cardNumber=100;
        public string  CardNumber {get; set;}
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        private int _balance;
        public int Balance { get{return _balance;}}
        public UserDetails()
        {
            CardNumber="Enter Card Number";
            UserName="Enter UserName";
        }
        public UserDetails(string userName,long phone, int balance)
        {
            s_cardNumber++;
            CardNumber="CMRL"+s_cardNumber;
            UserName=userName;
            PhoneNumber=phone;
            _balance=balance;
        }
        public UserDetails(string data)
        {
        string []values=data.Split(",");
        s_cardNumber=int.Parse(values[0].Remove(0,4));
        CardNumber=values[0];
        UserName=values[1];
        PhoneNumber=long.Parse(values[2]);
        _balance=int.Parse(values[3]);
        }
        public void Recharge(int amount)
        {
            _balance+=amount;
        }
        public void Deduct(int amount)
        {
            _balance-=amount;
        }

    }
}