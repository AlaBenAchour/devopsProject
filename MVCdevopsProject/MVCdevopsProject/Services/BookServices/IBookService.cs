using MVCdevopsProject.DTOs;

namespace MVCdevopsProject.Services.BookServices
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetBooks();
    }

}