using System;
using System.Collections.Generic;

namespace _02._02
{
    class Program
    {
        //CRONOLOGIA É A LSIAT ORIGINAL
        //Cronologia Star Wars
        //=========================================
        //Episódio I: A Ameaça Fantasma         1999
        //Episódio II: Ataque dos Clones        2002
        //A Guerra dos Clones                   2003
        //Episódio III: A Vingança dos Sith     2005
        //Rebels                                2014
        //Rogue One                             2016
        //Episódio IV -Uma nova esperança       1977
        //Episódio V -O Império Contra-Ataca    1980
        //Episódio VI -O Retorno de Jedi        1983
        //Episódio VII -O Despertar da Força    2015
        //Episódio VIII: Os Últimos Jedi        2017
        static void Main(string[] args)
        {
            //TAREFA PRINCIPAL
            //=================
            //colocar os filmes abaixo na ordem cronológica
            var esperanca = new Filme("Episódio IV -Uma nova esperança", 1977);
            var imperio = new Filme("Episódio V -O Império Contra-Ataca", 1980);
            var retorno = new Filme("Episódio VI -O Retorno de Jedi", 1983);
            var ameaca = new Filme("Episódio I: A Ameaça Fantasma", 1999);
            var ataque = new Filme("Episódio II: Ataque dos Clones", 2002);
            var guerraClones = new Filme("A Guerra dos Clones", 2003);
            var vinganca = new Filme("Episódio III: A Vingança dos Sith", 2005);
            var rebels = new Filme("Rebels", 2014);
            var despertar = new Filme("Episódio VII -O Despertar da Força", 2015);
            var rogue = new Filme("Rogue One", 2016);
            var ultimo = new Filme("Episódio VIII: Os Últimos Jedi", 2017);

            ///TAREFA: criar uma coleção vazia, que irá crescer aos poucos
            //Lista do tipo Filme
            List<Filme> cronologia = new List<Filme>();

            ///TAREFA: checar a capacidade da lista
            Console.WriteLine("Tamanho da Lista: " + cronologia.Count);
            Console.WriteLine("Capacidade da lista " + cronologia.Capacity);

            ///TAREFA: adicionar o filme "Episódio IV -Uma nova esperança"
            cronologia.Add(esperanca);

            ///TAREFA: checar novamente a capacidade da lista
            Console.WriteLine("Tamanho da Lista: " + cronologia.Count);
            Console.WriteLine("Capacidade da lista " + cronologia.Capacity);

            ///TAREFA: Adicionar no final: Império Contra Ataca e Retorno de Jedi
            //cronologia.Add(imperio);
            //cronologia.Add(retorno);
            cronologia.AddRange(new List<Filme> { imperio, retorno });

            ///TAREFA: Declarar a lista com inicialização simplificada
            cronologia = new List<Filme> { esperanca, imperio, retorno };

            ///TAREFA: checar novamente a capacidade da lista
            Console.WriteLine("Capacidade da lista " + cronologia.Capacity);
            
            ///TAREFA: imprimir a cronologia
            Imprimir(cronologia);

            ///TAREFA: inserir Ameaça Fantasma no início da cronologia
            ///adicionando a ameaca no inicio da lista
            Console.WriteLine("---Inserindo o filme no ínicio da lista---");
            cronologia.Insert(0, ameaca);
            Imprimir(cronologia);

            ///TAREFA: Inserir na segunda posição: Ataque dos Clones, Guerra dos Clone, Vingança dos Sith
            var novoFilmes = new [] { ataque, guerraClones, vinganca, rebels };
            cronologia.InsertRange(1, novoFilmes);
            Imprimir(cronologia);

            ///TAREFA: adicionar Despertar da Força no fim da cronologia
            cronologia.Add(despertar);
            Imprimir(cronologia);

            ///TAREFA: checar novamente a capacidade da lista
            Console.WriteLine("Tamanho da Lista: " + cronologia.Count);
            Console.WriteLine("Capacidade da lista " + cronologia.Capacity);

            ///TAREFA: inserir Rogue One antes de Uma Nova Esperança
            ///Descobrindo o índice de um elemento com indexof
            var indice = cronologia.IndexOf(esperanca);
            cronologia.Insert(indice, rogue);
            Imprimir(cronologia);

            ///TAREFA: adicionar O Último Jedi ao final da cronologia
            cronologia.Add(ultimo);
            Imprimir(cronologia);

            ///TAREFA: exibir a cronologia inversa
            Console.WriteLine("---INVERTENDO A ORDEM---");
            cronologia.Reverse();
            Imprimir(cronologia);

            ///TAREFA: voltar a cronologia à ordem original
            cronologia.Reverse();
            Console.WriteLine(cronologia);

            ///TAREFA: obter lista de filmes só com atores (sem rebels e guerra dos clones)
            var FilmesComAtores = new List<Filme>(cronologia);

            var indiceRebels = FilmesComAtores.IndexOf(rebels);
            FilmesComAtores.RemoveAt(indiceRebels);
            Imprimir(FilmesComAtores);

            FilmesComAtores.Remove(guerraClones);
            Imprimir(FilmesComAtores);

            ///TAREFA: obter trilogia original (filmes lançados até 1983)
            var trilogiaOriginal = new List<Filme>(cronologia);
            //RemoveAll verifica se cada item da lista será removido ou não de acordo com a condição
            trilogiaOriginal.RemoveAll((item) => item.Ano > 1983) ;
            Imprimir(trilogiaOriginal);

            ///TAREFA: exibir filmes em ordem alfabética
            //para ordenar é preciso implementar a interface IComparable no tipo da lista
            Console.WriteLine("---Lista em ordem alfabética---");
            var ordemAlfabetica = new List<Filme>(FilmesComAtores);
            ordemAlfabetica.Sort();
            Imprimir(ordemAlfabetica);


            ///TAREFA: exibir filmes em ordem de lançamento
            Console.WriteLine("---Lista em ordem de lançamento---");
            var ordemLançamento = new List<Filme>(FilmesComAtores);
            //fazendo com que a lista seja ordenada pela ordem cronológica - anos -
            ordemLançamento.Sort((item1, item2) => item1.Ano.CompareTo(item2.Ano));
            Imprimir(ordemLançamento);

            ///TAREFA: exibir filmes da trilogia inicial (posições 3, 4 e 5)
            //copiando a lista ordemLançamento para o array trilogia Inicial
            var trilogiaInicial = new Filme[3];
            ordemLançamento.CopyTo(3,trilogiaInicial, 0, 3);
            Imprimir(trilogiaInicial);

            ///TAREFA: exibir primeiro filme da cronologia

            ///TAREFA: exibir último filme da cronologia

        }

        private static void Imprimir(IEnumerable<Filme> lista)
        {
            foreach (var filme in lista)
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

        //Ao implementar a classe, é preciso implementar o método CompareTO
        //criando a nosssa regra de ordenação
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
    }
}
