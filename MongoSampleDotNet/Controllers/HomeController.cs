using System;
using System.Linq;
using System.Web.Mvc;
using Book.Domains;
using Book.Services;
using MongoDB.Bson;

namespace BookDesktop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
 //           _bookService.Insert(new BookEntity()
 //           {
 //               AddDate = DateTime.Now,
 //               Author = "Ali Samiyen",
 //               Id = ObjectId.GenerateNewId(),
 //               Name = " Galatasaray Stadı"
 //,
 //           });

          var booklist =  _bookService.GetAll();

            return View(booklist);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}