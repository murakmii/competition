using System;
using System.Linq;
using System.Collections.Generic;

public class RGBStreet {
   public int estimateCost(string[] houses) {
      var costs = houses.Select(e => e.Split(' ').Select(c => int.Parse(c)).ToArray()).ToArray();
      var dp = new int[20, 3, 20001];

      for (int i = 0; i < 3; i++) {
         dp[0, i, costs[0][i]] = 1;
      }

      for (int i = 1; i < costs.Length; i++) {
         for (int j = 0; j < 3; j++) {
            for (int k = 0; k < 20001; k++) {
               if (dp[i - 1, j, k] == 1) {
                  if (j == 0) {
                     dp[i, 1, k + costs[i][1]] = dp[i, 2, k + costs[i][2]] = 1;
                  } else if (j == 1) {
                     dp[i, 0, k + costs[i][0]] = dp[i, 2, k + costs[i][2]] = 1;
                  } else {
                     dp[i, 0, k + costs[i][0]] = dp[i, 1, k + costs[i][1]] = 1;
                  }
               }
            }
         }
      }

      int ans = 20000;
      for (int i = 0; i < 3; i++) {
         for (int j = 0; j < 20001; j++) {
            if (dp[costs.Length - 1, i, j] == 1 && ans > j) {
               ans = j;
            }
         }
      }

      return ans;
   }
}
