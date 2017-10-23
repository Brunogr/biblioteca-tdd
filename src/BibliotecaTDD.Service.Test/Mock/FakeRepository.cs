using BibliotecaTDD.Domain.Model.Base;
using LivrariaTDD.Infra.Data.Repository.Base;
using LivrariaTDD.Infra.Data.Repository.Base.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaTDD.Service.Test.Mock
{
    public static class FakeRepository<TModel> where TModel : BaseModel
    {
        public static Mock<TRepository> GetMock<TRepository>() where TRepository : Repository<TModel>, IRepository<TModel>
        {
            var items = new List<TModel>();

            var mock = new Mock<TRepository>();

            mock.Setup(mr => mr.Insert(It.IsAny<TModel>())).Returns(
                (TModel target) =>
                {
                    items.Add(target);
                    return target;
                });

            mock.Setup(mr => mr.Get(It.IsAny<Guid>())).Returns(
                (Guid id) => items.FirstOrDefault(c => c.Id == id));

            mock.Setup(mr => mr.GetAll()).Returns(() => items);

            mock.Setup(mr => mr.GetByFilter(It.IsAny<Func<TModel, bool>>())).Returns(
                (Func<TModel, bool> filter) => items.Where(filter));

            mock.Setup(mr => mr.Update(It.IsAny<TModel>())).Returns(
                (TModel item) =>
                {
                    var itemToUpdate = items.FirstOrDefault(i => i.Id == item.Id);
                    itemToUpdate = item;
                    return itemToUpdate;
                });

            mock.Setup(mr => mr.Delete(It.IsAny<Guid>())).Returns(
                (Guid id) =>
                {
                    var item = items.FirstOrDefault(i => i.Id == id);
                    return items.Remove(item);
                }
            );

            return mock;
        }

        public static Mock<TRepository> GetMock<TRepository>(List<TModel> itemsList) where TRepository : Repository<TModel>, IRepository<TModel>
        {
            var items = itemsList;

            var mock = new Mock<TRepository>();

            mock.Setup(mr => mr.Insert(It.IsAny<TModel>())).Returns(
                (TModel target) =>
                {
                    items.Add(target);
                    return target;
                });

            mock.Setup(mr => mr.Get(It.IsAny<Guid>())).Returns(
                (Guid id) => items.FirstOrDefault(c => c.Id == id));

            mock.Setup(mr => mr.GetAll()).Returns(() => items);

            mock.Setup(mr => mr.GetByFilter(It.IsAny<Func<TModel, bool>>())).Returns(
                (Func<TModel, bool> filter) => items.Where(filter));

            mock.Setup(mr => mr.Update(It.IsAny<TModel>())).Returns(
                (TModel item) =>
                {
                    var itemToUpdate = items.FirstOrDefault(i => i.Id == item.Id);
                    itemToUpdate = item;
                    return itemToUpdate;
                });

            mock.Setup(mr => mr.Delete(It.IsAny<Guid>())).Returns(
                (Guid id) =>
                {
                    var item = items.FirstOrDefault(i => i.Id == id);
                    return items.Remove(item);
                }
            );

            return mock;
        }
    }
}
