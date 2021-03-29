using Guide.Domain.Domain;
using Guide.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guide.Controllers
{
    public class FinancesController : ControllerBase
    {
        private readonly IFinanceService _financeService;
        public FinancesController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet("GravarNoBanco")]
        public async Task<IActionResult> GravarNoBanco()
        {

        var ret = await _financeService.InsertFinances();
            
            if (ret == null)
                return StatusCode(500);
            else
                return Ok(ret);

        }

        [HttpGet("ObterPregoes")]
        public IActionResult ObterPregoes()
        {

            var ret = _financeService.GetFinances().ToList();
            List<GuideModel> lst = new List<GuideModel>();
            foreach(var o in ret)
            {
                var guide = new GuideModel()
                {
                    ChartPreviousClose = o.ChartPreviousClose
                    , Currency = o.Currency
                    , DataGranularity = o.DataGranularity
                    , ExchangeName = o.ExchangeName
                    , ExchangeTimezoneName = o.ExchangeTimezoneName
                    , FirstTradeDate = o.FirstTradeDate
                    , Gmtoffset = o.Gmtoffset
                    , InstrumentType = o.InstrumentType
                    , Id = o.Id
                    , PreviousClose = o.PreviousClose
                    , PriceHint = o.PriceHint
                    , Range = o.Range
                    , RegularMarketPrice = o.RegularMarketPrice
                    , RegularMarketTime = o.RegularMarketTime
                    , Scale = o.Scale
                    ,Symbol = o.Symbol
                    ,Timezone = o.Timezone
                };
                lst.Add(guide);
            }

            return Ok(lst);

        }

    }
}
