using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CafeX
{
    public class Customer 
    {

        public string name { get; set; }
        public Dictionary<MenuName,int> orders { get; set; }
        public double total { get; set; }
        public double surcharge { get; set; }
        public double grandTotal { get; set; }

        public Customer(string name)
        {
            this.name = name;
            total = 0.0;
            surcharge = 0.0;
            grandTotal = 0.0;
            orders = new Dictionary<MenuName,int>();
        }
        public void Order(MenuName menuName, int qty)
        {
            orders.Add(menuName,qty);
        }
    }
}
