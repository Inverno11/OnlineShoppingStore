using OnlineShoppingStore.DatabasesModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineShoppingStore.Repository
{
    public class Repository<Tb_Entity> : IRepository<Tb_Entity> where Tb_Entity : class
    {
        DbSet<Tb_Entity> _dbSet;
        dbMyOnlineShoppingEntities _DBEntity;

        public Repository(dbMyOnlineShoppingEntities _DBEntity)
        {
            this._DBEntity = _DBEntity;
            _dbSet = _DBEntity.Set<Tb_Entity>();
        }


        public void Add(Tb_Entity entity)
        {
            _dbSet.Add(entity);
            _DBEntity.SaveChanges();
        }

        public IEnumerable<Tb_Entity> GetAllRecordes()
        {

            return _dbSet.ToList();
        }

        public IQueryable<Tb_Entity> GetAllRecordesIQueryable(Expression<Func<Tb_Entity, bool>> cond )
        {
            return _dbSet.Where(cond); 


        }

        public int GetCountOfRecordes()
        {
            return _dbSet.Count();


        }

        public Tb_Entity GetFirstorDefault(int recordId)
        {
            return _dbSet.Find(recordId);

        }

        public Tb_Entity GetFirstorDefaultByParameter(Expression<Func<Tb_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<Tb_Entity> GetListParameter(Expression<Func<Tb_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).ToList();


        }

        public IEnumerable<Tb_Entity> GetResultBySqlprocedure(string query, params object[] parameters)
        {
            if (parameters != null)
            {
                return _DBEntity.Database.SqlQuery<Tb_Entity>(query, parameters).ToList();
            }
            else
                return _DBEntity.Database.SqlQuery<Tb_Entity>(query).ToList();
        }

        public void InactiveAndDeleteMarkByWhereClause(Expression<Func<Tb_Entity, bool>> wherePredict, Action<Tb_Entity> ForEachPredict)
        {

            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public bool Remove(int id)
        {

            var model = GetFirstorDefault(id);
            if (model != null)

            {
                _dbSet.Remove(model);
               
                return _DBEntity.SaveChanges() > 0 ? true :false ;
            }
            
            else
            {
                return false;

            }

        }

      

       

        public void Update(Tb_Entity entity)
        {
            _dbSet.Attach(entity);
            _DBEntity.Entry(entity).State = EntityState.Modified;
            _DBEntity.SaveChanges();


        }

        public void UpdateByWhereClause(Expression<Func<Tb_Entity, bool>> wherePredict, Action<Tb_Entity> predivt)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(predivt);
           

        }

        public IEnumerable<Tb_Entity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<Tb_Entity, bool>> wherePredict, Expression<Func<Tb_Entity, int>> orderByPredict)
        {
            if (wherePredict != null)
            {
                return _dbSet.OrderBy(orderByPredict).Where(wherePredict).ToList();

            }

            else
            {
                return _dbSet.OrderBy(orderByPredict).ToList();
            }
        }
    }
}