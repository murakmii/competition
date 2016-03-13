using System;
using System.Linq;
using System.Collections.Generic;

public class MutaliskEasy {
   List<int> dmg = new List<int>();
   Dictionary<string, int> mm = new Dictionary<string, int>();

   public int minimalAttacks(int[] x) {
      for (int i = 0, j = 9; i < x.Length; i++, j /= 3) dmg.Add(j);

      return dfs(x, 0);
   }

   int dfs(int[] x, int step) {
      if (x.Where(e => e > 0).Count() == 0) return step;

      var key = Key(x);
      if (mm.ContainsKey(key)) return mm[key];

      int ret = 61;
      step++;
      C.Perm(dmg, perm => {
         for (int i = 0; i < x.Length; i++) x[i] -= perm[i];
         ret = Math.Min(ret, dfs(x, step));
         for (int i = 0; i < x.Length; i++) x[i] += perm[i];
      });

      return mm[key] = ret;
   }

   string Key(int[] x) {
      var sb = new System.Text.StringBuilder();
      foreach (var e in x) {
         if (sb.Length > 0) {
            sb.Append('-');
         }
         sb.Append(e);
      }

      return sb.ToString();
   }
}

public class C {
   public static void Perm<T>(IEnumerable<T> elem, Action<T[]> callback) {
      PermImpl<T>(elem.ToList(), 0, new T[elem.Count()], callback);
   }

   static void PermImpl<T>(List<T> elem, int processed, T[] perm, Action<T[]> callback) {
      int c = elem.Count;
      if (c == 1) {
         perm[processed] = elem[0];
         callback(perm);
      } else if (c > 1) {
         for (int i = 0; i < c; i++) {
            perm[processed] = elem[i];

            elem.RemoveAt(i);
            PermImpl<T>(elem, processed + 1, perm, callback);
            elem.Insert(i, perm[processed]);
         }
      }
   }
}
