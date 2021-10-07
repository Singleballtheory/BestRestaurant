using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BestRestaurant.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantContext _db;

    public RestaurantsController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
        var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
        return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
        _db.Entry(restaurant).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        _db.Restaurants.Remove(thisRestaurant);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}


// using Microsoft.AspNetCore.Mvc;
// using ToDoList.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Threading.Tasks;

// namespace ToDoList.Controllers
// {
//   public class ItemsController : Controller
//   {
//     private readonly ToDoListContext _db;

//     public ItemsController(ToDoListContext db)
//     {
//       _db = db;
//     }
//     public ActionResult Edit(int id)
//     {
//       var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
//       ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
//       return View(thisItem);
//     }

//     [HttpPost]
//     public ActionResult Edit(Item item)
//     {
//       _db.Entry(item).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
//     //end edit item
//     //start delete item
//     public ActionResult Delete(int id)
//     {
//       var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
//       return View(thisItem);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed (int id)
//     {
//       var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
//       _db.Items.Remove(thisItem);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
//     //end delete item

//     public ActionResult Index()
//     {
//       List<Item> model = _db.Items.Include(item => item.Category).ToList();
//       return View(model);
//     }

//     public ActionResult Create()
//     {
//         ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
//         return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Item item)
//     {
//         _db.Items.Add(item);
//         _db.SaveChanges();
//         return RedirectToAction("Index");
//     }

//     public ActionResult Details(int id)
//     {
//       Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
//       return View(thisItem);
//     }

//     // public async Task OnGetAsync(string SearchString)
//     // {
//     // var items = from m in _db.Items
//     //             select m;
//     // if (!string.IsNullOrEmpty(SearchString))
//     // {
//     //     items = items.Where(s => s.Description.Contains(SearchString));
//     // }

//     var thisItem = await items.ToListAsync();
//     }

//     [HttpPost, ActionName("OnGetAsync")]
//     public ActionResult Show(Item thisItem)
//     {
//       return View(thisItem);
//     }
//   }
// }
