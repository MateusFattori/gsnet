using gsnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gsnet.Services
{
    public interface ILocalizacaoService
    {
        Task CreateLocalizacaoAsync(Localizacao localizacao);
        Task<Localizacao> GetLocalizacaoByIdAsync(int localizacaoId);
        Task UpdateLocalizacaoAsync(Localizacao localizacao);
        Task DeleteLocalizacaoAsync(int localizacaoId);
    }
}
