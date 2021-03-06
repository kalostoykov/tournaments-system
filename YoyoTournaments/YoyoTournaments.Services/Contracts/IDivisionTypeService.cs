﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoTournaments.Models;

namespace YoyoTournaments.Services.Contracts
{
    public interface IDivisionTypeService
    {
        IEnumerable<DivisionType> GetAllDivisionTypes();

        DivisionType GetDivisionTypeById(Guid id);
    }
}
