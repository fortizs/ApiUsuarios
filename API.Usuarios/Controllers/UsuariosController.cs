using API.BussinessLogic;
using API.Entity;
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
    public class UsuariosController : ControllerBase
    {
        [HttpGet("Listar")]
        public List<BEUsuarioERP> Listar()
        {
            BLUsuarios oUsuarioLogic = new BLUsuarios();
            return oUsuarioLogic.ListarUsuariosERP();
        }
    }
}
