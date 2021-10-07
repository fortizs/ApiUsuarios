using API.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Repository.Implementation
{
    public class ConfiguracionRepository : IConfigurationRepository,IDisposable
    {
        private MyDBContext context;

        public ConfiguracionRepository(MyDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Configuracion> GetConfiguracion()
        {
            return context.Configuraciones.ToList();
        }

        public Configuracion GetByPeriodo(string Periodo)
        {
            return context.Configuraciones.Find(Periodo);
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


        //IEnumerable<Configuracion> GetConfiguracion();
        //Configuracion GetByPeriodo(string Periodo);
    }
}




//public List<Recursos> GetAllRecursos()
//{
//    return context.Recursos.ToList();
//}

//public Recursos GetRecursoById(int recursoID)
//{
//    return context.Recursos.Find(recursoID);


//public class RecursosRepository : IRecursosRepository, IDisposable
//{
//    private myContext context;

//    public RecursosRepository(myContext context)
//    {
//        this.context = context;
//    }
//    public void DeleteRecurso(int recursoID)
//    {
//        Recursos recurso = context.Recursos.Find(recursoID);
//        context.Recursos.Remove(recurso);
//    }
