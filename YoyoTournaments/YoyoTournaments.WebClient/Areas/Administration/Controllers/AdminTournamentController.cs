using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YoyoTournaments.Models;
using YoyoTournaments.Services.Contracts;
using YoyoTournaments.WebClient.Areas.Administration.Models;
using YoyoTournaments.WebClient.CustomAttributes;

namespace YoyoTournaments.WebClient.Areas.Administration.Controllers
{
    [AuthorizeAdmin(Roles = "Admin")]
    public class AdminTournamentController : Controller
    {
        private readonly ICountryService countryService;
        private readonly ITournamentService tournamentService;

        public AdminTournamentController(ITournamentService tournamentService, ICountryService countryService)
        {
            this.tournamentService = tournamentService;
            this.countryService = countryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var countries = this.countryService.GetAllCountries().ToList();

            var viewModel = new TournamentCreateFormViewModel()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Countries = countries
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TournamentCreateFormViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.tournamentService.CreateTournament(model.Name, model.Place, model.StartDate, model.EndDate, model.SelectedCountryId);

            return Redirect("~/Home/Index");
        }
    }
}