using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoyoTournaments.Services.Contracts;
using YoyoTournaments.WebClient.Models;

namespace YoyoTournaments.WebClient.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IDivisionService divisionService;
        private readonly ITournamentService tournamentService;

        public TournamentController(ITournamentService tournamentService, IDivisionService divisionService)
        {
            this.tournamentService = tournamentService;
            this.divisionService = divisionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var tournament = this.tournamentService.GetTournamentById(id);

            var viewModel = new TournamentDetailsViewModel()
            {
                Name = tournament.Name,
                Place = tournament.Place,
                StartDate = tournament.StartDate,
                EndDate = tournament.EndDate,
                Country = tournament.Country,
                DivisionsInTournament = tournament.DivisionsInTournament.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Division(Guid id)
        {
            var division = this.divisionService.GetDivisionById(id);

            var viewModel = new DivisionDetailsViewModel()
            {
                DivisionType = division.DivisionType,
                TournamentId = division.TournamentId,
                Users = division.Users.ToList()
            };

            return View(viewModel);
        }
    }
}