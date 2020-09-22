using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
            Console.WriteLine($"{Title}\n" +
                $"Calificación Definitiva: {Calificacion}\n" +
                $"IMDB: {Calificacion_imdb}\n" +
                $"Rotten Tomatoes: {Calificacion_rotten}\n" +
                $"Metascore: {Calificacion_metacritics}\n" +
                $"Mi Calificación: {Calificacion_usuario}\n" + //cambiar enfoque que pelicula guarde la calificacion además del usuario
                $"Descripción: {Descripcion}\n" +
                $"Año: {Fecha_de_estreno}");
        }
        public void Recalcular_calificacion(Usuario user)
        {
            Calificacion_usuario = user.Mi_calificacion;
            int contador = 0;
            if (Calificacion_imdb != null)
            {
                contador += 1;
            }
            if (Calificacion_rotten != null)
            {
                contador += 1;
            }
            if (Calificacion_metacritics != null)
            {
                contador += 1;
            }
            Calificacion = (double)((Calificacion * (contador) + user.Nota_estandarizada()) /(contador + 1));
        }
    }
}
