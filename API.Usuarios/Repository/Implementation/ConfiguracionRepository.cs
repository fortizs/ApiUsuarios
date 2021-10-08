using API.Usuarios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Repository.Implementation
{
    public class ConfiguracionRepository : Repository<Configuracion>, IConfigurationRepository
    {

        public ConfiguracionRepository(MyDBContext myDBContext) : base(myDBContext)
        {
        }

        public async Task<List<Configuracion>> GetAllConfiguracionAsync()
        {
            return await GetAll().ToListAsync();
        }

        //public IQueryable<Configuracion> GetAllCustomersAsync()
        //{
        //    try
        //    {
        //        return context.Set<Configuracion>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Couldn't retrieve entities: {ex.Message}");
        //    }
        //}

        //public async Task<List<Configuracion>> GetAllConfiguracionAsync()
        //{
        //    try
        //    {
        //        return context.Set<Configuracion>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Couldn't retrieve entities: {ex.Message}");
        //    }

           
        //}



        //public IEnumerable<Configuracion> GetConfiguracion()
        //{
        //    return context.Configuraciones.ToList();
        //}

        //public Configuracion GetByPeriodo(string Periodo)
        //{
        //    return context.Configuraciones.Find(Periodo);
        //}


        //#region IDisposable Support
        //private bool disposedValue = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposedValue)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }

        //        disposedValue = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        //#endregion


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
