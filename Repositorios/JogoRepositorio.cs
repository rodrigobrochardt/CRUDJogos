using System.Collections.Generic;
using CRUDJogos.Interfaces;
using CRUDJogos.Modelos;

namespace CRUDJogos.Repositorios
{
  public class JogoRepositorio : IRepositorio<Jogo>
  {
    private List<Jogo> listaJogos = new List<Jogo>();
    public void Add(Jogo obj)
    {
      listaJogos.Add(obj);
    }

    public void Delete(int id)
    {
      listaJogos[id].Delete();
    }

    public List<Jogo> GetAll()
    {
      return listaJogos;
    }

    public Jogo GetById(int id)
    {
      return listaJogos[id];
    }

    public int NextId()
    {
      return listaJogos.Count;
    }

    public void Update(int id, Jogo obj)
    {
      listaJogos[id] = obj;
    }
  }
}