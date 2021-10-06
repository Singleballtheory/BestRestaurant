using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BestRestaurant.Controllers
{
    public class CuisinesController : Controller
    {
      private readonly BestRestaurantContext _db;

      public CuisinesController(BestRestaurantContext db)
      {
        _db = db;
      }
    }
}
