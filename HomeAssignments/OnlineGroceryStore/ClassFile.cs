using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public static  class ClassFile
    {
        public static void Create()
        {
            if(!Directory.Exists("OnlineGroceryStore"))
            {
                Directory.CreateDirectory("OnlineGroceryStore");
            }
            if(!File.Exists("OnlineGroceryStore/CustomerDetails.csv"))
            {
                File.Create("OnlineGroceryStore/CustomerDetails.csv").Close();
            }
            if(!File.Exists("OnlineGroceryStore/ProductDetails.csv"))
            {
                File.Create("OnlineGroceryStore/ProductDetails.csv").Close();
            }
            if(!File.Exists("OnlineGroceryStore/OrderDetails.csv"))
            {
                File.Create("OnlineGroceryStore/OrderDetails.csv").Close();
            }
            if(!File.Exists("OnlineGroceryStore/BookingDetails.csv"))
            {
                File.Create("OnlineGroceryStore/BookingDetails.csv").Close();
            }
        }
        public static void WriteToCSV()
        {
            string []text=new string [Operations.customerList.Count];
            for(int i=0;i<Operations.customerList.Count;i++)
            {
                text[i]=Operations.customerList[i].CustomerID+","+Operations.customerList[i].WalletBalance+","+Operations.customerList[i].Name+","+Operations.customerList[i].FatherName+","+Operations.customerList[i].Gender+","+Operations.customerList[i].Mobile+","+Operations.customerList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.customerList[i].MailID;
            }
            File.WriteAllLines("OnlineGroceryStore/CustomerDetails.csv",text);
            string []text2=new string[Operations.productList.Count];
            for(int i=0;i<Operations.productList.Count;i++)
            {
                text2[i]=Operations.productList[i].ProductID+","+Operations.productList[i].ProductName+","+Operations.productList[i].QuantityAvailable+","+Operations.productList[i].PricePerQuantity;
            }
            File.WriteAllLines("OnlineGroceryStore/ProductDetails.csv",text2);
            string []text3=new string[Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
                text3[i]=Operations.orderList[i].OrderID+","+Operations.orderList[i].BookingID+","+Operations.orderList[i].ProductID+","+Operations.orderList[i].PurchaseCount+","+Operations.orderList[i].PriceOfOrder;
            }
            File.WriteAllLines("OnlineGroceryStore/OrderDetails.csv",text3);
            string []text4=new string [Operations.bookList.Count];
            for(int i=0;i<Operations.bookList.Count;i++)
            {
                text4[i]=Operations.bookList[i].BookingID+","+Operations.bookList[i].CustomerID+","+Operations.bookList[i].TotalPrice+","+Operations.bookList[i].DateOfBooking.ToString("dd/MM/yyyy")+","+Operations.bookList[i].Status;
            }
            File.WriteAllLines("OnlineGroceryStore/BookingDetails.csv",text4);
        }
        public static void ReadFromCSV()
        {
            string []orderDetails=File.ReadAllLines("OnlineGroceryStore/OrderDetails.csv");
            foreach(string data in orderDetails)
            {
                OrderDetails order=new OrderDetails(data);
                Operations.orderList.Add(order);
            }
            string []customerDetails=File.ReadAllLines("OnlineGroceryStore/CustomerDetails.csv");
            foreach(string data in customerDetails)
            {
                CustomerRegistration customer=new CustomerRegistration(data);
                Operations.customerList.Add(customer);
            }
            string[]productDetails=File.ReadAllLines("OnlineGroceryStore/ProductDetails.csv");
            foreach(string data in productDetails)
            {
                ProductDetails product=new ProductDetails(data);
                Operations.productList.Add(product);
            }
            string[]bookingDetails=File.ReadAllLines("OnlineGroceryStore/BookingDetails.csv");
            foreach(string data in bookingDetails)
            {
                BookingDetails book=new BookingDetails(data);
                Operations.bookList.Add(book);
            }
        }
        
    }
}