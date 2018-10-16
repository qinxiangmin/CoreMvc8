using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using CoreMvc8.Authorization;
using CoreMvc8.Books.Dto;
using CoreMvc8.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc8.Books
{
    public class BookAppService : CoreMvc8AppServiceBase, IBookAppService
    {
        private readonly IBookRepository _bookRepository;  //IRepository<Book>
        private readonly IRepository<UserLoginAttempt, long> _taskRepository;//仓储
        private IUnitOfWorkManager _unitOfWorkManager;
        public BookAppService(IBookRepository bookRepository, IRepository<UserLoginAttempt, long> taskRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _bookRepository = bookRepository;
            _taskRepository = taskRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<BookDto> CreateAsync(BookDto input)
        {
            // var book = ObjectMapper.Map<Book>(input);
            // book.UserId = 1;
            Book b = new Book()
            {
                BookName = input.BookName,
                Price = input.Price,
                UserId = AbpSession.GetUserId()
                
            };
            await _bookRepository.InsertAsync(b);

            return new BookDto();
        }

        public async Task DeleteAsync(EntityDto<int> input)
        {
            var user = await _bookRepository.GetAll().SingleOrDefaultAsync(p => p.Id == input.Id); ;
            await _bookRepository.DeleteAsync(user);
        }

        [AbpAuthorize(PermissionNames.Pages_Book_See)]//特性方式权限检查

        public async Task<PagedResultDto<BookListoutput>> GetAllAsync(PageInput pageInput, SeachInput seachInput, OrderInput orderInput)
        {
            //  PermissionChecker.Authorize(PermissionNames.Pages_Book_See);权限检查

            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))//禁用默认过滤器
            {
                var bookList = await _bookRepository.GetAll().Include(p => p.User).ToListAsync();

                if (!string.IsNullOrEmpty(seachInput.SeachBookName))
                {                           
                    bookList = bookList.Where(p=>p.BookName.Contains(seachInput.SeachBookName)).ToList();
                }
                if (orderInput.OrderName == "Desc")
                {
                    bookList = bookList.OrderByDescending(p=>p.BookName).ToList();
                }
                else 
                {
                    bookList = bookList.OrderBy(p => p.BookName).ToList();
                }

           

                var booksCount = bookList.Count();
                var taskList = bookList.Skip((pageInput.pageIndex - 1) * pageInput.pageMax).Take(pageInput.pageMax).ToList();


                return new PagedResultDto<BookListoutput>(booksCount, taskList.MapTo<List<BookListoutput>>()
                    );

            }

           // var bookList = await _bookRepository.GetAll().Include(p => p.User).ToListAsync();

        }

        public BookListoutput GetBookById(IdDto entity)
        {
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))//禁用默认过滤器
            {
                var book = _bookRepository.GetAll().Include(p => p.User).Where(p => p.Id == entity.Id).FirstOrDefault();//FirstOrDefault()获取第一个值

                return ObjectMapper.Map<BookListoutput>(book);
            }
           

        }

        //public async Task<BookListoutput> GetBookById(EntityDto<int> input)
        //{
        //    var book = await _bookRepository.GetAsync(input.Id);
        //    return ObjectMapper.Map<BookListoutput>(book);
        //}

        public int GetBookCount()
        {
            var bookCount = _bookRepository.Count();
            return bookCount;
        }

        public ListResultDto<LoginIngoDto> GetLoginInfo()
        {
          var reso = _taskRepository.GetAllList(p=>p.UserId == AbpSession.GetUserId());//仅仅查询登陆的用户
            
            return new ListResultDto<LoginIngoDto>(
               ObjectMapper.Map<List<LoginIngoDto>>(reso)
           );
            //return new LoginIngoDto();
        }

        public long GetUserId()
        {
           return AbpSession.GetUserId();//获取用户当前登陆Id
        }

    }
}
