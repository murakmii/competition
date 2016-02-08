using System;
using System.Linq;
using System.Collections.Generic;

public class AliceGameEasy {
   public long findMinimumValue(long x, long y) {
      if (x == 0 && y == 0) {
         return 0;
      }

      // 何ターン目に終わったか調べる. x+yは最高で2*10^12なので
      // 2 * 10^12 <= n(n + 1) / 2
      // なので10^7くらいまでのターンを調べる
      // (解いてから考えたらn(n + 1)/2がx+yを上回ったらループは終了で良かった)
      long t = -1;
      for (long n = 1; n <= 10000000; n++) {
         if ((n * n + n) / 2 == (x + y)) {
            t = n;
            break;
         }
      }

      if (t == -1) {
         return -1;
      }

      long ans = 0;
      while (t > 0) {
         if (t <= x) {
            x -= t;
            ans++;
            if (x == 0) {
               break;
            }
         }
         t--;
      }

      return ans;
   }
}


