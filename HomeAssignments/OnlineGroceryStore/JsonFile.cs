using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public static class JsonFile
    {
        public static void Create()
        {
            if(!Directory.Exists("OnlineGroceryStore"))
            {
                Directory.CreateDirectory("OnlineGroceryStore");
            }
            if(!File.Exists("OnlineGroceryStore/CustomerDetails.json"))
            {
                File.Create("OnlineGroceryStore/CustomerDetails.json").Close();
            }
            if(!File.Exists("OnlineGroceryStore/ProductDetails.json"))
            {
                File.Create("OnlineGroceryStore/ProductDetails.json").Close();
            }
            if(!File.Exists("OnlineGroceryStore/OrderDetails.json"))
            {
                File.Create("OnlineGroceryStore/OrderDetails.json").Close();
            }
            if(!File.Exists("OnlineGroceryStore/BookingDetails.json"))
            {
                File.Create("OnlineGroceryStore/BookingDetails.json").Close();
            }
        }
        public static void  WriteToJson()
        {
            var options=new JsonSerializerOptions(){WriteIndented=true};
            StreamWriter writeCustomer=new StreamWriter("OnlineGroceryStore/CustomerDetails.json");
            writeCustomer.WriteLine(JsonSerializer.Serialize(Operations.customerList,options));
            writeCustomer.Close();
            StreamWriter writeProduct=new StreamWriter("OnlineGroceryStore/ProductDetails.json");
            writeProduct.WriteLine(JsonSerializer.Serialize(Operations.productList,options));
            writeProduct.Close();
            StreamWriter writeOrder=new StreamWriter("OnlineGroceryStore/OrderDetails.json");
            writeOrder.WriteLine(JsonSerializer.Serialize(Operations.orderList,options));
            writeOrder.Close();
            StreamWriter writeBook=new StreamWriter("OnlineGroceryStore/BookingDetails.json");
            writeBook.WriteLine(JsonSerializer.Serialize(Operations.bookList,options));
            writeBook.Close();
        }
        public static void ReadFromJSON()
        {

        }
    }
}