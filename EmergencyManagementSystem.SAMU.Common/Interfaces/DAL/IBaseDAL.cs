using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.PagedList;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces
{
    public interface IBaseDAL<TEntity>
    {
        Result Insert(TEntity entity);
        Result Update(TEntity entity);
        Result Delete(TEntity entity);
        Result Save();

        IPagedList<TModel> FindPaginated<TModel>(IFilter filter,
            Func<IQueryable<TEntity>, IFilter, IQueryable<TModel>> applyFilter);
    }
}

