using System;
using System.Linq;
using System.Collections.Generic;

class MysticAndCandiesEasy
{
   public int minBoxes(int C, int X, int[] high)
   {
      var h = new Queue<int>(high.OrderBy(e => e));
      var box = new List<int>();

      while(C > 0 && h.Count > 0) {
         var t = h.Dequeue();
         box.Add(C >= t ? t : C);
         C -= t;
      }

      box.Reverse();

      int ans = h.Count;
      int c = 0;
     
      foreach (var b in box) {
         c += b;
         ans++;
         if (c >= X) {
            break;
         }
      }

      return ans;
   }
}
