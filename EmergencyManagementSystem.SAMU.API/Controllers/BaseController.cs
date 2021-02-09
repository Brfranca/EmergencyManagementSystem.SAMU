using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EmergencyManagementSystem.SAMU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TEntity, TFilter> : ControllerBase 
        where TModel : class
        where TEntity : class
        where TFilter : class
    {
        private readonly IBaseBLL<TModel, TEntity> _baseBLL;

        public BaseController(IBaseBLL<TModel, TEntity> baseBLL)
        {
            _baseBLL = baseBLL;
        }

        [HttpPost("Register")]
        public Result Register(TModel model)
        {
            return _baseBLL.Register(model);
        }

        [HttpPost("Delete")]
        public Result Delete(TModel model)
        {
            return _baseBLL.Delete(model);
        }

        [HttpGet("Find")]
        public Result Find(IFilter filter)
        {
            return _baseBLL.Find(filter);
        }

        [HttpPost("Update")]
        public Result Update(TModel model)
        {
            return _baseBLL.Update(model);
        }

        [HttpPost("FindPaginated")]
        public PaginationModel<TModel> FindPaginated(TFilter filter)
        {
            var result = _baseBLL.FindPaginated((IFilter)filter);
            return new PaginationModel<TModel>(result.ToListAsync().Result, new DataPagination(result.GetMetaData()));
        }

        [HttpPost("Find")]
        public Result<TModel> Find(TFilter filter)
        {
            var result = _baseBLL.Find((IFilter)filter);
            return result;
        }
    }
}
