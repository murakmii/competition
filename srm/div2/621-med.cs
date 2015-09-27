using System;
using System.Linq;
using System.Collections.Generic;

public class NumbersChallenge {

   public int MinNumber(int[] S) {

      var pat = new List<int>(S);
      GenPat(0, 0, S, pat);

      pat.Sort();

      if (pat[0] > 1) {
         return pat[0] - 1;
      } else {
         for (int i = 0; i < pat.Count - 1; i++) {
            if (pat[i + 1] - pat[i] > 1) {
               return pat[i] + 1;
            }
         }
      }

      return pat.Last() + 1;
   }

   void GenPat(int sum, int idx, int[] S, List<int> pat) {
      if (idx < S.Length) {
         pat.Add(sum);
         GenPat(sum, idx + 1, S, pat);

         pat.Add(sum + S[idx]);
         GenPat(sum + S[idx], idx + 1, S, pat);
      }
   }

}
