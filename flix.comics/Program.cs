using System;
using flix.comics.Enums;
using Classes;
using System.Collections.Generic;

namespace flix.comics
{
    class Program
    {
        /// <summary>
        /// Flix.Comics um respositorio de história em quadrinhos.
        /// Opções de Listar, Adicionar, Atualizar, Excluir
        /// ou Visualizar Histórias em Quadrinho.
        /// </summary>

        static void Main(string[] args)
        {
            ComicsRepositorie repositorie = new ComicsRepositorie();
            short selected = 0;
            do
            {
                try
                {
                    int id;
                    Comics comics;
                    selected = Convert.ToInt16(Options());
                    switch ((Menu)selected)
                    {
                        case Menu.List:
                            ListComics(repositorie.ComicsList());
                            break;
                        case Menu.Insert:
                            Console.WriteLine("\nInserir nova história em quadrinhos");
                            Console.WriteLine("===================================");
                            comics = CreateComics();
                            repositorie.Insert(comics);
                            break;
                        case Menu.Update:
                            Console.WriteLine("\nAtualiza história em quadrinhos");
                            Console.WriteLine("===============================");
                            (id, comics) = UpdateComics(repositorie.ComicsList());
                            repositorie.Update(id, comics);
                            break;
                        case Menu.Exclude:
                            Console.WriteLine("\nExcluir história em quadrinhos");
                            Console.WriteLine("==============================");
                            ExcludeComics(repositorie);
                            break;
                        case Menu.Show:
                            Console.WriteLine("\nVisualizar história em quadrinhos");
                            Console.WriteLine("=================================");
                            ShowComics(repositorie);
                            break;
                        case Menu.Clean:
                            Console.Clear();
                            break;
                        case Menu.Exit:
                            break;
                        default:
                            Console.WriteLine($"Informado: {selected}\nInforme um valor possível do menu!");
                            break;
                    }

                }
                catch(Exception)
                {
                    Console.Clear();
                    Console.WriteLine($"Permitido apenas valores númericos do menu.");
                    selected = 9;
                }
            } while (selected != 0);

            Console.WriteLine("Até uma próxima!");
        }

        static string Options()
        {
            /// <summary>
            /// Menu CLI para trabalhar com o Flix.Comics
            /// </summary>
            
            string selected;

            Console.WriteLine("\n========================================");
            Console.WriteLine("(1) Listar história em quadrinhos");
            Console.WriteLine("(2) Inserir nova história em quadrinhos");
            Console.WriteLine("(3) Atualizar história em quadrinhos");
            Console.WriteLine("(4) Excluir história em quadrinhos");
            Console.WriteLine("(5) Visualizar história em quadrinhos");
            Console.WriteLine("(6) Limpar Tela");
            Console.WriteLine("========================================");
            Console.WriteLine("(0) Sair");
            Console.Write("\nSelecionar: ");
            selected = Console.ReadLine();
           
            return selected;
        }

        static void ListComics(List<Comics> comicsList)
        {
            foreach (Comics comics in comicsList)
            {
                System.Console.WriteLine($"ID: {comics.Id} - Nome: {comics.Name}({comics.Year}), Excluida: {(comics.Excluded ? "Sim." : "Não.")}");
            }
        }

        private static Comics CreateComics()
        {
            Console.Write("Nome do quadrinho: ");
            string name = Console.ReadLine();

            short genre;
            do
            {    
                foreach (int item in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine($"{item} - {Enum.GetName(typeof(Genre), item)}");
                }
                Console.Write("Selecione o Gênero: ");
                genre = Convert.ToInt16(Console.ReadLine());
            } while (genre < 1 || genre > 11);

            Console.Write("Informe o Ano de publicação: ");
            short year = Convert.ToInt16(Console.ReadLine());

            Console.Write("Descrição do exemplar: ");
            string description = Console.ReadLine();

            short status;
            do
            {
                foreach (int item in Enum.GetValues(typeof(Status)))
                {
                    Console.WriteLine($"{item} - {Enum.GetName(typeof(Status), item)}");
                }
                Console.WriteLine("Selecione o Estado de publicação: ");
                status = Convert.ToInt16(Console.ReadLine());
            } while (status < 1 || status > 3);

            Comics comics = new Comics(name, year, (Genre)genre, (Status)status, description);
            return comics;
        }

        static (int, Comics) UpdateComics(List<Comics> comicsList)
        {
            Console.Write("Id da história em quadrinhos: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Comics comics = CreateComics();

            return (id, comics);
        }

        static void ExcludeComics(ComicsRepositorie repositorie)
        {
            Console.Write("Id da história em quadrinhos: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Comics comics = repositorie.Exclude(id);
            Console.WriteLine($"Quadrinho ID: {comics.Id}, Nome: {comics.Name}({comics.Year}) excluido.");
        }

        static void ShowComics(ComicsRepositorie repositorie)
        {
            Console.Write("Id da história em quadrinhos: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Comics comics = repositorie.ReturnById(id);

            Console.WriteLine(comics);
        }
    }
}
