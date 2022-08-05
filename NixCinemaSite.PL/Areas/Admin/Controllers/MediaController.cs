using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.PL.Areas.Admin.Controllers
{
    [Controller]
    [Area("Admin")]
    [Authorize(Roles = "Moderator, Admin")]
    public class MediaController : Controller
    {
        private readonly IMediaService _presentationMediaService;

        public MediaController(IMediaService presentationMediaService)
        {
            _presentationMediaService = presentationMediaService;
        }

        [HttpGet("Media/Index")]
        [HttpGet("Media/Index/{sortOrder?}")]
        [HttpGet("Media/Index/{sortOrder?}/{currentPage?}")]
        [HttpGet("Media/Index/{sortOrder?}/{currentPage?}/{searchString?}")]
        public ActionResult Index(string? sortOrder, int? currentPage, string searchString)
        {
            var page = _presentationMediaService.GetPageAfterPagination(sortOrder, currentPage, searchString);
            return View(page);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var a = _presentationMediaService.Details(id);
            return View(a);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MediaDTO media)
        {
            try
            {
                _presentationMediaService.Create(media);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(_presentationMediaService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, MediaDTO media)
        {
            try
            {
                _presentationMediaService.Edit(media);
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
            return View(_presentationMediaService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MediaDTO media)
        {
            try
            {
                _presentationMediaService.Delete(media.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("media/get/{input}")]
        public ActionResult get(string input)
        {
            return Ok(_presentationMediaService.GetById(Guid.Parse(input)));
        }
    }
}
