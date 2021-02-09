using EmergencyManagementSystem.SAMU.Common.Interfaces;
using EmergencyManagementSystem.SAMU.Common.Interfaces.BLL;
using EmergencyManagementSystem.SAMU.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using X.PagedList;

namespace EmergencyManagementSystem.SAMU.DAL.DAL
{
    public class BaseDAL<TEntity> : IBaseDAL<TEntity> where TEntity : class
    {
        public DbSet<TEntity> Set { get; set; }
        public Context Context { get; set; }
        public BaseDAL(Context context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        public Result Insert(TEntity entity)
        {
            try
            {
                Set.Add(entity);
                return Result.BuildSuccess();
            }
            catch (Exception error)
            {
                return Result.BuildError($"Erro ao adicionar {nameof(TEntity)}", error);
            }
        }

        public Result Update(TEntity entity)
        {
            try
            {
                Set.Update(entity);
                return Result.BuildSuccess();
            }
            catch (Exception error)
            {
                return Result.BuildError($"Erro ao atualizar {nameof(TEntity)}", error);
            }
        }

        public Result Delete(TEntity entity)
        {
            try
            {
                Set.Remove(entity);
                return Result.BuildSuccess();
            }
            catch (Exception error)
            {
                return Result.BuildError($"Erro ao deletar {nameof(TEntity)}", error);
            }
        }

        public Result Save()
        {
            try
            {
                var result = Context.SaveChanges();
                if (result > 0)
                    return Result.BuildSuccess();

                return Result.BuildError("Erro ao salvar o contexto.");
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao salvar o contexto.", error);
            }
        }

        public IPagedList<TModel> FindPaginated<TModel>(IFilter filter,
            Func<IQueryable<TEntity>, IFilter, IQueryable<TModel>> applyFilter)
        {
            return applyFilter(Set.AsQueryable(), filter).ToPagedList(filter.CurrentPage, 10);
        }
    }
}
