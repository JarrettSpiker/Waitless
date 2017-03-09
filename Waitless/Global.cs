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
        

        public static String ChangeFromDefault(String Ref, String Cmp)
        {
            if (Cmp.Length < Ref.Length) return "";
            char[] cmp = Cmp.ToCharArray();
            char[] REF = Ref.ToCharArray();
            int i;
            for (i = 0; i < Cmp.Length; i++)
                if (cmp[i] != REF[i])
                    break;
            return cmp[i].ToString();
        }

       

    }
}
