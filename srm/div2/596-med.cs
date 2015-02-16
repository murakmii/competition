using System;
using System.Collections.Generic;

class ColorfulRoad
{
   class Node
   {
      public int IDX;
      public int C;
   }

   int ans = -1;
   string road;

   public int getMin(string road)
   {
      this.road = road;

      Solve(new Node {IDX = 0, C = 0}); 
      return ans;
   }

   void Solve(Node N)
   {
      if (ans != -1 && N.C >= ans) {
         return;
      }

      if (N.IDX == road.Length - 1) {
         ans = ans == -1 ? N.C : Math.Min(ans, N.C);
         return;
      }

      char next;
      if (road[N.IDX] == 'R') {
         next = 'G';
      } else if (road[N.IDX] == 'G') {
         next = 'B';
      } else {
         next = 'R';
      }

      for (int i = N.IDX + 1; i < road.Length; i++) {
         if (road[i] == next) {
            Solve(new Node{IDX = i, C = N.C + (i - N.IDX) * (i - N.IDX)});
         }
      }
   }
}
