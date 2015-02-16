using System;
using System.Collections.Generic;

class AlienAndGame
{
   public int getNumber(string[] board)
   {
      int R = board.Length, C = board[0].Length;
      int S = 0;

      for (int i = 0; i < R; i++) {
         for (int j = 0; j < C; j++) {
            int s = 1;
            while(true) {
               if (i + s - 1 >= R || j + s - 1 >= C) {
                  s--;
                  break;
               }

               var ok = true;
               for (int k = 0; k < s; k++) {
                  var set = new HashSet<char>(board[i + k].Substring(j, s));
                  if (!(ok = set.Count == 1)) {
                     break;
                  }
               }

               if (!ok) {
                  s--;
                  break;
               } else {
                  s++;
               }
            }
            S = Math.Max(s, S);
         }

      }

      return S * S;
   }
}
