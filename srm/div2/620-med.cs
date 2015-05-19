using System;
using System.Linq;
using System.Collections.Generic;

public class PairGameEasy
{
   class Data
   {
      public int A;
      public int B;
   }

   public string able(int a, int b, int c, int d)
   {
      var data = new Queue<Data>();
      data.Enqueue(new Data { A = a, B = b });

      var able = false;
      while (data.Count > 0) {
         var dt = data.Dequeue();
         if (dt.A == c && dt.B == d) {
            able = true;
            break;
         }

         if (dt.A + dt.B <= c) {
            data.Enqueue(new Data { A = dt.A + dt.B, B = dt.B });
         }

         if (dt.A + dt.B <= d) {
            data.Enqueue(new Data { A = dt.A, B = dt.B + dt.A });
         }
      }

      return able ? "Able to generate" : "Not able to generate";
   }
}

