using System;
using System.Collections.Generic;

namespace _02._03
{
    class Program
    {
        static void Main(string[] args)
        {
            var esperanca = new Filme("Episódio IV -Uma nova esperança", 1977);
            var imperio = new Filme("Episódio V -O Império Contra-Ataca", 1980);
            var retorno = new Filme("Episódio VI -O Retorno de Jedi", 1983);
            var ameaca = new Filme("Episódio I: A Ameaça Fantasma", 1999);

            //SETS = CONJUNTOS

            //declarando set/conjuntos de filmes
            //criando uma coleção HashSet
            //HashSet<Filme> filmes = new HashSet<Filme>();
            ISet<Filme> filmes = new HashSet<Filme>();

            //adicionando: esperanca, imperio, retorno
            filmes.Add(esperanca);
            filmes.Add(imperio);
            filmes.Add(retorno);
            Imprimir(filmes);
            //Características do Set (conjunto)
            //1. não permite duplicidade
            filmes.Add(retorno); //não é possível fazer essa inserção
            Imprimir(filmes);

            //2. os elementos não são mantidos em ordem específica
            filmes.Remove(imperio);
            Imprimir(filmes);
            filmes.Add(ameaca); // o elemento é adicionado em qualquer posição
            Imprimir(filmes);

            //3. não permite acesso pelo índice
            //filme[0]

            //qual a vantagem do set sobre a lista? tempo de pesquisa!
            //https ://stackoverflow.com/a/10762995

            //desvantagem: consumo de memória

            //É possível ordenar um conjunto?
            //filmes.Sort() isso não é possível
            //Mas poderamos copiar para uma lista e ordenar
            //copiando para uma lista
            List<Filme> listaFilmes = new List<Filme>(filmes);

            //ordenando copia
            listaFilmes.Sort();

            //imprimindo copia
            Imprimir(listaFilmes);

            //verificando se objeto existe
            Console.WriteLine("O filme uma nova esperanças existe? " + filmes.Contains(esperanca));

            //verificando se objeto com mesmos dados existe
            //precisa-se implementar o método contain e o método compareto da interface IComparable
            var novaEsperanca = new Filme("Episódio IV -Uma nova esperança", 1977);
            Console.WriteLine("O filme uma nova esperanças existe? " + filmes.Contains(novaEsperanca));

        }

        private static void Imprimir(IEnumerable<Filme> filmes)
        {
            foreach (var filme in filmes)
            {
                Console.WriteLine(filme);
            }
            Console.WriteLine();
        }
    }

    public class Filme : IComparable
    {
        public Filme(string titulo, int ano)
        {
            Titulo = titulo;
            Ano = ano;
        }

        public string Titulo { get; set; }
        public int Ano { get; set; }

        public int CompareTo(object obj)
        {
            Filme esta = this;
            Filme outra = obj as Filme;

            if (outra == null)
            {
                return 1;
            }

            return esta.Titulo.CompareTo(outra.Titulo);
        }

        public override string ToString()
        {
            return $"{Titulo} - {Ano}";
        }

        public override bool Equals(object obj)
        {
            Filme outra = obj as Filme;
            if (outra == null)
            {
                return false;
            }
            return outra.Titulo.Equals(this.Titulo) && outra.Ano.Equals(this.Ano);
        }

        //essa método faz o mapeamento entre o objeto e a sua posição
        public override int GetHashCode()
        {
            int hashCode = -131496797;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titulo);
            hashCode = hashCode * -1521134295 + Ano.GetHashCode();
            return hashCode;
        }
    }
}
