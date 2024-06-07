using gsnet.Data;
using gsnet.Models;

namespace gsnet.Services
{
    public class LocalizacaoService : ILocalizacaoService
    {
        private readonly DataContext _context;

        public LocalizacaoService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateLocalizacaoAsync(Localizacao localizacao)
        {
            _context.Localizacaoes.Add(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Localizacao> GetLocalizacaoByIdAsync(int localizacaoId)
        {
            return await _context.Localizacaoes.FindAsync(localizacaoId);
        }

        public async Task UpdateLocalizacaoAsync(Localizacao localizacao)
        {
            _context.Localizacaoes.Update(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocalizacaoAsync(int localizacaoId)
        {
            var localizacao = await _context.Localizacaoes.FindAsync(localizacaoId);
            if (localizacao != null)
            {
                _context.Localizacaoes.Remove(localizacao);
                await _context.SaveChangesAsync();
            }
        }

        public Task<string?> GetAllLocalizacoesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
