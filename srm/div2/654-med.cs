using System;
using System.Linq;
using System.Collections.Generic;

public class OneEntrance {
   public int count(int[] a, int[] b, int s) {
      // 部屋の数は最大で9(0 ~ 8)なので、荷物を置いていく部屋の順番の順列を列挙して
      // 生成された順番が正しいものかどうかを検証する

      var con = new Dictionary<int, HashSet<int>>();
      int n = a.Length + 1;
      for (int i = 0; i < n; i++) con.Add(i, new HashSet<int>());

      for (int i = 0; i < a.Length; i++) {
         con[a[i]].Add(b[i]);
         con[b[i]].Add(a[i]);
      }

      // sで指定される部屋を根として各部屋の親を出しておく
      int[] parent = new int[n];
      dfs(con, s, -1, parent);

      // ある部屋に荷物を配置する際に、その子となっている部屋で
      // 荷物を配置していない部屋が出た場合はその配置順は無効
      int ans = 0;
      var puts = new HashSet<int>();
      C.Perm(Enumerable.Range(0, n), perm => {
         puts.Clear();
         bool ok = true;
         foreach (var room in perm) {
            int child = con[room].Where(e => e != parent[room] && puts.Contains(e)).Count();
            if (child > 0) {
               ok = false;
               break;
            }

            puts.Add(room);
         }

         if (ok) ans++;
      });

      return ans;
   }

   void dfs(Dictionary<int, HashSet<int>> con, int cur, int from, int[] parent) {
      parent[cur] = from;
      foreach (var e in con[cur]) {
         if (e != from) {
            dfs(con, e, cur, parent);
         }
      }
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
