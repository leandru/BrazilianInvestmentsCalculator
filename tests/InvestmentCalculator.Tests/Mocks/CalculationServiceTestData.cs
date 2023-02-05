using System.Collections;

namespace InvestmentCalculator.Tests.Mocks
{
    public class CalculatorServiceTestData : IEnumerable<object[]>
    {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { CdiDayMock.GetListOfThreeDays(), 1000, 120, 1001.32 };
                yield return new object[] { CdiDayMock.GetListOfOneMonth(), 5346.67, 109.99, 5391.09 };
                yield return new object[] { CdiDayMock.GetListOfOneYear(), 152500.99, 115.00, 174426.24 };
                yield return new object[] { CdiDayMock.GetEmptyList(), 12345.99, 147.00, 12345.99 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
