using Dapper;
using Dapper.Mapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BD
{
    public class DataAcces : IDataAcces
    {
        private readonly IConfiguration config;

        public DataAcces(IConfiguration _config)//crea la propiedad de la variable que el constructor tiene
        {
            config = _config;
        }

        public SqlConnection DbConnection => new SqlConnection(//Metodo para obtener nuestra coneccion
            new SqlConnectionStringBuilder(config.GetConnectionString("Conn")).ConnectionString

        );

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param = null, int? Timeout = null)//Dentro de la tarea asignamos T es una entidad, va dentro de la tarea

        {
            try
            {
                using (var exec = DbConnection)//Ejecuta la coneccion del metodo DbConnection
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<dynamic>> QueryAsync(string sp, object Param = null, int? Timeout = null)//Dentro de la tarea asignamos dynamic

        {
            try
            {
                using (var exec = DbConnection)//Ejecuta la coneccion del metodo DbConnection
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task<IEnumerable<T>> QueryAsync<T, B>(string sp, object Param = null, int? Timeout = null)//Dentro de la tarea asignamos T es una entidad, va dentro de la tarea

        {
            try
            {
                using (var exec = DbConnection)//Ejecuta la coneccion del metodo DbConnection
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C>(string sp, object Param = null, int? Timeout = null)//Dentro de la tarea asignamos T es una entidad, va dentro de la tarea

        {
            try
            {
                using (var exec = DbConnection)//Ejecuta la coneccion del metodo DbConnection
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D>(string sp, object Param = null, int? Timeout = null)//Dentro de la tarea asignamos T es una entidad, va dentro de la tarea

        {
            try
            {
                using (var exec = DbConnection)//Ejecuta la coneccion del metodo DbConnection
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C, D>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E>(string sp, object Param = null, int? Timeout = null)//Dentro de la tarea asignamos T es una entidad, va dentro de la tarea

        {
            try
            {
                using (var exec = DbConnection)//Ejecuta la coneccion del metodo DbConnection
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C, D, E>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F>(string sp, object Param = null, int? Timeout = null)//Dentro de la tarea asignamos T es una entidad, va dentro de la tarea

        {
            try
            {
                using (var exec = DbConnection)//Ejecuta la coneccion del metodo DbConnection
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C, D, E, F>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F, G>(string sp, object Param = null, int? Timeout = null)//Dentro de la tarea asignamos T es una entidad, va dentro de la tarea

        {
            try
            {
                using (var exec = DbConnection)//Ejecuta la coneccion del metodo DbConnection
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C, D, E, F, G>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    return await result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Metodo para las acciones crut, con este metodo obtengo los detalles de una entidad

        public async Task<T> QueryFirstAsync<T>(string sp, object Param = null, int? Timeout = null)//T entidad Principal
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryFirstOrDefaultAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO Q SE EJECUTA PARA INSERTAR, ACTUALIZAR Y ELIMINAR, DEVUELVE RESULTADOS
        public async Task<DBEntity> ExecuteAsync(string sp, object Param = null, int? Timeout = null)//T entidad Principal
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = await exec.ExecuteReaderAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    await result.ReadAsync();

                    return new()//Retorna los errores

                    {
                        CodError = result.GetInt32(0),
                        MsgError = result.GetString(1)

                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
