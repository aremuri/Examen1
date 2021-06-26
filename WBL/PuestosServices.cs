using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class PuestosServices
    {
        private readonly IDataAcces sql; //propiedad

        public PuestosServices(IDataAcces _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<PuestosEntity>> Get()  //IEnumerable representa las listas
        {
            try
            {
                var result = sql.QueryAsync<PuestosEntity>("PuestosObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PuestosEntity> GetById(PuestosEntity entity) //trae el detalle del primero objeto del registro q yo seleccione
        {
            try
            {
                var result = sql.QueryFirstAsync<PuestosEntity>("PuestosObtener", new
                {
                    entity.Id_Puesto

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Create(PuestosEntity entity)//DBEntity maneja las excepciones de errores, Create inserta datos
        {
            try
            {
                var result = sql.ExecuteAsync("PuestosInsertar", new //ExecuteAsync Es un metodo del DataAcces
                {
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Update(PuestosEntity entity)//DBEntity maneja las excepciones de errores
        {
            try
            {
                var result = sql.ExecuteAsync("PuestosActualizar", new //ExecuteAsync Es un metodo del DataAcces
                {
                    entity.Id_Puesto,//los mismos parametros del Proc almacenado
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(PuestosEntity entity)//DBEntity maneja las excepciones de errores
        {
            try
            {
                var result = sql.ExecuteAsync("PuestosEliminar", new //ExecuteAsync Es un metodo del DataAcces
                {
                    entity.Id_Puesto //los mismos parametros del Proc almacenado
                }
                );

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
