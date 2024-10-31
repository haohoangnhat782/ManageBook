using DomainLayer.Entities;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace  InfrastructureLayer.Repositories
{
      public class UserRepository : GenericRepository<User>, IUserRepository
      {

        public UserRepository(AppDbContext context) : base(context) { }



    }
}
