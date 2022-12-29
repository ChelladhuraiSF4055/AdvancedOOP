using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket
{
    public class UserDetails:PersonalDetails,IWallet
    {
        private double wallet;
        public double WalletBalance{get{return wallet;}  }
        public void RechargeWallet(int amount)
        {
            wallet+=amount;
        }
        private static int s_userID=1000;
        public string UserID { get;}

        public UserDetails()
        {
            UserID="Enter UserID";
        }    
        
        public UserDetails(string name,int age,long phone,int walletBalance)
        :base(name,age,phone)
        {
            s_userID++;
            UserID="UID"+s_userID;
            wallet=walletBalance;
        }
        public void Deduct(double amount)
        {
            wallet-=amount;
        }
        public void Refund(double amount)
        {
            wallet+=amount;
        }
        
    }
}