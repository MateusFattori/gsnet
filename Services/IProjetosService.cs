using gsnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gsnet.Services
{
    public interface IProjetoService
    {
        Task CreateProjetoAsync(Projeto projeto);
        Task<Projeto> GetProjetoByIdAsync(int projetoId);
        Task UpdateProjetoAsync(Projeto projeto);
        Task DeleteProjetoAsync(int projetoId);
    }
}
