using System;
using System.Linq;
using System.Collections.Generic;

public class SlimeXSlimonadeTycoon
{
   public int sell(int[] morning, int[] customers, int stale_limit)
   {
      int ans = 0;
      int l = stale_limit - 1;

      for (int i = 0; i < morning.Length; i++) {
         for (int j = i - l < 0 ? 0 : i - l; j <= i; j++) {
            var a = morning[j] >= customers[i] ? customers[i] : morning[j];

            morning[j] -= a;
            customers[i] -= a;
            ans += a;
         }
      }

      return ans;
   }
}
