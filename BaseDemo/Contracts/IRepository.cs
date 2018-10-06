﻿using System.Linq;
using BaseDemo.Models;

namespace BaseDemo.Contracts {
    public interface IRepository<T> where T : BaseEntity {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string id);
        T Find(string id);
        void Insert(T t);
        void Update(T t);
    }
}