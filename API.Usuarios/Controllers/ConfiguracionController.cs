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
        
        private readonly IConfiguracionService service;
        public ConfiguracionController(IConfiguracionService services)
        {            
            service = services;
        }    

        [HttpGet]
        public async Task<ActionResult<List<Configuracion>>> GetConfiguracion()
        {
            return await service.GetAllConfiguracionAsync();
        }     
       
        [HttpPost]
        public async Task<ActionResult<Configuracion>> CreateConfiguracion(Configuracion configuracion)
        {
            return await service.AddConfiguracionAsync(configuracion);            
        }

        [HttpGet("GetByPeriodo", Name = "GetByPeriodo")]
        public IActionResult GetByPeriodo(string Periodo)
        {
            return Ok(service.GetConfiguracionByPeriodoAsync(Periodo));
        }

    }
}
