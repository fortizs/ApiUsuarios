using API.Usuarios.Models;
using API.Usuarios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Services
{
    public class ConfiguracionService 
    {
        private IConfigurationRepository repo;

        public ConfiguracionService(IConfigurationRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Configuracion> GetConfiguracion()
        {
            return repo.GetConfiguracion();
        }

        public Configuracion GetByPeriodo(string Periodo)
        {
            return repo.GetByPeriodo(Periodo);
        }
    }
}

 

