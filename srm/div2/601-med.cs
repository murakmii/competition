using System;
using System.Linq;
using System.Collections.Generic;

class WinterAndCandies
{
   public int getNumber(int[] type)
   {
      var T = type.OrderBy(t => t).ToList();
      var dic = new Dictionary<int, int>();
      var n = 1;

      for (int i = 0; i < T.Count; i++) {
         var ok = false;
         if (T[i] == n) {
            ok = true;   
         } else if (T[i] == n + 1) {
            n++;
            ok = true;
         }

         if (ok) {
            if (!dic.ContainsKey(T[i])) {
               dic.Add(T[i], 0);
            }

            dic[T[i]]++;
         } else {
            break;
         }
      }
      
      int ans = 0;
      for (int i = 0; i < 50; i++) {
         if (!dic.ContainsKey(i + 1)) {
            break;
         }

         int a = 1;
         for (int j = 0; j <= i; j++) {
            a *= dic[j + 1];
         }
         ans += a;
      }

      return ans;
   }
}
