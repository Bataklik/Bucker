using Domain.Models;

namespace Domain.Interfaces;

public interface IBugService {
    Task<IEnumerable<Bug>> GetBugsDbAsync();
    Task<Bug> GetBugDbAsync(int id);
    Task<bool> UpdateBugAsync(Bug bug);
    Task<Bug> CreateBugAsync(Bug bug);
    Task<bool> DeleteBugAsync(int id);
    bool BugExists(int id);
}