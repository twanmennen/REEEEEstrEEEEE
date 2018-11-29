using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Rockstar.ViewModels.Category
{
    public class CategoriesOfCompanyViewModel
    {
        public List<Company> Companies { get; set; }
        public List<Models.Category> Categories { get; set; }
    }
}
