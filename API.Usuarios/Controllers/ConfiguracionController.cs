using API.Usuarios.Models;
using API.Usuarios.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        //private MyDBContext myDbContext;
        private IConfiguracionService service;
        public ConfiguracionController(IConfiguracionService services)
        {
            //myDbContext = context;
            service = services;
        }

        [HttpGet]
        public IEnumerable<Configuracion> GetConfiguracion()
        {
            return service.GetConfiguracion();
            //return (this.myDbContext.Configuraciones.ToList());
        }

        //[HttpGet("getRecursos", Name = "GetRecursos")]
        //public List<RecursosInfo> GetRecursos()
        //{
        //    return infoManager.getRecursos();
        //}
         
        [HttpGet("GetByPeriodo", Name = "GetByPeriodo")]
        public IActionResult GetByPeriodo(string Periodo)
        {
            return Ok(service.GetByPeriodo(Periodo));
        }

    }
}
