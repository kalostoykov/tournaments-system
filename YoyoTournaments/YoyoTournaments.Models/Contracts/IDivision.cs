using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoyoTournaments.Models.Contracts
{
    public class IDivision
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}
