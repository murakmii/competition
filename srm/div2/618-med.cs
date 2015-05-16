using System;
using System.Linq;
using System.Collections.Generic;

public class LongWordsDiv2
{
   public string find(string word)
   {
      var c = new Dictionary<char, int>();
      for (int i = 0; i < word.Length; i++) {
         if (i + 1 < word.Length && word[i] == word[i + 1]) {
            return "Dislikes";
         }

         if (!c.ContainsKey(word[i])) {
            c[word[i]] = 0;
         }
         if (++c[word[i]] == 4) {
            return "Dislikes";
         }
      }

      for (int i = 0; i < word.Length - 1; i++) {
         var bet = new HashSet<char>();
         var f = false;

         for (int j = i + 1; j < word.Length; j++) {
            if (word[j] == word[i]) {
               f = true;
            } else if (!f) {
               bet.Add(word[j]);
            } else if (bet.Contains(word[j])) {
               return "Dislikes";
            }
         }
      }

      return "Likes";
   }
}
