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
        
        [HttpPut]
        public async Task<ActionResult<Configuracion>> UpdateConfiguracion(Configuracion configuracion)
        {
            return await service.UpdateConfiguracionAsync(configuracion);            
        }


        [HttpGet("GetByPeriodo", Name = "GetByPeriodo")]
        public async Task<ActionResult<Configuracion>> GetByPeriodo(string Periodo)
        {
            //return Ok(service.GetConfiguracionByPeriodoAsync(Periodo));
            return await service.GetConfiguracionByPeriodoAsync(Periodo);
        }

        [HttpGet("GetById", Name = "GetById")]        
        public async Task<ActionResult<Configuracion>> GetById(int id)
        {            
            return await service.GetConfiguracionById(id);
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    var movie = await _context.Movie.FindAsync(id);
        //    _context.Movie.Remove(movie);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
