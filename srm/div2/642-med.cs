using System;
using System.Linq;
using System.Collections.Generic;

public class LightSwitchingPuzzle {
   public int minFlips(string state) {
      var s = state.ToCharArray();
      int ans = 0;
      for (int i = 1; i <= s.Length; i++) {
         if (s[i - 1] == 'Y') {
            ans++;
            for (int j = i; j <= s.Length; j += i) {
               s[j - 1] = s[j - 1] == 'Y' ? 'N' : 'Y';
            }
         }
      }

      return ans;
   }
}
