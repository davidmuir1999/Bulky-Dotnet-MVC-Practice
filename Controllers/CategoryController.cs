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
            if (obj.Name == obj.DisplayOrder.ToString()) // this is server side validation
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)// validation that will add new category to database only if validations are met
            {
                _db.Categories.Add(obj); // telling entity framework you have to add this category object to category table
                _db.SaveChanges();//go to database and create that category
                TempData["success"] = "Category created successfully"; //creating a page messaged
                return RedirectToAction("Index");
                //reason we redirect to index is because index and category are in same controller
                //if they were in different controllers, you would write category, not index
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);  //retrieving category from db
            //Other methods to retrieve
            //Category? categoryFromDb = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb = _db.Categories.Where(u=>.Id==id).FirstOrDefault;
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj) //when creating a post method object category is needed
        {
            if (ModelState.IsValid)// validation that will add new category to database only if validations are met
            {
                _db.Categories.Update(obj); // telling entity framework you have to update this category object to category table
                _db.SaveChanges();//go to database and create that category
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
                //reason we redirect to index is because index and category are in same controller
                //if they were in different controllers, you would write category, not index
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);  //retrieving category from db
            //Other methods to retrieve
            //Category? categoryFromDb = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb = _db.Categories.Where(u=>.Id==id).FirstOrDefault;
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id) //when creating a post method object category is needed
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);//remove category obj with given id
            _db.SaveChanges();//go to database and create that category
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            //reason we redirect to index is because index and category are in same controller
            //if they were in different controllers, you would write category, not index
        }
    }
}