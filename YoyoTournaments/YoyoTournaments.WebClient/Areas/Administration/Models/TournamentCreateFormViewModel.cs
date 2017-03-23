using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YoyoTournaments.Models;

namespace YoyoTournaments.WebClient.Areas.Administration.Models
{
    public class TournamentCreateFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string Place { get; set; }

        public List<Country> Countries { get; set; }

        public Guid SelectedCountryId { get; set; }
    }
}