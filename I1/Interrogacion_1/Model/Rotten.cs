using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
        //public Rotten(string title, string critics_consensus, double calificacion, double min, double max)
        //{
        //    Title = title;
        //    Critics_consensus = critics_consensus;
        //    Calificacion = calificacion;
        //    Min = min;
        //    Max = max;
        //}
    }
    class Rotten2
    {
        public string Title { get; set; }
        [JsonProperty("critics consensus")]
        public string Criticsconsensus { get; set; }
        public int Tomatometer { get; set; }
    }
    class Critics_rotten
    {
        public List<Rotten> Critics { get; set; }
    }
}
