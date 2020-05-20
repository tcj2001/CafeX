using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CafeX
{
    class Program
    {
        static void Main(string[] args)
        {
            //To start let create a CafeX Entity
            var cafeX = new Cafe();

            //Add menu items to CafeX cafe
            cafeX.AddMenu(new Menu(MenuName.Cola, 0.50, FoodType.Drinks));
            cafeX.AddMenu(new Menu(MenuName.Coffee, 1.00, FoodType.Drinks));
            cafeX.AddMenu(new Menu(MenuName.CheeseSandwich, 2.00, FoodType.ColdFood));
            cafeX.AddMenu(new Menu(MenuName.SteakSandwich, 4.50, FoodType.HotFood));

            //Customers Enters CafeX, simulating 4 customer enter CafeX
            var customer1 = new Customer("Tom");
            var customer2 = new Customer("John");
            var customer3 = new Customer("Jane");
            var customer4 = new Customer("Harry");
            cafeX.AddCustomer(customer1);
            cafeX.AddCustomer(customer2);
            cafeX.AddCustomer(customer3);
            cafeX.AddCustomer(customer4);

            //Customer places order, simulating 4 scenarios
            //Exercise 1 First sceanrio(Only Drinks)
            customer1.Order(MenuName.Cola, 2);
            customer1.Order(MenuName.Coffee, 1);
               
            //Exercise 1 Second Scenario (Cold Foods only)
            customer2.Order(MenuName.CheeseSandwich, 4);
            customer2.Order(MenuName.Coffee, 4);

            //Exercise 2 (Hot Foods) scenario with service charge less than 20 pound 
            customer3.Order(MenuName.SteakSandwich, 1);
            customer3.Order(MenuName.CheeseSandwich, 1);
            customer3.Order(MenuName.Cola, 1);
            
            //Exercise 2 (Hot Foods) scenario with service charge above or equal to 20 pound 
            customer4.Order(MenuName.SteakSandwich, 20);
            customer4.Order(MenuName.CheeseSandwich, 20);
            customer4.Order(MenuName.Cola, 20);

            //Calculate bills and then generate bill for customers
            //Exercise 1 Second Scenario (Only Drinks)
            cafeX.CalculateBill(customer1);
            cafeX.GenerateBill(customer1);

            //Exercise 1 Second Scenario (Cold Foods only)
            cafeX.CalculateBill(customer2);
            cafeX.GenerateBill(customer2);

            //Exercise 2 (Hot Foods) scenario with service charge less than 20 pound 
            cafeX.CalculateBill(customer3);
            cafeX.GenerateBill(customer3);

            //Exercise 2 (Hot Foods) scenario with service charge above or equal to 20 pound 
            cafeX.CalculateBill(customer4);
            cafeX.GenerateBill(customer4);

  



        }
    }
}
