using EmergencyManagementSystem.SAMU.Common.Interfaces;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace EmergencyManagementSystem.SAMU.BLL.BLL
{
    public abstract class BaseBLL<TModel, TEntity> : IBaseBLL<TModel, TEntity>
        where TModel : class
        where TEntity : class

    {
        private readonly IBaseDAL<TEntity> _baseDAL;

        public BaseBLL(IBaseDAL<TEntity> baseDAL)
        {
            _baseDAL = baseDAL;
        }
        public abstract Result<TEntity> Register(TModel model);
        public abstract Result Update(TModel model);
        public abstract Result Delete(TModel model);
        public abstract Result<TModel> Find(IFilter filter);

        public PagedList<TModel> FindPaginated(IFilter filter)
        {
            var modelPaginated = _baseDAL.FindPaginated(filter, ApplyFilterPagination);
            return (PagedList<TModel>)modelPaginated;
        }

        public abstract IQueryable<TModel> ApplyFilterPagination(IQueryable<TEntity> query, IFilter filter);

        public abstract Result<List<TModel>> FindAll(IFilter filter);
    }
}
