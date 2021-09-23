using System;

namespace _02._01
{
    class Program
    {
        static void Main(string[] args)
        {
            string alura = "Alura";
            string caelum = "Caelum";
            string casaDoCodigo = "Casa do código";

            Console.WriteLine(alura);
            Console.WriteLine(caelum);
            Console.WriteLine(casaDoCodigo);

            //Matriz = array

            //1º maneira de construir um array
            //array [] do tipo string com o nome empresas com 3 posições fixas
            //string[] empresas = new string[3];

            //2º maneira de construir um array
            //atribuindo uma variável a uma posição do array
            //empresas[0] = "Alura";
            //empresas[1] = "Caelum";
            //empresas[2] = "Casa do código";

            //3º maneira de construir um array
            //string[] empresas = new string[]
            //{
            //    alura, caelum, casaDoCodigo
            //};

            //4º maneira de construir um array
            string[] empresas = { alura, caelum, casaDoCodigo };
            Imprimir(empresas);

          
            empresas[1] = "Caelum Ensio e Inovação";

            Imprimir(empresas);
            Console.WriteLine("");
            Console.WriteLine("Primeiro elemento: "+empresas[0]);
            Console.WriteLine("Ultimo elemento: "+empresas[empresas.Length - 1]);

            //Localizando o índice da primeira ocorrência no array
            Console.WriteLine("");
            Console.WriteLine("O índice da Casa do Código é: "+ Array.IndexOf(empresas, "Casa do código"));

            //Localizando a ultima ocorrencia no array
            Console.WriteLine("O último índice de ocorrência de Casa do Código é: " + Array.LastIndexOf(empresas, "Casa do código"));

            //revertendo a sequência do Array
            Console.WriteLine("");
            Console.WriteLine("------Invertendo a sequência de um array-------");
            Array.Reverse(empresas);
            Imprimir(empresas);

            //Redimensionando um array (truncando a última posíção)
            Console.WriteLine("");
            Console.WriteLine("-----Redimensionando um array-----");
            Array.Resize(ref empresas, 2);
            Imprimir(empresas);

            //Redimensionando um array (deixando a última posição vazia)
            Array.Resize(ref empresas, 3);
            Imprimir(empresas);

            empresas[empresas.Length - 1] = "Sei lá";

            //Ordenando o Arrya pela ordem natural dos elementos(alfabética)
            Console.WriteLine("----Ordenando em ordem alfabética----");
            Array.Sort(empresas);
            Imprimir(empresas);

            //Copiando um Array em outro
            Console.WriteLine("------Copiando um array em outro array------");
            string[] copia = new string[2];
            //copiando a partir da posição 1
            //2 é quantidade de elementos
            Array.Copy(empresas, 1, copia, 0, 2);
            Imprimir(copia);

            //Clonando um Array em um novo Array
            Console.WriteLine("----Clonando um Array em um novo Array----");
            string[] clone = empresas.Clone() as string[];
            Imprimir(clone);

            //Limpando algunas índices do Array
            //1 é posição do elemento que a limpeza começará
            //e o último parametro é onde a limpeza deve parar
            Console.WriteLine("------Limpando alguns índices do Array------");
            Array.Clear(clone, 1, clone.Length - 1);
            Imprimir(clone);
        }

        //imprimindo cada elemento do array Empresas
        private static void Imprimir(string[] empresas)
        {
            //for (int i = 0; i < empresas.Length; i++)
            //{
            //    string empresa = empresas[i];
            //    Console.WriteLine(empresa);
            //}
            //imprimindo cada elemento do array Empresas
            foreach (var empresa in empresas)
            {
                Console.WriteLine(empresa);
            }
            Console.WriteLine();
        }
    }
}
