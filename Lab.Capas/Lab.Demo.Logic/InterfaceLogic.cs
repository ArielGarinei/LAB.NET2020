using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
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
