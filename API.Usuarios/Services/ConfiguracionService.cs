using API.Usuarios.Models;
using API.Usuarios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Services
{
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly IConfigurationRepository repo;        

        public ConfiguracionService(IConfigurationRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<Configuracion>> GetAllConfiguracionAsync()
        {
            return await repo.GetAllConfiguracionAsync();
        }

        //public IEnumerable<Configuracion> GetConfiguracion()
        //{
        //    return repo.GetConfiguracion();
        //}

        //public Configuracion GetByPeriodo(string Periodo)
        //{
        //    return repo.GetByPeriodo(Periodo);
        //}
    }
}

 

