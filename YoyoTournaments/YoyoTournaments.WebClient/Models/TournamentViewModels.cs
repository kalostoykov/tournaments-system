using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YoyoTournaments.Models;

namespace YoyoTournaments.WebClient.Models
{
    public class TournamentDetailsViewModel
    {
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public Country Country { get; set; }

        public string Place { get; set; }

        public List<Division> DivisionsInTournament { get; set; }
    }
}