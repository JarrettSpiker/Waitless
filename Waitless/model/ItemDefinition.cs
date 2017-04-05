using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.model
{
    public class ItemDefinition
    {

        public enum Categories { AppetizersForOne, AppetizersToShare, Burgers, Steaks, SeaFood, Sandwhiches, Pasta, Pizza, Sides, Dessert, Drinks, Alcohol };


        //NOTE: the set only exists for the stupid deserializer. We should never be setting any of these in code
        public string name { get; set; }
        public string description { get; set; }
        public Categories category { get; set; }
        public string imageRef { get; set; }
        public int numStars { get; set; }
        public int cost { get; set; }
        public string nutritionalInfo { get; set; }

        public bool isSpicy { get; set; }
        public bool isVeg { get; set; }
        public bool isSpecialty { get;  }

        public bool needsPreparation { get; set; }
        public bool hasSides { get; set; }
        public bool hasSize { get; set; }
        public bool isCustomizable { get; set; }

        public List<string> possibleCustomizations { get; set; }
        public List<string> possiblePreparations { get; set; }
        public List<string> possibleSizes { get; set; }
        public List<string> possibleSides { get; set; }
        public List<int> sizeCosts { get; set; }

        public bool freeRefills { get; set; }


        public ItemDefinition()
        {
            //Necessary for deserialization
        }

        public ItemDefinition(string _name, string _description, Categories _category, string _imageRef, int _numStars,
            int _cost, string _nutritionalInfo, bool _needsPreparation, bool _hasSides, bool _hasSize, bool _isCustomizable,
            List<string> _customizations, List<string> _preparations, List<string> _sizes, List<string> _sides, bool _refills,
            bool _isSpicy, bool _isVeg, bool _isSpecialty, List<int> _sizeCosts)
        {
            name = _name;
            description = _description;
            category = _category;
            imageRef = _imageRef;
            numStars = _numStars;
            cost = _cost;
            nutritionalInfo = _nutritionalInfo;

            needsPreparation = _needsPreparation;
            hasSides = _hasSides;
            hasSize = _hasSize;
            isCustomizable = _isCustomizable;

            possibleCustomizations = _customizations;
            possiblePreparations = _preparations;
            possibleSizes = _sizes;
            possibleSides = _sides;

            freeRefills = _refills;

            isSpecialty = _isSpecialty;
            isSpicy = _isSpicy;
            isVeg = _isVeg;

            sizeCosts = _sizeCosts;
        }

    }
}
