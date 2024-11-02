using Microsoft.AspNetCore.Mvc;
using MVCdevopsProject.Services.BookServices;

namespace MVCdevopsProject.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly IBookService _bookService;
        public AccountController(IBookService bookService)
        {

            _bookService = bookService;
        }
        public async Task<IActionResult> Login()
        {
            var result = await _bookService.GetBooks();
            return View(result);
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
