using System;
using System.Linq;
using System.Collections.Generic;

public class XMarksTheSpot {
   List<int> row_q = new List<int>();
   List<int> col_q = new List<int>();

   public int countArea(string[] board) {
      int t = 50, b = -1, r = -1, l = 50;

      for (int i = 0; i < board.Length; i++) {
         for (int j = 0; j < board[i].Length; j++) {
            if (board[i][j] == '?') {
               row_q.Add(i);
               col_q.Add(j);
            } else if (board[i][j] == 'O') {
               t = Math.Min(t, i);
               b = Math.Max(b, i);
               r = Math.Max(r, j);
               l = Math.Min(l, j);
            }
         }
      }

      if (row_q.Count == 0) {
         return (b - t + 1) * (r - l + 1);
      } else {
         return dfs(0, true, t, b, r, l) + dfs(0, false, t, b, r, l);
      }
   }

   int dfs(int next, bool is_land, int t, int b, int r, int l) {
      if (is_land) {
         t = Math.Min(t, row_q[next]);
         b = Math.Max(b, row_q[next]);
         r = Math.Max(r, col_q[next]);
         l = Math.Min(l, col_q[next]);
      }

      if (next + 1 == row_q.Count) {
         return (b - t + 1) * (r - l + 1);
      } else {
         return dfs(next + 1, true, t, b, r, l) + dfs(next + 1, false, t, b, r, l);
      }
   }
}
