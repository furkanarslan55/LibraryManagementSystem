using AutoMapper;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.Comment;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Concrete
{
    public class BookCommentManager : IBookCommentService
    {
        private readonly IBookCommentDal _commentDal;
        private readonly IAuthenticatedUserService _authService; // Kimsin sen?
        private readonly IMapper _mapper;

        public BookCommentManager(IBookCommentDal commentDal, IAuthenticatedUserService authService, IMapper mapper)
        {
            _commentDal = commentDal;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task AddCommentAsync(AddCommentDto dto)
        {
            // KURAL 1: Puan 1 ile 5 arasında olmalı.
            if (dto.Score < 1 || dto.Score > 5)
                throw new Exception("Puan 1 ile 5 arasında olmalıdır.");

            // KURAL 2: Giriş yapmış mı?
            var userId = _authService.UserId ?? throw new Exception("Giriş yapmalısınız.");

            var comment = _mapper.Map<BookComment>(dto);
            comment.UserId = userId; // Token'dan aldık

            // Interceptor tarihleri halledecek.
            await _commentDal.AddAsync(comment);
        }

        public async Task<List<ListCommentDto>> GetCommentsByBookIdAsync(int bookId)
        {
            // Sadece o kitaba ait yorumları getir.
            // AYRICA: Yorumu yapan kullanıcının adını da getir (Include User).
            var comments = await _commentDal.GetAllAsync(x => x.BookId == bookId);

            return _mapper.Map<List<ListCommentDto>>(comments);
        }
    }
}
