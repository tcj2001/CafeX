using System;
using Xunit;


namespace CafeX.test
{

    public class HotFoodCustomerSmallOrder
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
            customer.Order(MenuName.SteakSandwich, 1);
            customer.Order(MenuName.CheeseSandwich, 1);
            customer.Order(MenuName.Cola, 1);

            //Calculate bills
            //Exercise 1 Second Scenario (Cold Foods only)
            cafeX.CalculateBill(customer);

            //Assert
            Assert.Equal(customer.total*20/100, customer.surcharge);

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
