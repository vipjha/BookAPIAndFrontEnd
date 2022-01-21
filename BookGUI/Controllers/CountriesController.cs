using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApiProject.Dtos;
using BookApiProject.Models;
using BookApiProject.Services;
using BookGUI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookGUI.Controllers
{
    public class CountriesController : Controller
    {

        ICoutryRepositoryGUI _countryRepositoryGUI;

        public CountriesController(ICoutryRepositoryGUI coutryRepositoryGUI)
        {
            _countryRepositoryGUI = coutryRepositoryGUI;   
        }

        
        public IActionResult Index()
        {
            var countries = _countryRepositoryGUI.GetCountries();

           //var countries = new List<CountryDto>();

            if (countries.Count()<=0)
            {
                ViewBag.Message = "Thre was a problem retriving countries from" +
                    "the database or no coutry exists";
            }

            return View(countries);
        }

        public IActionResult GetCountryById(int countryId)
        {
            var country = _countryRepositoryGUI.GetConturyById(countryId);
           //country = null;

            if (country==null)
            {
                ModelState.AddModelError("", "Error getting a country");

                ViewBag.Message = $"There is proble retiving Country with id {countryId}" +
                    $"from the database or no coury whit that id exists";

                country = new CountryDto();
            }

            return View(country);
        }
    }
}
