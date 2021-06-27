using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ITituloServices
    {
        Task<DBEntity> Create(TitulosEntity entity);
        Task<DBEntity> Delete(TitulosEntity entity);
        Task<IEnumerable<TitulosEntity>> Get();
        Task<TitulosEntity> GetById(TitulosEntity entity);
        Task<DBEntity> Update(TitulosEntity entity);
    }

    public class TituloServices : ITituloServices
    {
        private readonly IDataAcces sql;

        public TituloServices(IDataAcces _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<TitulosEntity>> Get()  //IEnumerable representa las listas
        {
            try
            {
                var result = sql.QueryAsync<TitulosEntity>("TitulosObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TitulosEntity> GetById(TitulosEntity entity) //trae el detalle del primero objeto del registro q yo seleccione, por eso no uso el IEnumerable y si recibe parametros
        {
            try
            {
                var result = sql.QueryFirstAsync<TitulosEntity>("TitulosObtener", new //Primer objeto q yo seleccione
                {
                    entity.Id_Titulo

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Create(TitulosEntity entity)//DBEntity maneja las excepciones de errores, Create inserta datos
        {
            try
            {
                var result = sql.ExecuteAsync("TitulosInsertar", new //ExecuteAsync Es un metodo del DataAcces
                {
                    entity.Descripcion,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Update(TitulosEntity entity)//DBEntity maneja las excepciones de errores
        {
            try
            {
                var result = sql.ExecuteAsync("TitulosActualizar", new //ExecuteAsync Es un metodo del DataAcces
                {
                    entity.Id_Titulo,//los mismos  parametros del Proc almacenado
                    entity.Descripcion,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(TitulosEntity entity)//DBEntity maneja las excepciones de errores
        {
            try
            {
                var result = sql.ExecuteAsync("TitulosEliminar", new //ExecuteAsync Es un metodo del DataAcces
                {
                    entity.Id_Titulo //los mismos parametros del Proc almacenado
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
