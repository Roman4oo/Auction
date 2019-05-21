using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auction.DAL.Operations.Abstract
{
    interface IDALOperations<T> where T : class 
    {
        List<T> GetAll();
        T GetByID(int id);
        void Insert(T item);
        void Delete(int id);
        void Update(T item);


    }
}
