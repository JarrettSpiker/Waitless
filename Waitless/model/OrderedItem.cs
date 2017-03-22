using System.Collections.Generic;
using System.Linq;

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

        public override bool Equals(object obj)
        {
            var item = obj as OrderedItem;

            if (item == null)
            {
                return false;
            }

            if(itemDefinition != item.itemDefinition)
            {
                return false;
            }
            if(selectedSide != item.selectedSide
                || selectedSize != item.selectedSize
                || selectedPreparation != item.selectedPreparation
                || specialRequest != item.specialRequest)
            {
                return false;
            }

            if (itemDefinition.isCustomizable)
            {
                bool equal = false;
                if (customizations.Count == item.customizations.Count) // Require equal count.
                {
                    equal = true;
                    foreach (var pair in customizations)
                    {
                        bool value;
                        if (item.customizations.TryGetValue(pair.Key, out value))
                        {
                            // Require value be equal.
                            if (value != pair.Value)
                            {
                                equal = false;
                                break;
                            }
                        }
                        else
                        {
                            // Require key be present.
                            equal = false;
                            break;
                        }
                    }
                }

                return equal;
            }
            return true;
        }
    }
}
