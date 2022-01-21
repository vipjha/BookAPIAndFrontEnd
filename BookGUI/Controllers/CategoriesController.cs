using BookApiProject.Dtos;
using BookGUI.Services;
using BookGUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookGUI.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoyRepositoryGUI _categoyRepositoryGUI;

        public CategoriesController(ICategoyRepositoryGUI categoyRepositoryGUI)
        {
            _categoyRepositoryGUI = categoyRepositoryGUI;
        }

        public IActionResult Index()
        {
            var categories = _categoyRepositoryGUI.GetCategories();
            if (categories.Count() <= 0)
            {
                ViewBag.Message = "There was a probem retriving caegories from the databse";
            }
            return View(categories);
        }

        public IActionResult GetCategoryById(int categoryId)
        {
            var category = _categoyRepositoryGUI.GetCategoryById(categoryId);
            
            if (category==null)
            {
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"There was a probem retriving caegory with id{categoryId}"+
                    $"from the database or no category with that id exists";
                category = new CategoryDto();
            }
            var books = _categoyRepositoryGUI.GetAllBooksForCategory(categoryId);
            if(books.Count()<=0)
            {
                ViewBag.BookMessage = $"{category.Name} has no books";
            }

            var bookCategoryViewModel = new CategoryBooksViewModel()
            {
                Category = category,
                Books = books
            };
            return View(bookCategoryViewModel);
        }
    }
}
