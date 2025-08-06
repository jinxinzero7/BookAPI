using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.CreateBook
{
    public record CreateBookCommand(string Title, Guid AuthorId) : IRequest<Guid>;
}
