using System;
using System.Linq;
using System.Collections.Generic;

namespace Codeforces
{
   public class Solver
   {
      static void Main(string[] args)
      {
         var arg = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
         int n = arg[0], k = arg[1];

         var ans = new List<string>();
         var cnt = 0;

         for (int i = 0; i < n; i++) {
            var l = string.Empty;
            char c = i % 2 == 0 ? 'L' : 'S';
            for (int j = 0; j < n; j++) {
               if (c == 'L' && ++cnt > k) {
                  c = 'S';
               }
               l += c;
               c = c == 'S' ? 'L' : 'S';
           } ans.Add(l);
         }

         if (cnt >= k) {
            Console.WriteLine("YES");
            Console.WriteLine(string.Join("\n", ans.ToArray()));
         } else {
            Console.WriteLine("NO");
         }
      }
   }
}
