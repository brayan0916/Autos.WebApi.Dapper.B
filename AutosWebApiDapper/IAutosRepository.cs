namespace AutosWebApiDapper
{
    public interface IAutosRepository
    {
       

        Task<List<AutosEntity>> GetListAutos();
        Task<AutosEntity> GetAutos(int id);
        
        Task<AutosEntity> AddAutos(AutosEntity autos);
        

    }
}
