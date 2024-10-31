using ApplicationLayer.DTOs;
using ApplicationLayer.Service.Contract;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagaBookMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _bookService.GetBooksAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookDto book)
        {


            if (ModelState.IsValid)
            {
               


            
                await _bookService.CreateBookAsync(book);
        
                return RedirectToAction("Index");


            }
            else
            {
    
                List<String> errors = new List<String>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = String.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(book);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            BookDto book = await _bookService.GetBookByIdAsync(Id);

            return View(book);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookDto book)
        {


            if (ModelState.IsValid)
            {


                await _bookService.UpdateBookAsync(book);
          
                return RedirectToAction("Index");


            }
            else
            {
                TempData["error"] = "Update thất bại";
                List<String> errors = new List<String>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = String.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(book);
        }
        public async Task<IActionResult> Delete(int Id)
        {

            await _bookService.DeleteBookAsync(Id);
       
            return RedirectToAction("Index");

        }
    }
}
