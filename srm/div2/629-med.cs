using System;
using System.Linq;
using System.Collections.Generic;

public class CandyMaking {
   public double findSuitableDensity(int[] containerVolume, int[] desiredWeight) {
      // 三分探索!!
      double l = 0.0, r = 1000000.0;

      for (int i = 0; i < 10000; i++) {
         var newl = l + (r - l) / 3.0;
         var newr = l + (r - l) / 1.5;

         var a = func(newl, containerVolume, desiredWeight);
         var b = func(newr, containerVolume, desiredWeight);

         if (a > b) {
            l = newl;
         } else {
            r = newr;
         }
      }

      return func(l + (r - l) / 2.0, containerVolume, desiredWeight);
   }

   double func(double weight, int[] v, int[] d) {
      var sum = 0.0;
      for (int i = 0; i < v.Length; i++) {
         sum += Math.Abs(v[i] * weight - d[i]);
      }
      return sum;
   }
}
