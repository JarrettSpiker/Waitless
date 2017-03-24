using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless
{
    class Global
    {
        public static String username;
        public static String tablecode;
        public static MainWindow Main;
        public static Keyboard kb;
 
        public static void paid()
        {
            Paid i = new Paid();
            i.Show();
        }

        public static void showKeyboard()
            {
            if (kb == null) kb = new Keyboard();
            kb.Show();
            }

        public static void hideKeyboard()
        {
            if (kb != null)
            {
                kb.closed = true;
                kb.Close();
                kb = null;
            }
        }

        public static String ChangeFromDefault(String Ref, String Cmp)
        {
            if (Cmp.Length < Ref.Length) return "";
            if (Cmp.Length > Ref.Length) return Cmp.ToCharArray()[Cmp.Length - 1].ToString();
            char[] cmp = Cmp.ToCharArray();
            char[] REF = Ref.ToCharArray();
            int i;
            for (i = 0; i < Cmp.Length; i++)
            {
                if (cmp[i] != REF[i])
                    break;
            }
            return cmp[i].ToString();
        }

 
    }
}
