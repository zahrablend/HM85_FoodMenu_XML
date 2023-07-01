using System.Xml.Linq;

namespace HM85_FoodMenu_XML
{
    public class BreakfastMenu
    {
        public List<MenuItem> MenuItems { get; set; }

        public BreakfastMenu()
        {
            MenuItems = new List<MenuItem>();
        }

        public void LoadFromFile(string fileName)
        {
            XDocument file = XDocument.Load(fileName);
            var menuItems = file.Descendants("food");
            foreach (var menuItem in menuItems)
            {
                string? name = menuItem.Element("name")?.Value;
                // ?. => null-conditional operator, if price null, doesn't throw not NullReferenceException
                // ?? => null-coalescing operator provides default value if price is null
                decimal price = decimal.Parse(menuItem.Element("price")?.Value.TrimStart('$') ?? "0.00");
                string? description = menuItem.Element("description")?.Value;
                ushort calories = ushort.Parse(menuItem.Element("calories")?.Value ?? "0");
                var item = new MenuItem(name, price, description, calories);
                MenuItems?.Add(item);
            }
        }

        public void SaveToFile(string fileName)
        {
            var file = new XDocument();
            // root element = top element in XML document hierarchy
            var root = new XElement("breakfast_menu");
            file.Add(root);
            foreach (var item in MenuItems)
            {
                var menuElement = new XElement("food");
                menuElement.Add(new XElement("name", item.Name));
                menuElement.Add(new XElement("price", $"${item.Price}"));
                menuElement.Add(new XElement("description", item.Description));
                menuElement.Add(new XElement("calories", item.Calories));
                root.Add(menuElement);
            }
            file.Save(fileName);
        }
    }
}
