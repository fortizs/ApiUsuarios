using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using API.Usuarios.Models;

namespace API.Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private MyDBContext myDbContext; 
        public UsuariosController(MyDBContext context)
        {
            myDbContext = context;
        }
         
        [HttpGet]
        public IEnumerable<UsuarioCursoOracle> Get()
        {
            return (this.myDbContext.UsuarioCursoOracles.ToList());
        }
        //private readonly Conexion _dbContext;
        //public UsuariosController(Conexion dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    using (_dbContext)
        //    {
        //        var list = _dbContext.UsuarioInfos.ToList();
        //        return Ok(list);
        //    }
        //}

        //private readonly AppDb _dbContext;
        //public UsuariosController(AppDb db)
        //{
        //    _dbContext = db;
        //}



        //public UsuariosController(Conexion dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    using (_dbContext)
        //    {
        //        // var list2 = "ok";
        //        return Ok(_dbContext.UsuarioInfos.ToArray());
        //        //var list = _dbContext.UsuarioInfos.ToList();
        //        //return Ok(list2);
        //    }
        //}


        //[HttpGet]
        //public ActionResult ListarUsuarios()
        //{
        //    return Ok(dbConexion.UsuarioInfos.ToArray());
        //}
        //public List<BEUsuarioERP> Listar()
        //{
        //    BLUsuarios oUsuarioLogic = new BLUsuarios();
        //    return oUsuarioLogic.ListarUsuariosERP();
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    using (dbConexion)
        //    {
        //        var list = dbConexion.UsuarioInfos.ToList();
        //        return Ok(list);
        //    }
        //}
    }
}
