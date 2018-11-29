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
            var viewModel = new CategoriesOfCompanyViewModel();
            viewModel.Categories = _reviewCategoryLogic.GetCategoriesSelectForCompany(); //Hiermee kan je dan met een checkbox de public bool Selected true maken
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CategoriesOfCompany(CategoriesOfCompanyViewModel viewModel)
        {
            var companyId = viewModel.CompanyId; //Value= company.Id van een select met companies
            var categories = viewModel.Categories;
            _reviewCategoryLogic.AddSelectedCategoriesToCompany(categories, companyId);
            return View();
        }
    }
}