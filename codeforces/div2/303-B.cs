using System;
using System.Linq;
using System.Collections.Generic;

public class EquidistantString
{
   public static void Main(string[] argv)
   {
      var s = Console.ReadLine();
      var t = Console.ReadLine();

      int sec = 0, tec = 0;

      var ans = new System.Text.StringBuilder(100000);
      for (int i = 0; i < s.Length; i++) {
         if (s[i] == t[i]) {
            ans.Append(s[i]);
         } else {
            if (sec > tec) {
               ans.Append(s[i]);
               tec++;
            } else if (sec < tec) {
               ans.Append(t[i]);
               sec++;
            } else {
               ans.Append('0');
               sec += s[i] == '0' ? 0 : 1;
               tec += t[i] == '0' ? 0 : 1;
            }
         }
      }

      Console.WriteLine(sec == tec ? ans.ToString() : "impossible");
   }
}
