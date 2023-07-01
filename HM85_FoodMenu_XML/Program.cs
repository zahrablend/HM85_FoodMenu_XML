namespace HM85_FoodMenu_XML
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var menu = new BreakfastMenu();
            menu.LoadFromFile("sample2.xml");

            var newItem = new MenuItem("Cupcake", 2.45m, "Blueberry banana muffins", 450);
            menu.MenuItems?.Add(newItem);

            menu.SaveToFile("sample2.xml");
        }
    }
}