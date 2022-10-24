using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    public class EmployeeLeaveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SicknessIndex()
        {
            return View();
        }

        public IActionResult SicknessCreate(int? id)
        {
            if (id == null) return NotFound();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SicknessCreate()
        {
            return View(nameof(Index));
        }
    }
}
