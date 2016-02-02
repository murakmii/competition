using System;
using System.Linq;
using System.Collections.Generic;

public class BracketExpressions {
   public string ifPossible(string expression) {
      var q = new Queue<char[]>();
      var ans = "impossible";
      var close_brackets = new Dictionary<char, char> {
         {'(', ')'},
         {'[', ']'},
         {'{', '}'}
      };

      q.Enqueue(expression.ToCharArray());
      while (q.Count > 0) {
         var e = q.Dequeue();
         var s = new Stack<char>();

         for (int i = 0; i < e.Length; i++) {
            if (close_brackets.Keys.Contains(e[i])) {
               s.Push(e[i]);
            } else if (e[i] != 'X') {
               if (s.Count == 0 || close_brackets[s.Peek()] != e[i]) {
                  break;
               } else {
                  s.Pop();
               }
            } else {
               // 妥協していっぱいコピー
               foreach (var b in close_brackets.Keys) {
                  var n = new char[e.Length];
                  e.CopyTo(n, 0);
                  n[i] = b;
                  q.Enqueue(n);
               }

               if (s.Count > 0) {
                  var n = new char[e.Length];
                  e.CopyTo(n, 0);
                  n[i] = close_brackets[s.Peek()];
                  q.Enqueue(n);
               }
               break;
            }

            if (e[i] != 'X' && i == e.Length - 1 && s.Count == 0) {
               ans = "possible";
               q.Clear();
            }
         }
      }

      return ans;
   }
}
