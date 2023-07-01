namespace HM85_FoodMenu_XML
{
    public class MenuItem
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public ushort Calories { get; set; }

        public MenuItem(string? name, decimal price, string? description, ushort calories)
        {
            Name = name;
            Price = price;
            Description = description;
            Calories = calories;
        }
    }
}
