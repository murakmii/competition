using System;
using System.Linq;
using System.Collections.Generic;

public class NumberGameAgain {
   public long solve(int k, long[] table) {
      long max = (long)Math.Pow(2, k) - 1;
      List<long> start = new List<long>(), end = new List<long>();

      // forbidden valuesによって無効になり得る数値の範囲を出す
      // tableが最大20要素, whileのループはkが最大40なので40回くらいのはず
      foreach (var t in table) {
         long tmp = t, range = 1;
         while (tmp <= max) {
            start.Add(tmp);
            end.Add(tmp + range - 1);
            tmp *= 2;
            range *= 2;
         }
      }

      // 数値の範囲の重複がなくなるよう統廃合する
      // もっと綺麗に書けんのか
      // 範囲の数は上記ループより最大800程度のはずなので、ここのループも800^2くらいで済むはず
      var invalid = new bool[start.Count];
      for (int i = 0; i < start.Count; i++) {
         if (invalid[i]) {
            continue;
         }

         long s1 = start[i], e1 = end[i];
         for (int j = 0; j < start.Count; j++) {
            if (i == j || invalid[j]) {
               continue;
            }
            long s2 = start[j], e2 = end[j];

            if (s1 <= s2 && e2 <= e1) {
               invalid[j] = true;
            } else if (s2 <= s1 && e1 <= e2) {
               invalid[i] = true;
               break;
            } else if (e2 < s1 || s2 > e1) {
               continue;
            } else if (s2 < s1 && s1 <= e2 && e2 <= e1) {
               invalid[j] = true;
               start[i] = s2;
            } else if (s1 <= s2 && s2 <= e1 && e1 < e2) {
               invalid[j] = true;
               end[i] = e2;
            }
         }
      }

      long fb = 0;
      for (int i = 0; i < start.Count; i++) {
         if (!invalid[i]) {
            fb += end[i] - start[i] + 1;
         }
      }

      return (long)Math.Pow(2, k) - 2 - fb;
   }
}
