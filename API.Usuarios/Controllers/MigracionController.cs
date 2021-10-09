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
        private MyDBContext myDbContext;
        public MigracionController(IConfiguracionService configuracion, IMigracionService migracion, MyDBContext contexts)
        {
            configuracionService = configuracion;
            migracionService = migracion;
            myDbContext = contexts;
        }

        [HttpPost]
        public ActionResult<List<Migracion>> IniciarMigracion()
        {
            //Obtener Periodo Activo

            var configuracion = myDbContext.Configuraciones.Single(p => p.Habilitar.Equals(true));
            var periodo = "";
            if (configuracion != null)
            {
                periodo = configuracion.Periodo;
            }

            Console.Write("Periodo: " + periodo);
            List<Migracion> listaMigracion = new List<Migracion>();

            if (!periodo.Equals(""))
            {

                //Buscar si existe periodo en la migracion
                
                var migraciones = myDbContext.Migraciones.Where(m => m.Periodo.Contains(periodo)).ToList();
                if (migraciones.Count > 0)
                {
                    //Existen Migraciones - Debe filtrar por fecha y periodo
                    var dateAndTime = DateTime.Now;
                    var fechaActual = dateAndTime.Date.ToString("dd-MM-yyyy");
                    var alumnosOracle = myDbContext.UsuarioCursoOracles.Where(o => o.Strm == periodo && o.Sysdate.ToString("dd-MM-yyyy") == fechaActual).ToList();
                    var alumnosMoodle = myDbContext.UsuarioCursoMoodles.Where(o => o.Strm == periodo && o.Sysdate.ToString("dd-MM-yyyy") == fechaActual).ToList();

                    foreach (UsuarioCursoOracle usuarioOracle in alumnosOracle)
                    {
                        var oMigracion = new Migracion();
                        var item = alumnosMoodle.Find(x => x.Emplid == usuarioOracle.Emplid);
                        if (item != null)
                        {
                            oMigracion.TipoMigracion = "Agregar";
                            oMigracion.Fecha = DateTime.Now;
                            oMigracion.NroMigracion = 1;
                            oMigracion.NroIntento = 1;
                            oMigracion.Emplid = usuarioOracle.Emplid;
                            oMigracion.Periodo = usuarioOracle.Strm;
                            listaMigracion.Add(oMigracion);
                        }
                    }

                    foreach (UsuarioCursoMoodle usuarioMoodle in alumnosMoodle)
                    {
                        var oMigracion = new Migracion();
                        var item = alumnosOracle.Find(x => x.Emplid == usuarioMoodle.Emplid);
                        if (item != null)
                        {
                            oMigracion.TipoMigracion = "Quitar";
                            oMigracion.Fecha = DateTime.Now;
                            oMigracion.NroMigracion = 1;
                            oMigracion.NroIntento = 1;
                            oMigracion.Emplid = usuarioMoodle.Emplid;
                            oMigracion.Periodo = usuarioMoodle.Strm;
                            listaMigracion.Add(oMigracion);
                        }
                    }
                }
                else
                {
                    //No Existen Migraciones - Debe filtrar por periodo
                    var alumnosOracle = myDbContext.UsuarioCursoOracles.Where(o => o.Strm == periodo).ToList();
                    var alumnosMoodle = myDbContext.UsuarioCursoMoodles.Where(o => o.Strm == periodo).ToList();

                    foreach (UsuarioCursoOracle usuarioOracle in alumnosOracle)
                    {
                        var oMigracion = new Migracion();
                        var item = alumnosMoodle.Find(x => x.Emplid == usuarioOracle.Emplid);
                        if (item == null)
                        {
                            oMigracion.TipoMigracion = "Agregar";
                            oMigracion.Fecha = DateTime.Now;
                            oMigracion.NroMigracion = 1;
                            oMigracion.NroIntento = 0;
                            oMigracion.Emplid = usuarioOracle.Emplid;
                            oMigracion.Periodo = usuarioOracle.Strm;
                            listaMigracion.Add(oMigracion);
                        }
                    }

                    foreach (UsuarioCursoMoodle usuarioMoodle in alumnosMoodle)
                    {
                        var oMigracion = new Migracion();
                        var item = alumnosOracle.Find(x => x.Emplid == usuarioMoodle.Emplid);
                        if (item != null)
                        {
                            oMigracion.TipoMigracion = "Quitar";
                            oMigracion.Fecha = DateTime.Now;
                            oMigracion.NroMigracion = 1;
                            oMigracion.NroIntento = 0;
                            oMigracion.Emplid = usuarioMoodle.Emplid;
                            oMigracion.Periodo = usuarioMoodle.Strm;
                            listaMigracion.Add(oMigracion);
                        }
                    }

                }


                //Insertar en la Tabla Migracion
                if (listaMigracion.Count > 0)
                {
                    foreach (var entity in listaMigracion) {
                        migracionService.AddAsync(entity);
                    }
                }

            }           

            return listaMigracion;
        }

    }
}
