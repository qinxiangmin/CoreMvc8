using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using CoreMvc8.Books;
using CoreMvc8.Books.Dto;
using CoreMvc8.Controllers;
using CoreMvc8.Web.Models.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Mvc.Core;
namespace CoreMvc8.Web.Mvc.Controllers
{
    public class BooksController : CoreMvc8ControllerBase   //AbpController
    {
        private readonly IBookAppService _bookAppService;
      
        public BooksController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
           
        }
        // GET: Books
        //[UnitOfWork]//启用工作单元
        public async Task<ActionResult> Index(string SeachText, string currentFilter, string sortOrder, int? page)
        {          
            ViewBag.NameSortParm = sortOrder;
            var pageSize = 3;//页大小
            if (SeachText != null)
            {
                page = 1;
            }
            else
            {
                SeachText = currentFilter;
            }

            var pageNumber = page ?? 1;//第几页
           

            ViewBag.CurrentFilter = SeachText;

            PageInput pageInput = new PageInput() {
                pageIndex = pageNumber,
                pageMax = pageSize
            };
            SeachInput seachInput = new SeachInput() {
                SeachBookName = SeachText
            };
            OrderInput orderInput = new OrderInput() {
                 OrderName = ViewBag.NameSortParm
            };
            var BookList = await _bookAppService.GetAllAsync(pageInput, seachInput,orderInput);
          
            var onePageOfBook = new StaticPagedList<BookListoutput>(BookList.Items, pageNumber, pageSize, BookList.TotalCount); //将分页结果放入ViewBag供View使用 ViewBag.OnePageOfTasks = onePageOfTasks; 
            //pageNumber, pageSize, counts  页索引  页大小  总数

            ViewBag.OnePageOfTasks = onePageOfBook;

            return View();      
        }

        // GET: Books/Details/5
        [HttpPost]
        public ActionResult Details(int id)
        {
            IdDto idDto = new IdDto() {
                 Id = id
            };
            var book = _bookAppService.GetBookById(idDto);
            BookViewModel bookViewModel = new BookViewModel() {
                 Id = book.Id,
                 BookName = book.BookName,
                 Price = book.Price,
                 UserName = book.UserName
            };
            return View("_EditBookModalView", bookViewModel);
           // return View();
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Movies()
        {
            var movies = new List<object>();
            movies.Add(new { Title = "Ghostbusters", Genre = "Comedy", ReleaseDate = new DateTime(2017, 1, 1) });
            movies.Add(new { Title = "Gone with Wind", Genre = "Drama", ReleaseDate = new DateTime(2017, 1, 3) });
            movies.Add(new { Title = "Star Wars", Genre = "Science Fiction", ReleaseDate = new DateTime(2017, 1, 23) });
            return Json(movies);
        }

        public ActionResult GetLoginInfo()
        {
            var loginInfo = _bookAppService.GetLoginInfo().Items;
          //  ListResultDto<LoginList>(ObjectMapper.Map<List<LoginList>>(loginInfo));
            return View(ObjectMapper.Map<List<LoginList>>(loginInfo));
        }

        public ActionResult GetUserId()//测试登陆Id
        {
           long result = _bookAppService.GetUserId();

            return Json(result);
        }

       
        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}