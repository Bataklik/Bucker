using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Services;

public class BugService : IBugService {
    private readonly AppDbContext _dbContext;

    public BugService(AppDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Bug>> GetBugsDbAsync() {
        return await _dbContext.Bugs.ToListAsync();
    }

    public async Task<Bug> GetBugDbAsync(Guid id) {
        return await _dbContext.Bugs.FindAsync(id);
    }

    public async Task<bool> UpdateBugAsync(Bug bug) {
        _dbContext.Bugs.Update(bug);

        try {
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException e) {
            var exists = await _dbContext.Bugs.AnyAsync(_bug => _bug.Id == bug.Id);
            if (!exists) {
                return false;
            }

            throw;
        }
    }
}