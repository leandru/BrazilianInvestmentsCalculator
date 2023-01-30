using InvestmentCalculator.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator.Tests.Utils
{
    public static class MockedValues
    {
        public static List<CdiDay> GetCdiDaysList()
        {
            var list = new List<CdiDay>
            {
                new CdiDay
                {
                    Date = "01/02/2022",
                    Value = "0.034749"
                },

                new CdiDay
                {
                    Date = "02/02/2022",
                    Value = "0.034749"
                },

                new CdiDay
                {
                    Date = "03/02/2022",
                    Value = "0.040168"
                }
            };

            return list;
        }
    }
}
