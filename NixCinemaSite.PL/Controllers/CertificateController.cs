using Microsoft.AspNetCore.Mvc;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using System;

namespace NixCinemaSite.PL.Controllers
{
    [Controller]
    public class CertificateController : Controller
    {
        private readonly IPresentationCertificateService _presentationCertificateService;

        public CertificateController(IPresentationCertificateService presentationCertificateService)
        {
            _presentationCertificateService = presentationCertificateService;
        }

        [HttpGet("Certificate/Index/")]
        [HttpGet("Certificate/Index/{sortOrder}")]
        [HttpGet("Certificate/Index/{sortOrder}/{currentPage}")]
        [HttpGet("Certificate/Index/{sortOrder}/{currentPage}/{searchString}")]
        public ActionResult Index(string? sortOrder, int? currentPage, string searchString)
        {
            var page = _presentationCertificateService.GetPageAfterPagination(sortOrder, currentPage, searchString);
            return View(page);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(_presentationCertificateService.Details(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CertificateDTO certificate)
        {
            try
            {
                _presentationCertificateService.Create(certificate);
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
            return View(_presentationCertificateService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, CertificateDTO certificate)
        {
            try
            {
                _presentationCertificateService.Edit(certificate);
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
            return View(_presentationCertificateService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, CertificateDTO certificate)
        {
            try
            {
                _presentationCertificateService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("certificate/get/{input}")]
        public ActionResult get(string input)
        {
            try
            {
                var a = Guid.Parse(input);
                return Ok(_presentationCertificateService.GetById(a));
            }
            catch (Exception)
            {
                return Ok(_presentationCertificateService.Find(input));
            }
        }

        [HttpGet]
        public ActionResult GetList()
        {
            return Ok(_presentationCertificateService.GetListPage());
        }


    }
}
