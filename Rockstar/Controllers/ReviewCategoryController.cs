using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Rockstar.ViewModels.Category;

namespace Rockstar.Controllers
{
    public class ReviewCategoryController : Controller
    {
        private ReviewLogic _reviewLogic = new ReviewLogic();
        private ReviewCategoryLogic _reviewCategoryLogic = new ReviewCategoryLogic();

        public IActionResult Add()
        {
            var viewModel = new AddCategoryViewModel();
            viewModel.Categories = _reviewLogic.GetAllCategories();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel viewModel)
        {
            var category = viewModel.Category;
            _reviewCategoryLogic.AddCategory(category);
            return View();
        }

        public IActionResult CategoriesOfCompany()
        {
            return View();
        }
    }
}