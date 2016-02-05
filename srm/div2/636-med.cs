using System;
using System.Linq;
using System.Collections.Generic;

public class SortishDiv2 {
   public int ways(int sortedness, int[] seq) {

      var zeroidx = Enumerable.Range(0, seq.Length).Where(i => seq[i] == 0).ToArray();
      var unused = new HashSet<int>(Enumerable.Range(1, seq.Length));
      unused.ExceptWith(seq.Where(e => e > 0));

      // 最大で5!通りそれぞれに対して約5000回ループなので全部探索してもいけそう
      var ans = new Dictionary<int, int>();
      Lib.Permutation(unused.ToArray(), p => {
         for (int i = 0; i < zeroidx.Length; i++) {
            seq[zeroidx[i]] = p[i];
         }

         int a = 0;
         for (int i = 0; i < seq.Length; i++) {
            for (int j = i + 1; j < seq.Length; j++) {
               if (seq[i] < seq[j]) {
                  a++;
               }
            }
         }

         if (!ans.ContainsKey(a)) {
            ans[a] = 0;
         }
         ans[a]++;
      });

      return ans.ContainsKey(sortedness) ? ans[sortedness] : 0;
   }
}

public class Lib {
   public static void Permutation<T>(IEnumerable<T> source, Action<T[]> func) {
      Permutation<T>(source.ToArray(), 0, (T[] p) => {
         func(p);
      });
   }

   static void Permutation<T>(T[] source, int start, Action<T[]> func) {
      if (start >= source.Length - 1) {
         func(source);
         return;
      }

      for (int i = start; i < source.Length; i++) {
         T tmp = source[start];
         source[start] = source[i];
         source[i] = tmp;

         Permutation<T>(source, start + 1, func);

         tmp = source[start];
         source[start] = source[i];
         source[i] = tmp;
      }
   }
}
