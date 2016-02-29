using System;
using System.Linq;
using System.Collections.Generic;

public class MoveStonesEasy {
   public int get(int[] a, int[] b) {
      if (a.Sum() != b.Sum()) {
         return -1;
      }

      int ans = 0, n = a.Length;

      for (int i = 0; i < n; i++) {
         if (a[i] >= b[i]) continue;
         int need = b[i] - a[i];

         for (int j = 0; j < n; j++) {
            if (i == j) continue;

            if (a[j] > b[j]) {
               int mv = Math.Min(need, a[j] - b[j]);
               need -= mv;
               a[i] += mv;
               a[j] -= mv;
               ans += mv * Math.Abs(i - j);
            }

            if (need == 0) break;
         }
      }

      return ans;
   }
}
