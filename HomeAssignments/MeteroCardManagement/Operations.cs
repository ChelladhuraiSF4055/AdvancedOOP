using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace MeteroCardManagement
{
    public delegate void EventManager();
    public static class Operations
    {
        public static CustomList<UserDetails>userList=new CustomList<UserDetails>();
        public static CustomList<TravelHistory>travelList=new CustomList<TravelHistory>();
        public static CustomList<TicketFair>ticketFairList=new CustomList<TicketFair>();
        static UserDetails currentUser=new UserDetails();

        public static event EventManager Starter;
        public static void Subscribe()
        {
            Starter+=new EventManager(StoreCSV.Create);
            Starter+=new EventManager(Operations.DefaultData);
            //Starter+=new EventManager(StoreCSV.ReadFromCSV);
            Starter+=new EventManager(Operations.MainMenu);
            Starter+=new EventManager(StoreCSV.WriteToCSV);
        }
        
        public static  void Start()
        {
            Subscribe();
            Starter();
        }

        public static void MainMenu()
        {
            int choice;
            do
            {
            Console.WriteLine("\t*****MainMenu*****");
            System.Console.WriteLine("\t1.UserRegistraion\n\t2.UserLogin\n\t3.Exit");
            choice=Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                {
                    System.Console.WriteLine("\t****UserRegistration****");
                    Registration();
                    break;
                }
                case 2:
                {
                    System.Console.WriteLine("\t****UserLogin****");
                    Login();
                    break;
                }
                case 3:
                {
                    System.Console.WriteLine("\t****Exit****");
                    break;
                }
            }
            }while(choice!=3);
        }
        static void Login()
        {
            System.Console.Write("Enter Your CardNumber: ");
            string cardNumber=Console.ReadLine().ToUpper();
            bool isValid=false;
            foreach(UserDetails user in userList)
            {
                if(user.CardNumber==cardNumber)
                {
                    isValid=true;
                    currentUser=user;
                    SubMenu();
                }
            }
            if(!isValid)
            {
                System.Console.WriteLine("Invalid CardNumber");
            }
        }
        static void SubMenu()
        {
            int action;
            do
            {
                System.Console.WriteLine("\t1.Balance Check\n\t2.Recharge\n\t3.View Travel History\n\t4.Travel\n\t5.Go To MainMenu");
                action=Convert.ToInt32(Console.ReadLine());
                switch(action)
                {
                    case 1:
                    {
                        System.Console.WriteLine("****Balance Check****");
                        BalanceCheck();
                        break;
                    }
                    case 2:
                    {
                        System.Console.WriteLine("****Recharge****");
                        Recharge();
                        break;
                    }
                    case 3:
                    {
                        System.Console.WriteLine("****View Travel History****");
                        ViewTravelHistory();
                        break;
                    }
                    case 4:
                    {
                        System.Console.WriteLine("****Travel****");
                        Travel();
                        break;
                    }
                }
            }while(action!=5);
        }
        public static void DefaultData()
        {
        UserDetails user1=new UserDetails("Ravi",98488,1000);
        userList.Add(user1);
        UserDetails user2=new UserDetails("Baskaran",99488,1000);
        userList.Add(user2);

        TravelHistory travel1=new TravelHistory("CMRL101","Airport","Egmore",new DateTime(2022,10,10),55);
        travelList.Add(travel1);
        TravelHistory travel2=new TravelHistory("CMRL101","Egmore","Koyambedu",new DateTime(2022,10,10),32);
        travelList.Add(travel2);
        TravelHistory travel3=new TravelHistory("CMRL102","Alandur","koyambedu",new DateTime(2022,11,10),25);
        travelList.Add(travel3);
        TravelHistory travel4=new TravelHistory("CMRL102","Egmore","Thirumangalam",new DateTime(2022,11,10),25);
        travelList.Add(travel4);

        TicketFair ticket1=new TicketFair("Airport","Egmore",55);
        ticketFairList.Add(ticket1);
        TicketFair ticket2=new TicketFair("Airport","Koyambedu",25);
        ticketFairList.Add(ticket2);
        TicketFair ticket3=new TicketFair("Alandur","Koyambedu",25);
        ticketFairList.Add(ticket3);
        TicketFair ticket4=new TicketFair("Koyambedu","Egmore",32);
        ticketFairList.Add(ticket4);

        }
        static void BalanceCheck()
        {
            Console.WriteLine($"Your Wallet Balance is: {currentUser.Balance}");
        }
        static void Recharge()
        {
            System.Console.Write("Enter the amount to be recharged: ");
            int amount=Convert.ToInt32(Console.ReadLine());
            currentUser.Recharge(amount);
            Console.WriteLine($"Recharge Successful\nYour Balance is: {currentUser.Balance}");
        }
        static void ViewTravelHistory()
        {
            bool isExist=false;
            foreach(TravelHistory travel in travelList)
            {
                if(currentUser.CardNumber==travel.CardNumber)
                {
                    isExist=true;
                    Console.WriteLine($"TravelID:{travel.TravelID} From:{travel.FromLocation} To:{travel.ToLocation} Date:{travel.Date.ToString("dd/MM/yyyy")} Cost:{travel.TravelCost}");
                }
            }
            if(!isExist)
            {
                System.Console.WriteLine("You've not Travelled Yet.");
            }
        }
        static void Travel()
        {
           foreach(TicketFair ticket in ticketFairList)
            {
                Console.WriteLine($"TicketID:{ticket.TicketID} FromLocation:{ticket.FromLocation} ToLocation:{ticket.ToLocation} Fair:{ticket.Fair}");
            } 
            System.Console.Write("Enter ticketID:");
            string ticketID=Console.ReadLine().ToUpper();
            bool isExist=false;
            foreach(TicketFair ticket in ticketFairList)
            {
                if(ticketID==ticket.TicketID)
                {
                    isExist=true;
                    if(currentUser.Balance>=ticket.Fair)
                    {
                        int amount=ticket.Fair;
                        currentUser.Deduct(amount);
                        TravelHistory travel=new TravelHistory(currentUser.CardNumber,ticket.FromLocation,ticket.ToLocation,DateTime.Today,amount);
                        travelList.Add(travel);
                        System.Console.WriteLine($"Travel Registered.\nYour TravelID: {travel.TravelID}");
                    }
                    else
                    {
                        System.Console.WriteLine("Insufficient Balance.");
                    }
                }

            }
            if(!isExist)
            {
                System.Console.WriteLine("Invalid Ticket ID");
            }
        }
        public static void Registration()   
        {
            System.Console.Write("Enter Your Name: ");
            string userName=Console.ReadLine();
            System.Console.Write("Enter Phone Number: ");
            long phone=Convert.ToInt64(Console.ReadLine());
            System.Console.Write("Recharge an amount for intial Balance: ");
            int balance=Convert.ToInt32(Console.ReadLine());
            UserDetails user=new UserDetails(userName,phone,balance);
            userList.Add(user);
            System.Console.WriteLine($"Registered Successfully.\nYour Card Number is: {user.CardNumber}");
        }  
    
    }
}