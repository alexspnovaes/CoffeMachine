using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMachine.UI.Utils
{
    public static class ChangeCalculate
    {
        public static string Calculate(decimal totalSoldValue, decimal totalInputValue,  decimal[] validCoins)
        {

            var troco = Math.Round(totalInputValue - totalSoldValue, 2);
            foreach (var moeda in validCoins)
            {
                var notas = (int)(troco / moeda);
                if (notas > 0)
                {
                    troco -= Math.Round(notas * moeda, 2);
                    return ($"Devolver ({moeda} x {notas}): {moeda * notas}");
                }
            }
            return string.Empty;
        }
    }
}
