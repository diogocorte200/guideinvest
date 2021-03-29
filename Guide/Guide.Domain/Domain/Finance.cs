namespace Guide.Domain.Domain
{
    public class Finance : BaseDomain
    {
        public Chart Chart { get; set; }
    }

    public class Chart : BaseDomain
    {
        public Result[] Result { get; set; }
        public object Error { get; set; }
    }

    public class Result : BaseDomain
    {
        public Meta Meta { get; set; }
        public int[] Timestamp { get; set; }
        public Indicators Indicators { get; set; }
    }

    public class Meta : BaseDomain
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
        public Currenttradingperiod CurrentTradingPeriod { get; set; }
        public Tradingperiod[][] TradingPeriods { get; set; }
        public string DataGranularity { get; set; }
        public string Range { get; set; }
        public string[] ValidRanges { get; set; }
    }

    public class Currenttradingperiod : BaseDomain
    {
        public Pre Pre { get; set; }
        public Regular Regular { get; set; }
        public Post Post { get; set; }
    }

    public class Pre : BaseDomain
    {
        public string Timezone { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Gmtoffset { get; set; }
    }

    public class Regular : Pre
    {
    }

    public class Post : Pre
    {
    }

    public class Tradingperiod : BaseDomain
    {
        public string Timezone { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Gmtoffset { get; set; }
    }
    public class Indicators : BaseDomain
    {
        public Quote[] Quote { get; set; }
    }

    public class Quote : BaseDomain
    {
        public int?[] Volume { get; set; }
        public decimal?[] Close { get; set; }
        public decimal?[] High { get; set; }
        public decimal?[] Low { get; set; }
        public decimal?[] Open { get; set; }
    }
}
