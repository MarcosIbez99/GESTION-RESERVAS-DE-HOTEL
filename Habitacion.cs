using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservacionesHotel
{
    public class Habitacion
    {
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public double PrecioPorNoche { get; set; }
        public bool Disponible { get; set; } = true;

        public Habitacion(int numero, string tipo, double precio)
        {
            Numero = numero;
            Tipo = tipo;
            PrecioPorNoche = precio;
        }
    }

}
