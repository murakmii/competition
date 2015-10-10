using System;
using System.Linq;
using System.Collections.Generic;

public class Drbalance {

   public int lesscng(string S, int k) {

      var s = S.ToCharArray();
      var mq = new Queue<int>(new int[] { -1 });
      for (int i = 0; i < s.Length; i++) {
         if (s[i] == '-') {
            mq.Enqueue(i);
         }
      }

      int n = 51, ans = 0;
      while (n > k) {

         if (mq.Count == 0) {
            break;
         }

         var midx = mq.Dequeue();
         if (midx >= 0) {
            s[midx] = '+';
            ans++;
         }

         n = 0;
         int m = 0, p = 0;
         for (int i = 0; i < s.Length; i++) {
            if (s[i] == '+') {
               p++;
            } else {
               m++;
            }
            if (m > p) {
               n++;
            }
         }
      }

      return ans;
   }
}
