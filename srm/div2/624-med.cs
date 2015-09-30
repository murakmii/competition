using System;
using System.Linq;
using System.Collections.Generic;

public class BuildingHeightsEasy {

   public int minimum(int M, int[] heights) {
      if (M == 1) {
         return 0;
      }

      Array.Sort(heights, (a, b) => a != b ? b - a : 0);

      int ans = -1;
      for (int i = 0; i < heights.Length - M + 1; i++) {
         int tmp = 0;
         for (int j = 1; j < M; j++) {
            tmp += heights[i] - heights[i + j];
         }

         ans = ans == -1 ? tmp : Math.Min(ans, tmp);
      }

      return ans;
   }

}
