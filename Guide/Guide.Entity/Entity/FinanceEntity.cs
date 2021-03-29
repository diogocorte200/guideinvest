using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Guide.Entity.Entity
{
    [Table("Finance")]
    public class FinanceEntity : BaseEntity
    {
        [Column(TypeName = "varchar(3)")]
        public string Currency { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Symbol { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string ExchangeName { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string InstrumentType { get; set; }
        [Column(TypeName = "int")]
        public int FirstTradeDate { get; set; }
        [Column(TypeName = "int")]
        public int RegularMarketTime { get; set; }
        [Column(TypeName = "int")]
        public int Gmtoffset { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string Timezone { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ExchangeTimezoneName { get; set; }
        [Column(TypeName = "decimal")]
        public decimal RegularMarketPrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal ChartPreviousClose { get; set; }
        [Column(TypeName = "decimal")]
        public decimal PreviousClose { get; set; }
        [Column(TypeName = "int")]
        public int Scale { get; set; }
        [Column(TypeName = "int")]
        public int PriceHint { get; set; }
        [Column(TypeName = "varchar(3)")]
        public string DataGranularity { get; set; }
        [Column(TypeName = "varchar(3)")]
        public string Range { get; set; }

        public virtual ICollection<CurrentTradingPeriodEntity> CurrentTradingPeriodEntities { get; set; }
        public virtual ICollection<QuoteIndicatorEntity> QuoteIndicatorsEntities { get; set; }
    }
}

