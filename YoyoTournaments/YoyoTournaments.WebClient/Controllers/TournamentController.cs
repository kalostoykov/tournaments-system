using Microsoft.AspNet.Identity;
using PagedList;
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

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (page < 1)
            {
                page = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            int count = 0;
            var tournaments = this.tournamentService.GetAllTournamentsWIthPaging(out count, page, pageSize);
            var tournamentsModel = new List<TournamentGridViewModel>();

            foreach (var tournament in tournaments)
            {
                var tournamentViewModel = new TournamentGridViewModel
                {
                    Id = tournament.Id,
                    Name = tournament.Name,
                    Country = tournament.Country,
                    StartDate = tournament.StartDate,
                    EndDate = tournament.EndDate
                };

                tournamentsModel.Add(tournamentViewModel);
            }

            var viewModel = new StaticPagedList<TournamentGridViewModel>(tournamentsModel, page, pageSize, count);

            return this.View(viewModel);
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

            return this.View(viewModel);
        }

        public ActionResult Division(Guid id, int page = 1, int pageSize = 10)
        {
            if (id == Guid.Empty)
            {
                return this.View("Error");
            }

            if (page < 1)
            {
                page = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            var division = this.divisionService.GetDivisionById(id);

            var viewModel = new DivisionDetailsViewModel()
            {
                Id = division.Id,
                DivisionType = division.DivisionType,
                TournamentId = division.TournamentId,
                Users = division.Users.ToPagedList(page, pageSize)
            };

            return this.View(viewModel);
        }

        public ActionResult SignIn(string divisionId)
        {
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            this.divisionService.AddUserToDivision(userId, Guid.Parse(divisionId));

            return this.Redirect("~/Tournament");
        }
    }
}