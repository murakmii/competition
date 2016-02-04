using System;
using System.Linq;
using System.Collections.Generic;

public class QuadraticLaw {

   public long getTime(long d) {
      long max = (long)Math.Ceiling(Math.Sqrt(d)), min = 0;

      // dが大きいのである程度の段階まで二分探索する
      while (max - min > 1000) {
         long c = min + (max - min) / 2;
         if (d - c > c * c) {
            min = c;
         } else {
            max = c;
         }
      }

      long ans = min;
      while (d - ans >= ans * ans) {
         ans++;
      }

      return ans - 1;
   }

}
