using Domain.Models;

namespace Domain.Interfaces;

public interface IBugService {
    Task<IEnumerable<Bug>> getBugsDbAsync();
}