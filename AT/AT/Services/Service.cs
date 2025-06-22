using AT.Data;
using AT.Models;
using Microsoft.EntityFrameworkCore;

namespace AT.Services
{
    public class Service : IService
    {
        private readonly ATContext _context;

        public Service(ATContext context)
        {
            _context = context;
        }

        // Retorna a lista de Cidades
        public async Task<List<PacoteTuristico>> GetAllAsync()
        {
            return await _context.PacotesTuristicos
                .Include(c => c.Titulo)
                .Include(c => c.Preco)
                .Include(c => c.CapacidadeMaxima)
                .Include(c => c.DataInicio)
                .ToListAsync();
        }

        public async Task<List<Destino>> GetAllAsyncDestino()
        {
            return await _context.Destinos.ToListAsync();
        }

        public async Task<List<PacoteTuristico>> GetAllAsyncPacoteTuristico()
        {
            return await _context.PacotesTuristicos.ToListAsync();
        }

        // Carrega todas as propriedades em Pacote Turistico
        public async Task<PacoteTuristico?> GetByIdAsync(int id)
        {
            return await _context.PacotesTuristicos                
                .Include(n => n.Destinos)
                .FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}
