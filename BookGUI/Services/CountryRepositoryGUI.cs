using BookApiProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public class CountryRepositoryGUI : ICoutryRepositoryGUI
    {
        public IEnumerable<AuthorDto> GetAuthorsFromACountry(int countryId)
        {
            IEnumerable<AuthorDto> authors = new List<AuthorDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"countries/{countryId}/authors");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<AuthorDto>>();
                    readTask.Wait();

                    authors = readTask.Result;
                }
            }
            return authors;

            //throw new NotImplementedException();
        }

        public CountryDto GetConturyById(int countryId)
        {
            CountryDto country = new CountryDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"countries/{countryId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CountryDto>();
                    readTask.Wait();
                    country = readTask.Result;
                }
            }
            return country;

            // throw new NotImplementedException();
        }

        public IEnumerable<CountryDto> GetCountries()
        {
            IEnumerable<CountryDto> countries = new List<CountryDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync("countries");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CountryDto>>();
                    readTask.Wait();

                    countries = readTask.Result;
                }
            }
            return countries;

          //  throw new NotImplementedException();
        }

        public CountryDto GetCountryOfAnAuthor(int authorId)
        {

            CountryDto country = new CountryDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/api/");

                var response = client.GetAsync($"countries/authors/{authorId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CountryDto>();
                    readTask.Wait();
                    country = readTask.Result;
                }
            }
            return country;

            //throw new NotImplementedException();
        }
    }
}
