using System;
using Xunit;


namespace CafeX.test
{

    public class DrinkOnlyCustomer
    {
        [Fact]
        public void CheckSurcharge()
        {
            Cafe cafeX = SetupCafe();

            //Customers Enters CafeX
            var customer = new Customer("Tom");
            cafeX.AddCustomer(customer);

            //Customer places order
            //Exercise 1 First sceanrio(Only Drinks)
            customer.Order(MenuName.Cola, 2);
            customer.Order(MenuName.Coffee, 1);

            //Calculate bills 
            cafeX.CalculateBill(customer);

            //Assert
            Assert.Equal(0, customer.surcharge);

        }

        private Cafe SetupCafe()
        {
            //To start let create a CafeX Entity
            var cafeX = new Cafe();

            //Add menu items to CafeX cafe
            cafeX.AddMenu(new Menu(MenuName.Cola, 0.50, FoodType.Drinks));
            cafeX.AddMenu(new Menu(MenuName.Coffee, 1.00, FoodType.Drinks));
            cafeX.AddMenu(new Menu(MenuName.CheeseSandwich, 2.00, FoodType.ColdFood));
            cafeX.AddMenu(new Menu(MenuName.SteakSandwich, 4.50, FoodType.HotFood));
            return cafeX;
        }
    }
}
