using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rockstar.ViewModels.Category
{
    public class AddCategoryViewModel
    {
        public List<Models.Category> Categories { get; set; }
        public Models.Category Category { get; set; }
    }
}
