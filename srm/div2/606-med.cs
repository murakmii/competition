using System;
using System.Linq;
using System.Collections.Generic;

class EllysNumberGuessing
{
   bool inRange(int n)
   {
      return n >= 1 && n <= 1000000000;
   }

   public int getNumber(int[] guesses, int[] answers)
   {
      HashSet<int> chk = new HashSet<int>(), ans = new HashSet<int>();

      for (int i = 0; i < guesses.Length; i++) {
         var aa = new int[] { guesses[i] - answers[i], guesses[i] + answers[i] };
         
         if (i > 0 && aa.Count(a => !chk.Contains(a)) == 2) {
            return -2;
         }
         chk = new HashSet<int>(aa);

         if (i == 0) {
            ans = new HashSet<int>(aa.Where(inRange));
         } else {
            ans = new HashSet<int>(ans.Intersect(aa.Where(inRange)));
         }
      }
   
      if (ans.Count == 0) {
         return -2;
      } else if (ans.Count == 1) {
         return ans.ToArray()[0];
      } else {
         return -1;
      }
   }
}
