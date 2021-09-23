using System;
using System.Collections.Generic;

namespace _02._05
{
    class Program
    {
        static void Main(string[] args)
        {
            //COLEÇÃO: FILA = QUEUE
            //Regra: primeiro que entra é o primeiro que sai

            //TAREFA: Implementar uma fila de pedágio

            ///<image url="$(ProjectDir)\Slides\queue0.png" scale=""/>

            var pedagio = new Pedagio();

            pedagio.Enfileirar("Van");
            pedagio.Enfileirar("Kombi");
            pedagio.Enfileirar("Guincho");
            pedagio.Enfileirar("Pickup");

            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();
            pedagio.Desenfileirar();

            pedagio.Desenfileirar();
            pedagio.Desenfileirar();


        }

        class Pedagio
        {
            //declarando uma fila
            Queue<string> fila = new Queue<string>();
            public void Enfileirar(string veiculo)
            {
                //adicionando o item na fila
                fila.Enqueue(veiculo);
                Console.WriteLine();
                Console.WriteLine("Entrou na fila: " + veiculo);
                Imprimir(fila);
            }

            private void Imprimir(Queue<string> fila)
            {
                Console.WriteLine();
                Console.WriteLine("Veiculos na fila:");
                Console.WriteLine(string.Join(", ", fila));
                //foreach (var v in fila)
                //{
                //    Console.WriteLine(v);
                //}
            }

            public void Desenfileirar()
            {
                if (fila.Count < 1)
                {
                    Console.WriteLine("A fila está vazia");
                    return;
                }

                Console.WriteLine();

                //.peek pega o próximo elemento da fila
                var proximo = fila.Peek();

                Console.WriteLine($"O veiculo {proximo} está fazendo o pagamento");
                Console.WriteLine();

                //tirando o item da fila
                var veiculo = fila.Dequeue();
                Console.WriteLine(veiculo+" saiu da fila") ;
                Imprimir(fila);

                //tenta fazer o peek com segurança
                Console.WriteLine( );
                fila.TryPeek(out proximo);
                Console.WriteLine("O próximo da fila é: "+ proximo);
            }
        }
    }
}
