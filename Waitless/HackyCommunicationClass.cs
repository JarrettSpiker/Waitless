using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless
{
    static class HackyCommunicationClass
    {
        public static MainWindow mainWindow { get; set; }

        public static void registerMainWindow(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
        }

        public static MenuPage menuPage { get; set; }

        public static void registerMenuPage(MenuPage _menuPage)
        {
            menuPage = _menuPage;
        }

        public static CategoriesPage categoriesPage { get; set; }

        public static void registerCategoriesPage(CategoriesPage _categoriesPage)
        {
            categoriesPage = _categoriesPage;
        }

    }
}
