using gsnet.Data;
using gsnet.Models;

namespace gsnet.Services
{
    public class CoralService : ICoralService
    {
        private readonly DataContext _context;

        public CoralService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateCoralAsync(Coral coral)
        {
            _context.Coralis.Add(coral);
            await _context.SaveChangesAsync();
        }

        public async Task<Coral> GetCoralByIdAsync(int coralId)
        {
            return await _context.Coralis.FindAsync(coralId);
        }

        public async Task UpdateCoralAsync(Coral coral)
        {
            _context.Coralis.Update(coral);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoralAsync(int coralId)
        {
            var coral = await _context.Coralis.FindAsync(coralId);
            if (coral != null)
            {
                _context.Coralis.Remove(coral);
                await _context.SaveChangesAsync();
            }
        }
    }
}