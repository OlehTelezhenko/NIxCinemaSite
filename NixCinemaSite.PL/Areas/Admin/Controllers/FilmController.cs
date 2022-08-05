using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using System;

namespace NixCinemaSite.PL.Areas.Admin.Controllers
{
    [Controller]
    [Area("Admin")]
    [Authorize(Roles = "Moderator, Admin")]
    public class FilmController : Controller
    {
        private readonly IFilmService _presentationFilmService;

        public FilmController(IFilmService presentationFilmService)
        {
            _presentationFilmService = presentationFilmService;
        }

        [HttpGet("Film/Index")]
        [HttpGet("Film/Index/{sortOrder?}")]
        [HttpGet("Film/Index/{sortOrder?}/{currentPage?}")]
        [HttpGet("Film/Index/{sortOrder?}/{currentPage?}/{searchString?}")]
        public ActionResult Index(string? sortOrder, int? currentPage, string searchString)
        {
            var page = _presentationFilmService.GetPageAfterPagination(sortOrder, currentPage, searchString);
            return View(page);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var a = _presentationFilmService.Details(id);
            return View(a);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmDTO film)
        {
            try
            {
                _presentationFilmService.Create(film);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(_presentationFilmService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, FilmDTO film)
        {
            try
            {
                _presentationFilmService.Edit(film);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var a = _presentationFilmService.GetById(id);
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FilmDTO film)
        {
            try
            {
                _presentationFilmService.Delete(film.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("film/get/{input}")]
        public ActionResult get(string input)
        {
            try
            {
                var a = Guid.Parse(input);
                return Ok(_presentationFilmService.GetById(a));
            }
            catch (Exception)
            {
                return Ok(_presentationFilmService.Find(input).FirstOrDefault());
            }
        }

    }
}
