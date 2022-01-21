using BookApiProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public class CategoryRepositoryGUI : ICategoyRepositoryGUI
    {
        public IEnumerable<BookDto> GetAllBooksForCategory(int categoryId)
        {
            IEnumerable<BookDto> books = new List<BookDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"categories/{categoryId}/books");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<BookDto>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
            }
            return books;

            //throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetAllCategories(int bookId)
        {
            IEnumerable<CategoryDto> categories = new List<CategoryDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"categories/books/{bookId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CategoryDto>>();
                    readTask.Wait();

                    categories = readTask.Result;
                }
            }
            return categories;

          //throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            IEnumerable<CategoryDto> categories = new List<CategoryDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync("categories");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CategoryDto>>();
                    readTask.Wait();

                    categories = readTask.Result;
                }
            }
            return categories;

            //throw new NotImplementedException();
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            CategoryDto category = new CategoryDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"categories/{categoryId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryDto>();
                    readTask.Wait();
                    category = readTask.Result;
                }
            }
            return category;

            // throw new NotImplementedException();
        }
    }
}
