using CBAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBAdmin.Service
{
    public interface IService<T>
    {

        Task<IList<T>> GetEntityListAsynch();
        T GetEntity(String id);

        void WriteEntity(T entity);

        void DeleteEntity(T entity);


    }
}

