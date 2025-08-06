using Application.Interfaces.Repos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken ct)
        {
            var book = new Book
            {
                Title = request.Title,
                AuthorId = request.AuthorId,
            };

            await _bookRepository.CreateBookAsync(book);
            return book.Id;
        }
    }
}
