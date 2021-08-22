using System.Collections.Generic;

namespace CRUDJogos.Interfaces
{
    public interface IRepositorio<T>
    {
      List<T> GetAll();
      T GetById(int id);
      void Add(T obj);
      void Delete(int id);
      void Update(int id, T obj);
      int NextId();    
    }
}