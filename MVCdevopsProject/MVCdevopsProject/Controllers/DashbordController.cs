using Microsoft.AspNetCore.Mvc;
using MVCdevopsProject.Services.BookServices;

namespace MVCdevopsProject.Controllers
{
    public class DashbordController : Controller
    {
        //private readonly IBookService _bookService;

        //public DashbordController(IBookService bookService)
        //{
        //    _bookService = bookService;
        //}

        public  IActionResult Dashbord()
        {
            //var result = await _bookService.GetBooks();
            return View();
        }
    }
}
