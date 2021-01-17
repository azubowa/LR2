using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР2Console.Kontroler
{
    public class knapsack_problem
    {
        public static List<int> knapsack(int[] cash, int[] cost, int need)
        {
            List<int> mybag = new List<int>();
            int n = cash.Length; // кол-во денег
            int[,] dp = new int[need + 1, n + 1];
            for (int j = 1; j <= n; j++)
            {
                for (int c = 1; c <= need; c++)
                {
                    if (cash[j - 1] <= c)
                    {
                        dp[c, j] = Math.Max(dp[c, j - 1], dp[c - cash[j - 1], j - 1] + cost[j - 1]);
                    }
                    else
                    {
                        dp[c, j] = dp[c, j - 1];
                    }
                }
            }
            int maxp = dp[need, n], a = need;
            for (int i = n; i >= 0; i--)  // в обратном порядке
            {
                if (maxp <= 0)  // собрали продукты
                    break;
                if (maxp == dp[a, i - 1])  // ничего не делаем, двигаемся дальше
                    continue;
                else
                // "забираем" продукт
                {
                    //mybag.Add(weights[i - 1]);
                    mybag.Add(i - 1);
                    maxp -= cost[i - 1];  // отнимаем значение ценности от общей
                    a -= cash[i - 1];
                }// отнимаем площадь от общей
            }
            mybag.Add(dp[need, n]);
            return mybag;
        }
    }
}
    
 
