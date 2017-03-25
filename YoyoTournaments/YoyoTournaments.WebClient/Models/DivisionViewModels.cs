using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoyoTournaments.Models;

namespace YoyoTournaments.WebClient.Models
{
    public class DivisionDetailsViewModel
    {
        public Guid Id { get; set; }

        public DivisionType DivisionType { get; set; }

        public IPagedList<ApplicationUser> Users { get; set; }

        public Guid TournamentId { get; set; }
    }
}