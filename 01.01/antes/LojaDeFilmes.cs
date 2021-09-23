using System.Collections.Generic;
using System.Xml.Serialization;

namespace _01._01
{
    //atributo para a "tradução" da raiz do arquivo XML para o arquivo de destino MovieStore
    [XmlRoot("MovieStore")]
    
    public class LojaDeFilmes //MovieStore
    {
        [XmlArray("Directors")]
        public List<Diretor> Diretores = new List<Diretor>(); //Directors
        [XmlArray("Movies")]
        public List<Filme> Filmes = new List<Filme>();//Movie
        public static void AdicionarFilme(Filme filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    [XmlType("Director")]
    public class Diretor //Director
    {
        [XmlElement("Name")]
        public string Nome { get; set; }
        [XmlIgnore]
        public int NumeroFilmes;
    }

    [XmlType("Movie")]
    public class Filme //Movie
    {
        [XmlElement("Director")]
        public Diretor Diretor { get; set; }
        [XmlElement("Title")]
        public string Titulo { get; set; }
        [XmlElement("Year")]
        public string Ano { get; set; }
    }
}
