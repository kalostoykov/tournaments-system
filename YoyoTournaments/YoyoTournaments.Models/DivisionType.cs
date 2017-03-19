using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoTournaments.Common;

namespace YoyoTournaments.Models
{
    public class DivisionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MinLength(Validation.MinDivisionNameLength)]
        [MaxLength(Validation.MaxDivisionNameLength)]
        public string Name { get; set; }

        [MinLength(Validation.MinDivisionDescriptionLength)]
        [MaxLength(Validation.MaxDivisionDescriptionLength)]
        public string Description { get; set; }
    }
}
