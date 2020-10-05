using System;

namespace Interrogacion_1.Model
{
    interface INadeje
    {
        public string Title { get; set; }
        public double? Calificacion { get; set; }
        public double? Calificacion_imdb { get; set; }
        public double? Calificacion_rotten { get; set; }
        public double? Calificacion_metacritics { get; set; }
        public double? Calificacion_usuario { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_de_estreno { get; set; }
        public void Imprimir(Usuario user)
        {
            double? Calificacion_final = null;
            if (Calificacion != null)
            {
                Calificacion_final = Math.Round((double)Calificacion, 2);
            }
            Console.WriteLine($"{Title}\n" +
                $"Calificación Definitiva: {Calificacion_final?.ToString() ?? "n/a"}\n" +
                $"IMDB: {Calificacion_imdb?.ToString() ?? "n/a"}\n" +
                $"Rotten Tomatoes: {Calificacion_rotten?.ToString() ?? "n/a"}\n" +
                $"Metascore: {Calificacion_metacritics?.ToString() ?? "n/a"}\n" +
                $"Mi Calificación: {Calificacion_usuario?.ToString() ?? "n/a"}\n" +
                $"Descripción: {Descripcion}\n" +
                $"Año: {Fecha_de_estreno}");
        }
        public void Recalcular_calificacion(Usuario user)
        {
            Calificacion_usuario = user.Mi_calificacion;
            int contador = 0;
            double? Suma_calificacion_antigua_estandarizada = 0;
            if (Calificacion_imdb != null)
            {
                contador += 1;
                Estandarizar_nota imdb_estandarizacion = new Estandarizar_nota(Calificacion_imdb, 1, 10);
                double? imdb_nota = imdb_estandarizacion.Nota_estandarizada();
                Suma_calificacion_antigua_estandarizada += imdb_nota;
            }
            if (Calificacion_rotten != null)
            {
                contador += 1;
                Estandarizar_nota rotten_estandarizacion = new Estandarizar_nota(Calificacion_rotten, 1, 100);
                double? rotten_nota = rotten_estandarizacion.Nota_estandarizada();
                Suma_calificacion_antigua_estandarizada += rotten_nota;
            }
            if (Calificacion_metacritics != null)
            {
                contador += 1;
                Estandarizar_nota metacritics_estandarizacion = new Estandarizar_nota(Calificacion_metacritics, 1, 100);
                double? metacritics_nota = metacritics_estandarizacion.Nota_estandarizada();
                Suma_calificacion_antigua_estandarizada += metacritics_nota;
            }
            Calificacion = (double)((Suma_calificacion_antigua_estandarizada + user.Nota_estandarizada()) /(contador + 1));
        }
    }
}
