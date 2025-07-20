using Application.Dtos;
using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {
        public List<BookDto> GetBooks()
        {
            return new List<BookDto>
            {
                new BookDto { Id = Guid.NewGuid(), Title = "Clean Code", Author = "Robert Martin" },
                new BookDto { Id = Guid.NewGuid(), Title = "CLR via C#", Author = "Jeffrey Richter" }
            };
        }
    }
}
