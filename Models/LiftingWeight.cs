using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.Models
{
    public class LiftingWeight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCompetitor { get; set; }
        [ForeignKey(nameof(IdCompetitor))]
        public virtual Competitor Competitor { get; set; }
        public int IdTypeLifting { get; set; }
        [ForeignKey(nameof(IdTypeLifting))]
        public virtual TypeLifting TypeLifting { get; set; }
        public double Weight { get; set; }
    }
}
