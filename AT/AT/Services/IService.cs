using AT.Models;

namespace AT.Services
{
    public interface IService
    {
        Task<List<PacoteTuristico>> GetAllAsync();
        Task<List<Destino>> GetAllAsyncDestino();
        Task<List<PacoteTuristico>> GetAllAsyncPacoteTuristico();
        Task<PacoteTuristico?> GetByIdAsync(int id);
    }
}
