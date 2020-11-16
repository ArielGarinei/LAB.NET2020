using MVC.ResourceAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Logic
{
    public class Logic<T> : InterfaceLogic<T> where T : class
    {

        private readonly NorthwindContext context;
        private IDbSet<T> dbEntity;
        string url = "https://localhost:44364/api/Products/";
        HttpClient client = new HttpClient();

        public Logic()
        {
            this.context = new NorthwindContext();
            this.dbEntity = context.Set<T>();
        }

        public async Task<string> GetAllApiProductsAsync()
        {
            try
            {
                var httpRespoonse = await client.GetAsync(url);
                if (httpRespoonse.IsSuccessStatusCode)
                {
                    var result = await httpRespoonse.Content.ReadAsStringAsync();
                    return result;
                }
                throw new CustomException("No se pudo Pedir el elemento");
            }
            catch (Exception)
            {

                throw new CustomException("Ocurrio un error inesperado");
            }

        }

        public async Task<string> GetApiProductsAsync(int id)
        {
            try
            {
                var httpRespoonse = await client.GetAsync(url + id.ToString());
                if (httpRespoonse.IsSuccessStatusCode)
                {
                    var result = await httpRespoonse.Content.ReadAsStringAsync();
                    return result;
                }
                throw new CustomException("No se pudo Pedir el elemento");
            }
            catch (Exception)
            {

                throw new CustomException("Ocurrio un error inesperado");
            }

        }


        public async Task<string> PostApiProductsAsync(T entity)
        {
            try
            {
                var data = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var httpRespoonse = await client.PostAsync(url, content);
                if (httpRespoonse.IsSuccessStatusCode)
                {
                    var result = await httpRespoonse.Content.ReadAsStringAsync();
                    return result;
                }
                throw new CustomException("No se pudo Postear el elemento");
            }
            catch (Exception)
            {
                throw new CustomException("Ocurrio un error inesperado");
            }

        }


        public async Task<string> PutApiProductsAsync(T entity, int id)
        {
            try
            {
                var data = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var httpRespoonse = await client.PutAsync(url + id.ToString() , content);
                if (httpRespoonse.IsSuccessStatusCode)
                {
                    var result = await httpRespoonse.Content.ReadAsStringAsync();
                    return result;
                }
                throw new CustomException("No se pudo Postear el elemento");
            }
            catch (Exception)
            {

                throw new CustomException("Ocurrio un error inesperado");
            }

        }
        public async Task<string> DeleteApiProductsAsync(int id)
        {
            try
            {
                var httpRespoonse = await client.DeleteAsync(url + id.ToString());

                if (httpRespoonse.IsSuccessStatusCode)
                {
                    var result = await httpRespoonse.Content.ReadAsStringAsync();
                    return result;
                }
                throw new CustomException("No se pudo eliminar el elemento");
            }
            catch (Exception)
            {
                throw new CustomException("Ocurrio un error inesperado");
            }

        }







        public List<T> GetAll()
        {
            return dbEntity.ToList();
        }

        public T GetOne(int entityId)
        {
            T entity;
            try
            {
                if (entityId <= 0)
                {
                    throw new CustomException("Error al ingresar datos.\nVerifique que el id corresponda a una categoría existente e intente nuevamente.");
                }
                entity = dbEntity.Find(entityId);
                if (entity == null)
                {
                    throw new CustomException("No se encontró el Id indicado.\nVerifique que el id corresponda a una categoría existente e intente nuevamente.");
                }
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
            catch (Exception)
            {
                throw new CustomException("En este momento no podemos buscar esta categoría.\nInténtelo más tarde.");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
            return entity;
        }

        public void InsertOne(T entity)
        {
            try
            {
                dbEntity.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new CustomException("En este momento no podemos guardar esta categoría.\nInténtelo más tarde.");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }

        }

        public void Update(T entity)
        {

           try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new CustomException("En este momento no podemos actualizar esta categoría.\nInténtelo más tarde.");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }

        }

        public void DeleteOne(T entity)
        {
            try
            {
                dbEntity.Remove(entity);
            }
            catch (Exception)
            {
                throw new CustomException("En este momento no podemos eliminar esta Categoría.\nInténtelo más tarde");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
        }

        public void DeleteOne(int id)
        {

            
            try
            {
                if (id <= 0)
                {
                    throw new CustomException("Error al ingresar datos.\nVerifique que el id corresponda a una categoría existente e intente nuevamente.");
                }
                T T = GetOne(id);
                if (T == null)
                {
                    throw new CustomException("No se encontró el Id indicado.\nVerifique que el id corresponda a una categoría existente e intente nuevamente.");
                }
                dbEntity.Remove(T);
                context.SaveChanges();
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
            catch (Exception)
            {
                throw new CustomException("En este momento no podemos eliminar esta Categoróa.\nInténtelo más tarde");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
        }

        public T DeleteOneSafe(int id)
        {
            T T;
            bool flag = false;
            try
            {
                if (id <= 0)
                {
                    throw new CustomException("Error al ingresar datos.\nVerifique que el id corresponda a una categorìa existente e intente nuevamente.");
                }
                T = GetOne(id);
                if (T == null)
                {
                    throw new CustomException("No se encontrí el Id indicado.\nVerifique que el id corresponda a una categoría existente e intente nuevamente.");
                }
                dbEntity.Remove(T);

                context.SaveChanges();
                flag = true;
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
            catch (Exception)
            {
                throw new CustomException("En este momento no podemos eliminar esta Categoría.\nIntentelo mas tarde");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
            finally
            {
                Console.WriteLine(flag ? "Operaciín Finalizada con Éxito" : "Operaciín Fallida");
            }
            return T;
        }

        public void DeleteAll()
        {
            var collection = GetAll();
            foreach (var item in collection)
            {
                try
                {
                    dbEntity.Remove(item);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new CustomException("En este momento no podemos eliminar esta CacnInténeelo mas tarde");
                    //TODO:Guardar excepcion para tener informacion almacenada de errores
                }
            }
        }


        public void Save()
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> InterfaceLogic<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}