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

        //[HttpPost]
        //public ActionResult<ResponseMigracion> IniciarMigracion()
        //{

        //    ResponseMigracion respuesta = new ResponseMigracion();
        //    int MigracionesCorrectas = 0;
        //    int MigracionesIncorrectas = 0;

        //    //Insertar 
        //    Schedule calendario = new Schedule();
        //    calendario.Fecha = DateTime.Now;
        //    myDbContext.Schedules.Add(calendario);
        //    myDbContext.SaveChanges();
        //    int IdSchedule = calendario.IdSchedule;


        //    //Obtener Periodo Activo

        //    var configuracion = myDbContext.Configuraciones.Single(p => p.Habilitar.Equals(true));
        //    var periodo = "";
        //    if (configuracion != null)
        //    {
        //        periodo = configuracion.Periodo;
        //    }

        //    Console.Write("Periodo: " + periodo);
        //    List<Migracion> listaMigracion = new List<Migracion>();

        //    if (!periodo.Equals(""))
        //    {

        //        //Buscar si existe periodo en la migracion

        //        var migraciones = myDbContext.Migraciones.Where(m => m.Periodo.Contains(periodo)).ToList();
        //        if (migraciones.Count > 0)
        //        {
        //            //Existen Migraciones - Debe filtrar por fecha y periodo
        //            var dateAndTime = DateTime.Now;
        //            var fechaActual = dateAndTime.Date.ToString("dd-MM-yyyy");
        //            var alumnosOracle = myDbContext.UsuarioCursoOracles.Where(o => o.Strm == periodo && o.Sysdate.ToString("dd-MM-yyyy") == fechaActual).ToList();
        //            var alumnosMoodle = myDbContext.UsuarioCursoMoodles.Where(o => o.Strm == periodo && o.Sysdate.ToString("dd-MM-yyyy") == fechaActual).ToList();

        //            foreach (UsuarioCursoOracle usuarioOracle in alumnosOracle)
        //            {
        //                var oMigracion = new Migracion();
        //                var item = alumnosMoodle.Find(x => x.Emplid == usuarioOracle.Emplid);
        //                if (item == null)
        //                {
        //                    oMigracion.TipoMigracion = "Agregar";
        //                    oMigracion.Fecha = DateTime.Now;
        //                    oMigracion.NroMigracion = IdSchedule;
        //                    oMigracion.NroIntento = 0;
        //                    oMigracion.Emplid = usuarioOracle.Emplid;
        //                    oMigracion.Periodo = usuarioOracle.Strm;
        //                    oMigracion.Estado = "Pendiente";
        //                    listaMigracion.Add(oMigracion);
        //                }
        //            }

        //            foreach (UsuarioCursoMoodle usuarioMoodle in alumnosMoodle)
        //            {
        //                var oMigracion = new Migracion();
        //                var item = alumnosOracle.Find(x => x.Emplid == usuarioMoodle.Emplid);
        //                if (item != null)
        //                {
        //                    oMigracion.TipoMigracion = "Quitar";
        //                    oMigracion.Fecha = DateTime.Now;
        //                    oMigracion.NroMigracion = IdSchedule;
        //                    oMigracion.NroIntento = 0;
        //                    oMigracion.Emplid = usuarioMoodle.Emplid;
        //                    oMigracion.Periodo = usuarioMoodle.Strm;
        //                    oMigracion.Estado = "Pendiente";
        //                    listaMigracion.Add(oMigracion);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //No Existen Migraciones - Debe filtrar por periodo
        //            var alumnosOracle = myDbContext.UsuarioCursoOracles.Where(o => o.Strm == periodo).ToList();
        //            var alumnosMoodle = myDbContext.UsuarioCursoMoodles.Where(o => o.Strm == periodo).ToList();

        //            foreach (UsuarioCursoOracle usuarioOracle in alumnosOracle)
        //            {
        //                var oMigracion = new Migracion();
        //                var item = alumnosMoodle.Find(x => x.Emplid == usuarioOracle.Emplid);
        //                if (item == null)
        //                {
        //                    oMigracion.TipoMigracion = "Agregar";
        //                    oMigracion.Fecha = DateTime.Now;
        //                    oMigracion.NroMigracion = IdSchedule;
        //                    oMigracion.NroIntento = 0;
        //                    oMigracion.Emplid = usuarioOracle.Emplid;
        //                    oMigracion.Periodo = usuarioOracle.Strm;
        //                    oMigracion.Estado = "Pendiente";
        //                    listaMigracion.Add(oMigracion);
        //                }
        //            }

        //            foreach (UsuarioCursoMoodle usuarioMoodle in alumnosMoodle)
        //            {
        //                var oMigracion = new Migracion();
        //                var item = alumnosOracle.Find(x => x.Emplid == usuarioMoodle.Emplid);
        //                if (item != null)
        //                {
        //                    oMigracion.TipoMigracion = "Quitar";
        //                    oMigracion.Fecha = DateTime.Now;
        //                    oMigracion.NroMigracion = IdSchedule;
        //                    oMigracion.NroIntento = 0;
        //                    oMigracion.Emplid = usuarioMoodle.Emplid;
        //                    oMigracion.Periodo = usuarioMoodle.Strm;
        //                    oMigracion.Estado = "Pendiente";
        //                    listaMigracion.Add(oMigracion);
        //                }
        //            }

        //        }


        //        //Insertar en la Tabla Migracion
        //        if (listaMigracion.Count > 0)
        //        {
        //            foreach (var entity in listaMigracion)
        //            {
        //                migracionService.AddAsync(entity);
        //            }
        //        }

        //        var listaEnvio = myDbContext.Migraciones.Where(m => m.Estado == "Pendiente" && m.IdMigracion == IdSchedule).ToList();

        //        var rptaMigracion1 = enviarMigraciones(IdSchedule, listaEnvio);
        //        MigracionesCorrectas = rptaMigracion1.correctas;
        //        MigracionesIncorrectas = rptaMigracion1.incorrectas;

        //        var listaEnvioError = myDbContext.Migraciones.Where(m => m.Estado == "Rechazado" && m.IdMigracion == IdSchedule).ToList();
        //        if (listaEnvioError.Count > 0)
        //        {
        //            int intento = 1;
        //            int intentoCorrecto = 0;
        //            do
        //            {
        //                var rptaMigracion2 = enviarMigraciones(IdSchedule, listaEnvio);
        //                intentoCorrecto += rptaMigracion2.correctas;
        //                intento++;
        //            } while (intento < 3);

        //            MigracionesCorrectas += intentoCorrecto;
        //            MigracionesIncorrectas -= intentoCorrecto;                    
        //        }

        //    }

        //    respuesta.correctas = MigracionesCorrectas;
        //    respuesta.incorrectas = MigracionesIncorrectas;
        //    respuesta.respuesta = "Migraciones Correctas: " + respuesta.correctas + ", Migraciones Incorrectas: " + MigracionesIncorrectas;
        //    return respuesta;
        //}

        //public ResponseMigracion enviarMigraciones(int IdSchedule, List<Migracion> listaEnvio)
        //{
        //    ResponseMigracion respuesta = new ResponseMigracion();
        //    int MigracionesCorrectas = 0;
        //    int MigracionesIncorrectas = 0;

        //    if (listaEnvio.Count > 0)
        //    {
        //        List<RequestUsuario> request = new List<RequestUsuario>();
        //        foreach (var entity in listaEnvio)
        //        {
        //            if (!entity.Estado.Equals("Aceptado"))
        //            {
        //                var alumno = myDbContext.Alumnos.Where(a => a.Emplid == entity.Emplid).First();
        //                if (alumno != null)
        //                {
        //                    RequestUsuario req = new RequestUsuario();
        //                    req.Emplid = alumno.Emplid;
        //                    req.Nombre = alumno.Nombre;
        //                    req.ApellidoPaterno = alumno.ApellidoPaterno;
        //                    req.ApellidoMaterno = alumno.ApellidoMaterno;
        //                    req.TipoMigracion = entity.TipoMigracion;

        //                    request.Add(req);

        //                    //Enviar a WS===============================================================

        //                    var response = "";

        //                    Log log = new Log();
        //                    log.IdMigracion = IdSchedule;
        //                    log.Request = Convert.ToString(req);
        //                    log.Response = response;
        //                    log.Fecha = DateTime.Now;
        //                    log.Tipo = entity.TipoMigracion;

        //                    myDbContext.Logs.Add(log);
        //                    myDbContext.SaveChanges();

        //                    if (response.Equals("Ok"))
        //                    {
        //                        MigracionesCorrectas++;
        //                        entity.NroIntento++;
        //                        entity.Estado = "Aceptado";
        //                        myDbContext.Migraciones.Add(entity);
        //                        myDbContext.SaveChanges();
        //                    }
        //                    else
        //                    {
        //                        MigracionesIncorrectas++;
        //                        entity.NroIntento++;
        //                        entity.Estado = "Rechazado";
        //                        myDbContext.Migraciones.Add(entity);
        //                        myDbContext.SaveChanges();
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    respuesta.correctas = MigracionesCorrectas;
        //    respuesta.incorrectas = MigracionesIncorrectas;
        //    return respuesta;
        //}

        public class RequestUsuario
        {
            public int Emplid { get; set; }
            public string Nombre { get; set; }
            public string ApellidoMaterno { get; set; }
            public string ApellidoPaterno { get; set; }
            public string TipoMigracion { get; set; }

        }
        public class ResponseUsuario
        {
            public int respuesta { get; set; }
            public DateTime fecha { get; set; }
        }
        
        public class ResponseMigracion
        {
            public int correctas { get; set; }
            public int incorrectas { get; set; }
            public string respuesta { get; set; }
        }


    }
}
