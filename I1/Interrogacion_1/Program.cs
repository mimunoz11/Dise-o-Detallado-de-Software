using Interrogacion_1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Interrogacion_1
{
    class Program
    {
        public static string path_imdb = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\imdb.json");
        public static string path_rotten = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\rotten.json");
        public static string path_metacritic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\metacritic.json");

        static void Main()
        {
            Usuario user = new Usuario();
            List<INadeje> lista_ordenada_peliculas = Inicializar_match(Read_json_file.DeserializeMetacriticJsonFile(Read_json_file.GetJsonFile(path_metacritic)), Read_json_file.DeserializeRottenJsonFile(Read_json_file.GetJsonFile(path_rotten)), Read_json_file.DeserializeImdbJsonFile(Read_json_file.GetJsonFile(path_imdb)));
            Menu principal_menu = new Menu(lista_ordenada_peliculas, user);
            principal_menu.Menu_principal();
        }
        public static List<INadeje> Inicializar_match(Critics_metacritics peliculas_metacritic, Critics_rotten peliculas_rotten, Movies_imdb peliculas_imdb)
        {
            Match match = new Match();
            List<INadeje> peliculas = match.Match_peliculas(peliculas_metacritic, peliculas_rotten, peliculas_imdb).OrderByDescending(o => o.Calificacion).ToList();
            return peliculas;
        }
    }
}
