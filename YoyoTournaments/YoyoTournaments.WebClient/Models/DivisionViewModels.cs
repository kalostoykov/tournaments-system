using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoyoTournaments.Models;

namespace YoyoTournaments.WebClient.Models
{
    public class DivisionDetailsViewModel
    {
        public DivisionType DivisionType { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public Guid TournamentId { get; set; }
    }
}