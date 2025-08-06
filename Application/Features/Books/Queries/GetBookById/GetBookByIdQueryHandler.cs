using Application.Dtos;
using Application.Interfaces.Repos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken ct)
        {
            var book = await _bookRepository.GetBookByIdWithAuthorAsync(request.id);
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name
            };
        }
    }
}
