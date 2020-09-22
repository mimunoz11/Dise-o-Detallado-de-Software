using System;
using System.Collections.Generic;
using System.Text;

namespace Interrogacion_1.Model
{
    class Usuario
    {
        public double Mi_calificacion { get; set; }
        public double Mi_calificacion_estandarizada { get; set; }

        static public List<INadeje> Repositorios { get; set; }

        public Usuario()
        {
            // Mi_calificacion = Convert.ToDouble(mi_calificacion);
            Repositorios = new List<INadeje> { }; // revisar
        }

        public static void AddINadeje(INadeje inadeje)
        {
            Repositorios.Add(inadeje); // revisar
        }
        public void Evaluar(double mi_calificacion)
        {
            Mi_calificacion = mi_calificacion;
        }
        public double Nota_estandarizada()
        {
            Mi_calificacion_estandarizada = (Mi_calificacion - 1) / (5 - 1);
            return Mi_calificacion_estandarizada;
        }
    }
}
