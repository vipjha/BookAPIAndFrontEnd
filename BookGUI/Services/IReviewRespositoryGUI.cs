using BookApiProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookGUI.Services
{
  public interface IReviewRespositoryGUI
    {
        BookDto GetBookOfAReview(int reviewId);
        ReviewDto GetReviewById(int reviewId);
        IEnumerable<ReviewDto> GetReviews();
        IEnumerable<ReviewDto> GetReviewsOfABook(int bookId);

    }
}
