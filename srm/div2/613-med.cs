using System;
using System.Linq;
using System.Collections.Generic;

public class TaroFriends
{
   public int getNumber(int[] coordinates, int X)
   {
      int ans = -1;

      var c = new List<int>(coordinates.Distinct());
      c.Sort();

      for (int i = 0; i <= c.Count; i++) {
         var t = new List<int>(c);
         for (int j = 0; j < t.Count; j++) {
            if (j < i) {
               t[j] += X;
            } else {
               t[j] -= X;
            }
         }

         int r = Math.Abs(t.Max() - t.Min());
         if (ans == -1 || ans > r) {
            ans = r;
         }
      }

      return ans;
   }
}
