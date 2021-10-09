using API.Usuarios.Models;
using API.Usuarios.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigracionController : ControllerBase
    {
        private readonly IConfiguracionService configuracionService;
        private readonly IMigracionService migracionService;
        public MigracionController(IConfiguracionService configuracion, IMigracionService migracion)
        {
            configuracionService = configuracion;
            migracionService = migracion;
        }

        //[HttpGet]
        //public ActionResult<List<Migracion>> GetConfiguracion()
        //{
        //    //Obtener Periodo Activo

        //    //Buscar si existe Data por Periodo - No es necesario traer toda la data.
        //    List<Migracion> listaMigracion

        //    return  service.GetAllConfiguracionAsync();
        //}

    }
}
