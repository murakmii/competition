using System;
using System.Linq;
using System.Collections.Generic;

class LittleElephantAndPermutationDiv2
{
   long Prod(List<int> list)
   {
      long f = 1;
      foreach (var l in list) {
         f *= l;
      }
      return f;
   }

   public long getNumber(int N, int K)
   {
      var A = Enumerable.Range(1, N).ToList();
      var S = A.Sum();

      if (S >= K) {
         var f = Prod(A);
         return f * f;
      }

      return Prod(A) * Solve(N, A, 0, new HashSet<int>(), K - S);
   }

   long Solve(int N, List<int> A, int I, HashSet<int> used, int need)
   {
      long result = 0;
      for (int i = 1; i <= N; i++) {

         if (used.Contains(i)) {
            continue;
         }

         var n = i - A[I] > 0 ? need - (i - A[I]) : need;
         if (n <= 0) {
            int c = 0;
            for (int j = 1; j <= N; j++) {
               if (!used.Contains(j) && j != i) {
                  c++;
               }
            }
            result += Prod(Enumerable.Range(1, c).ToList());
         } else {
            used.Add(i);
            result += Solve(N, A, I + 1, used, n);
            used.Remove(i);
         }
      }

      return result;
   }
}
