namespace AutosWebApiDapper
{
    public interface IAutosRepository
    {
       

        Task<List<AutosEntity>> GetListAutos();
        Task<AutosEntity> GetAutosId(int id);
        
        Task<AutosEntity> AddAutos(AutosEntity autos);
        

    }
}
