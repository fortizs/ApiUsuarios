using API.DataAccess;
using API.Entity;
using System.Collections.Generic;

namespace API.BussinessLogic
{
    public class BLUsuarios
    {
        public List<BEUsuarioERP> ListarUsuariosERP()
        {
            return DAUsuarios.ListarUsuariosERP();
        }
    }
}
