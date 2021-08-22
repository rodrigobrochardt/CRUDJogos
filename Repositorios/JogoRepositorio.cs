using System.Collections.Generic;
using CRUDJogos.Enums;
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

    public List<Jogo>  GetByGenre(Genero genero){
      List<Jogo> listaGenero = new List<Jogo>();
      foreach(Jogo jogo in listaJogos){
        if (jogo.GetGenre() == genero){
          listaGenero.Add(jogo);
        }
      }
      return listaGenero;
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