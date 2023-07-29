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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj) //when creating a post method object category is needed
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }
            if(obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid)// validation that will add new category to database only if validations are met
            {
                _db.Categories.Add(obj); // telling entity framework you have to add this category object to category table
                _db.SaveChanges();//go to database and create that category
                return RedirectToAction("Index");
            //reason we redirect to index is because index and category are in same controller
            //if they were in different controllers, you would write category, not index
            }
            return View();
        }
    }
}