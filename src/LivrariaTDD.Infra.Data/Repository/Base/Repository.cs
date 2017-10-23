using LivrariaTDD.Infra.Data.Repository.Base.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaTDD.Infra.Data.Repository.Base
{
    public class Repository<TModel> : IRepository<TModel>
    {
        public virtual bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TModel> GetByFilter(Func<TModel, bool> filter)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Insert(TModel model)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Update(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
