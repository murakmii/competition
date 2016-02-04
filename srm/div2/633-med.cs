using System;
using System.Linq;
using System.Collections.Generic;

public class Jumping {

   // ジャンプ出来る距離の一覧+目的地までの距離を辺として多角形を作れるかどうか
   public string ableToGet(int x, int y, int[] jumpLengths) {
      var sides = jumpLengths.Select(e => (double)e).ToList();
      sides.Add(Math.Sqrt(x * x + y * y));

      int m = 0;
      for (int i = 1; i < sides.Count; i++) {
         if (sides[m] < sides[i]) {
            m = i;
         }
      }

      double max = sides[m];
      sides.RemoveAt(m);

      // 最長辺以外が1直線に並んでもいいので"<"ではなく"<="でいいはず
      return max <= sides.Sum() ? "Able" : "Not able";
   }

}
