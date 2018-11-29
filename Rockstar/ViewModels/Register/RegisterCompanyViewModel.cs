using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models;

namespace Rockstar.ViewModels.Register
{
    public class RegisterCompanyViewModel
    {
        public Company Company { get; set; }
        public IFormFile Image { get; set; }

        public RegisterCompanyViewModel()
        {
            Company = new Company();
        }
    }
}
