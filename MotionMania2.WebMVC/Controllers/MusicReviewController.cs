using Microsoft.AspNet.Identity;
using MotionMania2.Models;
using MotionMania2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotionMania2.WebMVC.Controllers
{
    [Authorize]
    public class MusicReviewController : Controller
    {
        // GET: MusicReview
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MusicReviewService(userId);
            var model = service.GetMusicReviews();
            return View(model);
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MusicReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMusicReviewService();

            if (service.CreateMusicReview(model))
            {
                TempData["SaveResult"] = "We appreciate your review.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your review could not be shared at this moment");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMusicReviewService();
            var model = svc.GetMusicReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMusicReviewService();
            var detail = service.GetMusicReviewById(id);
            var model =
                new MusicReviewEdit
                {
                    MusicReviewId = detail.MusicReviewId,
                    Artist = detail.Artist,
                    MusicTitle = detail.MusicTitle,
                    ReleaseType = detail.ReleaseType,
                    MusicGenreType = detail.MusicGenreType,
                    MusicMania = detail.MusicMania,
                    MusicRating = detail.MusicRating
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int musicReviewId, MusicReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MusicReviewId != musicReviewId)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateMusicReviewService();

            if (service.UpdateMusicReview(model))
            {
                TempData["SaveResult"] = "Your review has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your review couldn't be updated at this time");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateMusicReviewService();
            var model = svc.GetMusicReviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMusicMania(int id)
        {
            var service = CreateMusicReviewService();

            service.DeleteMusicReview(id);

            TempData["SaveResult"] = "Your review has been successfully deleted";

            return RedirectToAction("Index");

        }

        private MusicReviewService CreateMusicReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MusicReviewService(userId);
            return service;
        }
    }
}