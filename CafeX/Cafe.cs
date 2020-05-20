using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeX
{
    public class Cafe
    {
        public List<Customer> customers { get; set; }
        public List<Menu> menus { get; set; }

        public Cafe()
        {
            this.menus = new List<Menu>();
            this.customers = new List<Customer>();
        }

        public void AddMenu(Menu menu)
        {
            this.menus.Add(menu);
        }

        public void AddCustomer(Customer customer)
        {
            this.customers.Add(customer);
        }

        Menu GetMenuDetail(MenuName name)
        {
            foreach (Menu menuitem in this.menus)
            {
                if (name == menuitem.name)
                {
                    return menuitem;
                }
            }
            return null;
        }

        public void CalculateBill(Customer customer)
        {
            //calcuate total first
            customer.total = 0;
            foreach (KeyValuePair<MenuName, int> menuItem in customer.orders)
            {
                var price = GetMenuDetail(menuItem.Key).price;
                var cost = price * menuItem.Value;
                customer.total += cost;
            }
            //calculate surcharge
            customer.surcharge = 0;
            //this loop check for any hot food
            foreach (KeyValuePair<MenuName, int> menuItem in customer.orders)
            {
                var menu = GetMenuDetail(menuItem.Key);
                if (menu.type == FoodType.HotFood)
                {
                    customer.surcharge = Math.Min(customer.total * 20 / 100, 20);
                    break;
                };
            }
            if (customer.surcharge == 0)
            {
                //this loop will check cold food in no hot hot exist in the mordered menu
                foreach (KeyValuePair<MenuName, int> menuItem in customer.orders)
                {
                    var menu = GetMenuDetail(menuItem.Key);
                    if (menu.type == FoodType.ColdFood)
                    {
                        customer.surcharge = customer.total * 10 / 100;
                        continue;
                    };
                }
            }
            //calculate grand total
            customer.grandTotal = Math.Round(customer.total + customer.surcharge, 2);


        }

        public void GenerateBill(Customer customer)
        {
            Console.WriteLine('\n');
            Console.WriteLine($"Customer: {customer.name}");
            Console.WriteLine("###################################################################");
            Console.WriteLine("Item                                      Qty                  Cost");
            Console.WriteLine("-------------------------------           ---           -----------");
            foreach (KeyValuePair<MenuName, int> menuItem in customer.orders)
            {
                var price = GetMenuDetail(menuItem.Key).price;
                var cost = price * menuItem.Value;
                Console.WriteLine($"{menuItem.Key.ToString().PadRight(43)} {menuItem.Value} {"".PadRight(14)}  {String.Format("{0,5:0.00}", cost)}");
            }
            Console.WriteLine("###################################################################");
            Console.WriteLine($"Sub Total:  {"".PadRight(49)} {String.Format("{0,5:0.00}", customer.total)}");
            Console.WriteLine($"Surcharge Total:  {"".PadRight(43)} {String.Format("{0,5:0.00}", customer.surcharge)}");
            Console.WriteLine($"Grand Total:  {"".PadRight(47)} {String.Format("{0,5:0.00}", customer.grandTotal)}");

        }
    }
}
