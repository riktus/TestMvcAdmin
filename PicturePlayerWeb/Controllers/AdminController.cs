using PicturePlayerWeb.Entity;
using PicturePlayerWeb.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicturePlayerWeb.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IRepository<PictureElement> picturesRepo;

        public int PageSize = 4;
        public AdminController(IRepository<PictureElement> repo)
        {
            picturesRepo = repo;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(picturesRepo.GetAllItems());
        }

        public ViewResult Edit(int pictureId)
        {
            PictureElement element = picturesRepo.GetAllItems().First(p => p.Id == pictureId);

            return View(element);
        }

        [HttpPost]
        public ActionResult Edit(PictureElement element)
        {
            if (ModelState.IsValid)
            {
                if(Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if(file != null && file.ContentLength > 0)
                    {
                        element.ImageMimeType = file.ContentType;
                        element.ImageData = new byte[file.ContentLength];
                        file.InputStream.Read(element.ImageData, 0, file.ContentLength);
                    }
                }

                picturesRepo.Save(element);
                TempData["status"] = string.Format("Изображение {0} было сохранено", element.Name);

                return RedirectToAction("Index");
            }
            else
            {
                return View(element);
            }
        }

        public ViewResult Create()
        {
            var element = new PictureElement();
            element.Name = " ";
            element.StartTime = " ";
            element.Link = " ";

            return View("Edit", element);
        }

        [HttpPost]
        public ActionResult Delete(int pictureId)
        {
            PictureElement element = picturesRepo.Delete(pictureId);
            if(element != null)
            {
                TempData["status"] = string.Format("Изображение {0} удалено", element.Name);
            }
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int pictureId)
        {
            var image = picturesRepo.GetAllItems().FirstOrDefault(t => t.Id == pictureId);
            if (image != null)
                return File(image.ImageData, image.ImageMimeType);
            else
                return null;
        }
    }
}