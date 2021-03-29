namespace Guide.Domain.Domain
{

    public class GuideModel : BaseDomain
    {
        
            public string Currency { get; set; }
            public string Symbol { get; set; }
            public string ExchangeName { get; set; }
            public string InstrumentType { get; set; }
            public int FirstTradeDate { get; set; }
            public int RegularMarketTime { get; set; }
            public int Gmtoffset { get; set; }
            public string Timezone { get; set; }
            public string ExchangeTimezoneName { get; set; }
            public decimal RegularMarketPrice { get; set; }
            public decimal ChartPreviousClose { get; set; }
            public decimal PreviousClose { get; set; }
            public int Scale { get; set; }
            public int PriceHint { get; set; }
            
            public string DataGranularity { get; set; }
            public string Range { get; set; }
        
    }


    public class QuoteIndicators : BaseDomain
    {

        public int TimestampMeta { get; set; }
        public decimal QuoteLow { get; set; }
        public decimal QuoteHigh { get; set; }
        public decimal QuoteOpen { get; set; }
        public decimal QuoteClose { get; set; }
        public decimal Volume { get; set; }

    }


}
