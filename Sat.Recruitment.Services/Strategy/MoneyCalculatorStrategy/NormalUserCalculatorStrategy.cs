using Microsoft.VisualBasic;
using Sat.Recruitment.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Strategy.MoneyCalculatorStrategy
{
    public class NormalUserCalculatorStrategy : ICalculatorStrategy
    {

        public decimal CalculateGift(decimal money)
        {
            decimal gift = 0;

            if (money > 100)
                gift = money * UserConstants.USER_NORMAL_PERCENTAGE_OVER_100;
            else if (money > 10)
                gift = money * UserConstants.USER_NORMAL_PERCENTAGE_LESS_100;

            return gift;
        }

    }
}
