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
    public class MovieReviewController : Controller
    {
        // GET: MovieReview
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieReviewService(userId);
            var model = service.GetMovieReviews();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMovieReviewService();

            if (service.CreateMovieReview(model))
            {
                TempData["SaveResult"] = "Your review has been successfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Review could not be created at this time.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMovieReviewService();
            var model = svc.GetMovieReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMovieReviewService();
            var detail = service.GetMovieReviewById(id);
            var model =
                new MovieReviewEdit
                {
                    MovieReviewId = detail.MovieReviewId,
                    MovieTitle = detail.MovieTitle,
                    MovieReleaseYear = detail.MovieReleaseYear,
                    Director = detail.Director,
                    MovieGenre = detail.MovieGenre,
                    MovieMania = detail.MovieMania,
                    MovieRating = detail.MovieRating
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MovieReviewId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateMovieReviewService();

            if (service.UpdateMovieReview(model))
            {
                TempData["SaveResult"] = "Your review has been updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your review could not be updated at this moment");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateMovieReviewService();
            var model = svc.GetMovieReviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMovieReviewService();

            service.DeleteMovieReview(id);

            TempData["SaveResult"] = "Your review has successfully been removed";

            return RedirectToAction("Index");


        }

        private MovieReviewService CreateMovieReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieReviewService(userId);
            return service;
        }
    }
}