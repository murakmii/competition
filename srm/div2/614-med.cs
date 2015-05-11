using System;
using System.Linq;
using System.Collections.Generic;

public class MinimumSquareEasy
{
   public long minArea(int[] x, int[] y)
   {
      long ans = -1;

      for (int i = 0; i < x.Length; i++) {
         for (int j = i + 1; j < x.Length; j++) {
            int xMin = 1000000001, xMax = -1000000001, yMin = 1000000001, yMax = -1000000001;
            for (int k = 0; k < x.Length; k++) {
               if (k == i || k == j) {
                  continue;
               }

               if (x[k] < xMin) {
                  xMin = x[k];
               }

               if (x[k] > xMax) {
                  xMax = x[k];
               }

               if (y[k] < yMin) {
                  yMin = y[k];
               }

               if (y[k] > yMax) {
                  yMax = y[k];
               }
            }

            var side = (long)Math.Max(Math.Abs(xMax - xMin) + 2, Math.Abs(yMax - yMin) + 2);
            long a = side * side;

            ans = ans == -1 ? a : Math.Min(ans, a);
         }
      }

      return ans;
   }
}
