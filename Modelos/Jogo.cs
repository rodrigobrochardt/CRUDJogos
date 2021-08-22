using System;
using CRUDJogos.Enums;

namespace CRUDJogos.Modelos
{
  public class Jogo : EntidadeBase
  {
    private string Nome { get; set; }
    private Genero Genero { get; set; }
    private string DataLançamento { get; set; }
    private string Descricao { get; set; }
    private Status Status{get;set;}

    public Jogo(int Id, string Nome, Genero Genero, string DataLançamento, string Descricao)
    {
      this.Id = Id;
      this.Nome = Nome;
      this.Genero = Genero;
      this.DataLançamento = DataLançamento;
      this.Descricao = Descricao;
      this.Status = Status.ATIVO;
    }

    public override string ToString()
    {
      string resultado = $@"
Nome: {this.Nome}
Genero: {this.Genero}
Data de Lançamento: {this.DataLançamento}
Sinopse: {this.Descricao}
      ";

      return resultado;
    }
    public string GetNome()
    {
      return this.Nome;

    }
    public int GetId()
    {
      return this.Id;

    }
    public Status GetStatus()
    {
      return this.Status;

    }
    public Genero GetGenre()
    {
      return this.Genero;

    }
    public void Delete(){
      this.Status = Status.EXCLUIDO;
    }

  }


}