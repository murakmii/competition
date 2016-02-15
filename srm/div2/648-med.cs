using System;
using System.Linq;
using System.Collections.Generic;

public class Fragile2 {
   public int countPairs(string[] graph) {
      var n = graph.Length;
      var g = new char[n, n];
      for (int i = 0; i < n; i++) {
         for (int j = 0; j < n; j++) {
            g[i, j] = graph[i][j];
         }
      }

      // 頂点の数が最大20個なので、任意の2頂点を取り除いた場合のコンポーネントの数を計算し
      // 元のコンポーネントの数より減っていた場合の頂点の組み合わせを全探索する
      var pair = new HashSet<string>();
      var org = Count(g, n);
      int ans = 0;

      for (int i = 0; i < n; i++) {

         // 頂点を切り離しておいて後で戻す
         var qi = new Queue<int>();
         for (int j = 0; j < n; j++) {
            if (g[i, j] == 'Y') {
               qi.Enqueue(j);
               g[i, j] = g[j, i] = 'N';
            }
         }

         for (int k = 0; k < n; k++) {
            var p = PairId(i, k);
            if (i == k || pair.Contains(p)) {
               continue;
            }
            pair.Add(p);

            var qk = new Queue<int>();
            for (int l = 0; l < n; l++) {
               if (g[k, l] == 'Y') {
                  qk.Enqueue(l);
                  g[k, l] = g[l, k] = 'N';
               }
            }

            // 2頂点を削除したと仮定しているので-2
            if (Count(g, n) - 2 > org) {
               ans++;
            }

            while (qk.Count > 0) {
               var l = qk.Dequeue();
               g[k, l] = g[l, k] = 'Y';
            }
         }

         while (qi.Count > 0) {
            var j = qi.Dequeue();
            g[i, j] = g[j, i] = 'Y';
         }
      }

      return ans;
   }

   string PairId(int a, int b) {
      return a < b ? a.ToString() + "-" + b.ToString() : b.ToString() + "-" + a.ToString();
   }

   int Count(char[,] g, int n) {
      var mark = new int[n];
      int m = 0;

      for (int i = 0; i < n; i++) {
         for (int j = 0; j < n; j++) {
            if (g[i, j] == 'Y') {
               if (mark[i] == 0) {
                  mark[i] = ++m;
               }

               if (mark[j] != 0) {
                  var mj = mark[j];
                  for (int k = 0; k < n; k++) {
                     if (mark[k] == mj) {
                        mark[k] = mark[i];
                     }
                  }
               } else {
                  mark[j] = mark[i];
               }
            }
         }
      }

      var z = mark.Count(e => e == 0);
      var d = mark.Distinct().Count();
      return z + (z == 0 ? d : d - 1);
   }
}
