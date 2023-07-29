using Microsoft.AspNetCore.Mvc;
using BulkyWebMVCProject.Data;
using BulkyWebMVCProject.Models;

namespace BulkyWebMVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; // creating a local variable

        public CategoryController(ApplicationDbContext db) //constructor
        {
            _db = db; // assigning the implementation within the constructor equal to local variable
        //by doing the above we can use the view section below inside any action method
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList(); // retrieving categories list
            return View(objCategoryList); // linking the object list to the view action method
        }
    }
}