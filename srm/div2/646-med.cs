using System;
using System.Linq;
using System.Collections.Generic;

struct Data {
   public int c;
   public int x;
   public int y;

   public Data(int c, int x, int y) {
      this.c = c;
      this.x = x;
      this.y = y;
   }
}

public class TheGridDivTwo {
   public int find(int[] x, int[] y, int k) {
      var visited = new bool[2001, 2001];
      var blocks = new bool[2001, 2001];
      for (int i = 0; i < x.Length; i++) {
         blocks[x[i] + 1000, y[i] + 1000] = true;
      }

      var q = new Queue<Data>();
      q.Enqueue(new Data(0, 0, 0));

      int ans = 0;
      while (q.Count > 0) {
         var d = q.Dequeue();
         int ax = d.x + 1000, ay = d.y + 1000;

         // * 時間オーバー *計算済みの解答を上回れないことが自明 *当該座標がブロック若しくは計算済み
         // なら打ち切り
         if (d.c > k || d.x + (k - d.c) <= ans || visited[ax, ay] || blocks[ax, ay]) {
            continue;
         }

         visited[ax, ay] = true;
         ans = Math.Max(d.x, ans);

         q.Enqueue(new Data(d.c + 1, d.x + 1, d.y));
         q.Enqueue(new Data(d.c + 1, d.x - 1, d.y));
         q.Enqueue(new Data(d.c + 1, d.x, d.y + 1));
         q.Enqueue(new Data(d.c + 1, d.x, d.y - 1));
      }

      return ans;
   }
}
