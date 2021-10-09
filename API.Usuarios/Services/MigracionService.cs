using API.Usuarios.Models;
using API.Usuarios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Services
{
    public class MigracionService : IMigracionService
    {
        private readonly IMigracionRepository repo;

        public MigracionService(IMigracionRepository repo)
        {
            this.repo = repo;
        }

        public List<Migracion> GetByPeriodo(string periodo) {
            return repo.GetByPeriodoAsync(periodo);
        }

        public async Task<Migracion> AddAsync(Migracion entity)
        {
            return await repo.AddAsync(entity);
        }

    }
}
