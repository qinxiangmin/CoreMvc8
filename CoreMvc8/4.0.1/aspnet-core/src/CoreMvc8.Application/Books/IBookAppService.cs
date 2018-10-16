using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreMvc8.Books.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreMvc8.Books
{
    public interface IBookAppService: IApplicationService
    {
        Task<PagedResultDto<BookListoutput>> GetAllAsync(PageInput pageInput, SeachInput seachInput, OrderInput orderInput);

        BookListoutput GetBookById(IdDto entity);

        int GetBookCount();
        //Task<BookListoutput> CreateAsync(Bookinput bookinput);
        long GetUserId();

        ListResultDto<LoginIngoDto> GetLoginInfo();

        Task DeleteAsync(EntityDto<int> input);

        Task<BookDto> CreateAsync(BookDto input);

      //  Task<BookListoutput> GetBookById(EntityDto<int> input);
    }
}
