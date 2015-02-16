using System;

class WolfDelaymaster
{
   public string check(string str)
   {
      for (int i = 0; i < str.Length;) {
         
         if (str[i] != 'w') {
            return "INVALID";
         }

         var w = 0;
         while(i < str.Length && str[i] == 'w') {
            w++;
            i++;
         }

         foreach (var t in new char[] {'o', 'l', 'f'}) {
            if (i + w > str.Length || new String(t, w) != str.Substring(i, w)) {
               return "INVALID";
            }

            i += w;
         }
      }

      return "VALID";
   }
}
