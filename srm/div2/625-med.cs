using System;
using System.Linq;
using System.Collections.Generic;

public class IncrementingSequence {

   public string canItBeDone(int k, int[] A) {

      var required = new HashSet<int>();
      for (int i = 0; i < A.Length; i++) {
         required.Add(i + 1);
      }

      var t = new HashSet<int>();
      var left = new List<HashSet<int>>();
      foreach (var e in A) {
         if (e > A.Length) {
            return "IMPOSSIBLE";
         }

         if (!t.Contains(e)) {
            t.Add(e);
            required.Remove(e);
         } else if (e == A.Length) {
            return "IMPOSSIBLE";
         } else {
            var l = new HashSet<int>();
            for (int a = e; a <= A.Length; a += k) {
               l.Add(a);
            }

            left.Add(l);
         }
      }

      return Search(required.ToList(), 0, left) ? "POSSIBLE" : "IMPOSSIBLE";
   }

   bool Search(List<int> required, int idx, List<HashSet<int>> left) {
      if (idx == required.Count) {
         return true;
      }

      for (int i = 0; i < left.Count; i++) {
         if (left[i].Contains(required[idx])) {
            var b = left[i];
            left.RemoveAt(i);
            if (Search(required, idx + 1, left)) {
               return true;
            }
            left.Insert(i, b);
         }
      }

      return false;
   }
}
