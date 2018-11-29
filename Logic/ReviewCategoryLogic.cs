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
    }
}
