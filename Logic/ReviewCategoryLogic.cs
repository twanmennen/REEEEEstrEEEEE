using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Models;

namespace Logic
{
    public class ReviewCategoryLogic
    {
        private ReviewCategoryContext reviewCategoryContext;

        public ReviewCategoryLogic()
        {
            reviewCategoryContext = new ReviewCategoryContext();
        }

        public void AddCategory(Category category)
        {
            reviewCategoryContext.AddCategory(category);
        }

        public List<Category> GetCategoriesSelectForCompany()
        {
            return reviewCategoryContext.GetCategoriesSelectForCompany();
        }

        public void AddSelectedCategoriesToCompany(List<Category> categories, int companyId)
        {

            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Selected == true)
                {
                    reviewCategoryContext.AddSelectedCategoriesToCompany((i+1), companyId);
                }
                
            }
        }
    }
}
