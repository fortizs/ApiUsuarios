using API.Usuarios.Models;
using System.Collections.Generic;

namespace API.Usuarios.Services
{
    public interface IMigracionService
    {
        List<Migracion> GetByPeriodo(string periodo);
    }
}