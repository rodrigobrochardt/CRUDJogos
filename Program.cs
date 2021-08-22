using System;
using CRUDJogos.Enums;
using CRUDJogos.Modelos;
using CRUDJogos.Repositorios;

namespace CRUDJogos
{
  class Program
  {
    static JogoRepositorio jogoRepo = new JogoRepositorio();

    static void Main(string[] args)
    {
      string opcaoUsuario = OpcoesUsuario(); ;
      while (opcaoUsuario != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            AdicionarJogo();
            break;
          case "2":
            break;
          case "3":
            break;
          case "4":
            ListarJogos();
            break;
          case "5":
            VisualizarJogo();
            break;
          case "L":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();


        }

        opcaoUsuario = OpcoesUsuario();
      }
    }
    private static string OpcoesUsuario()
    {
      Console.WriteLine(@"Escolha uma opção:
1-Adicionar jogo;
2-Remover jogo;
3-Atualizar informações do jogo;
4-Listar jogos;
5-Visualizar jogo;
L-Limpar console;
X-Sair.");
      string escolhaUsuario = Console.ReadLine();
      Console.Clear();
      return escolhaUsuario.ToUpper();
    }

    private static void AdicionarJogo()
    {
      string nomeJogo;
      string dataLançamentoJogo;
      string descricaoJogo;
      int generoJogo;

      Console.WriteLine("Nome do jogo:");
      nomeJogo = Console.ReadLine();
      Console.WriteLine("Gênero do jogo:");
      foreach (int elemento in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", elemento, Enum.GetName(typeof(Genero), elemento));
      }
      generoJogo = int.Parse(Console.ReadLine());
      Console.WriteLine("Data de lançamento:");
      dataLançamentoJogo = Console.ReadLine();
      Console.WriteLine("Descrição do jogo:");
      descricaoJogo = Console.ReadLine();
      Console.Clear();
      Jogo novoJogo = new Jogo(jogoRepo.NextId(), nomeJogo, (Genero)generoJogo,
                              dataLançamentoJogo, descricaoJogo);
      jogoRepo.Add(novoJogo);
    }

    private static void ListarJogos()
    {
      Console.WriteLine("Lista dos jogos atuais:");
      foreach (Jogo e in jogoRepo.GetAll())
      {
        Console.WriteLine("{0}-{1}", e.GetId(), e.GetNome());
      }
      Console.WriteLine("");
    }
    private static void VisualizarJogo()
    {
      int idConsulta;
      Console.WriteLine("Digite o id do jogo:");
      idConsulta = int.Parse(Console.ReadLine());
      Console.WriteLine("Informações do jogo:");
      Console.WriteLine(jogoRepo.GetById(idConsulta).ToString());
      Console.WriteLine("");
    }

  }

}
