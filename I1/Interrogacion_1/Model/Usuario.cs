using System.Collections.Generic;

namespace Interrogacion_1.Model
{
    class Usuario
    {
        public double Mi_calificacion { get; set; }
        public double Mi_calificacion_estandarizada { get; set; }
        static public List<INadeje> Repositorios { get; set; }
        public Usuario()
        {
            Repositorios = new List<INadeje> { };
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
