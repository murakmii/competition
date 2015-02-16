using System;
using System.Linq;
using System.Collections.Generic;

class SplitIntoPairs
{
   public int makepairs(int[] A, int X)
   {
      int ans = 0;
      var P = A.Where(a => a >= 0).OrderBy(a => a).ToList();

      int RP = -1;
      if (P.Count % 2 == 0) {
         ans += P.Count / 2;
      } else {
         ans += (P.Count - 1) / 2; 
         RP = P[0];
      }

      var N = (new List<int>(A)).Where(a => a < 0).ToList();
      if (N.Count % 2 == 0) {
         ans += N.Count / 2;
      } else {
         ans += (N.Count - 1) / 2;
         foreach (var n in N) {
            long nl = n;
            long rp = RP;
            if (nl * rp >= (long)X) {
               ans++;
               break;
            }
         }
      }

      return ans;
   }
}
