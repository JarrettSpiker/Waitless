using System.Collections.Generic;
using Waitless.model;
using System.Web.Script.Serialization;
using System.IO;

namespace Waitless
{
    static class ItemDefinitionController
    {
        public static Dictionary<string, ItemDefinition> itemDefinitions { get; set; }
        private static readonly string fileName = "../../itemDefinitions.json";



        public static void InitializeItemDefinitions()
        {
            itemDefinitions = new Dictionary<string, ItemDefinition>();
            string jsonString = File.ReadAllText(fileName);

            List<ItemDefinition> items = new JavaScriptSerializer().Deserialize<List<ItemDefinition>>(jsonString);

            foreach(ItemDefinition item in items)
            {
                itemDefinitions[item.name] = item;
            }
        }


        //DONT CALL THIS!!!!!!!
        public static void CreateSerialization()
        {
            List<ItemDefinition> definitions = new List<ItemDefinition>();

            definitions.Add(new ItemDefinition("Jalapeno Poppers", "Sample Description", ItemDefinition.Categories.AppetizersForOne,
                "/Images/MenuItems/JalapenoPopper.jpg", 4, 900, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
                false, true, true, false));

            definitions.Add(new ItemDefinition("Calamari", "Sample Description", ItemDefinition.Categories.AppetizersForOne,
                "/Images/MenuItems/calamari.jpg", 3, 1100, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
                false, false, false, true));

            definitions.Add(new ItemDefinition("Nachos", "Sample Description", ItemDefinition.Categories.AppetizersToShare,
                "/Images/MenuItems/nachos.jpg", 5, 1100, "Sample Nutritional Info", false, false, false, true, new List<string> {"Add gound beef?" }, null, null, null,
                false, true, false, true));


            definitions.Add(new ItemDefinition("Short Ribs", "Sample Description", ItemDefinition.Categories.AppetizersToShare,
               "/Images/MenuItems/shortRibs.jpg", 3, 1500, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
               false, false, false, false));

            definitions.Add(new ItemDefinition("Classic Burger", "Sample Description", ItemDefinition.Categories.Burgers,
               "/Images/MenuItems/classicBurger.jpg", 4, 1600, "Sample Nutritional Info", false, true, false, true,
               new List<string> { "Remove Lettuce", "Remove Tomato", "Remove Pickles" }, null, null,
               new List<string> { "Yukon Fries", "Yam Fries", "Mashed Potatoes", "Caesar Salad" },
               false, false, false, true));

            definitions.Add(new ItemDefinition("Western Burger", "Sample Description", ItemDefinition.Categories.Burgers,
              "/Images/MenuItems/westernBurger.jpg", 2, 1900, "Sample Nutritional Info", false, true, false, true,
              new List<string> { "Remove Lettuce", "Remove Tomato", "Remove Pickles"}, null, null,
              new List<string> { "Yukon Fries", "Yam Fries", "Mashed Potatoes", "Caesar Salad" },
              false, false, false, false));

            definitions.Add(new ItemDefinition("Chicken Burger", "Sample Description", ItemDefinition.Categories.Burgers,
              "/Images/MenuItems/chickenBurger.jpg", 4, 1300, "Sample Nutritional Info", false, true, false, true,
              new List<string> { "Remove Lettuce", "Remove Tomato"}, null, null, 
              new List<string> { "Yukon Fries", "Yam Fries", "Mashed Potatoes", "Caesar Salad" },
              false, false, false, false));

            definitions.Add(new ItemDefinition("T-Bone Steak", "Sample Description", ItemDefinition.Categories.Steaks,
              "/Images/MenuItems/tBone.jpg", 5, 3100, "Sample Nutritional Info", true, true, false, true,
              new List<string> { "Add Steak Sauce", "Add Peppercorns"}, new List<string> { "Rare", "Medium-Rare", "Medium", "Well Done" },
              null, new List<string> { "Yukon Fries", "Yam Fries", "Mashed Potatoes", "Caesar Salad"},
              false, false, false, true));

            definitions.Add(new ItemDefinition("New York Strip Loin", "Sample Description", ItemDefinition.Categories.Steaks,
              "/Images/MenuItems/newYorkStrip.jpg", 5, 3500, "Sample Nutritional Info", true, true, false, true,
              new List<string> { "Add Steak Sauce", "Add Peppercorns" }, new List<string> { "Rare", "Medium-Rare", "Medium", "Well Done" },
              null, new List<string> { "Yukon Fries", "Yam Fries", "Mashed Potatoes", "Caesar Salad" },
              false, false, false, false));

            definitions.Add(new ItemDefinition("Fish and Chips", "Sample Description", ItemDefinition.Categories.SeaFood,
              "/Images/MenuItems/fishAndChips.jpg", 3, 1300, "Sample Nutritional Info", false, true, false, true,
              new List<string> { "Add Lemon" }, null,
              null, new List<string> { "Yukon Fries", "Caesar Salad" },
              false, false, false, false));

            definitions.Add(new ItemDefinition("Salmon", "Sample Description", ItemDefinition.Categories.SeaFood,
              "/Images/MenuItems/salmon.jpg", 5, 2500, "Sample Nutritional Info", false, true, false, true,
              new List<string> { "Add Lemon" }, null,
              null, new List<string> { "Yukon Fries", "Caesar Salad" },
              false, false, false, false));

            definitions.Add(new ItemDefinition("Chicken Club", "Sample Description", ItemDefinition.Categories.Sandwhiches,
              "/Images/MenuItems/chickenClub.jpg", 4, 1900, "Sample Nutritional Info", false, true, false, true,
              new List<string> { "Remove Lettuce", "Remove Tomato" }, null,
              null, new List<string> { "Yukon Fries", "Caesar Salad" },
              false, false, false, false));

            definitions.Add(new ItemDefinition("BLT", "Sample Description", ItemDefinition.Categories.Sandwhiches,
              "/Images/MenuItems/blt.jpg", 5, 1700, "Sample Nutritional Info", false, true, false, true,
              new List<string> { "Remove Lettuce", "Remove Tomato" }, null,
              null, new List<string> { "Yukon Fries", "Caesar Salad" },
              false, false, false, false));

            definitions.Add(new ItemDefinition("Spaghetti", "Sample Description", ItemDefinition.Categories.Pasta,
              "/Images/MenuItems/spaghetti.jpg", 4, 1700, "Sample Nutritional Info", false, true, true, true,
              new List<string> { "Add Parmesean" }, null,
              new List<string> {"Full Size", "Half Size"}, new List<string> { "Garlic Bread", "Caesar Salad" },
              false, false, true, false));

            definitions.Add(new ItemDefinition("Lasagna", "Sample Description", ItemDefinition.Categories.Pasta,
              "/Images/MenuItems/lasagna.jpg", 4, 2000, "Sample Nutritional Info", false, true, true, true,
              new List<string> { "Add Parmesean" }, null,
              new List<string> { "Full Size", "Half Size" }, new List<string> { "Garlic Bread", "Caesar Salad" },
              false, false, true, true));

            definitions.Add(new ItemDefinition("Cheese Pizza", "Sample Description", ItemDefinition.Categories.Pizza,
              "/Images/MenuItems/cheesePizza.jpg", 5, 2100, "Sample Nutritional Info", false, false, true, false,
              new List<string> { "Add Parmesean" }, null,
              new List<string> { "12 inch", "14 inch" }, null,
              false, false, false, false));

            definitions.Add(new ItemDefinition("Pepperoni Pizza", "Sample Description", ItemDefinition.Categories.Pizza,
              "/Images/MenuItems/pepperoniPizza.jpg", 4, 2200, "Sample Nutritional Info", false, false, true, false,
              new List<string> { "Add Parmesean" }, null,
              new List<string> { "12 inch", "14 inch" }, null,
              false, false, false, false));

            definitions.Add(new ItemDefinition("Ice Cream", "Sample Description", ItemDefinition.Categories.Dessert,
                "/Images/MenuItems/IceCream.jpg", 4, 1000, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
                false, false, true, false));

            definitions.Add(new ItemDefinition("Chocolate Brownie", "Sample Description", ItemDefinition.Categories.Dessert,
                "/Images/MenuItems/brownie.jpg", 4, 1200, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
                false, false, true, false));

            definitions.Add(new ItemDefinition("Water", "Sample Description", ItemDefinition.Categories.Drinks,
                "/Images/MenuItems/water.jpg", 0, 0, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
                true, false, false, false));

            definitions.Add(new ItemDefinition("Milk", "Sample Description", ItemDefinition.Categories.Drinks,
                "/Images/MenuItems/milk.jpg", 0, 300, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
                true, false, false, false));

            definitions.Add(new ItemDefinition("Pepsi", "Sample Description", ItemDefinition.Categories.Drinks,
                "/Images/MenuItems/Pepsi.png", 0, 300, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
                true, false, false, false));

            definitions.Add(new ItemDefinition("7-Up", "Sample Description", ItemDefinition.Categories.Drinks,
               "/Images/MenuItems/7up.png", 0, 300, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
               true, false, false, false));

            definitions.Add(new ItemDefinition("Rickards Red", "Sample Description", ItemDefinition.Categories.Alcohol,
               "/Images/MenuItems/rickardsRed.jpg", 4, 700, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
               false, false, false, false));

            definitions.Add(new ItemDefinition("Alexander Keiths", "Sample Description", ItemDefinition.Categories.Alcohol,
               "/Images/MenuItems/alexanderKeiths.jpg", 5, 800, "Sample Nutritional Info", false, false, false, false, null, null, null, null,
               false, false, false, false));

            definitions.Add(new ItemDefinition("Red Wine", "Sample Description", ItemDefinition.Categories.Alcohol,
               "/Images/MenuItems/wine.jpg", 2, 500, "Sample Nutritional Info", false, false, true, false, null, null,
               new List<string> {"Glass", "Bottle" }, null, false, false, false, false));

            string json = new JavaScriptSerializer().Serialize(definitions);
            File.WriteAllText(fileName, json);

        }

    }
}
