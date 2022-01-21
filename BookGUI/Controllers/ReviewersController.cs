using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApiProject.Dtos;
using BookGUI.Services;
using BookGUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookGUI.Controllers
{
    public class ReviewersController : Controller
    {
        IReviewerRepositoryGUI _reviewerRepositoryGUI;
        IReviewRespositoryGUI _reviewRespositoryGUI;

        public ReviewersController(IReviewerRepositoryGUI reviewerRepositoryGUI, IReviewRespositoryGUI reviewRespositoryGUI)
        {
            _reviewerRepositoryGUI = reviewerRepositoryGUI;
            _reviewRespositoryGUI = reviewRespositoryGUI;
        }

        public IActionResult Index()
        {
            var reviewers = _reviewerRepositoryGUI.GetReviewers();

            if(reviewers.Count()<=0)
            {
                ViewBag.Message = "There was a problem retriving reviewers from the database or no reviewer exists";
            }
            return View(reviewers);
        }

        public IActionResult GetReviewerById(int reviewerId)
        {
            var reviewer = _reviewerRepositoryGUI.GetReviewerById(reviewerId);
            if (reviewer==null)
            {

                ModelState.AddModelError("", "Some kind if error getting reviewer");
                ViewBag.ReviewerMessage = $"There wa a problem retriving reviewer from the database" +
                    $"or no reviewer with id {reviewerId} exist";

                reviewer = new ReviewerDto();
            }

            var reviews = _reviewerRepositoryGUI.GetReviewsByReviewer(reviewerId);
            if(reviews.Count()<=0)
            {
                ViewBag.ReviewMessage = $"Reviewer {reviewer.FirstName} {reviewer.LastName} has no reviews";
            }

            IDictionary<ReviewDto, BookDto> reviewAndBook = new Dictionary<ReviewDto, BookDto>();

            foreach(var review in reviews)
            {
                var book = _reviewRespositoryGUI.GetBookOfAReview(review.Id);
                reviewAndBook.Add(review, book);
            }

            var reviewerReviewBooksViewModel = new ReviwerReviewsBookViewModel
            {
                Reviewer = reviewer,
                ReviewBook = reviewAndBook
            };
            return View(reviewerReviewBooksViewModel);
        }
    }
}