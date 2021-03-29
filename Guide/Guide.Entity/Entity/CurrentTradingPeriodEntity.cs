using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Guide.Entity.Entity
{
    [Table("CurrentTradingPeriod")]
    public class CurrentTradingPeriodEntity 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CurrentTradingPeriodId { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("Finance")]
        public int IdFinance { get; set; }
        public virtual FinanceEntity Finance { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Type { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string Timezone { get; set; }
        [Column(TypeName = "int")]
        public int Start { get; set; }
        [Column(TypeName = "int")]
        public int End { get; set; }
        [Column(TypeName = "int")]
        public int Gmtoffset { get; set; }
    }
}
