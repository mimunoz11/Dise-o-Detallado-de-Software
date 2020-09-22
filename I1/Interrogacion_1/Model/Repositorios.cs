using System;
using System.Collections.Generic;
using System.Text;

namespace Interrogacion_1.Model
{
    interface IRepositorios
    {
        public double? Calificacion { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
    }
}
