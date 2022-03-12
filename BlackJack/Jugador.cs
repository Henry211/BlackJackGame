using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Jugador
    {
        //Atributos
        private int Id;
        private string Nombre;
        private string[] Mano;
        private bool Pasar;
        private bool Pedir;
        private int fondos;
        private int apuestaActual;
        int dinero;
        //Constructores
        public Jugador() { }
        public Jugador(int id, string Nombre, string[] Mano) { this.Id = id; this.Nombre = Nombre; this.Mano = Mano; }
        //Metodos
        public void setId(int id) { this.Id = id; }
        public void setNombre(string Nombre) { this.Nombre = Nombre; }
        public void setMano(string[] Mano) { this.Mano = Mano; }
        public int getId() { return Id; }
        public string getNombre() { return Nombre; }
        public string[] getMano() { return Mano; }
    }
}

