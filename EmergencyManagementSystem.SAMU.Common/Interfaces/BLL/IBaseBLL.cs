using EmergencyManagementSystem.SAMU.Common.Models;
using System.Collections.Generic;
using X.PagedList;

namespace EmergencyManagementSystem.SAMU.Common.Interfaces.BLL
{
    public interface IBaseBLL<TModel, TEntity> 
        where TModel : class
        where TEntity : class
    {
        Result<TEntity> Register(TModel model);
        Result Update(TModel model);
        Result Delete(TModel model);
        Result<TModel> Find(IFilter filter);
        PagedList<TModel> FindPaginated(IFilter filter);
        Result<List<TModel>> FindAll(IFilter filter);
    }
}
