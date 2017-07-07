using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BE
{
    public class AlumnoBE
    {
        public int AlumnoKey { get; set; }
        public string Nombres { get; set; }
        public string apellidos { get; set; }
        public decimal Practica1 { get; set; }
        public decimal Practica2 { get; set; }
        public decimal Practica3 { get; set; }
        public decimal Practica4 { get; set; }
        public decimal MenorPractica { get; set; }
        public decimal ExamenParcial{ get; set; }
        public decimal ExamenFinal { get; set; }
        public decimal PromedioPracticas { get; set; }
        public decimal PromedioFinal { get; set; }
        public int Estado { get; set; }
        
    }
}
