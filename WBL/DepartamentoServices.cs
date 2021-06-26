using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class DepartamentoServices
    {
        private readonly IDataAcces sql;//genera la propiedad de tipo privada al darle CLT. en _sql

        public DepartamentoServices(IDataAcces _sql)  //variable que hace ref a la interfaz de data acces del proyecto BD
        {
            sql = _sql;
        }

        //Metodos asyncronicos con tareas

        //Metodo para obtener la información

        public async Task<IEnumerable<DepartamentoEntity>> Get()  //IEnumerable representa las listas
        {
            try
            {
                var result = sql.QueryAsync<DepartamentoEntity>("DepartamentoObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DepartamentoEntity> GetById(DepartamentoEntity entity) //trae el detalle del primero objeto del registro q yo seleccione
        {
            try
            {
                var result = sql.QueryFirstAsync<DepartamentoEntity>("DepartamentoObtener", new
                {
                    entity.Id_Departamento

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
            public async Task<DBEntity> Create(DepartamentoEntity entity)//DBEntity maneja las excepciones de errores, Create inserta datos
            {
                try
                {
                    var result = sql.ExecuteAsync("DepartamentoInsertar", new //ExecuteAsync Es un metodo del DataAcces
                    {
                        entity.Descripcion,
                        entity.Ubicacion,
                        entity.Estado
                    });

                    return await result;
                }
                catch (Exception)
                {
                    throw;
                }

            }

        public async Task<DBEntity> Update(DepartamentoEntity entity)//DBEntity maneja las excepciones de errores
        {
            try
            {
                var result = sql.ExecuteAsync("DepartamentoActualizar", new //ExecuteAsync Es un metodo del DataAcces
                {
                    entity.Id_Departamento,//los mismos  parametros del Proc almacenado
                    entity.Descripcion,
                    entity.Ubicacion,
                    entity.Estado
                }
                );

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(DepartamentoEntity entity)//DBEntity maneja las excepciones de errores
        {
            try
            {
                var result = sql.ExecuteAsync("DepartamentoEliminar", new //ExecuteAsync Es un metodo del DataAcces
                {
                    entity.Id_Departamento //los mismos parametros del Proc almacenado
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
