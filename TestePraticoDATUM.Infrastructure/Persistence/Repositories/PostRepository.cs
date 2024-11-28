using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Core.Entities;
using TestePraticoDATUM.Core.Repositories;

namespace TestePraticoDATUM.Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly TestePraticoDATUMDbContext _dbContext;
        public PostRepository(TestePraticoDATUMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task AddAsync(Post project)
        {
            await _dbContext.Posts.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _dbContext.Posts.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}