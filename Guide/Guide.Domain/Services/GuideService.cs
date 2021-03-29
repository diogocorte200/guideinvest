using AutoMapper;
using Guide.Domain.Domain;
using Guide.Domain.Services.Generic;
using Guide.Entity.Entity;
using Guide.Entity.Repositories.Interfaces;
using Guide.Entity.UnitofWork;
using System.Collections.Generic;

namespace Guide.Domain.Services
{
    public class GuideService<Tv, Te> : GenericServiceAsync<Tv, Te>
                                              where Tv : GuideModel
                                              where Te : FinanceEntity
        
    {
        private readonly IGuideRepository _guideRepository;
        private readonly ICurrentTradingPeriodRepository _currentTradingPeriodRepository;
        private readonly IQuoteIndicatorRepository _quoteIndicatorRepository;
            public GuideService(IUnitOfWork unitOfWork, IMapper mapper,
                             IGuideRepository guideRepository, ICurrentTradingPeriodRepository currentTradingPeriodRepository, IQuoteIndicatorRepository quoteIndicatorRepository)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;

            if (_guideRepository == null)
                _guideRepository = guideRepository;

            if (_currentTradingPeriodRepository == null)
                _currentTradingPeriodRepository = currentTradingPeriodRepository;
            if (_quoteIndicatorRepository == null)
                _quoteIndicatorRepository = quoteIndicatorRepository;
        }

        public IEnumerable< FinanceEntity> GetFinances(int timeFinances)
        {
            return _guideRepository.Find(x => x.RegularMarketTime > timeFinances);
        }

        public void ProcessFinance(Finance finance)
        {
            var obj = new FinanceEntity()
            {
                ChartPreviousClose = finance.Chart.Result[0].Meta.ChartPreviousClose,
                Currency = finance.Chart.Result[0].Meta.Currency,
                DataGranularity = finance.Chart.Result[0].Meta.DataGranularity,
                ExchangeName = finance.Chart.Result[0].Meta.ExchangeName,
                ExchangeTimezoneName = finance.Chart.Result[0].Meta.ExchangeTimezoneName,
                FirstTradeDate = finance.Chart.Result[0].Meta.FirstTradeDate,
                Gmtoffset = finance.Chart.Result[0].Meta.Gmtoffset,
                InstrumentType = finance.Chart.Result[0].Meta.InstrumentType,
                PreviousClose = finance.Chart.Result[0].Meta.PreviousClose,
                PriceHint = finance.Chart.Result[0].Meta.PriceHint,
                Range = finance.Chart.Result[0].Meta.Range,
                RegularMarketPrice = finance.Chart.Result[0].Meta.RegularMarketPrice,
                RegularMarketTime = finance.Chart.Result[0].Meta.RegularMarketTime,
                Scale = finance.Chart.Result[0].Meta.Scale,
                Symbol = finance.Chart.Result[0].Meta.Symbol,
                Timezone = finance.Chart.Result[0].Meta.Timezone
                
            };
            _guideRepository.Add(obj);
            _guideRepository.Save();
            var idFinance = obj.Id;

            var pre = new CurrentTradingPeriodEntity()
            {
                IdFinance = idFinance,
                Type = "pre",
                End = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Pre.End,
                Gmtoffset = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Pre.Gmtoffset,
                Start = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Pre.Start,
                Timezone = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Pre.Timezone
            };
            _currentTradingPeriodRepository.Add(pre);
            var post = new CurrentTradingPeriodEntity()
            {
                IdFinance = idFinance,
                Type = "post",
                End = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Post.End,
                Gmtoffset = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Post.Gmtoffset,
                Start = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Post.Start,
                Timezone = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Post.Timezone
            };
            _currentTradingPeriodRepository.Add(post);
            var regular = new CurrentTradingPeriodEntity()
            {
                IdFinance = idFinance,
                Type = "regular",
                End = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Regular.End,
                Gmtoffset = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Regular.Gmtoffset,
                Start = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Regular.Start,
                Timezone = finance.Chart.Result[0].Meta.CurrentTradingPeriod.Regular.Timezone
            };
            _currentTradingPeriodRepository.Add(regular);

            foreach (var o in finance.Chart.Result[0].Meta.TradingPeriods)
            {
                foreach(var per in o)
                {
                    var trading = new CurrentTradingPeriodEntity()
                    {
                        IdFinance = idFinance,
                        End = per.End,
                        Gmtoffset = per.Gmtoffset,
                        Start = per.Start,
                        Timezone = per.Timezone,
                    };
                    _currentTradingPeriodRepository.Add(trading);
                }
                
            }
            _currentTradingPeriodRepository.Save();

            for (int i =0; i < finance.Chart.Result[0].Timestamp.Length; i++)
            {
                var timeStamp = finance.Chart.Result[0].Timestamp[i];
                var quotes = finance.Chart.Result[0].Indicators.Quote;
                var quoteIndic = new QuoteIndicatorEntity()
                {
                    IdFinance = idFinance,
                    TimestampMeta = timeStamp,
                    QuoteClose = quotes[0].Close[i],
                    QuoteHigh = quotes[0].High[i],
                    QuoteLow = quotes[0].Low[i],
                    QuoteOpen = quotes[0].Open[i],
                    Volume = quotes[0].Volume[i],
                };
                _quoteIndicatorRepository.Add(quoteIndic);
            }
            _quoteIndicatorRepository.Save();

        }

        
    }
}
