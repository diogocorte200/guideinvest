using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Guide.Entity.Entity
{
    [Table("QuoteIndicator")]
    public class QuoteIndicatorEntity 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuoteIndicatorId { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("Finance")]
        public int IdFinance { get; set; }
        public virtual FinanceEntity Finance { get; set; }

        [Column(TypeName = "int")]
        public int? TimestampMeta { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? QuoteLow { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? QuoteHigh { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? QuoteOpen { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? QuoteClose { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? Volume { get; set; }

    }
}
