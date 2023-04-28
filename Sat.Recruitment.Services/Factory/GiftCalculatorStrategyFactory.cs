using Sat.Recruitment.Domain.Enum;
using Sat.Recruitment.Services.Strategy.MoneyCalculatorStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Factory
{
    public static class GiftCalculatorStrategyFactory
    {
        public static ICalculatorStrategy GetStrategy(UserTypeEnum userType) => userType switch
        {
            UserTypeEnum.NORMAL => new NormalUserCalculatorStrategy(),
            UserTypeEnum.SUPER_USER => new SuperUserCalculatorStrategy(),
            UserTypeEnum.PREMIUM => new PremiumUserCalculatorStrategy(),
            _ => throw new NotImplementedException()
        };
    }
}
