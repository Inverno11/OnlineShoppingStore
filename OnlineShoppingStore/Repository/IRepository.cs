using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OnlineShoppingStore.Repository
{
    public interface IRepository<Tbl_Entity> where Tbl_Entity : class
    {
        IEnumerable<Tbl_Entity> GetAllRecordes();
        IQueryable<Tbl_Entity> GetAllRecordesIQueryable(Expression<Func<Tbl_Entity, bool>> cond);
        int GetCountOfRecordes();
        void Add(Tbl_Entity entity);
        void Update(Tbl_Entity entity);

        void UpdateByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> predivt);

        Tbl_Entity GetFirstorDefault(int recordId);

        bool Remove(int id);
         void InactiveAndDeleteMarkByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict);
        Tbl_Entity GetFirstorDefaultByParameter(Expression<Func<Tbl_Entity, bool>> wherePredict);
        IEnumerable<Tbl_Entity> GetListParameter(Expression<Func<Tbl_Entity, bool>> wherePredict);

        IEnumerable<Tbl_Entity> GetResultBySqlprocedure(string query, params object[] parameters);



    }
}