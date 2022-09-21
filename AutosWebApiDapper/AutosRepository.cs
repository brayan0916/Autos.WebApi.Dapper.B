namespace AutosWebApiDapper
{
    public class AutosRepository : IAutosRepository
    {

        private readonly AutosDBContext _context;

        public AutosRepository(AutosDBContext context)
        {
            _context = context;
        }

        public Task<AutosEntity> AddAutos(AutosEntity autos)
        {
            throw new NotImplementedException();
        }

        public Task<AutosEntity> GetAutos(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AutosEntity>> GetListAutos()
        {
            throw new NotImplementedException();
        }
    }
}
