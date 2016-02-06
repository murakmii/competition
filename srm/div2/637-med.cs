using System;
using System.Linq;
using System.Collections.Generic;

public class PathGameDiv2 {
   public int calc(string[] board) {
      int ans = 0;
      foreach (var start_row in new int[] {0, 1}) {
         if (board[start_row][0] == '#') {
            continue;
         }

         int r = start_row, path_cell = 0;
         for (int c = 0; c < board[0].Length; c++) {
            path_cell++;
            if (board[r][c] == '#') {
               r = (r + 1) % 2;
               c--;
            }
         }

         int a = (board[0] + board[1]).Count(c => c == '.') - path_cell;
         ans = Math.Max(ans, a);
      }

      return ans;
   }
}
