using CommonTypesLayer.Utilities;
using MK.Model.Dtos.Book;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Business.Interface
{
    public interface IBookBs
    {
        Task<ApiResponse<List<BookGetDto>>> GetProductsAsync(params string[] includeList);
        Task<ApiResponse<List<BookGetDto>>> GetProductsByPriceAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<BookGetDto>> GetByIdAsync(int productid, params string[] includeList);
        Task<ApiResponse<Book>> InsertAsync(BookPostDto prdouct);
        Task<ApiResponse<NoData>> UpdateAsync(BookPutDto prdouct);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
