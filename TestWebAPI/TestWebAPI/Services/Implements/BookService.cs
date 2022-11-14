using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Models.Responses;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookService : IBookService
    {
        private TestContext _context;

        public BookService(TestContext context)
        {
            _context = context;
        }

        public async Task<AddBookResponse> Add(AddBookRequest bookToAdd)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == bookToAdd.CategoryId);
            if (category == null)
            {
                return null;
            }

            var b = new Book()
            {
                BookTitle = bookToAdd.BookTitle,
                CategoryId = bookToAdd.CategoryId,
                Category = category
            };
            await _context.Books.AddAsync(b);
            await _context.SaveChangesAsync();

            return new AddBookResponse
            {
                Id = b.BookId,
                BookTitle = b.BookTitle,
            };
        }

        public bool Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book != null)
            {
                _context.Remove(book);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool SoftDelete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book != null)
                {
                    book.IsDeleted = true;
                    _context.Update(book);
                    _context.SaveChanges();

                    return true;
                }

                return false;
        }

        public async Task<IEnumerable<BookResponse?>> Get()
        {
            var listBooks = await _context.Books.Include(m => m.Category).ToListAsync();
            List<BookResponse> response = new List<BookResponse>();

            foreach(var item in listBooks)
            {
                var newBook = new BookResponse
                {
                    BookId = item.BookId,
                    BookTitle= item.BookTitle,
                    Category=item.Category,
                    IsDeleted = item.IsDeleted
                };
                response.Add(newBook);
            }

            return response;
        }

        public async Task<Book?> Get(int id)
        {
            return await _context.Books
                .Include(m => m.Category)
                .FirstOrDefaultAsync(x => x.BookId == id);
        }

        public Book Update(int id, UpdateBookRequest bookToUpdate)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book != null){
                var category = _context.Categories.FirstOrDefault(c => c.CategoryId == bookToUpdate.CategoryId);
                
                if (category != null)
                {
                    book.BookTitle = bookToUpdate.BookTitle;
                    book.CategoryId = bookToUpdate.CategoryId;
                    book.Category = category;
                    book.IsDeleted = bookToUpdate.IsDeleted;
                    _context.Books.Update(book);
                    _context.SaveChanges();

                    return book;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}
