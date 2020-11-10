using Lab.Demo.ResourceAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
{
    public class Logic<T> : InterfaceLogic<T> where T : class
    {

        private readonly NorthwindContext context;
        private IDbSet<T> dbEntity;

        public Logic()
        {
            this.context = new NorthwindContext();
            this.dbEntity = context.Set<T>();
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
                if(entity == null)
                {
                    throw new CustomException("No se encontró el Id indicado.\nVerifique que el id corresponda a una categoría existente e intente nuevamente.");
                }
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new CustomException("En este momento no podemos buscar esta categoría.\nInténtelo más tarde.");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
            return entity;
        }

        public void InsertOne(T entity)
        {
            bool flag = false;
            try
            {
                dbEntity.Add(entity);
                context.SaveChanges();
                flag = true;
                
            }
            catch (Exception ex)
            {
                throw new CustomException("En este momento no podemos guardar esta categoría.\nInténtelo más tarde.");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
            finally
            {
                Console.WriteLine(flag ? "Operación Finalizada con éxito" : "Operación Fallida");
            }
            
        }

        public void Update(T entity)
        {

            bool flag = false;
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                flag = true;

            }
            catch (Exception ex)
            {
                throw new CustomException("En este momento no podemos actualizar esta categoría.\nInténtelo más tarde.");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
            finally
            {
                Console.WriteLine(flag ? "Operación Finalizada con éxito" : "Operación Fallida");
            }

        }

        public void DeleteOne(T entity)
        {
            bool flag = false;
            try
            {
                dbEntity.Remove(entity);
                flag = true;
            }
            catch (Exception ex)
            {
                throw new CustomException("En este momento no podemos eliminar esta Categoría.\nInténtelo más tarde");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
            finally
            {
                Console.WriteLine(flag ? "Operación Finalizada con éxito" : "Operación Fallida");
            }
        }

        public void DeleteOne(int id)
        {

            bool flag = false;
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
                flag = true;
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new CustomException("En este momento no podemos eliminar esta Categoróa.\nInténtelo más tarde");
                //TODO:Guardar excepcion para tener informacion almacenada de errores
            }
            finally
            {
                Console.WriteLine(flag ? "Operación Finalizada con éxito" : "Operación Fallida");
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
            catch (Exception ex)
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
            bool flag = false;
            var collection = GetAll();
            foreach (var item in collection)
            {
                try
                {
                    dbEntity.Remove(item);
                    context.SaveChanges();
                    flag = true;
                }
                catch (Exception ex)
                {
                    flag = false;
                    throw new CustomException("En este momento no podemos eliminar esta CacnInténeelo mas tarde");
                    //TODO:Guardar excepcion para tener informacion almacenada de errores
                }
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbEntity.ToList<T>();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
