using BookApiProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookGUI.Services
{
   public interface IReviewerRepositoryGUI
    {
        ReviewerDto GetReviewerById(int reviewerId);
        ReviewerDto GetReviewerOfAReview(int reviewId);
        IEnumerable<ReviewerDto> GetReviewers();
        IEnumerable<ReviewDto> GetReviewsByReviewer(int reviewerId);
    }
}
