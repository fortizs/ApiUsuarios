using API.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public class DAUsuarios
    {
        public static List<BEUsuarioERP> ListarUsuariosERP()
        {
            var lista = new List<BEUsuarioERP>();
            string cadenaConexion = "Data Source=CHECO;DataBase=BDApi;Integrated Security=true";
            //string cadenaConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SpListarUsuariosERP", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();

            while (drlector.Read())
            {
                BEUsuarioERP oCategoria = new BEUsuarioERP();
                oCategoria.Id = Convert.ToInt32(drlector["Id"]);
                oCategoria.Usuario = drlector["Usuario"].ToString().Trim(); 
                lista.Add(oCategoria);
            }
            return lista;
        }
    }
}
