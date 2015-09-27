using System;
using System.Linq;
using System.Collections.Generic;

public class BoxesDiv2 {

   public int findSize(int[] candyCounts) {
      int boxes = candyCounts.Select(e => DetectBoxSize(e)).Sum();
      return DetectBoxSize(boxes, 32);
   }

   int DetectBoxSize(int x, int max = 10) {
      for (int i = 0; i < max; i++) {
         int sz = 1 << i;
         if (x <= sz) {
            return sz;
         }
      }

      return 1 << max;
   }

}
