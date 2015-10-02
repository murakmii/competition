using System;
using System.Linq;
using System.Collections.Generic;

public class HappyLetterDiv2 {

   public char getHappyLetter(string letters) {
      var cnt = new Dictionary<char, int>();
      int max = 0;
      char ans = '.';
      foreach (var c in letters) {
         if (!cnt.ContainsKey(c)) {
            cnt.Add(c, 0);
         }

         if (++cnt[c] > max) {
            max = cnt[c];
            ans = c;
         }
      }

      return (max > letters.Length / 2) ? ans : '.';
   }

}
