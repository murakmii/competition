using System;
using System.Linq;
using System.Collections.Generic;

struct Pair {
   public int index;
   public string str;

   public Pair(int i, string s) {
      index = i;
      str = s;
   }
}

public class LostCharacter {
   public int[] getmins(string[] str) {
      var ans = new int[str.Length];

      // 配列内の文字列それぞれについて、
      // 当該文字列以外を可能な限り辞書順で後ろにする方法を考えればいいので
      //  * 当該文字列以外が持つ"?"を全て"z"
      //  * 当該文字列が持つ"?"を全て"a"
      // とし辞書順ソートした後のインデックスを調べていけばOK
      for (int i = 0; i < str.Length; i++) {
         var l = new List<Pair>();

         for (int j = 0; j < str.Length; j++) {
            l.Add(new Pair(j, str[j].Replace("?", i == j ? "a" : "z")));
         }

         l.Sort((a, b) => String.Compare(a.str, b.str));

         var k = l.FindIndex(p => p.index == i);
         var s = l[k].str;
         while (k >= 0 && l[k].str == s) {
            k--;
         }
         ans[i] = k + 1;
      }

      return ans;
   }
}
