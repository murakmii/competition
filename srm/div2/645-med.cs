using System;
using System.Linq;
using System.Collections.Generic;

struct Pair {
   public int pos;
   public int len;

   public Pair(int p, int l) {
      pos = p;
      len = l;
   }
}

public class ConnectingCars {
   public long minimizeCost(int[] positions, int[] lengths) {
      var pair = new List<Pair>();
      for (int i = 0; i < positions.Length; i++) {
         pair.Add(new Pair(positions[i], lengths[i]));
      }
      pair.Sort((a, b) => a.pos - b.pos);

      long ans = 1000000000L * 50;
      for (int i = 0; i < pair.Count; i++) {
         int p = pair[i].pos, l = pair[i].len;
         long a = 0;

         for (int j = i - 1; j >= 0; j--) {
            a += p - pair[j].pos - pair[j].len;
            p -= pair[j].len;
            l += pair[j].len;
         }

         for (int j = i + 1; j < pair.Count; j++) {
            a += pair[j].pos - (p + l);
            l += pair[j].len;
         }

         ans = Math.Min(ans, a);
      }

      return ans;
   }
}

