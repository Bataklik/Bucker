using Domain.Models;

namespace Domain.Interfaces;

public interface IBugService {
    Task<IEnumerable<Bug>> GetBugsDbAsync();
    Task<Bug> GetBugDbAsync(Guid id);
    Task<bool> UpdateBugAsync(Bug bug);
}