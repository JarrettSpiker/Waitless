using System.Collections.Generic;
using System.Linq;

namespace Waitless.model
{
    public class OrderedItem
    {
        public ItemDefinition itemDefinition {get;}
        public string userId { get; }
        public Dictionary<string, bool> customizations { get; }
        public string selectedSide { get; set; }
        public string selectedSize { get; set; }
        public string selectedPreparation { get; set; }
        public string specialRequest { get; set; }
        public bool isRefill { get; set; }
        public int paidAlready = 0;

        public OrderedItem(ItemDefinition _itemDefinition, string _userId)
        {
            itemDefinition = _itemDefinition;
            userId = _userId;
            isRefill = false;
            if (itemDefinition.isCustomizable)
            {
                customizations = new Dictionary<string, bool>();
                foreach(string cust in itemDefinition.possibleCustomizations)
                {
                    customizations[cust] = false;
                }
            }
            
        }

        public int EffectiveCost()
        {
            if (!itemDefinition.hasSize || selectedSize == null)
            {
                return itemDefinition.cost - paidAlready;
            }

            int modifier = 0;
            for(int i = 0; i<itemDefinition.possibleSizes.Count; i++)
            {
                if (itemDefinition.possibleSizes[i].Equals(selectedSize))
                {
                    modifier = itemDefinition.sizeCosts[i];
                    break;
                }
            }
            return itemDefinition.cost + modifier - paidAlready;
        }

        public OrderedItem CreateCopy()
        {
            OrderedItem copy = new OrderedItem(itemDefinition, userId);
            copy.selectedSide = selectedSide;
            copy.selectedSize = selectedSize;
            copy.selectedPreparation = selectedPreparation;
            copy.specialRequest = specialRequest;
            copy.paidAlready = paidAlready;
            if (itemDefinition.isCustomizable)
            {
                foreach(KeyValuePair<string,bool> entry in customizations)
                {
                    copy.customizations[entry.Key] = entry.Value;
                }
            }
            return copy;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
