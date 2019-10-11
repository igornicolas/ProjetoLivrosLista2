using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista2
{
    public class Program
    {
        
        public static void menu()
        {
            
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|    0.Sair                        |");
            Console.WriteLine("|    1.Adicionar livro             |");
            Console.WriteLine("|    2.Pesquisar livro (sintético) |");
            Console.WriteLine("|    3.Pesquisar livro (analítico) |");
            Console.WriteLine("|    4.Adicionar exemplar          |");
            Console.WriteLine("|    5.Registrar empréstimo        |");
            Console.WriteLine("|    6.Registrar devolução        |");
            Console.WriteLine("-----------------------------------");
        }
        static void Main(string[] args)
        {
            Livros acervoNovo = new Livros();
        int opc = 0;
            
            do
            {
                
                menu();
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.WriteLine(acervoNovo.Acervo.Count()); 
                        Console.WriteLine("Qual o isbnt do livro?");
                        int isbntNovo = int.Parse(Console.ReadLine());
                        for (int i=0; i<acervoNovo.Acervo.Count(); i++)
                        {
                            if (acervoNovo.Acervo[i].Isbnt.Equals(isbntNovo))
                            {
                                Console.WriteLine("ISBNT já cadastrado!");
                                Console.ReadKey();
                                System.Environment.Exit(0);
                            }
                        }
                        
                        Console.WriteLine("Qual o titulo do livro?");
                        string tituloNLivro = Console.ReadLine();
                        Console.WriteLine("Qual o autor do livro?");
                        string autorNLivro = Console.ReadLine();
                        Console.WriteLine("Qual a editora do livro?");
                        string editoraNLivro = Console.ReadLine();

                        acervoNovo.adicionar(new Livro(isbntNovo, tituloNLivro, autorNLivro, editoraNLivro));
                        
                        break;

                    case 2:
                        Console.WriteLine(acervoNovo.Acervo.Count());
                        Console.WriteLine(acervoNovo.Acervo.Last().Isbnt);
                        Console.WriteLine("Qual o isbnt do livro que voce deseja pesquisar?");
                        int isbntPesquisa= int.Parse(Console.ReadLine());
                        
                        Console.WriteLine(acervoNovo.pesquisar(new Livro(isbntPesquisa)).Isbnt); 
                        Livro contatoachado = acervoNovo.pesquisar(new Livro(isbntPesquisa));
                        Console.WriteLine("ISBNT: {0}",contatoachado.Isbnt);
                        Console.WriteLine("Titulo: {0}", contatoachado.Titulo);
                        Console.WriteLine("Autor: {0}", contatoachado.Autor);
                        Console.WriteLine("Editora: {0}", contatoachado.Editora);
                        Console.WriteLine("Quantidade Exemplares: {0}", contatoachado.qtdeExemplares());
                        Console.WriteLine("Quantidade Disponiveis: {0}", contatoachado.qtdeDisponiveis());
                        Console.WriteLine("Porcentagem de disponibilidade: "+ (contatoachado.percDisponibilidade()*100)+"%");


                        break;


                    case 3:
                        Console.WriteLine(acervoNovo.Acervo.Count());
                        Console.WriteLine(acervoNovo.Acervo.Last().Isbnt);
                        Console.WriteLine("Qual o isbnt do livro que voce deseja pesquisar?");
                         isbntPesquisa = int.Parse(Console.ReadLine());

                        Console.WriteLine(acervoNovo.pesquisar(new Livro(isbntPesquisa)).Isbnt);
                         contatoachado = acervoNovo.pesquisar(new Livro(isbntPesquisa));
                        Console.WriteLine("ISBNT: {0}", contatoachado.Isbnt);
                        Console.WriteLine("Titulo: {0}", contatoachado.Titulo);
                        Console.WriteLine("Autor: {0}", contatoachado.Autor);
                        Console.WriteLine("Editora: {0}", contatoachado.Editora);
                        Console.WriteLine("Quantidade Exemplares: {0}", contatoachado.qtdeExemplares());
                        Console.WriteLine("Quantidade Disponiveis: {0}", contatoachado.qtdeDisponiveis());
                        Console.WriteLine("Porcentagem de disponibilidade: " + (contatoachado.percDisponibilidade() * 100) + "%");
                        for (int i=0;i<contatoachado.Exemplares.Count();i++)
                        {
                            Console.WriteLine("Exemplar: "+(i+1));

                            for (int j = 0; j < contatoachado.Exemplares[i].Emprestimos.Count();j++)
                            {
                                Console.WriteLine("Emprestimos:" + contatoachado.Exemplares[i].Emprestimos[j].DtEmprestimo);
                                if (contatoachado.Exemplares[i].Emprestimos[j].DtDevolucao == DateTime.MinValue)
                                {
                                    Console.WriteLine("Ainda nao foi devolvido");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.WriteLine("Devolução:" + contatoachado.Exemplares[i].Emprestimos[j].DtDevolucao);
                            }
                            

                        }



                        break;

                    case 4:
                        Console.WriteLine("Qual o isbnt do livro ?");
                        isbntPesquisa = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o tombo do livro ?");
                        int tomboA = int.Parse(Console.ReadLine());
                        acervoNovo.pesquisar(new Livro(isbntPesquisa)).adicionarExemplar(new Exemplar(tomboA));
                        
                        break;

                    case 5:
                        Console.WriteLine("Qual o isbnt do livro ?");
                        isbntPesquisa = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o tombo do livro ?");
                        tomboA = int.Parse(Console.ReadLine());
                        Exemplar exemplarAchado = new Exemplar();
                        foreach (Exemplar ex in acervoNovo.pesquisar(new Livro(isbntPesquisa)).Exemplares) {
                            int c = 0;
                            if (ex.Tombo.Equals(acervoNovo.pesquisar(new Livro(isbntPesquisa)).Exemplares[c].Tombo))
                            {
                                exemplarAchado = acervoNovo.pesquisar(new Livro(isbntPesquisa)).Exemplares[c];
                            }
                            
                            c++;
                        }
                        Console.WriteLine(exemplarAchado.Tombo);
                        Console.WriteLine(exemplarAchado.Emprestimos.Count());
                        exemplarAchado.emprestar();
                        Console.WriteLine(exemplarAchado.Emprestimos.Last().DtEmprestimo);
                        break;

                    case 6:
                        Console.WriteLine("Qual o isbnt do livro ?");
                        isbntPesquisa = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o tombo do livro ?");
                        tomboA = int.Parse(Console.ReadLine());
                        exemplarAchado = new Exemplar();
                        foreach (Exemplar ex in acervoNovo.pesquisar(new Livro(isbntPesquisa)).Exemplares)
                        {
                            int c = 0;
                            if (ex.Tombo.Equals(acervoNovo.pesquisar(new Livro(isbntPesquisa)).Exemplares[c].Tombo))
                            {
                                exemplarAchado = acervoNovo.pesquisar(new Livro(isbntPesquisa)).Exemplares[c];
                            }

                            c++;
                        }
                        Console.WriteLine(exemplarAchado.Tombo);
                        Console.WriteLine(exemplarAchado.Emprestimos.Count());
                        exemplarAchado.devolver();
                        Console.WriteLine(exemplarAchado.Emprestimos.Last().DtDevolucao);
                        break;
                }
            } while (opc != 0);


                Console.ReadKey();
        }

        
       
    }
}
