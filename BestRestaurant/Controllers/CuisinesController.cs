using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantContext _db;

    public CuisinesController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }
    public ActionResult Edit(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
      _db.Entry(cuisine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}

// using System.Collections.Generic;
// using System;
// using Microsoft.AspNetCore.Mvc;
// using ToDoList.Models;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;

// namespace ToDoList.Controllers
// {
//   public class CategoriesController : Controller
//   {
//     private readonly ToDoListContext _db;

//     public CategoriesController(ToDoListContext db)
//     {
//       _db = db;
//     }

//     public ActionResult Index()
//     {
//       List<Category> model = _db.Categories.ToList();
//       return View(model);
//     }

//     public ActionResult Create()
//     {
//       return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Category category)
//     {
//       _db.Categories.Add(category);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Details(int id)
//     {
//       Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
//       return View(thisCategory);
//     }

//     public ActionResult Edit(int id)
//     {
//       var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
//       return View(thisCategory);
//     }

//     [HttpPost]
//     public ActionResult Edit(Category category)
//     {
//       _db.Entry(category).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//       var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
//       return View(thisCategory);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
//       _db.Categories.Remove(thisCategory);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
//   }
// }