using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IBookRepository
    {
        Task<Book> CreateBookAsync(Book book);
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Book> GetBookByIdWithAuthorAsync(Guid id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
    }
}
