using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Interrogacion_1.Model
{
    class Read_json_file
    {
        // private string path_imdb = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/imdb.json";
        // private string path_metacritic = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/metacritic.json";
        // private string path_rotten = "C:/Users/mmuno/Desktop/Interrogacion_1/Interrogacion_1/rotten.json";
        public static string GetJsonFile(string path)
        {
            string json;
            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }
        public static Movies_imdb DeserializeImdbJsonFile(string imdb)
        {
            Console.WriteLine(imdb);
            var jsonlist = JsonConvert.DeserializeObject<Movies_imdb>(imdb);
            return jsonlist;
        }
        public static Critics_metacritics DeserializeMetacriticJsonFile(string metacritic)
        {
            Console.WriteLine(metacritic);
            var jsonlist = JsonConvert.DeserializeObject<Critics_metacritics>(metacritic);
            return jsonlist;
        }
        public static Critics_rotten DeserializeRottenJsonFile(string rotten)
        {
            Console.WriteLine(rotten);
            var jsonlist = JsonConvert.DeserializeObject<Critics_rotten>(rotten);
            return jsonlist;
        }
    }
}
