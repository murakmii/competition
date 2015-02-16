using System;
using System.Linq;
using System.Collections.Generic;

class PowerOfThreeEasy
{
   class Move
   {
      public int I;
      public int X;
      public int Y;
   }

   public string ableToGet(int x, int y)
   {
      var q = new Queue<Move>();
      q.Enqueue(new Move { I = 1, X = 0, Y = 0 });

      string ans = "Impossible";
      while(q.Count > 0) {
         var d = q.Dequeue();

         if (d.X == x && d.Y == y) {
            ans = "Possible";
            break;
         }

         if (d.X <= x && d.Y <= y) {
            q.Enqueue(new Move { I = d.I * 3, X = d.X + d.I, Y = d.Y });
            q.Enqueue(new Move { I = d.I * 3, X = d.X, Y = d.Y + d.I });
         }
      }

      return ans;
   }
}
