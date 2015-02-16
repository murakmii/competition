using System;
using System.Linq;
using System.Collections.Generic;

class BinPackingEasy
{
   public int minBins(int[] I)
   {
      var b = new List<int>(new int[]{ 300 });
      var items = I.OrderByDescending(i => i).ToList();

      for (int j = 0; j < items.Count;) {
         var item = items[j];

         int min = -1;
         for (int i = 0; i < b.Count; i++) {
            if (b[i] >= item && (min == -1 || b[min] > b[i])) {
               min = i;
            }
         }

         if (min == -1) {
            b.Add(300);
         } else {
            b[min] -= item;
            j++;
         }
      }

      return b.Count;
   }
}
