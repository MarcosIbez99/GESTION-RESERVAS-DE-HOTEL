using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservacionesHotel
{
    public class Reservacion
    {
        public Cliente Cliente { get; set; }
        public Habitacion Habitacion { get; set; }
        public int Noches { get; set; }
        public double MontoTotal => Noches * Habitacion.PrecioPorNoche;

        public Reservacion(Cliente cliente, Habitacion habitacion, int noches)
        {
            Cliente = cliente;
            Habitacion = habitacion;
            Noches = noches;
        }
    }

}
