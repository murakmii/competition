using System;
using System.Linq;
using System.Collections.Generic;

public class PackingBallsDiv2
{
   public int minPacks(int R, int G, int B)
   {
      var min = Math.Min(R, Math.Min(G, B));
      var ans = min;
      var remain = (new int[] { R - min, G - min, B - min }).Where(c => c > 0).ToList(); 

      for (int i = 0; i < remain.Count; i++) {
         var p = (int)Math.Floor(remain[i] / 3f);
         ans += p;
         remain[i] -= p * 3;
      }

      remain = remain.Where(r => r > 0).ToList();

      if (remain.Count == 0) {
         return ans;
      } else if (remain.Count == 1) {
         return ans + (int)Math.Ceiling(remain[0] / 3f);
      } else {
         return ans + Math.Max(remain[0], remain[1]);
      }
   }
}

