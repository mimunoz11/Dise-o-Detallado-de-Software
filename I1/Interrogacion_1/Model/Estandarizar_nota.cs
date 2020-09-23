using System;
using System.Collections.Generic;
using System.Text;

namespace Interrogacion_1.Model
{
    class Estandarizar_nota
    {
        public double? Nota { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }

        public Estandarizar_nota(double? nota, double? min, double? max)
        {
            Nota = nota;
            Min = min;
            Max = max;
        }
        public double? Nota_estandarizada()
        {
            double? Mi_calificacion_estandarizada = (Nota - Min) / (Max - Min);
            return Mi_calificacion_estandarizada;
        }
    }
}
