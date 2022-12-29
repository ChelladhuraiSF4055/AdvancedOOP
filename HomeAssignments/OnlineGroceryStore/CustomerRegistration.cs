using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class CustomerRegistration:PersonalDetails,IBalance
    {
        private int _wallet;
        public int WalletBalance { get{return _wallet;}}
        public void WalletRecharge(int amount)
        {
            _wallet+=amount;
        }
        private static int s_customerID=3000;
        public string CustomerID { get; set; }

        public CustomerRegistration()
        {
            Gender=Gender.Select;
        }
        public CustomerRegistration(int walletBalance,string name,string fatherName,Gender gender,long mobile,DateTime dob,string mailID)
        :base(name,fatherName,gender,mobile,dob,mailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            _wallet=walletBalance;
        }
        public CustomerRegistration(string data)
        {
            string[]values=data.Split(",");
            s_customerID=int.Parse(values[0].Remove(0,3));
            CustomerID=values[0];
            _wallet=int.Parse(values[1]);
            Name=values[2];
            FatherName=values[3];
            Gender=Enum.Parse<Gender>(values[4]);
            Mobile=long.Parse(values[5]);
            DOB=DateTime.ParseExact(values[6],"dd/MM/yyyy",null);
            MailID=values[7];

            
        }
        public void Deduct(int amount)
        {
            _wallet-=amount;
        }
    }
}