using Newtonsoft.Json;
using System.Collections.Generic;

namespace Interrogacion_1.Model
{
    class Imdb : IRepositorios
    {
        public string Name { get; set; }
        [JsonProperty("rating")]
        public double? Calificacion { get; set; }
        private double min = 1.0;
        private double max = 10.0;
        public double Min { get { return min; } set { min = 1.0; } }
        public double Max { get { return max; } set { max = 10.0; } }
        public int? Year { get; set; }
        public string Genre { get; set; }
        public string Summary { get; set; }
        public string Director { get; set; }
        public string Stars { get; set; }
    }
    class Movies_imdb
    {
        public List<Imdb> Movies { get; set; }
    }
}
