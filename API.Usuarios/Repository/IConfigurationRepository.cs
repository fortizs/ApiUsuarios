using API.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Repository
{
    public interface IConfigurationRepository : IDisposable
    {
        IEnumerable<Configuracion> GetConfiguracion();
        Configuracion GetByPeriodo(string Periodo);
    }
}
