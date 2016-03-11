using System;
using System.Linq;
using System.Collections.Generic;

public class FoldingPaper2 {
   public int solve(int W, int H, int A) {
      // 面積Aは高々100000なので、
      // 目的の面積を作れるような幅と高さの組み合わせを全探索する
      // 幅, 高さは最大で10^9になるけど
      // あるサイズまで小さくするための手数は対数時間で出せているはずなので大丈夫

      var wh = new Dictionary<int, int>();
      for (int i = 1; i <= A; i++) {
         if (A % i == 0 && !wh.ContainsKey(i) && !wh.ContainsKey(A / i)) {
            wh.Add(i, A / i);
         }
      }

      int ans = -1;

      foreach (KeyValuePair<int, int> kv in wh) {
         int a, b;

         a = SmallestStep(W, kv.Key, 0);
         b = SmallestStep(H, kv.Value, 0);
         if (a >= 0 && b >= 0) ans = ans == -1 ? a + b : Math.Min(ans, a + b);

         a = SmallestStep(W, kv.Value, 0);
         b = SmallestStep(H, kv.Key, 0);
         if (a >= 0 && b >= 0) ans = ans == -1 ? a + b : Math.Min(ans, a + b);
      }

      return ans;
   }

   // 半分に折った後のサイズが、目標のサイズ以上なら再帰
   // 目標のサイズ未満なら半分に折るのではなく目標のサイズと同じになるよう折れば良い
   int SmallestStep(int from, int to, int step) {
      if (from == to) {
         return step;
      } else if (from < to) {
         return -1;
      }

      step++;
      int next = (int)Math.Ceiling(from / 2.0);

      if (next >= to) {
         return SmallestStep(next, to, step);
      } else {
         return step;
      }
   }
}


