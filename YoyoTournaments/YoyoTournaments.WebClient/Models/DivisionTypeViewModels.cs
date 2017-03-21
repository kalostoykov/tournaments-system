using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoyoTournaments.WebClient.Models
{
    public class DivisionTypeGridViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class DivisionTypeDetailsViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}