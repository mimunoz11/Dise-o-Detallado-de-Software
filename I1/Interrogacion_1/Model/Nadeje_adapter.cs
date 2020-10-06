using System.Linq;

namespace Interrogacion_1.Model
{
    class Nadeje_adapter : INadeje
    {
        private const int V = 1000000000;

        public string Title { get; set; }
        public double? Calificacion { get; set; }
        public double? Calificacion_imdb { get; set; }
        public double? Calificacion_rotten { get; set; }
        public double? Calificacion_metacritics { get; set; }
        public double? Calificacion_usuario { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_de_estreno { get; set; }
        public Nadeje_adapter(string title, Imdb imdb, Metacritic metacritic, Rotten rotten)
        {
            Title = title;
            Calificacion = Calificar(imdb, metacritic, rotten);
            Setear_calificacion_imdb(imdb);
            Setear_calificacion_rotten(rotten);
            Setear_calificacion_metacritics(metacritic);
            Calificacion_usuario = null;
            Descripcion = Asignar_descripcion(imdb, metacritic, rotten);
            Fecha_de_estreno = Asignar_fecha(imdb, metacritic);
        }
        public double Calificar(Imdb imdb, Metacritic metacritics, Rotten rotten)
        {
            int contador = 0;
            double nota = 0;
            if(imdb != null)
            {
                contador += 1;
                nota += Estandarizar(imdb);
            }
            if (metacritics != null)
            {
                contador += 1;
                nota += Estandarizar(metacritics);
            }
            if (rotten != null)
            {
                contador += 1;
                nota += Estandarizar(rotten);
            }
            if (contador == 0)
            {
                return -1;
            }
            return nota/contador;
        }
        public static double Estandarizar(IRepositorios repositorio)
        {
            if (repositorio != null)
            {
                return (double)(repositorio.Calificacion - repositorio.Min) / (repositorio.Max - repositorio.Min); // revisar
            }
            return -1;
        }
        public static string Asignar_descripcion(Imdb imdb, Metacritic metacritics, Rotten rotten)
        {
            int menor = Busco_menor_descripcion(imdb, metacritics, rotten);
            if (imdb != null && imdb.Summary.Length == menor)
            {
                return imdb.Summary;
            }
            else if(rotten != null && rotten.Critics_consensus.Length == menor)
            {
                return rotten.Critics_consensus;
            }
            else if(metacritics != null && metacritics.Details.Summary.Length == menor)
            {
                return metacritics.Details.Summary;
            }
            else
            {
                return "n/a";
            }
        }
        public static int Busco_menor_descripcion(Imdb imdb, Metacritic metacritics, Rotten rotten)
        {
            int largo_descripcion_imdb;
            if (imdb != null)
            {
                largo_descripcion_imdb = imdb.Summary.Length;
            }
            else
            {
                largo_descripcion_imdb = V;
            }
            int largo_descripcion_roten;
            if (rotten != null)
            {
                largo_descripcion_roten = rotten.Critics_consensus.Length;
            }
            else
            {
                largo_descripcion_roten = V;
            }
            int largo_descripcion_metacritics;
            if (metacritics != null)
            {
                largo_descripcion_metacritics = metacritics.Details.Summary.Length;
            }
            else
            {
                largo_descripcion_metacritics = V;
            }
            int[] array_largo_descripciones = new int[] { largo_descripcion_imdb, largo_descripcion_roten, largo_descripcion_metacritics };
            int menor = array_largo_descripciones.Min();
            return menor;
        }
        public static string Asignar_fecha(Imdb imdb, Metacritic metacritics)
        {
            if (imdb != null && imdb.Year != null)
            {
                return imdb.Year.ToString();
            }
            else if (metacritics != null && metacritics.Details.Year != null)
            {
                return metacritics.Details.Year.ToString();
            }
            else
            {
                return null;
            }
        }
        public void Setear_calificacion_imdb(Imdb imdb)
        {
            if (imdb != null)
            {
                Calificacion_imdb = imdb.Calificacion;
            }
            else
            {
                Calificacion_imdb = null;
            }
        }
        public void Setear_calificacion_rotten(Rotten rotten)
        {
            if (rotten != null)
            {
                Calificacion_rotten = rotten.Calificacion;
            }
            else
            {
                Calificacion_rotten = null;
            }
        }
        public void Setear_calificacion_metacritics(Metacritic metacritic)
        {
            if (metacritic != null)
            {
                Calificacion_metacritics = metacritic.Calificacion;
            }
            else
            {
                Calificacion_metacritics = null;
            }
        }
    }
}
