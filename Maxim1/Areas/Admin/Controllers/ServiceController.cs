using Maxim1.Areas.Admin.ViewModels;
using Maxim1.DAL;
using Maxim1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maxim1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ServiceController(AppDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Service> services =await _dbContext.Services.ToListAsync();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(ServiceCreateVM serviceCreateVM)
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Update(ServiceUpdateVM serviceUpdateVM)
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
