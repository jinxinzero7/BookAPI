using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(Guid id) : IRequest<BookDto>;
}
