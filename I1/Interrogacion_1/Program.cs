using Interrogacion_1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Interrogacion_1
{
    class Program
    {
        public static string path_imdb = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/imdb.json";
        public static string path_metacritic = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/metacritic.json";
        public static string path_rotten = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/rotten.json";

        static void Main(string[] args)
        {
            Usuario user = new Usuario();
            // inicializar menu con los datos
            Critics_metacritics Criticsmetacritics = Read_json_file.DeserializeMetacriticJsonFile(Read_json_file.GetJsonFile(path_metacritic));
            Critics_rotten Criticsrotten= Read_json_file.DeserializeRottenJsonFile(Read_json_file.GetJsonFile(path_rotten));
            Movies_imdb Moviesimdb = Read_json_file.DeserializeImdbJsonFile(Read_json_file.GetJsonFile(path_imdb));
            // Console.Write(Criticsmetacritics.Critics[0]);
            List<INadeje> sorted_list = Inicializar_match(Read_json_file.DeserializeMetacriticJsonFile(Read_json_file.GetJsonFile(path_metacritic)), Read_json_file.DeserializeRottenJsonFile(Read_json_file.GetJsonFile(path_rotten)), Read_json_file.DeserializeImdbJsonFile(Read_json_file.GetJsonFile(path_imdb)));
            // Console.WriteLine(Read_json_file.DeserializeMetacriticJsonFile(Read_json_file.GetJsonFile(path_metacritic))[0].Name); 
            Console.WriteLine(sorted_list);
            Menu Principal_menu = new Menu(sorted_list, user);
            Principal_menu.Menu_principal();

            // json read
            //var imdb = GetImdbJsonFile();
            //DeserializeImdbJsonFile(imdb);

            //var metacritic = GetMetacriticJsonFile();
            //DeserializeMetacriticJsonFile(metacritic);

            //var rotten = GetRottenJsonFile();
            //DeserializeRottenJsonFile(rotten);
        }
        //public static string GetImdbJsonFile()
        //{
        //    string imdb;
        //    string path = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/imdb.json";
        //    using (var reader = new StreamReader(path))
        //    {
        //        imdb = reader.ReadToEnd();
        //    }
        //    return imdb;
        //}
        //public static Movies_imdb DeserializeImdbJsonFile(string imdb)
        //{
        //    Console.WriteLine(imdb);
        //    var jsonlist = JsonConvert.DeserializeObject<Movies_imdb>(imdb);
        //    return jsonlist;
        //}
        //public static string GetMetacriticJsonFile()
        //{
        //    string metacritic;
        //    string path = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/metacritic.json";
        //    using (var reader = new StreamReader(path))
        //    {
        //        metacritic = reader.ReadToEnd();
        //    }
        //    return metacritic;
        //}
        //public static Critics_metacritics DeserializeMetacriticJsonFile(string metacritic)
        //{
        //    Console.WriteLine(metacritic);
        //    var jsonlist = JsonConvert.DeserializeObject<Critics_metacritics>(metacritic);
        //    return jsonlist;
        //}
        //public static string GetRottenJsonFile()
        //{
        //    string rotten;
        //    string path = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/rotten.json";
        //    using (var reader = new StreamReader(path))
        //    {
        //        rotten = reader.ReadToEnd();
        //    }
        //    return rotten;
        //}
        //public static Critics_rotten DeserializeRottenJsonFile(string rotten)
        //{
        //    Console.WriteLine(rotten);
        //    var jsonlist = JsonConvert.DeserializeObject<Critics_rotten>(rotten);
        //    return jsonlist;
        //}
        public static void Inicializar_json()
        {
            // json read
            var imdb = Read_json_file.GetJsonFile(path_imdb);
            Movies_imdb peliculas_imdb = Read_json_file.DeserializeImdbJsonFile(imdb);

            var metacritic = Read_json_file.GetJsonFile(path_metacritic);
            Critics_metacritics peliculas_metacritic = Read_json_file.DeserializeMetacriticJsonFile(metacritic);

            var rotten = Read_json_file.GetJsonFile(path_rotten);
            Critics_rotten peliculas_rotten = Read_json_file.DeserializeRottenJsonFile(rotten);
            // FALTA RETORNAR LOS OBJETOS

            // Match entre distintos tipos de repositorios
            //Match match = new Match();
            //List<INadeje> peliculas = match.Match_peliculas(peliculas_metacritic, peliculas_rotten, peliculas_imdb);
            //// peliculas.ordenar();
            //List<INadeje> SortedList_peliculas = peliculas.OrderBy(o => o.Calificacion).ToList();
            //// iterar sobre peliculas e imprimir segun orden de calificacion
            //// imprimir pelicula
            // definir user consultarle nota
            //int nota = Convert.ToInt32(Console.ReadLine());
            Usuario user = new Usuario();
            //for (int i = 0; i < SortedList_peliculas.Count; i++)
            //{
            //    SortedList_peliculas[i].Imprimir(user);
            //}
        }
        public static List<INadeje> Inicializar_match(Critics_metacritics peliculas_metacritic, Critics_rotten peliculas_rotten, Movies_imdb peliculas_imdb)
        {
            // json read
            //var imdb = Read_json_file.GetJsonFile(path_imdb);
            //Movies_imdb peliculas_imdb = Read_json_file.DeserializeImdbJsonFile(imdb);

            //var metacritic = Read_json_file.GetJsonFile(path_metacritic);
            //Critics_metacritics peliculas_metacritic = Read_json_file.DeserializeMetacriticJsonFile(metacritic);

            //var rotten = Read_json_file.GetJsonFile(path_rotten);
            //Critics_rotten peliculas_rotten = Read_json_file.DeserializeRottenJsonFile(rotten);

            // Match entre distintos tipos de repositorios
            Match match = new Match();
            List<INadeje> peliculas = match.Match_peliculas(peliculas_metacritic, peliculas_rotten, peliculas_imdb).OrderByDescending(o => o.Calificacion).ToList();
            // peliculas.ordenar();
            // List<INadeje> SortedList_peliculas = peliculas.OrderByDescending(o => o.Calificacion).ToList();
            return peliculas;
        }
    }
}
