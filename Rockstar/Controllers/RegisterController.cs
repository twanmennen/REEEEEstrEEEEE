using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Rockstar.ViewModels.Account;
using Rockstar.ViewModels.Register;

namespace Rockstar.Controllers
{
    public class RegisterController : Controller
    {
        private RegisterLogic registerLogic = new RegisterLogic();
        private IHostingEnvironment _hostingEnvironment;

        public RegisterController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IActionResult RegisterUser()
        {
            int roleId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "RoleId")?.Value);

            RegisterUserViewModel viewModel = new RegisterUserViewModel(roleId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUserViewModel viewModel)
        {
            if (/*viewModel.State == valid*/ viewModel.EMail != null && viewModel.Name != null && viewModel.PassWord != null)
            {
                string eMailLoggedIn = Convert.ToString(User.Claims.Where(claim => claim.Type == ClaimTypes.Email).Select(claim => claim.Value).SingleOrDefault());

                registerLogic.RegisterUser(viewModel.Name, viewModel.EMail, viewModel.PassWord, viewModel.Role, eMailLoggedIn);
                return RedirectToAction("Index", "Home");
            }

            return View("RegisterUser", viewModel);
        }

        public IActionResult RegisterCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyViewModel viewModel)
        {
            var company = viewModel.Company;
            var companyImage = viewModel.Image;
            string companyImageFileName = companyImage.FileName;
            company.Image = companyImageFileName;
            registerLogic.RegisterCompany(company);

            //Add image to root of app
            string mapRoot = "CompanyImages/";

            var companyImagePath = Path.Combine(_hostingEnvironment.WebRootPath, mapRoot);
            await AddFileToDirectory(companyImage, companyImagePath);

            return RedirectToAction("RegisterCompany");
        }

        public async Task AddFileToDirectory(IFormFile file, string path)
        {
            if (file.Length > 0)
            {
                try
                {
                    var filePath = Path.Combine(path, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);

                    }
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(path);

                    await AddFileToDirectory(file, path);
                }
            }
            else
            {
                throw new Exception("File is leeg");
            }
        }
    }
}