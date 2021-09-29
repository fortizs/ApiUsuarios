using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public static class Conexion
    { 
        private static string cConexion = "Data Source=CHECO;DataBase=Northwind;Integrated Security=true";
        public static string CONEXION
        {
            get => cConexion;
        }
    }
}
