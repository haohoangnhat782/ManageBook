using DomainLayer.Entities;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace  InfrastructureLayer.Repositories
{
      public class BookRepository : GenericRepository<Book>, IBookRepository
      {

        public BookRepository(AppDbContext context) : base(context) { }



    }
}
