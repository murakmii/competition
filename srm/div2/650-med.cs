using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TaroFillingAStringDiv2 {
   public int getNumber(string S) {
      // 文字列長が1でペアが成立しなかったり, 全ての文字を任意に変更出来る場合は必ず0
      if (S.Length == 1 || S.Count(e => e == '?') == S.Length) {
         return 0;
      }

      // 'A'と'B'が可能な限り交互に並んでいることが条件なので
      // 連続している'?'を探して、隣接している文字と異なる文字で置換していく
      var c = S.ToCharArray();
      foreach (Match m in Regex.Matches(S, "\\?+")) {
         int s = m.Index, e = m.Index + m.Value.Length;
         if (s - 1 >= 0) {
            for (int i = s; i < e; i++) {
               c[i] = c[i - 1] == 'A' ? 'B' : 'A';
            }
         } else {
            for (int i = e - 1; i >= s; i--) {
               c[i] = c[i + 1] == 'A' ? 'B' : 'A';
            }
         }
      }

      // 置換後のペアの数を算出して終わり
      int ans = 0;
      for (int i = 1; i < c.Length; i++) {
         if (c[i] == c[i - 1]) {
            ans++;
         }
      }

      return ans;
   }
}
