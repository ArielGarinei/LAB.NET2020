using System.Collections.Generic;

namespace MVC.Logic
{
    interface InterfaceLogic<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(int entityId);
        void InsertOne(T entity);
        void Update(T entity);
        void DeleteOne(T entity);
        void DeleteAll();
        void Save();
    }
}