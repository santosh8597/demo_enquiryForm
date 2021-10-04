using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnquiry.BL
{
    interface IRepository<TEntity,Tkey> where TEntity:class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Tkey key);
        List<TEntity> GetAll();
        TEntity GetById(Tkey key);
    }
}
