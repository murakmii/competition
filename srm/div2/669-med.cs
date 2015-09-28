using System;
using System.Linq;
using System.Collections.Generic;

public class CombiningSlimes {

   public int maxMascots(int[] a) {
      int ans = 0;
      var s = new List<int>(a);
      while (s.Count > 1) {
         var next = new List<int>();

         s.Sort();
         s.Reverse();

         var q = new Queue<int>(s);
         while (q.Count >= 2) {
            int x = q.Dequeue(), y = q.Dequeue();
            ans += x * y;
            next.Add(x + y);
         }

         if (q.Count == 1) {
            next.Add(q.Dequeue());
         }

         s = next;
      }

      return ans;
   }

}
