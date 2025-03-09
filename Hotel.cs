using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservacionesHotel
{
    using System;
    using System.Collections.Generic;

    public class Hotel
    {
        public Habitacion[,] Habitaciones { get; private set; }
        public List<Cliente> Clientes { get; private set; }
        public Dictionary<int, Reservacion> Reservaciones { get; private set; }

        public Hotel()
        {
            Habitaciones = new Habitacion[5, 10];
            Clientes = new List<Cliente>();
            Reservaciones = new Dictionary<int, Reservacion>();

            int num = 1;
            string[] tipos = { "Sencilla", "Doble", "Suite" };
            double[] precios = { 75, 160, 255 };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Habitaciones[i, j] = new Habitacion(num, tipos[j % 3], precios[j % 3]);
                    num++;
                }
            }
        }

        public void RegistrarCliente(string nombre, string documento, string telefono)
        {
            Clientes.Add(new Cliente(nombre, documento, telefono));
        }

        public List<Habitacion> ObtenerHabitacionesDisponibles()
        {
            List<Habitacion> disponibles = new List<Habitacion>();
            foreach (var habitacion in Habitaciones)
            {
                if (habitacion.Disponible)
                    disponibles.Add(habitacion);
            }
            return disponibles;
        }

        public bool CrearReservacion(string documento, int numeroHabitacion, int noches)
        {
            Cliente cliente = Clientes.Find(c => c.Documento == documento);
            if (cliente == null) return false; // Si el cliente no existe, no se puede reservar.

            foreach (var habitacion in Habitaciones)
            {
                if (habitacion.Numero == numeroHabitacion)
                {
                    if (!habitacion.Disponible) return false; // Si ya está ocupada, error.

                    habitacion.Disponible = false;
                    Reservaciones[numeroHabitacion] = new Reservacion(cliente, habitacion, noches);
                    return true;
                }
            }
            return false; // Si no se encontró la habitación.
        }

        public bool CancelarReservacion(int numeroHabitacion)
        {
            if (Reservaciones.ContainsKey(numeroHabitacion))
            {
                Reservaciones[numeroHabitacion].Habitacion.Disponible = true;
                Reservaciones.Remove(numeroHabitacion);
                return true;
            }
            return false;
        }
    }

}
