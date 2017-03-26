using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoyoTournaments.Services;
using YoyoTournaments.Services.Contracts;
using YoyoTournaments.WebClient.Models;

namespace YoyoTournaments.WebClient.Controllers
{
    public class DivisionTypeController : Controller
    {
        private readonly IDivisionTypeService service;

        public DivisionTypeController(IDivisionTypeService service)
        {
            Guard.WhenArgument(service, nameof(service)).IsNull().Throw();

            this.service = service;
        }

        public ActionResult Index()
        {
            var divisions = this.service.GetAllDivisionTypes().ToList();

            var divisionTypeViewModels = new List<DivisionTypeGridViewModel>();
            foreach (var divisionType in divisions)
            {
                var viewModel = new DivisionTypeGridViewModel()
                {
                    Id = divisionType.Id,
                    Name = divisionType.Name
                };

                divisionTypeViewModels.Add(viewModel);
            }

            return View(divisionTypeViewModels);
        }

        public ActionResult Details(Guid Id)
        {
            var divisionType = this.service.GetDivisionTypeById(Id);

            var viewModel = new DivisionTypeDetailsViewModel()
            {
                Name = divisionType.Name,
                Description = divisionType.Description
            };

            return View(viewModel);
        }
    }
}