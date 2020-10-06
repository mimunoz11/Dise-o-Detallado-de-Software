using Newtonsoft.Json;
using System;

namespace Interrogacion_1.Model
{
    class Metacritic : IRepositorios
    {
        public string Name { get; set; }
        [JsonProperty("metascore")]
        public double? Calificacion { get; set; }
        private double min = 1;
        private double max = 100;
        public double Min { get { return min; } set { min = 1; } }
        public double Max { get { return max; } set { max = 100; } }
        public Detalles Details { get; set; }
    }
    class Detalles
    {
        private int? year;
        public int? Year { get { return year; } set { year = Convert.ToInt32(value); } }
        public string Starring { get; set; }
        public string Summary { get; set; }
    }
}
