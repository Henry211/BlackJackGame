
using System;
using System.Collections.Generic;

namespace BlackJack
{
	public class Mesa
	{
		private List<Carta> cartasMazo = new List<Carta>();
		private List<Carta> cartasJugador = new List<Carta>();
		private List<Carta> cartasContrarios = new List<Carta>();
		int dinero;

		public Mesa()
		{

		}

		public void setMazo(List<Carta> mazo) => this.cartasMazo = mazo;
		public List<Carta> getMazo() => this.cartasMazo;
		public void setCartasJugador(List<Carta> mazo) => this.cartasJugador = mazo;
		public List<Carta> getCartasJugador() => this.cartasJugador;
		public void setCartasContrarios(List<Carta> mazo) => this.cartasContrarios = mazo;
		public List<Carta> getCartasConstrarios() => this.cartasContrarios;
		public void setDinero(int money) { this.dinero = money; }
		public int getDinero() { return this.dinero; }
	}
}