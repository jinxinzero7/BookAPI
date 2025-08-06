using Application.Interfaces.Repos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken ct)
        {
            var author = new Author
            {
                Name = request.Name,
                LastName = request.LastName
            };

            await _authorRepository.CreateAuthorAsync(author);
            return author.Id;
        }
    }
}
