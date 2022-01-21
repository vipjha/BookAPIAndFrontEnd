using BookApiProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public class ReviewRepositoryGUI : IReviewRespositoryGUI
    {
        public BookDto GetBookOfAReview(int reviewId)
        {
            BookDto book = new BookDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"reviews/{reviewId}/book");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BookDto>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }
            return book;
        
        //throw new NotImplementedException();
    }

        public ReviewDto GetReviewById(int reviewId)
        {
            ReviewDto review = new ReviewDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"reviews/{reviewId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ReviewDto>();
                    readTask.Wait();
                    review = readTask.Result;
                }
            }
            return review;
        }

        public IEnumerable<ReviewDto> GetReviews()
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync("reviews");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ReviewDto>>();
                    readTask.Wait();

                    reviews = readTask.Result;
                }
            }
            return reviews;
        }

        public IEnumerable<ReviewDto> GetReviewsOfABook(int bookId)
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"reviews/books/{bookId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ReviewDto>>();
                    readTask.Wait();

                    reviews = readTask.Result;
                }
            }
            return reviews;
        }
    }
}
