using Microsoft.EntityFrameworkCore;

namespace AutosWebApiDapper
{
    public class AutosRepository : IAutosRepository
    {

        private readonly AutosDBContext _context;

        public AutosRepository(AutosDBContext context)
        {
            _context = context;
        }

        public async Task<AutosEntity> AddAutos(AutosEntity autos)
        {
            _context.Add(autos);
            await _context.SaveChangesAsync();
            return autos;
        }

        public async Task<AutosEntity> GetAutosId(int id)
        {
           return  await _context.autosCar.FindAsync(id);
        }

        public async Task<List<AutosEntity>> GetListAutos()
        {
            return  await _context.autosCar.ToListAsync();
        }
    }
}
