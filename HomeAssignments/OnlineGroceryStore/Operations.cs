using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore;
public delegate void EventManager();

    public static class Operations
    {
        public static CustomList<CustomerRegistration>customerList=new CustomList<CustomerRegistration>();
        public static  CustomList<ProductDetails>productList=new CustomList<ProductDetails>();
        public static CustomList<BookingDetails>bookList=new CustomList<BookingDetails>();
        public static CustomList<OrderDetails>orderList=new CustomList<OrderDetails>();
        static CustomerRegistration currentCustomer=new CustomerRegistration();

        public static event EventManager Starter;
        public static void Subscribe()
        {
            Starter += new EventManager(ClassFile.Create);
           // Starter += new EventManager(Operations.DefaultData);
           Starter+=new EventManager(ClassFile.ReadFromCSV);
            Starter += new EventManager(Operations.MainMenu);
            Starter += new EventManager(ClassFile.WriteToCSV);
        }
        public static void Start()
        {
            Subscribe();
            Starter();
        }
        public static void  DefaultData()
        {
        CustomerRegistration customer1=new CustomerRegistration(100,"Ravi","Ettapparajan",Gender.male,974774646,new DateTime(1999,11,11),"ravi@gmail.com");
        customerList.Add(customer1);
        CustomerRegistration customer2=new CustomerRegistration(15000,"Baskaran","Sethurajan",Gender.male,847575775,new(1999,11,11),"baskaran@gmail.com");
        customerList.Add(customer2);

        ProductDetails product1=new ProductDetails("Sugar",20,40);
        productList.Add(product1);
        ProductDetails product2=new ProductDetails("Rice",100,50);
        productList.Add(product2);
        ProductDetails product3=new ProductDetails("Milk",10,40);
        productList.Add(product3);
        ProductDetails product4=new ProductDetails("Coffee",10,10);
        productList.Add(product4);
        ProductDetails product5=new ProductDetails("Tea",10,10);
        productList.Add(product5);
        ProductDetails product6=new ProductDetails("Masala Powder",10,20);
        productList.Add(product6);
        ProductDetails product7=new ProductDetails("Salt",10,10);
        productList.Add(product7);
        ProductDetails product8=new ProductDetails("Turmeric Powder",10,25);
        productList.Add(product8);
        ProductDetails product9=new ProductDetails("Chilli Powder",10,20);
        productList.Add(product9);
        ProductDetails product10=new ProductDetails("Groundnut Oil",10,140);
        productList.Add(product10);

        BookingDetails booking1=new BookingDetails("CID3001",220,new(2022,7,26),Status.Booked);
        bookList.Add(booking1);
        BookingDetails booking2=new BookingDetails("CID3002",400,new DateTime(2022,7,26),Status.Booked);
        bookList.Add(booking2);
        BookingDetails booking3=new BookingDetails("CID3001",280,new(2022,7,26),Status.Cancelled);
        bookList.Add(booking3);
        
        OrderDetails order1=new OrderDetails("BID3001","PID101",2,80);
        orderList.Add(order1);
        OrderDetails order2=new OrderDetails("BID3001","PID102",2,100);
        orderList.Add(order2);
        OrderDetails order3=new OrderDetails("BID3001","PID103",1,40);
        orderList.Add(order3);
        OrderDetails order4=new OrderDetails("BID3002","PID101",1,40);
        orderList.Add(order4);
        OrderDetails order5=new OrderDetails("BID3002",	"PID102",4,200);
        orderList.Add(order5);
        OrderDetails order6=new OrderDetails("BID3002",	"PID110",1,140);
        orderList.Add(order6);
        OrderDetails order7=new OrderDetails("BID3002","PID109",1,20);
        orderList.Add(order7);
        OrderDetails order8=new OrderDetails("BID3003","PID102",2,100);
        orderList.Add(order8);
        OrderDetails order9=new OrderDetails("BID3003","PID108",4,100);
        orderList.Add(order9);
        OrderDetails order10=new OrderDetails("BID3003","PID101",2,80);
        orderList.Add(order10);

        }
        public static void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\t****Main Menu*****");
                Console.WriteLine("\t1.Customer Registration\n\t2.Customer Login\n\t3.Exit");
                choice=Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                    {
                        System.Console.WriteLine("****Customer Registration****");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        System.Console.WriteLine("****Customer Login****");
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
        public static void Login()
        {
            System.Console.Write("Enter CustomerID: ");
            string customerID=Console.ReadLine().ToUpper();
            bool isExist=false;
            foreach(CustomerRegistration customer in customerList)
            {
                if(customer.CustomerID==customerID)
                {
                    isExist=true;
                    currentCustomer=customer;
                    SubMenu();
                }
            }
            if(!isExist)
            {
                System.Console.WriteLine("InValid CustomerID.");
            }
        }
        public static void SubMenu()
        {
            int action;
            do
            {
                Console.WriteLine($"\t----Hello {currentCustomer.Name}----");
                System.Console.WriteLine("\t1.Show Customer Details\n\t2.Show Product Details\n\t3.Wallet Recharge\n\t4.Take Order\n\t5.Modify Order Quantity\n\t6.Cancel Order\n\t7.Exit");
                action=Convert.ToInt32(Console.ReadLine());
                switch(action)
                {
                    case 1: 
                    {
                        System.Console.WriteLine("\t****Show Customer Details****");
                        ShowCustomerDetails();
                        break;
                    }
                    case 2:
                    {
                        System.Console.WriteLine("\t****Show Product Details****");
                        ProductDetails();
                        break;
                    }
                    case 3:
                    {
                        System.Console.WriteLine("\t****Wallet Recharge****");
                        WalletRecharge();
                        break;
                    }
                    case 4:
                    {
                        System.Console.WriteLine("\t****Take Order****");
                        TakeOrder();
                        break;
                    }
                    case 5:
                    {
                        System.Console.WriteLine("\t****Modify Order Quantity****");
                        ModifyOrderQuantity();
                        break;
                    }
                    case 6:
                    {
                        System.Console.WriteLine("\t****Cancel Order****");
                        CancelBooking();
                        break;
                    }
                    
                }
            }while(action!=7);
        }
        public static void ShowCustomerDetails()
        {
            Console.WriteLine($"CustomerID: {currentCustomer.CustomerID} WalletBalance: {currentCustomer.WalletBalance} Name:{currentCustomer.Name} FatherName:{currentCustomer.FatherName}");
            Console.WriteLine($"Gender:{currentCustomer.Gender} Mobile:{currentCustomer.Mobile} DOB:{currentCustomer.DOB.ToString("dd/MM/yyyy")} MailID:{currentCustomer.MailID}\n");
        }
        public static void ProductDetails()
        {
            foreach(ProductDetails product in productList)
            {
                Console.WriteLine($"ProductID:{product.ProductID} ProductName:{product.ProductName} Quantity:{product.QuantityAvailable} PricePerQuantity:{product.PricePerQuantity}");
            }
        }
        public static void WalletRecharge()
        {
            System.Console.WriteLine("Enter the amount to be recharged: ");
            int amount=Convert.ToInt32(Console.ReadLine());
            currentCustomer.WalletRecharge(amount);
            System.Console.WriteLine($"You've successfully recharged.\nYour Balance is: {currentCustomer.WalletBalance}");
        }
        public static void ModifyOrderQuantity()
        { 
            bool exist=false; 
            foreach(BookingDetails booking in bookList)
            {
                if(currentCustomer.CustomerID==booking.CustomerID && booking.Status==Status.Booked)
                { exist=true;
                    Console.WriteLine($"BookingID:{booking.BookingID} CustomerID:{booking.CustomerID} TotalPrice:{booking.TotalPrice} DateOfBooking:{booking.DateOfBooking.ToString("dd/MM/yyyy")} BookingStatus:{booking.Status}");
                }
            }
            if(exist)
            {
            System.Console.Write("Enter Your Booking ID: ");
            string bookingID=Console.ReadLine().ToUpper();
            bool isExist=false;
            //validating Booking ID
            foreach(BookingDetails booking in bookList)
            {
                if(booking.BookingID==bookingID && booking.Status==Status.Booked)
                {
                    isExist=true;
                    foreach(OrderDetails order in orderList)
                    {
                        //Displaying Order ID
                        if(order.BookingID==bookingID)
                        {
                            Console.WriteLine($"OrderID:{order.OrderID} BookingID:{order.BookingID} ProductID:{order.ProductID} PurchaseCount:{order.PurchaseCount} PriceOfOrder:{order.PriceOfOrder}");
                        }
                    }
                    System.Console.Write("Selected an Order ID to modify: ");
                    string selOrderID=Console.ReadLine().ToUpper();
                    bool isOrderExist=false;
                    foreach(OrderDetails order in orderList)
                    {
                        if(order.OrderID==selOrderID)
                        {
                            isOrderExist=true;
                            System.Console.WriteLine("Enter Quantity: ");
                            int newQuantity=Convert.ToInt32(Console.ReadLine());
                            order.PurchaseCount=newQuantity;
                            foreach(ProductDetails product in productList)
                            {
                                if(order.ProductID==product.ProductID)
                                {
                                    booking.TotalPrice-=order.PriceOfOrder;
                                    order.PriceOfOrder=newQuantity*product.PricePerQuantity;
                                    product.IncreaseCount(order.PurchaseCount);
                                    product.DeductCount(newQuantity);
                                    booking.TotalPrice+=order.PriceOfOrder;
                                    Console.WriteLine("Order Modified");
                                }
                            }

                            
                        }
                    }
                    if(!isOrderExist)
                    {
                        System.Console.WriteLine("Invalid Order ID.");
                    }

                }
            }
            if(!isExist)
            {
                System.Console.WriteLine("Invalid Booking ID.");
            }
            }
            else if(!exist)
            {
                System.Console.WriteLine("You've not Booked yet");
            }
        }
        public static  void  CancelBooking()
        {
            bool isIt=false;
           foreach(BookingDetails booking in bookList)
            {
                if(currentCustomer.CustomerID==booking.CustomerID && booking.Status==Status.Booked)
                { isIt=true;
                     Console.WriteLine($"BookingID:{booking.BookingID} CustomerID:{booking.CustomerID} TotalPrice:{booking.TotalPrice} DateOfBooking:{booking.DateOfBooking.ToString("dd/MM/yyyy")} BookingStatus:{booking.Status}");
                }
            } 
            if(isIt)
            {
                System.Console.Write("Enter Booking ID to cancel:");
                string bookingID=Console.ReadLine().ToUpper();
                bool isExist=false;
                foreach(BookingDetails booking in bookList)
                {
                    if(bookingID==booking.BookingID && booking.Status==Status.Booked)
                    {
                        isExist=true;
                        int amount=booking.TotalPrice;
                        currentCustomer.WalletRecharge(amount);
                        foreach(OrderDetails order in orderList)
                        {
                            if(order.BookingID==booking.BookingID)
                            {
                                foreach(ProductDetails product in productList)
                                {
                                    if(product.ProductID==order.ProductID)
                                    {
                                        product.IncreaseCount(order.PurchaseCount);
                                    }
                                }
                            }
                        }
                        booking.Status=Status.Cancelled;
                        System.Console.WriteLine("Successfully Cancelled");
                        //should we use inheritance for product???
                    }
                } 
                if(!isExist)
                {
                    System.Console.WriteLine("Invalid Booking ID.");
                }
            }
            else
            {
                System.Console.WriteLine("You've not Order Yet.");
            }
        }
        public static void TakeOrder()
        {
            //Ask User IF he want to purchase or not, if no -  glad him
            System.Console.Write("Do You want to Purchase: ");
            bool answer=Console.ReadLine().ToLower()=="yes"?true:false;
            if(answer)
            {
                //if yes - create booking object with total price 0 and status as initiated
                BookingDetails book=new BookingDetails(currentCustomer.CustomerID,0,DateTime.Now,Status.Initiated);
                //create tempOrderList
                CustomList<OrderDetails>tempOrderList=new CustomList<OrderDetails>();
                validProductID:
                //show Product Details
                ProductDetails();
                bool isValid=false;
                //select Product ID and Purchase Quantity
                System.Console.Write("Enter Product ID: ");
                string productID=Console.ReadLine().ToUpper();
                // validate product ID and check quantity with Product count in product Detail
                foreach(ProductDetails product in productList)
                {
                    if(productID==product.ProductID)
                    {
                        isValid=true;
                        checkQuantity:
                        Console.Write("Enter Purchase Quantity: ");
                        int quantity=Convert.ToInt32(Console.ReadLine());
                        if(product.QuantityAvailable>=quantity)
                        {
                            int orderPrice=quantity*product.PricePerQuantity;
                            //Create order object deduct purchase count from Product detail store it in tempOrderList
                            OrderDetails temporder=new OrderDetails(book.BookingID,product.ProductID,quantity,orderPrice);
                            tempOrderList.Add(temporder);
                            product.DeductCount(quantity);
                            //Ask If he want to book another product
                            System.Console.Write("Do You want to select another Product?:");
                            bool another=Console.ReadLine().ToLower()=="yes"?true:false;
                            //if yes -  repeat from selecting product
                            if(another)
                            {
                                goto validProductID;
                            }
                            //if no - ask if he want to confirm order - 
                            else
                            {
                                System.Console.Write("Do You want to confirm your order:");
                                bool confirm=Console.ReadLine().ToLower()=="yes"?true:false;
                                if(confirm)
                                {
                                    foreach(OrderDetails order in tempOrderList)
                                    {
                                        book.TotalPrice+=order.PriceOfOrder;
                                    }
                                    //if yes - update book object - add tempOrderList to orderList
                                    proceedBooking:
                                    if(currentCustomer.WalletBalance>=book.TotalPrice)
                                    {
                                        currentCustomer.Deduct(orderPrice);
                                        orderList.AddRange(tempOrderList);
                                        book.Status=Status.Booked;
                                        bookList.Add(book);
                                        Console.WriteLine($"Your Booking has been successfully placed.\nYour Booking ID: {book.BookingID} TotalPrice: {book.TotalPrice}");

                                    }
                                    //if yes - check user has enough balance - if no - Recharge()
                                    else
                                    {
                                        insufficient:
                                        System.Console.Write($"Insufficient Balance. Your Products Costs: {book.TotalPrice} Your Balance: {currentCustomer.WalletBalance}\nDo You want to recharge: ");
                                        bool recharge=Console.ReadLine().ToLower()=="yes"?true:false;
                                        if(recharge)
                                        {
                                            WalletRecharge();
                                            if(currentCustomer.WalletBalance<book.TotalPrice)
                                            {
                                                goto insufficient;
                                            }
                                            else
                                            {
                                                goto proceedBooking;
                                            }
                                        }
                                    }

                                }
                                //if no - update product count to product details
                                else
                                {
                                    foreach(OrderDetails temprorder in tempOrderList)
                                    {
                                        if(temprorder.ProductID==product.ProductID)
                                        {
                                            product.IncreaseCount(temporder.PurchaseCount);
                                        }
                                    }
                                    System.Console.WriteLine("Cart Removed Successfully");

                                }
                            }

                        }
                        else
                        {
                            System.Console.WriteLine($"Specified Quantity not available\nAvailable Quantity: {product.QuantityAvailable}");
                            goto checkQuantity;
                        }

                    }
                }
                if(!isValid)
                {
                    System.Console.WriteLine("Invalid ProductID.");
                    goto validProductID;
                }
                
            }
        }
        public static void Registration()
        {
            System.Console.Write("Enter Your Name: ");
            string name=Console.ReadLine(); 
            System.Console.Write("Enter Your FatherName: ");
            string fatherName=Console.ReadLine();
            System.Console.Write("Specifiy Your Gender(male/female): ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine());
            System.Console.Write("Enter Your Mobile Number: ");
            long phone=Convert.ToInt64(Console.ReadLine());
            System.Console.Write("Enter Your DOB: ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            System.Console.Write("Enter Your MailID: ");
            string mailID=Console.ReadLine();
            System.Console.WriteLine("Recharge an Initial amount to proceed: ");
            int initial=Convert.ToInt32(Console.ReadLine());

            CustomerRegistration person=new CustomerRegistration(initial,name,fatherName,gender,phone,dob,mailID);
            customerList.Add(person);
            System.Console.WriteLine($"Registration successful\nYour Customer ID: {person.CustomerID}");

        }
    
    }
