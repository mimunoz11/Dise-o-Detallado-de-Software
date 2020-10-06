using Newtonsoft.Json;
using System.IO;

namespace Interrogacion_1.Model
{
    class Read_json_file
    {
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
            var jsonlist = JsonConvert.DeserializeObject<Movies_imdb>(imdb);
            return jsonlist;
        }
        public static Critics_metacritics DeserializeMetacriticJsonFile(string metacritic)
        {
            var jsonlist = JsonConvert.DeserializeObject<Critics_metacritics>(metacritic);
            return jsonlist;
        }
        public static Critics_rotten DeserializeRottenJsonFile(string rotten)
        {
            var jsonlist = JsonConvert.DeserializeObject<Critics_rotten>(rotten);
            return jsonlist;
        }
    }
}
