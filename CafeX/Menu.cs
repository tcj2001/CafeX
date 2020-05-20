namespace CafeX
{
    public class Menu
    {
        public MenuName name { get; set; }
        public double price { get; set; }
        public FoodType type { get; set; }

        public Menu(MenuName name,double price, FoodType type)
        {
            this.name = name;
            this.price = price;
            this.type = type;
        }
    }
}
