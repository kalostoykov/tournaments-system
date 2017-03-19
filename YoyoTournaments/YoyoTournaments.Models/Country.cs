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
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MinLength(Validation.MinCountryNameLength)]
        [MaxLength(Validation.MaxCountryNameLength)]
        public string Name { get; set; }
    }
}
