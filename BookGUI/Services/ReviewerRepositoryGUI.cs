using BookApiProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public class ReviewerRepositoryGUI : IReviewerRepositoryGUI
    {
        public ReviewerDto GetReviewerById(int reviewerId)
        {
            ReviewerDto reviewer = new ReviewerDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"reviewers/{reviewerId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ReviewerDto>();
                    readTask.Wait();
                    reviewer = readTask.Result;
                }
            }
            return reviewer;

            // throw new NotImplementedException();
        }

        public ReviewerDto GetReviewerOfAReview(int reviewId)
        {
            ReviewerDto reviewer = new ReviewerDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"reviewers/{reviewId}/reviewer");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ReviewerDto>();
                    readTask.Wait();
                    reviewer = readTask.Result;
                }
            }
            return reviewer;

            // throw new NotImplementedException();
        }

        public IEnumerable<ReviewerDto> GetReviewers()
        {
            IEnumerable<ReviewerDto> reviewer = new List<ReviewerDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync("reviewers");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ReviewerDto>>();
                    readTask.Wait();

                    reviewer = readTask.Result;
                }
            }
            return reviewer;

            //  throw new NotImplementedException();
        }

        public IEnumerable<ReviewDto> GetReviewsByReviewer(int reviewerId)
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"reviewers/{reviewerId}/review");
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

            //  throw new NotImplementedException();
        }
    }
}
