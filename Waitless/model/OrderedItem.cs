using System.Collections.Generic;

namespace Waitless.model
{
    class OrderedItem
    {
        public ItemDefinition itemDefinition {get;}
        public string userId { get; }
        public Dictionary<string, bool> customizations { get; }
        public string selectedSide { get; set; }
        public string selectedSize { get; set; }
        public string selectedPreparation { get; set; }
        public string specialRequest { get; set; }

        public OrderedItem(ItemDefinition _itemDefinition, string _userId)
        {
            itemDefinition = _itemDefinition;
            userId = _userId;

            if (itemDefinition.isCustomizable)
            {
                customizations = new Dictionary<string, bool>();
                foreach(string cust in itemDefinition.possibleCustomizations)
                {
                    customizations[cust] = false;
                }
            }
            
        }

    }
}
