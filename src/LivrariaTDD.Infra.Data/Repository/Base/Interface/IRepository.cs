using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaTDD.Infra.Data.Repository.Base.Interface
{
    public interface IRepository<TModel>
    {
        IEnumerable<TModel> GetAll();
        TModel Get(Guid Id);
        IEnumerable<TModel> GetByFilter(Func<TModel, bool> filter);
        TModel Insert(TModel model);
        TModel Update(TModel model);        
        bool Delete(Guid Id);
    }
}
