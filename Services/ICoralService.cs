using gsnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gsnet.Services
{
    public interface ICoralService
    {
        Task CreateCoralAsync(Coral coral);
        Task<Coral> GetCoralByIdAsync(int coralId);
        Task UpdateCoralAsync(Coral coral);
        Task DeleteCoralAsync(int coralId);
    }
}
