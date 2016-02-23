using System;
using System.Linq;
using System.Collections.Generic;

public class TopBiologist {
   public string findShortestNewSequence(string sequence) {
      var dna = new string[] {"A", "C", "G", "T"};
      var q = new Queue<string>(dna);

      int min = 2001;
      string ans = "";
      while (q.Count > 0) {
         var d = q.Dequeue();
         if (d.Length >= min) {
            continue;
         }

         var i = sequence.IndexOf(d);
         if (i >= 0) {
            foreach (var c in dna) {
               q.Enqueue(d + c);
            }
         } else {
            if (d.Length < min) {
               min = d.Length;
               ans = d;
            }
         }
      }

      return ans;
   }
}

