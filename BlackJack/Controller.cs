using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using BlackJack;

namespace BlackJack
{
    class Controller
    {
        string[] deck = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        bool juegoEnCurso;
		bool turnoDelJugador;
		bool win, lose;

		BitmapImage backImg = new BitmapImage(new Uri("/Recursos/Back.png", UriKind.Relative));

		string[] imgNames = { "ClubsA","Clubs2","Clubs3","Clubs4","Clubs5","Clubs6","Clubs7","Clubs8","Clubs9","Clubs10","ClubsJ","ClubsQ","ClubsK","DiamondsA","Diamonds2","Diamonds3","Diamonds4","Diamonds5","Diamonds6","Diamonds7","Diamonds8","Diamonds9","Diamonds10","DiamondsJ","DiamondsQ","DiamondsK","HeartsA","Hearts2","Hearts3","Hearts4","Hearts5","Hearts6","Hearts7","Hearts8","Hearts9","Hearts10","HeartsJ","HeartsQ","HeartsK","SpadesA","Spades2","Spades3","Spades4","Spades5","Spades6","Spades7","Spades8","Spades9","Spades10","SpadesJ","SpadesQ","SpadesK"};
		//BitmapImage[] imageCards;
		private List<Carta> mazo = new List<Carta>(52);
		private List<Carta> P1_Cartas = new List<Carta>();
		private List<Jugador> jugadores = new List<Jugador>();
		private int P1_ValueOf_Cards;
		//BitmapImage image = new BitmapImage();
		private List<BitmapImage> imageCards = new List<BitmapImage>();

		double dineroApostado;
		double dineroTotal;
		int cards = 52; //la cantidad de cartas existentes en el mazo
		int playerIndex; //la cantidad de cartas del jugador
		bool primeraVez = true, pedir = true, pasar = true, registro = true, gameBucle = true;


		Mesa mesa = new Mesa();

		public void setMesa(Mesa mesa) => this.mesa = mesa;
		public Mesa getMesa() => this.mesa;



		public Controller()
        {
			
			//funcarListas(imageCards);
			//var gameThread = new Thread(this.iniciarJuego);
			//gameThread.Start();
			Thread t = new Thread(new ThreadStart(() => iniciarJuego("Henry", 01)));
			t.Start();

			ordenarListas();
            generarMazo();	//	AQUÍ se inicializan los mazos
			//repartirPrimerasCartas();

			//iniciarJuego(juegoEnCurso);
		
        }

		

		private void iniciarJuego(string nombre, int id)
        {
			while (true)
			{

				if (registro)
				{
					Jugador jugador = new Jugador(id, nombre, deck);
					//registro(jugador);
					aJugar();
				}
				if (gameBucle)
				{
					aJugar();
					//	...
				}

			}
        }

		private void aJugar()
		{
			if (primeraVez == true)
			{
				//repartirPrimerasCartas();
				primeraVez = false;
			}
			if (turnoDelJugador)
			{
				Console.WriteLine("\nQué le gustaría hacer?\n1.Pedir\n2.Pasar");
				
				if (pedir)
				{
					makeHit();
				}
				if (pasar)
				{
					makeStay();
				}
			}
		}


		public List<Carta> getMazo()
        {
			return this.mazo;
        }
		public List<Carta> getP1_Cartas()
		{
			return this.P1_Cartas;
		}

		public void repartirPrimerasCartas()
        {		//ERROR EN: 'mazo'
			for (int i = 0; i < 3; i++)
            {
				Carta auxCard = new Carta();	
				//auxCard = mazo[i];          // el índice del 'mazo' debería ser 'cards' ,  pero da error
				auxCard = mazo.ElementAt(cards);
				this.P1_Cartas.Insert(i,auxCard);
				//this.P1_Cartas.Add(mazo[cards]);			//	OTRA FORMA

				int auxInt = auxCard.getNumero();
				this.P1_ValueOf_Cards += auxInt;
				cards--;// (las cartas son 52, conforme se van usando, se va restando el índice)
			}
			
			if (P1_ValueOf_Cards == 21) //EVALUAR si pegó 21 a la primera
			{
				juegoEnCurso = false;
				dineroApostado = dineroApostado * 1.5;
			}
			this.mesa.setCartasJugador(P1_Cartas);
		}

