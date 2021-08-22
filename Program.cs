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
            RemoverJogo();
            break;
          case "3":
            AtualizarJogo();
            break;
          case "4":
            ListarJogos();
            break;
          case "5":
            ListarJogosPorGenero();
            break;
          case "6":
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
3-Atualizar jogo;
4-Listar jogos;
5-Listar jogos por gênero;
6-Visualizar jogo;
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
      Jogo novoJogo = new Jogo(Id: jogoRepo.NextId(),
                              Nome: nomeJogo,
                              Genero: (Genero)generoJogo,
                              DataLançamento: dataLançamentoJogo,
                              Descricao: descricaoJogo);
      jogoRepo.Add(novoJogo);
    }

    private static void ListarJogos()
    {
      Console.WriteLine("Lista dos jogos atuais:");
      foreach (Jogo e in jogoRepo.GetAll())
      {
        if (e.GetStatus() == Status.ATIVO)
        {
          Console.WriteLine("{0}-{1}", e.GetId(), e.GetNome());

        }
      }
      Console.WriteLine("");
    }

    private static void ListarJogosPorGenero()
    {
      int generoJogo;

      Console.WriteLine("Digite o gênero que deseja listar:");
      foreach (int elemento in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", elemento, Enum.GetName(typeof(Genero), elemento));
      }
      generoJogo = int.Parse(Console.ReadLine());
      Console.Clear();
      foreach(Jogo e in jogoRepo.GetByGenre((Genero)generoJogo)){
        if(e.GetStatus() == Status.ATIVO){
          Console.WriteLine("{0}-{1}", e.GetId(), e.GetNome());
        }
      }
      Console.WriteLine("");

    }

    private static void VisualizarJogo()
    {
      int idConsulta;
      Jogo jogoVisualizado;
      Console.WriteLine("Digite o id do jogo:");
      idConsulta = int.Parse(Console.ReadLine());
      Console.Clear();
      jogoVisualizado = jogoRepo.GetById(idConsulta);
      if (jogoVisualizado.GetStatus() == Status.EXCLUIDO)
      {
        Console.WriteLine("Este jogo foi removido da base de dados!");
      }
      else
      {
        Console.WriteLine("Informações do jogo:");

      }
      Console.WriteLine(jogoVisualizado.ToString());

      Console.WriteLine("");
    }
    private static void AtualizarJogo()
    {
      int idJogo;
      string nomeJogo;
      string dataLançamentoJogo;
      string descricaoJogo;
      int generoJogo;

      Console.WriteLine("Digite o id do jogo:");
      idJogo = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite o novo nome do jogo:");
      nomeJogo = Console.ReadLine();
      Console.WriteLine("Digite o novo gênero do jogo:");
      foreach (int elemento in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", elemento, Enum.GetName(typeof(Genero), elemento));
      }
      generoJogo = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite a nova data de lançamento:");
      dataLançamentoJogo = Console.ReadLine();
      Console.WriteLine("Digite a nova descrição do jogo:");
      descricaoJogo = Console.ReadLine();
      Console.Clear();

      Jogo jogoAtualizado = new Jogo(Id: idJogo,
                                    Nome: nomeJogo,
                                    Genero: (Genero)generoJogo,
                                    DataLançamento: dataLançamentoJogo,
                                    Descricao: descricaoJogo);
      jogoRepo.Update(idJogo, jogoAtualizado);

      Console.WriteLine("Dados Atualizados:");
      Console.WriteLine(jogoRepo.GetById(idJogo).ToString());
      Console.WriteLine("");
    }

    private static void RemoverJogo()
    {
      int idJogo;
      Jogo jogoRemovido;
      Console.WriteLine("Digite o id do jogo que deseja remover:");
      idJogo = int.Parse(Console.ReadLine());
      jogoRepo.Delete(idJogo);
      jogoRemovido = jogoRepo.GetById(idJogo);
      Console.WriteLine("O jogo {0} foi removido com sucesso!", jogoRemovido.GetNome());
      Console.WriteLine("");
    }

  }



}
