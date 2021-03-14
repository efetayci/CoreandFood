using CoreandFood.Data;
using CoreandFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Repositories
{
    public class GenericRepository<T> where T:class,new()
    {
        Context C = new Context();
        public List<T> TList()
        {
            return C.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            C.Set<T>().Add(p);
            C.SaveChanges();
        }
        public void TDelete(T p)
        {
            C.Set<T>().Remove(p);
            C.SaveChanges();
        }
        public void TUpdate(T p)
        {
            C.Set<T>().Update(p);
            C.SaveChanges();
        }
        public T TGet(int id)
        {
            return C.Set<T>().Find(id);
        }
        public List<T> TList(string p)
        {
            return C.Set<T>().Include(p).ToList();
        }
    }
}
