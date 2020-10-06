using Newtonsoft.Json;

namespace Interrogacion_1.Model
{
    class Rotten : IRepositorios
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("critics consensus")]
        public string Critics_consensus { get; set; }
        [JsonProperty("tomatometer")]
        public double? Calificacion { get; set; }
        private double min = 1;
        private double max = 100;
        public double Min { get { return min; } set { min = 1; } }
        public double Max { get { return max; } set { max = 100; } }
    }
}
