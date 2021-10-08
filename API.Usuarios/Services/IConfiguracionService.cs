using API.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Services
{
    public interface IConfiguracionService
    {      
        Task<List<Configuracion>> GetAllConfiguracionAsync();

        //Task<Configuracion> GetByPeriodo(String Periodo);
    }
    
}
