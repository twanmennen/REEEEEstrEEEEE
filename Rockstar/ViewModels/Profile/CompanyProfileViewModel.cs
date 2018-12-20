using System.Collections.Generic;
using Models;

namespace Rockstar.ViewModels.Account
{
    public class CompanyProfileViewModel
    {
        public Company Company { get; set; } = new Company();
        public List<Models.Review> Reviews { get; set; }
    }
}
