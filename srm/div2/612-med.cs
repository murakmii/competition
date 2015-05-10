using System;
using System.Linq;
using System.Collections.Generic;

public class EmoticonsDiv2
{
   class Data
   {
      public int Op;
      public int Emo;
      public int Cb;
   }

   public int printSmiles(int smiles)
   {
      int ans = -1;

      var q = new Queue<Data>();
      q.Enqueue(new Data { Op = 2, Emo = 2, Cb = 1 } );

      while(q.Count > 0) {
         var d = q.Dequeue();
         if (ans != -1 && d.Op >= ans - 1) {
            continue;
         }

         if(d.Emo == smiles) {
            ans = ans == -1 ? d.Op : Math.Min(ans, d.Op);
         } else {

            if ((smiles - d.Emo) % d.Cb == 0) {
               var a = (smiles - d.Emo) / d.Cb + d.Op;
               ans = ans == -1 ? a : Math.Min(ans, a);
            }

            if(d.Emo + d.Cb <= smiles) {
               q.Enqueue(new Data { Op = d.Op + 1, Emo = d.Emo + d.Cb, Cb = d.Cb });
            }

            if (d.Emo * 2 <= smiles) {
               q.Enqueue(new Data { Op = d.Op + 2, Emo = d.Emo * 2, Cb = d.Emo });
            }
         }
      }

      return ans;
   }
}
