using System;
using System.Linq;
using System.Collections.Generic;

public class ShoppingSurveyDiv2 {

   public int minValue(int N, int[] s) {
      int ans = 0;
      while (s.Sum() / (double)N > (s.Length - 1)) {
         ans++;
         N--;
         for (int i = 0; i < s.Length; i++) {
            s[i]--;
         }
      }

      return ans;
   }

}
