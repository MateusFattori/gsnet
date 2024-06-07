// ProjetoService.cs
using gsnet.Data;
using gsnet.Models;

namespace gsnet.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly DataContext _context;

        public ProjetoService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateProjetoAsync(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task<Projeto> GetProjetoByIdAsync(int projetoId)
        {
            return await _context.Projetos.FindAsync(projetoId);
        }

        public async Task UpdateProjetoAsync(Projeto projeto)
        {
            _context.Projetos.Update(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjetoAsync(int projetoId)
        {
            var projeto = await _context.Projetos.FindAsync(projetoId);
            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
