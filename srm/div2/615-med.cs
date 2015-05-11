using System;
using System.Linq;
using System.Collections.Generic;

public class LongLongTripDiv2
{
   public string isAble(long D, int T, int B)
   {
      // 2sぎりぎりなのでもしかすると落ちるかも
      while(D > 0 && T > 0 && D >= T) {
         if (D == T) {
            return "Possible";
         }

         T--;
         D -= B;

         if (T == 0 && D == 0) {
            return "Possible";
         }
      }

      return "Impossible";
   }
}
