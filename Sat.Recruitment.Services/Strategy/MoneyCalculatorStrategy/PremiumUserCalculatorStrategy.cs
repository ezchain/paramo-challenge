using Sat.Recruitment.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Strategy.MoneyCalculatorStrategy
{
    public class PremiumUserCalculatorStrategy : ICalculatorStrategy
    {
        public decimal CalculateGift(decimal money)
        {
            decimal gift = 0;

            if (money > 100)
                gift = money*UserConstants.USER_PREMIUM_PERCENTAGE;

            return gift;
        }
    }
}
