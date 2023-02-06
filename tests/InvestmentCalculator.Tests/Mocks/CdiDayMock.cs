﻿using InvestmentCalculator.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvestmentCalculator.Tests.Mocks
{
    public static class CdiDayMock
    {
        public static IEnumerable<CdiDay> GetListOfThreeDays()
        {
            yield return new CdiDay
            {
                Date = "01/02/2022",
                Value = "0.034749"
            };
            yield return new CdiDay
            {
                Date = "02/02/2022",
                Value = "0.034749"
            };

            yield return new CdiDay
            {
                Date = "03/02/2022",
                Value = "0.040168"
            };
        }

        public static IEnumerable<CdiDay> GetListOfOneMonth()
        {
            var json = "[{\"data\":\"01/02/2022\",\"valor\":\"0.034749\"},{\"data\":\"02/02/2022\",\"valor\":\"0.034749\"},{\"data\":\"03/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"04/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"07/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"08/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"09/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"10/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"11/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"14/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"15/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"16/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"17/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"18/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"21/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"22/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"23/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"24/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"25/02/2022\",\"valor\":\"0.040168\"}]";

            var data = JsonSerializer.Deserialize<IEnumerable<CdiDay>>(json);

            return data;
        }

        public static IEnumerable<CdiDay> GetListOfOneYear()
        {
            var json = "[{\"data\":\"03/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"04/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"05/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"06/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"07/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"10/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"11/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"12/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"13/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"14/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"17/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"18/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"19/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"20/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"21/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"24/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"25/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"26/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"27/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"28/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"31/01/2022\",\"valor\":\"0.034749\"},{\"data\":\"01/02/2022\",\"valor\":\"0.034749\"},{\"data\":\"02/02/2022\",\"valor\":\"0.034749\"},{\"data\":\"03/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"04/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"07/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"08/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"09/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"10/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"11/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"14/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"15/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"16/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"17/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"18/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"21/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"22/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"23/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"24/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"25/02/2022\",\"valor\":\"0.040168\"},{\"data\":\"02/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"03/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"04/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"07/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"08/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"09/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"10/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"11/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"14/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"15/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"16/03/2022\",\"valor\":\"0.040168\"},{\"data\":\"17/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"18/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"21/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"22/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"23/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"24/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"25/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"28/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"29/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"30/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"31/03/2022\",\"valor\":\"0.043739\"},{\"data\":\"01/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"04/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"05/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"06/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"07/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"08/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"11/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"12/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"13/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"14/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"18/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"19/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"20/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"22/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"25/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"26/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"27/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"28/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"29/04/2022\",\"valor\":\"0.043739\"},{\"data\":\"02/05/2022\",\"valor\":\"0.043739\"},{\"data\":\"03/05/2022\",\"valor\":\"0.043739\"},{\"data\":\"04/05/2022\",\"valor\":\"0.043739\"},{\"data\":\"05/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"06/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"09/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"10/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"11/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"12/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"13/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"16/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"17/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"18/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"19/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"20/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"23/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"24/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"25/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"26/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"27/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"30/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"31/05/2022\",\"valor\":\"0.047279\"},{\"data\":\"01/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"02/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"03/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"06/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"07/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"08/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"09/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"10/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"13/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"14/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"15/06/2022\",\"valor\":\"0.047279\"},{\"data\":\"17/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"20/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"21/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"22/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"23/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"24/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"27/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"28/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"29/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"30/06/2022\",\"valor\":\"0.049037\"},{\"data\":\"01/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"04/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"05/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"06/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"07/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"08/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"11/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"12/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"13/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"14/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"15/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"18/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"19/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"20/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"21/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"22/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"25/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"26/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"27/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"28/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"29/07/2022\",\"valor\":\"0.049037\"},{\"data\":\"01/08/2022\",\"valor\":\"0.049037\"},{\"data\":\"02/08/2022\",\"valor\":\"0.049037\"},{\"data\":\"03/08/2022\",\"valor\":\"0.049037\"},{\"data\":\"04/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"05/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"08/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"09/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"10/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"11/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"12/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"15/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"16/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"17/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"18/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"19/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"22/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"23/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"24/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"25/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"26/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"29/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"30/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"31/08/2022\",\"valor\":\"0.050788\"},{\"data\":\"01/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"02/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"05/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"06/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"08/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"09/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"12/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"13/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"14/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"15/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"16/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"19/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"20/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"21/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"22/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"23/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"26/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"27/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"28/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"29/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"30/09/2022\",\"valor\":\"0.050788\"},{\"data\":\"03/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"04/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"05/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"06/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"07/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"10/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"11/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"13/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"14/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"17/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"18/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"19/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"20/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"21/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"24/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"25/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"26/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"27/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"28/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"31/10/2022\",\"valor\":\"0.050788\"},{\"data\":\"01/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"03/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"04/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"07/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"08/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"09/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"10/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"11/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"14/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"16/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"17/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"18/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"21/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"22/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"23/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"24/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"25/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"28/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"29/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"30/11/2022\",\"valor\":\"0.050788\"},{\"data\":\"01/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"02/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"05/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"06/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"07/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"08/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"09/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"12/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"13/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"14/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"15/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"16/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"19/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"20/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"21/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"22/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"23/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"26/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"27/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"28/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"29/12/2022\",\"valor\":\"0.050788\"},{\"data\":\"30/12/2022\",\"valor\":\"0.050788\"}]";

            var data = JsonSerializer.Deserialize<IEnumerable<CdiDay>>(json);

            return data;
        }

        public static IEnumerable<CdiDay> GetEmptyList()
        {
            return Enumerable.Empty<CdiDay>();
        }


    }
}