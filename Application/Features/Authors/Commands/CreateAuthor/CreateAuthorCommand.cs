using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Commands.CreateAuthor
{
    public record CreateAuthorCommand(string Name, string LastName) : IRequest<Guid>;
}
