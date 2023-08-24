
using AutoMapper;
using MK.Business.Interface;
using MK.DataAccess.Interfaces;
using MK.Model.Dtos.Book;
using MK.Model.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTypesLayer.Utilities;
using MK.Business.CustomExceptions;

namespace MK.Business.Implementation
{
    public class BookBs : IBookBs
    {


        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;


        public BookBs(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var book = await _repo.GetByIdAsycn(id);

            _repo.DeleteAsync(book);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<BookGetDto>> GetByIdAsync(int bookId, params string[] includeList)
        {


            var book = await _repo.GetByIdAsycn(bookId, includeList);

            if (book != null)
            {
                var dto = _mapper.Map<BookGetDto>(book);
                return ApiResponse<BookGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }
        public async Task<ApiResponse<List<BookGetDto>>> GetProductsAsync(params string[] includeList)
        {
            //Loglama
            //Authenticaiton

            //VeriTabanından getAll ile ürünleri getirecek....
            //return _repo.GetAll(null,includeList);

            var book = await _repo.GetAllAsync(includeList: includeList);
            if (book.Count > 0)
            {
                var bookList = _mapper.Map<List<BookGetDto>>(book);
                var response = ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, bookList);

                return response;
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");

            //Loglama
            //Validation
            //Authenticaiton
        }

        public async Task<ApiResponse<List<BookGetDto>>> GetProductsByPriceAsync(decimal min, decimal max, params string[] includeList)
        {
            //Loglama
            //Authenticaiton


            if (min > max)
                throw new BadRequestException("Min Değeri Max değerinden küçük olamaz!");
            if (min == max)
                throw new BadRequestException("Min değeri ile eşit olamaz");
            if (min < 0 || max < 0)
                throw new BadRequestException("min veya max değerinleri negatif olamaz!");
            // tüm validasyon parametrelerini burada işleyebilirisiniz...

            var book = await _repo.GetByPriceRangeAsycn(min, max, includeList);

            if (book != null || book.Count > 0)
            {
                var returnList = _mapper.Map<List<BookGetDto>>(book);
                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new BadRequestException("Ürün Yok");

            //Loglama
            //Validation
            //Authenticaiton
        }



        public async Task<ApiResponse<Book>> InsertAsync(BookPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.Price <= 0)
                throw new BadRequestException("Kaydedilecek Ürün fiyatı 0'dan büyük olmalıdır.");
            // validasyonlar....
            var book = _mapper.Map<Book>(dto);
            var insertedProduct = await _repo.InsertAsync(book);
            return ApiResponse<Book>.Success(StatusCodes.Status200OK, insertedProduct);



        }

        public async Task<ApiResponse<NoData>> UpdateAsync(BookPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.Price <= 0)
                throw new BadRequestException("Kaydedilecek Ürün fiyatı 0'dan büyük olmalıdır.");
            var book = _mapper.Map<Book>(dto);
            await _repo.UpdateAsync(book);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);


        }
    }
}
