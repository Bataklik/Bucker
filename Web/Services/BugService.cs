using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Services;

public class BugService : IBugService {

    private readonly AppDbContext _dbContext;

    public BugService(AppDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Bug>> getBugsDbAsync() {
        return await _dbContext.Bugs.ToListAsync();
    }
}