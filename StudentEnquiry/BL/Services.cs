using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentEnquiry.BL;
using StudentEnquiry.Models;
using System.Data.Entity;

namespace StudentEnquiry.BL
{
    public class Services<TEntity,Tkey>:IRepository<TEntity,Tkey> where TEntity:class
    {
        StudenquiryDbEntities db;

        public Services(StudenquiryDbEntities db)
        {
            this.db = db;
        }

        public void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            Save();
        }
        public void Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = EntityState.Modified;
            Save();
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> lst = db.Set<TEntity>().ToList();
            return lst;
        }
        public TEntity GetById(Tkey Key)
        {
            TEntity entity = db.Set<TEntity>().Find(Key);
            return entity;
        }
        public void Delete(Tkey key)
        {
            TEntity entity = GetById(key);
            db.Set<TEntity>().Remove(entity);
            Save();
        }
        private void Save()
        {
            db.SaveChanges();
        }
    }
}