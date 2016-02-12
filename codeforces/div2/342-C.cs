using System;
using System.Linq;
using System.Collections.Generic;

public class Codeforces {
   public static void Main(string[] argv) {
      var arg = Console.ReadLine().Split(' ');
      int n = int.Parse(arg[0]);
      int k = int.Parse(arg[1]) - 1;
      var t = new int[n,n];

      var e = Enumerable.Range(1, n * n).ToArray();
      int s = (n - k ) * n;

      int l = n * n - s;
      for (int i = 0; i < n; i++) {
         for (int j = k; j < n; j++) {
            t[j, i] = e[l++];
         }
      }

      l = 0;
      for (int i = 0; i < n; i++) {
         for (int j = 0; j < k; j++) {
            t[j, i] = e[l++];
         }
      }

      int ans = 0;
      for (int i = 0; i < n; i++) {
         ans += t[k, i];
      }

      Console.WriteLine(ans);
      for (int i = 0; i < n; i++) {
         var tmp = new List<String>();
         for (int j = 0; j < n; j++) {
            tmp.Add(t[j, i].ToString());
         }
         Console.WriteLine(String.Join(" ", tmp.ToArray()));
      }
   }
}
