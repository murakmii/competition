using System;
using System.Linq;
using System.Collections.Generic;

class LittleElephantAndIntervalsDiv2
{
   public int getNumber(int N, int[] L, int [] R)
   {
      var pattern = new List<int>();
      for (int i = 0; i < N; i++) {
         pattern.Add(0);
      }

      for (int i = 0; i < L.Length; i++) {
         for (int j = L[i] - 1; j < R[i]; j++) {
            pattern[j] = i + 1;
         }
      }

      return (int)Math.Pow(2, pattern.Where(p => p != 0).Distinct().Count());
   }
}
