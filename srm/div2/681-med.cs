using System;
using System.Linq;
using System.Collections.Generic;

public class ExplodingRobots {
   public string canExplode(int x1, int y1, int x2, int y2, string instructions) {
      // check1回でいいと思うけど
      return check(x1, y1, x2, y2, instructions) || check(x2, y2, x1, y1, instructions) ? "Explosion" : "Safe";
   }

   bool check(int x1, int y1, int x2, int y2, string instructions) {
      int l = 0, r = 0, u = 0, d = 0;
      foreach (var c in instructions) {
         if (c == 'L') l++;
         if (c == 'R') r++;
         if (c == 'U') u++;
         if (c == 'D') d++;
      }

      int v = l + r, h = u + d;
      return (
         ((x2 <= x1 && x2 >= x1 - v) || (x2 >= x1 && x2 <= x1 + v)) &&
         ((y2 <= y1 && y2 >= y1 - h) || (y2 >= y1 && y2 <= y1 + h))
      );
   }
}
