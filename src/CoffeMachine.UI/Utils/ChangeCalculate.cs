using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMachine.UI.Utils
{
    public static class ChangeCalculate
    {
        public static void Calculate(decimal totalSoldValue, decimal totalInputValue,  decimal[] validCoins)
        {
            var changeValue = totalInputValue - totalSoldValue;
            Array.Sort(validCoins);
            Array.Reverse(validCoins);
            int actualCoin = 0;

            foreach (var coin in validCoins)
            {
                while (changeValue >= coin)
                {
                    actualCoin++;
                    changeValue -= coin;
                }
                if (actualCoin > 0)
                {
                    Console.WriteLine($"{actualCoin} Moeda(s) de R$ {coin} ");
                    actualCoin = 0;
                }
            }
        }
    }
}
