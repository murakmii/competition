using System;
using System.Linq;
using System.Collections.Generic;

public class CatAndRat {

   public double getTime(int R, int T, int Vrat, int Vcat) {

      if (Vrat >= Vcat) {
         return -1.0;
      }

      var esc = Math.Min(R * Math.PI, T * Vrat);
      return esc / (Vcat - Vrat);
   }

}
