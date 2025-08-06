using Application.Dtos;
using Application.Features.Authors.Commands.CreateAuthor;
using Application.Features.Books.Commands.CreateBook;
using Application.Features.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-book")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
        {
            var command = new CreateBookCommand(dto.Title, dto.AuthorId);
            var bookId = await _mediator.Send(command);

            // Исправлено: добавлен объект значения и имя маршрута
            return CreatedAtAction(
                actionName: nameof(GetBook),
                routeValues: new { id = bookId },
                value: new { id = bookId } // Тело ответа
            );
        }

        [HttpPost("create-author")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto dto)
        {
            var command = new CreateAuthorCommand(dto.Name, dto.LastName);
            var authorId = await _mediator.Send(command);

            // Исправлено: используем правильный путь
            return Created($"/api/v1/book/authors/{authorId}", new { id = authorId });
        }

        // Добавлен метод для получения автора
        [HttpGet("authors/{id}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            // TODO: Реализуйте получение автора
            return Ok(new { id = id });
        }

        // Исправлено: добавлено имя маршрута
        [HttpGet("{id}", Name = "GetBook")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var query = new GetBookByIdQuery(id);
            var bookDto = await _mediator.Send(query);
            return Ok(bookDto);
        }
    }
}
