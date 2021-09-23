using System;
using System.Collections.Generic;

namespace _02._04
{
    class Program
    {
        static void Main(string[] args)
        {
            var esperanca = new Filme("Episódio IV -Uma nova esperança", 1977);
            var imperio = new Filme("Episódio V -O Império Contra-Ataca", 1980);
            var retorno = new Filme("Episódio VI -O Retorno de Jedi", 1983);
            var ameaca = new Filme("Episódio I: A Ameaça Fantasma", 1999);

            //CRIANDO UM DICIONÁRIO
            //passando o valor da chave - no caso int - , e o tipo de valor que será guardado - no caso filme -
            Dictionary<int, Filme> filmes = new Dictionary<int, Filme>();

            //ADICIONANDO elementos NO DICIONÁRIO
            //add(chave, variável)
            filmes.Add(34672, esperanca);
            filmes.Add(5617, imperio);
            filmes.Add(17645, retorno);

            //Imprimindo os filmes
            foreach (var filme in filmes)
            {
                Console.WriteLine(filme);
            }

            //Imprimindo as chaves
            foreach (var filme in filmes)
            {
                Console.WriteLine(filme.Key);
            }

            //imprimindo somente os valores;
            foreach (var filme in filmes)
            {
                Console.WriteLine(filme.Value);
            }

            //Imprimendo as chaves
            foreach (var chave in filmes.Keys)
            {
                Console.WriteLine(chave);
            }

            //imprimindo somente os valores;
            foreach (var valor in filmes.Values)
            {
                Console.WriteLine(valor);
            }

            //Pesquisando um elemento no dicionário pelo ID - no caso 34672 -
            Console.WriteLine("Qual é o filme com ID 34672" + filmes[34672]);

            //e se tentarmos adicionar outro filme com a mesa chave
            //filmes.Add(34672, ameaca); não é possível

            //e se quisermos troca o filme que tem a mesma chave? é possível
            filmes[34672] = ameaca;

            //qual é o filme 34672 agora? ameaca
            Console.WriteLine("Qual é o filme 34672 agora? "+ filmes[34672]);

            //buscando uma chave que não existe: 34673
            //estoura um erro e aplicação para de funcionar
            //Console.WriteLine("Buscando uma chave que não existe: 34673" + filmes[34673]);

            //verificando se a chave 34673 existe
            Console.WriteLine("Verificando se a chave 34673 existe "+ filmes.ContainsKey(34673));

            //buscando uma chave 34673 de forma segura e lançando uma aviso na tela
            //buscando o id e gerando um "retorno/saída" com out que pode ser usada
            filmes.TryGetValue(34673, out Filme filme34673);
            if (filme34673 == null)
            {
                Console.WriteLine("Filme com a chave 34673 não existe");
            }

        }
        //implementou a interface IComparable
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

                return outra.Titulo.Equals(this.Titulo)
                    && outra.Ano.Equals(this.Ano);
            }

            public override int GetHashCode()
            {
                var hashCode = -131496797;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titulo);
                hashCode = hashCode * -1521134295 + Ano.GetHashCode();
                return hashCode;
            }
        }
    }
}