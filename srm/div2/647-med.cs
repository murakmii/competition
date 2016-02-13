using System;
using System.Linq;
using System.Collections.Generic;

struct Item {
   public int p;
   public int c;

   public Item(int p, int c) {
      this.p = p;
      this.c = c;
   }
}

public class TravellingSalesmanEasy {
   public int getMaxProfit(int M, int[] profit, int[] city, int[] visit) {
      var items = new List<Item>(profit.Length);
      for (int i = 0; i < profit.Length; i++) {
         items.Add(new Item(profit[i], city[i]));
      }

      items.Sort((a, b) => b.p - a.p);

      // 訪れた街で販売可能な商品のうち、最も利益の高い商品から売っていくだけでOK
      // 街を訪れる回数が最大2500, 商品の数が最大2500なので最大で2500^2のループ
      int ans = 0;
      var sold = new bool[items.Count];
      foreach (var v in visit) {
         for (int i = 0; i < items.Count; i++) {
            if (items[i].c == v && !sold[i]) {
               ans += items[i].p;
               sold[i] = true;
               break;
            }
         }
      }

      return ans;
   }
}
