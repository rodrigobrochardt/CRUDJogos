using System;
using CRUDJogos.Enums;

namespace CRUDJogos.Modelos
{
  public class Jogo : EntidadeBase
  {
    private string Nome { get; set; }
    private Genero Genero { get; set; }
    private string DataLançamento { get; set; }
    private string Sinopse { get; set; }

    public Jogo(int Id, string Nome, Genero Genero, string DataLançamento, string Sinopse)
    {
      this.Id = Id;
      this.Nome = Nome;
      this.Genero = Genero;
      this.DataLançamento = DataLançamento;
      this.Sinopse = Sinopse;
    }

    public override string ToString()
    {
      string resultado = $@"
        Nome: {this.Nome}
        Genero: {this.Genero}
        Data de Lançamento: {this.DataLançamento}
        Sinopse: {this.Sinopse}
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

  }


}