using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly AppDbContext _context;
        public IUserRepository Users { get; set; }
        public IBookRepository Books { get; set; }

        public UnitOfWork(AppDbContext context,
                          IUserRepository userRepository,
                          IBookRepository bookRepository)
        {
            _context = context;
            Users = userRepository;
            Books = bookRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}