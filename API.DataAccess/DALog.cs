using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public class DALog
    {

        public BERetornoTran Guardar(BEBase pEntidad)
        {
            BERetornoTran BERetorno = new BERetornoTran();
            SqlCommand cmd = ConexionCmd("gen.LogGuardar");
            BE

            cmd = LlenarEstructura(pEntidad, cmd, "I");
            try
            {


                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                BERetorno.Retorno = Convert.ToString(cmd.Parameters["ReturnValue"].Value);
                BERetorno.ErrorMensaje = Convert.ToString(cmd.Parameters["@ErrorMensaje"].Value);
            }
            catch (Exception ex)
            {
                BERetorno.ErrorMensaje = ex.ToString();
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return BERetorno;
        }
    }
}
