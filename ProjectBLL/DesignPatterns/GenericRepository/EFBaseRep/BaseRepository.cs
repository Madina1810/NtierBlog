using DAL.ContextClasses;
using Entities.Enums;
using Entities.Models;
using ProjectBLL.DesignPatterns.GenericRepository.IntRep;
using ProjectBLL.DesignPatterns.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBLL.DesignPatterns.GenericRepository.EFBaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
       protected MyContext _db;
        public BaseRepository()
        {
            _db = DbTool.DbInstance;
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

       protected void Save()
        {
            _db.SaveChanges();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.Status = Entities.Enums.DataStatus.Deleted;
            item.DeletedDate= DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
           _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrderDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);   
          
        }

        public List<T> GetActives()
        {
            return where(x => x.Status != DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();

        }

        public List<T> GetDatas(int count)
        {
            return _db.Set<T>().Take(count).ToList();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _db.Set<T>().OrderBy(x=>x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetLastDatas(int count)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetModifieds()
        {
            return where(x => x.Status == DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return where(x => x.Status == DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();   
        }

        public List<MyModel> SelectVia<MyModel>(Expression<Func<T, MyModel>> exp) where MyModel : class
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void Update(T item)
        {
            item.Status = DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T originalData = Find(item.ID);
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list) Update(item);
        }

        public List<T> where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
