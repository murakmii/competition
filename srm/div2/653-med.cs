using System;
using System.Linq;
using System.Collections.Generic;

public class RockPaperScissorsMagicEasy {
   public int count(int[] card, int score) {
      // カードの枚数をn, スコアをsと考えると
      // sだけ必ず勝つ(n枚のカードからs枚勝つカードを選択する)組み合わせがnCs
      // それ以外のカードは引き分けか負けるかの2通りが有り得るので組み合わせが2^(n-s)
      // 合計でnCs * 2^(n-s)通りの組み合わせがある

      if (card.Length < score) {
         return 0;
      } else if (card.Length == score) {
         return 1;
      }

      var p = 1000000007L;
      long a = CModPrime(card.Length, score, p);
      long b = PowerMod(2, card.Length - score, p);

      return (int)(a * b % p);
   }

   // (ab mod m) == (a mod m)(b mod m) mod mでオーバーフローしないように
   // 最後にb^(p - 2) ≡ b^(-1) mod pを使って余りを出す
   long CModPrime(long n, long k, long p) {
      long nume = n % p;
      for (int i = 1; i < n; i++) nume = (nume * (i % p)) % p;

      long deno = 1, nk = n - k;
      while (nk >= 1) deno = (deno * (nk-- % p)) % p;
      while (k >= 1)  deno = (deno * (k-- % p)) % p;

      return (nume * PowerMod(deno, p - 2, p)) % p;
   }

   // 冪乗法。速い。n = 1000000005でも終わる
   long PowerMod(long a, long n, long m) {
      long ret = 1;
      while (n >= 1) {
         if ((n & 1) == 1) {
            ret = (a * ret) % m;
         }

         a = (a * a) % m;
         n >>= 1;
      }

      return ret;
   }
}

