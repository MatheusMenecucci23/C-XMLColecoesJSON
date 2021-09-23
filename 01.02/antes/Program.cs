using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;



namespace _01._02
{
    ///<image url="$(ProjectDir)/img01.png"/>
    ///<image url="$(ProjectDir)/img02.png"/>

    class Program
    {
        static void Main(string[] args)
        {
            //SERIALIZAÇÃO JSON
            var loja = ObterDados();

            //1) usando JavaScriptSerializer
            //serializando 
            Console.WriteLine("1) usando JavaScriptSerializer");
            var javaScriptSerializer = new JavaScriptSerializer();
            var json = javaScriptSerializer.Serialize(loja);
            //pegando os dados no formato json e exibindo na tela
            Console.WriteLine(json);

            //criando nosso arquivo json
            using (var streamWriter = new StreamWriter("Loja.json"))
            {
                //escrevendo os dados json no arquivo Loja
                streamWriter.Write(json);  
            }
            //convertendo um arquivo json para um objeto
            // é preciso fazer a conversão explicita, cast
            var copiaDaLoja = (LojaDeFilmes)javaScriptSerializer.Deserialize(json, typeof(LojaDeFilmes));
            foreach (var filme in copiaDaLoja.Filmes)
            {
                Console.Write(filme.Titulo+" - ");
                Console.WriteLine(filme.Ano);
            }



            //2) usando Json.NET (NewtonSoft)
            Console.WriteLine("2) usando Json.NET (NewtonSoft)");
            json = JsonConvert.SerializeObject(loja);
            Console.WriteLine(json);
            using (var streamWriter = new StreamWriter("Loja.json"))
            {
                //escrevendo os dados json no arquivo Loja
                streamWriter.Write(json);
            }

            //as duas maneiras de serializar são validas
            //copiaDaLoja = (LojaDeFilmes)JsonConvert.DeserializeObject(json);
            copiaDaLoja = JsonConvert.DeserializeObject<LojaDeFilmes>(json);

            foreach (var filme in copiaDaLoja.Filmes)
            {
                Console.WriteLine(filme.Titulo);
            }
            MovieStore movieStore = JsonConvert.DeserializeObject<MovieStore>(json);
            foreach (var movie in movieStore.Movies)
            {
                Console.WriteLine(movie.Title);
            }
            Console.ReadKey();
        }

        private static LojaDeFilmes ObterDados()
        {
            return new LojaDeFilmes
            {
                Diretores = new List<Diretor>
                {
                    new Diretor { Nome = "James Cameron", NumeroFilmes = 5 },
                    new Diretor { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                    new Diretor { Nome = "Zack Snyder", NumeroFilmes = 6 },
                    new Diretor { Nome = "Joss Whedon", NumeroFilmes = 7 },
                    new Diretor { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                    new Diretor { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                    new Diretor { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                    new Diretor { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                    new Diretor { Nome = "Justin Kurzel", NumeroFilmes = 6 }
                },
                Filmes = new List<Filme> {
                    new Filme {
                        Diretor = new Diretor { Nome = "James Cameron", NumeroFilmes = 5 },
                        Titulo = "Avatar",
                        Ano = "2009"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                        Titulo = "I Am Legend",
                        Ano = "2007"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Zack Snyder", NumeroFilmes = 6 },
                        Titulo = "300",
                        Ano = "2006"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Joss Whedon", NumeroFilmes = 7 },
                        Titulo = "The Avengers",
                        Ano = "2012"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                        Titulo = "The Wolf of Wall Street",
                        Ano = "2013"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                        Titulo = "Interstellar",
                        Ano = "2014"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Game of Thrones",
                        Ano = "2011–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Vikings",
                        Ano = "2013–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Gotham",
                        Ano = "2014–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Power",
                        Ano = "2014–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Narcos",
                        Ano = "2015–"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Breaking Bad",
                        Ano = "2008–2013"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                        Titulo = "Doctor Strange",
                        Ano = "2016"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                        Titulo = "Rogue One: A Star Wars Story",
                        Ano = "2016"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "Justin Kurzel", NumeroFilmes = 6 },
                        Titulo = "Assassin's Creed",
                        Ano = "2016"
                    },
                    new Filme {
                        Diretor = new Diretor { Nome = "N/A" },
                        Titulo = "Luke Cage",
                        Ano = "2016–"
                    }
                }
            };
        }
    }
}