        public void generarMazo()
        {
            for(int i = 0;i < 52; i++)
            {
				//this.mazo.Insert(i,new Carta(deck[i],getValueOf(deck,i),true,imageCards[i]));
				//this.mazo.Add(new Carta(deck[i], getValueOf(deck, i), true, imageCards[i]));
				this.mazo.Add(new Carta(deck[i], getValueOf(deck, i), true, imageCards[i])); //-----Debería ser la carta en vez de null-----

				this.P1_Cartas.Add(new Carta());
            }
			this.mesa.setMazo(this.mazo);
			
			//this.mesa.setCartasContrarios(Ps_contrarios);
			
        }

		public void ordenarListas()
        {
			for (int i = 0; i < 52; i++)
            {
				BitmapImage image = new BitmapImage(new Uri("/Recursos/"+ imgNames[i].ToString() + ".png", UriKind.Relative));
				//BitmapImage imagen = new BitmapImage(new Uri("/Back.png", UriKind.Relative));
				
				imageCards.Add(image);
            }

		}

		public void makeHit()
        {
			// SI la carta que sacó es 'As' (11) y el mazo supera los 21-- convertirlo en '1'
			if (mazo[cards].getNumero() == 11 && P1_ValueOf_Cards + mazo[cards].getNumero() > 21)
            {
				playerIndex++;//	incrementa la cantidad de cartas de jugador
				mazo[cards].setUnoToAs();//	asigna a la carta 'As' el valor de '1'
				P1_Cartas.Insert(playerIndex,mazo[cards]);//	asigna la carta al mazo del jugador
				P1_ValueOf_Cards += mazo[cards].getNumero();// suma el valor de la carta al valor total del jugador
				cards--;//	retira una unidad en el indice de cartas del mazo
            }
            else//	si no es 'As'
            {
				playerIndex++;
				P1_Cartas.Insert(playerIndex,mazo[cards]);
				P1_ValueOf_Cards += mazo[cards].getNumero();
				cards--;
            }
			//	si el jugador ha sobrepasado los '21'
			if(P1_ValueOf_Cards > 21)
            {
				//	revisar si tiene algún 'As' con valor 11 ---	retorna el índice de la carta As
 				int indexOfAs = checkForAce(P1_Cartas);
				if(P1_Cartas[indexOfAs].getSigno() == "A")
                {
					P1_Cartas[indexOfAs].setNumero(1);
					P1_ValueOf_Cards -= 10;
                }
                else//	HA PERDIDO
                {
					lose = true;
					turnoDelJugador = false;
                }
            }

		}

		public void makeStay()
        {
			turnoDelJugador = false;
			
        }

        private int checkForAce(List<Carta> cartas)
        {
			// Declaring Index Variable
			int index = -1;

			// Declaring Bool Variable
			bool isDoneChecking = false;

			// Implementing While Loop
			while (!isDoneChecking)
			{
				index++;
				if (cartas[index].getSigno() == "A" || index == cartas.Count - 1)
				{
					isDoneChecking = true;
				}
			}

			// Returning Index Value of Ace Location, if no Ace Location, returns the Last Index of Deck
			return index;
		}

        public List<Carta> revolver(List<Carta> deck)
        {
			Random shuffler = new Random();

			// Declaring Variables
			int shuffleIndex;
			int shuffleIndexTwo;
			Carta temp;

			for (int i = 0; i < 10000; i++)
			{
				
				shuffleIndex = shuffler.Next(0, 52);
				shuffleIndexTwo = shuffler.Next(0, 52);
				temp = deck[shuffleIndex];
				deck[shuffleIndex] = deck[shuffleIndexTwo];
				deck[shuffleIndexTwo] = temp;
			}

			// Returning Shuffled Deck
			return deck;
		}

        public int getValueOf(string[] deck, int i)
        {
			switch (deck[i])
			{
				case "A":
					return 11;
					
				case "K":
				case "Q":
				case "J":
				case "10":
					return 10;
					
				case "9":
					return 9;
					
				case "8":
					return 8;
					
				case "7":
					return 7;
					
				case "6":
					return 6;
					
				case "5":
					return 5;
					
				case "4":
					return 4;
					
				case "3":
					return 3;
					
				case "2":
					return 2;
					
				default:
					return 0;
					
			}
		}

    }
}
