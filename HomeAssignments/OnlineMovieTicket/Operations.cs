using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket;
public delegate void EventManager();


    public static class Operations
    {
        static UserDetails currentUser=new UserDetails();
        public static CustomList<BookingDetails>bookList=new CustomList<BookingDetails>();
        public  static CustomList<UserDetails>userList=new CustomList<UserDetails>();
        public static CustomList<TheatreDetails>theatreList=new CustomList<TheatreDetails>();
        public static CustomList<MovieDetails>movieList=new CustomList<MovieDetails>();
        public static CustomList<ScreeningDetails>screenList=new CustomList<ScreeningDetails>();
        
        
        public static event  EventManager Starter;
        public static void Subscribe()
        {
            Starter+=new EventManager (ClassFIle.Create);
            //Starter+=new EventManager (Operations.DefaultData);
            Starter+=new EventManager(ClassFIle.ReadFromCSV);
            Starter+=new EventManager (Operations.MainMenu);
            Starter+=new EventManager (ClassFIle.WriteToCSV);
            
        }
        public static void Start()
        {
            Subscribe();
            Starter();
        }


    public static  void MainMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\t****Main Menu****");
            Console.WriteLine("\t1.UserRegistration\n\t2.Login\n\t3.Exit");
            choice=Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1: 
                {
                    System.Console.WriteLine("****UserRegistration****");
                    UserRegistration();
                    break;
                }
                case 2:
                {
                    System.Console.WriteLine("****Login****");
                    Login();
                    break;
                }
                case 3:
                {
                    System.Console.WriteLine("****Exit****");
                    break;
                }
            }       
        }while(choice!=3);
    }
    static void Login()
    {
        string userID;
        System.Console.Write("Enter Your UserID:");
        userID=Console.ReadLine().ToUpper();
        //validating user
        bool isExist=false;
        foreach(UserDetails user in userList)
        {
            if(user.UserID==userID)
            {
                isExist=true;
                Console.WriteLine("Valid");
                currentUser=user;
                SubMenu();
            }
        }
        if(!isExist)
        {
            System.Console.WriteLine("Invalid UserID");
        }
    }
    static void SubMenu()
    {
        int action;
        do
        {
            Console.WriteLine("\t****Login****");
            Console.WriteLine("\t1.TicketBooking\n\t2.TicketCancellation\n\t3.BookingHistory\n\t4.WalletRecharge\n\t5.Exit");
            action=Convert.ToInt32(Console.ReadLine());
            switch(action)
            {
                case 1: 
                {
                    Console.WriteLine("***TicketBooking***");
                    TicketBooking();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("****TicketCancellation****");
                    TicketCancellation();
                    break;
                }
                case 3: 
                {
                    System.Console.WriteLine("****BookingHistory****");
                    BookingHistory();
                    break;
                }
                case 4:
                {
                    System.Console.WriteLine("****WalletRecharge****");
                    RechargeWallet();
                    System.Console.WriteLine($"Your Balance is: {currentUser.WalletBalance}");
                    break;
                }
                case 5:
                {
                    System.Console.WriteLine("****Exit****");
                    break;
                }
            }
        }while(action!=5);
    } 
    public static void UserRegistration()
    {
        System.Console.Write("Enter Your Name: ");
        string name=Console.ReadLine();
        System.Console.WriteLine("Enter Age: ");
        int age=Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Enter Your Phone; ");
        long phone=Convert.ToInt64(Console.ReadLine());
        System.Console.WriteLine("Enter the initial amount to be recharged: ");
        int wallet=int.Parse(Console.ReadLine());
        UserDetails user=new UserDetails(name,age,phone,wallet);
        userList.Add(user);
        Console.WriteLine($"Your UserID: {user.UserID}");
    }
    public static void BookingHistory()
    {
        foreach(BookingDetails booking in bookList)
        {
            if(booking.UserID==currentUser.UserID)
            {
                Console.WriteLine($"BookingID: {booking.BookingID} UserID: {booking.UserID} MovieID: {booking.MovieID} TheatreID: {booking.TheatreID} SeatCount: {booking.SeatCount} Total Amount: {booking.TotalAmount} Status: {booking.BookStatus}");
            }
        }
    }
    public static void RechargeWallet()
    {
        System.Console.Write("Enter the amount to be recharged:");
        int amount=Convert.ToInt32(Console.ReadLine());
        currentUser.RechargeWallet(amount);
        Console.WriteLine("Recharge Successful");
    }
    public static void TicketBooking()
    {
        //displaying theatres
        foreach(TheatreDetails theatre in theatreList)
        {
            Console.WriteLine($"TheatreID: {theatre.TheatreID} TheatreName: {theatre.TheatreName} TheatreLocation: {theatre.TheatreLocation}");
        }
        Console.Write("Enter the Theatre ID to select Theatre:");
        string theatreID=Console.ReadLine().ToUpper();
        //validating theatre id
        bool isValid=false;
        foreach(ScreeningDetails screen in screenList)
        {
            if(theatreID==screen.TheatreID)
            {
                isValid=true;
                //movie details in that theatre
                foreach(MovieDetails movie in movieList)
                {
                    if(screen.MovieID==movie.MovieID)
                    {
                        Console.WriteLine($"Movie ID: {movie.MovieID} MovieName: {movie.MovieName} Language: {movie.Language}");
                    }
                }
            }
        }
        if(!isValid)
        {
            System.Console.WriteLine("Invalid Theatre ID.");
        }    
        //select movie id
        System.Console.Write("Choose a Movie ID: ");
        string movieID=Console.ReadLine().ToUpper();
        bool isExist=false;  
        foreach(ScreeningDetails screen in screenList)
        {
            if(movieID==screen.MovieID && !isExist)
            {
                isExist=true;
                System.Console.Write("Enter No Of Tickets: "); 
                int count=int.Parse(Console.ReadLine());
                //if required not available - show currentAvailability
                if(count<=screen.SeatAvailability)
                {
                    //if available - calculate total amount 
                    int totalAmount=count *screen.TicketPrice;
                    double payAmount=totalAmount+(0.18*totalAmount);
                    //check current logged in user's wallet balance 
                    if(payAmount<=currentUser.WalletBalance)
                    {
                    //if yes - deduct total amount from wallet 
                        currentUser.Deduct(payAmount);
                        // - deduct seat count of the screen
                        screen.DecreaseSeat(count);
                                //create book object
                        BookingDetails book=new BookingDetails(currentUser.UserID,movieID,theatreID,count,payAmount,Status.Booked);
                        bookList.Add(book);
                        Console.WriteLine($"Booked Successfully. Your Booking ID: {book.BookingID}");
                    }
                    //if not sufficient - insufficient
                    else if(payAmount>currentUser.WalletBalance)
                    {
                        System.Console.WriteLine("Insufficient Balance\nPlease Recharge Your Wallet.");
                    }
                }
                else
                {
                    System.Console.WriteLine($"Required Seat Count not available. Available seat count{screen.SeatAvailability}");
                }
            }
        }
        if(!isExist)
        {
            System.Console.WriteLine("Movie not getting screened in selected theatre.");
        }
        
    }
    public static void TicketCancellation()
    {
        foreach(BookingDetails book in bookList)
        {
            if(currentUser.UserID==book.UserID && book.BookStatus==Status.Booked)
            {
                Console.WriteLine($"BookingID: {book.BookingID} MovieID:{book.MovieID} TheatreID: {book.TheatreID} TotalAmount: {book.TotalAmount} Status: {book.BookStatus}");
            }
        }
        bool isValid=false;
        System.Console.Write("Enter BookID to cancel: ");
        string bookID=Console.ReadLine().ToUpper();
        
        foreach(BookingDetails book in bookList)
        {
            if(currentUser.UserID==book.UserID && bookID==book.BookingID)
            {
                isValid=true;
                if( book.BookStatus==Status.Booked)
                {
                    book.BookStatus=Status.Cancelled;
                    book.SeatCount++;
                    currentUser.Refund(book.TotalAmount-20);
                    Console.WriteLine("Your Booking has been Successfully Cancelled.");
                    Console.WriteLine($"An amount of {book.TotalAmount-20} has been refunded\nYour Balance is: {currentUser.WalletBalance}" );
                }
                else
                {
                    Console.WriteLine("You've not Booked yet.");
                }
            }
        }
        if(!isValid)
        {
            Console.WriteLine("Invalid Booking ID.");
        }
    }   
    public static void DefaultData()
    {
    BookingDetails booking1=new BookingDetails("UID1001","MID501","TID301",1,200,Status.Booked);
    bookList.Add(booking1);
    BookingDetails booking2=new BookingDetails("UID1001","MID504","TID302",1,400,Status.Booked);
    bookList.Add(booking2);
    BookingDetails booking3=new BookingDetails("UID1002","MID505","TID302",1,300,Status.Booked);
    bookList.Add(booking3);

    UserDetails user1=new UserDetails("RaviChandran",30,8599488003,1000);
    userList.Add(user1);
    UserDetails user2=new UserDetails("Baskaran",30,9857747327,2000);
    userList.Add(user2);

    TheatreDetails theatre1=new TheatreDetails("INOX","Anna Nagar");
    theatreList.Add(theatre1);
    TheatreDetails theatre2=new TheatreDetails("Ega Theatre","Chetpet");
    theatreList.Add(theatre2);
    TheatreDetails theatre3=new TheatreDetails("Kamala","Vadapalani");
    theatreList.Add(theatre3);

    ScreeningDetails screen1=new ScreeningDetails("MID501","TID301",200,5);
    screenList.Add(screen1);
    ScreeningDetails screen2=new ScreeningDetails("MID502","TID301",300,2);
    screenList.Add(screen2);
    ScreeningDetails screen3=new ScreeningDetails("MID506","TID301",50,1);
    screenList.Add(screen3);
    ScreeningDetails screen4=new ScreeningDetails("MID501","TID302",400,11);
    screenList.Add(screen4);
    ScreeningDetails screen5=new ScreeningDetails("MID505","TID302",300,20);
    screenList.Add(screen5);
    ScreeningDetails screen6=new ScreeningDetails("MID504","TID302",500,2);
    screenList.Add(screen6);
    ScreeningDetails screen7=new ScreeningDetails("MID505","TID303",100,11);
    screenList.Add(screen7);
    ScreeningDetails screen8=new ScreeningDetails("MID502","TID303",200,20);
    screenList.Add(screen8);
    ScreeningDetails screen9=new ScreeningDetails("MID504","TID303",350,2);
    screenList.Add(screen9);

    MovieDetails movie1=new MovieDetails("Bagubali 2","Telugu");
    movieList.Add(movie1);
    MovieDetails movie2=new MovieDetails("Ponniyin Selvan","Tamil");
    movieList.Add(movie2);
    MovieDetails movie3=new MovieDetails("Cobra","Tamil");
    movieList.Add(movie3);
    MovieDetails movie4=new MovieDetails("Vikram","Hindi");
    movieList.Add(movie4);
    MovieDetails movie5=new MovieDetails("Vikram","Tamil");
    movieList.Add(movie5);
    MovieDetails movie6=new MovieDetails("Beast","English");
    movieList.Add(movie6);

    }
}
