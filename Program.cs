using DIO.Series.Classes;
using System;

namespace DIO.Series
{
    class Program
    {
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                       ListarSeries();
                        break;
                    case "2":
                       InserirSeries();
                        break;
                    case "3":
                       AtualizarSeries();
                        break;
                    case "4":
                       ExcluirSeries();
                        break;
                    case "5":
                       VisualizarSeries();
                        break;
                    case "6":
                        ListarFilmes();
                        break;
                    case "7":
                        InserirFilmes();
                        break;
                    case "8":
                        AtualizarFilmes();
                        break;
                    case "9":
                        ExcluirFilmes();
                        break;
                    case "10":
                        VisualizarFilmes();
                        break;
                    case "C":
                      Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Tem Certeza que Deseja Excluir: (s/n)?");
            char resp = char.Parse(Console.ReadLine());
            if(resp == 's' || resp == 'S')
            {
                repositorio.Excluir(indiceSerie);
            }
            else
            {
                 ObterOpcaoUsuario();
            }
        }


        private static void ExcluirFilmes()
        {
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            Console.WriteLine("Tem Certeza que Deseja Excluir: (s/n)?");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                repositorioFilme.Excluir(indiceFilme);
            }
            else
            {
                ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void VisualizarFilmes()
        {
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Inserir nova Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescrição = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescrição);

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void AtualizarFilmes()
        {
            Console.WriteLine("Inserir novo Filme");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescrição = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescrição);

            repositorioFilme.Atualizar(indiceFilme, atualizaFilme);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar Filmes");

            var lista = repositorioFilme.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Filme cadastrado.");
                return;
            }
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }


        private static  void InserirSeries()
        {
            Console.WriteLine("Inserir nova Série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescrição = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescrição);

            repositorio.Insere(novaSerie);
        }

        private static void InserirFilmes()
        {
            Console.WriteLine("Inserir novo Filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");

            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescrição = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescrição);

            repositorioFilme.Insere(novoFilme);
        }

        private static string ObterOpcaoUsuario()
        {
          
            Console.WriteLine("Informe a opção desejada: (s)Série ou (f)Filme ?");
            char resp = char.Parse(Console.ReadLine());
            if(resp == 's' || resp == 'S')
            {
                Console.WriteLine();
                Console.WriteLine("DIO Séries a seu dispor!!!");
                Console.WriteLine("1- Listar Séries");
                Console.WriteLine("2- Inserir nova Série");
                Console.WriteLine("3- Atualizar Série");
                Console.WriteLine("4- Excluir Série");
                Console.WriteLine("5- Visualizar Série");
                Console.WriteLine("C- Limpar tela");
                Console.WriteLine("X- Sair");

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("DIO Filmes a seu dispor!!!");
                Console.WriteLine("6- Listar Filmes");
                Console.WriteLine("7- Inserir novo Filme");
                Console.WriteLine("8- Atualizar Filme");
                Console.WriteLine("9- Excluir Filme");
                Console.WriteLine("10- Visualizar Filme");
                Console.WriteLine("C- Limpar tela");
                Console.WriteLine("X- Sair");

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }

      

         
        }

    }
}
