using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BlackJack
{
	public class Principal
	{
		Carta cartas = new Carta();
		

		String[] deck = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
		bool juegoEnCurso;
		

		Carta[] baraja;
		private List<Carta> mazo;
		public ObservableCollection<Carta> PlayerCards { get; set; }


		public Principal()
		{
			//generarCartas();
			//imprimirCartas();
			
		}


		public void comenzarJuego(string[] deck, double dineroApostado, double dineroTotal)
        {
			string[] P1_Cards = new string[100];
			string[] P1_SplitCards = new string[100];
			string[] House_Cards = new string[100];
			int card = 51;

			bool juegoEnCurso = true;
			bool primerTurno = true;
			bool turnoDeJugador = true;
			string choice;
			//-------------------------------
			//---Variables finales------
			bool lost = false;
			bool win = false;
			//-------------------------------
			//-------------------------------
			int P1_ValueOf_Cards =0;
			int House_ValueOf_Cards =0;

			deck = barajar(deck);

			int i = 0;
			for (; i < 2; i++)
            {
				P1_Cards[i] = deck[card];
				Console.WriteLine("Has recibido la carta: " + deck[card]);
			}

			if(P1_ValueOf_Cards == 21)
            {
				juegoEnCurso = false;
				dineroApostado = dineroApostado * 1.5;
            }
			// Si el crupier tiene 21 y el jugador no se aseguró, informe al jugador después de que el jugador presione cualquier tecla
			if (House_ValueOf_Cards == 21 && win == false && lost == false)
            {
				juegoEnCurso = false;
            }

			

            /*
			//Si el jugador tiene dos de los mismos tipos de cartas, permite dividir (SPLIT)
            if (playerCards[0] == playerCards[1] || playerCards[1] == "A - One" && playerCards[0] == "A") { splitavailable = true; }
			 */


            while (juegoEnCurso)
            {
                if (turnoDeJugador)
                {
					Console.WriteLine("\nE valor de sus cartas es:  " + P1_ValueOf_Cards);

					Console.WriteLine("\nQué le gustaría hacer?\n1.Pedir\n2.Quedarme");
					if (primerTurno) { Console.WriteLine("3.Doblar la apuesta\n4.Rendirse"); }
					choice = Console.ReadLine();

					
                    switch (choice)
                    {
						case "1":	//	HIT
							// Si la siguiente carta es un As con valor de 11 y el mazo del jugador supera los 21 con la suma, conviértalo en un valor de uno
							if(getValueOfCard(deck,card) == 11 && P1_ValueOf_Cards + getValueOfCard(deck, card) > 21)
                            {
								i++;
								P1_Cards[i] = "A - One";
								P1_ValueOf_Cards += 1;
								Console.WriteLine("\nHas pedido! Obtuviste " + deck[card] + ", Ahora tienes " + P1_ValueOf_Cards);
								// Move Down Deck
								card--;
							}
                            else
                            {
								i++;
								P1_Cards[i] = deck[card];
								P1_ValueOf_Cards += getValueOfCard(deck, card);
								Console.WriteLine("\nHas pedido! Obtuviste " + deck[card] + ", Ahora tienes " + P1_ValueOf_Cards);
								// Move Down Deck
								card--;
							}

							//Si el jugador tiene más de 21
							if(P1_ValueOf_Cards > 21)
                            {
								//validar si es posible el quiebre del As
								int index = getAsIndex(P1_Cards);
								// si se puede, hacerlo.
								if(P1_Cards[index] == "A")
                                {
									P1_Cards[index] = "A - One";
									P1_ValueOf_Cards -= 10;
                                }
                                else
                                {
									//	Definitivamente ha perdido
									lost = true;

                                }
                            }
							break;

						case "2":   //	STAND	

							turnoDeJugador = false;
							break;
					}
                    if (primerTurno)
                    {
						switch (choice)
						{
							case "3":   //	DOBLAR
										// Vlidar si tiene suficiente dinero para doblar
								if (dineroTotal - dineroApostado * 2 >= 0)
								{
									//Si sale un As y el 11 rebasa el 21, convertir el As en 1
									if (getValueOfCard(deck, card) == 11 && P1_ValueOf_Cards + getValueOfCard(deck, card) > 21)
									{ 
										i++;
										P1_Cards[i] = "A - One";
										P1_ValueOf_Cards += 1;
										card--;
									}
									else
									{
										i++;
										P1_Cards[i] = deck[card];
										P1_ValueOf_Cards += getValueOfCard(deck, card);
										card--;
									}
									if (P1_ValueOf_Cards > 21)
									{
										// Checks if has Ace in Hand with the value of 11 
										int index = validarSiHayAS(P1_Cards);
										// If Has Ace in hand with the value off 11 
										if (P1_Cards[index] == "A")
										{
											// Give Ace the Value of One From 11
											P1_Cards[index] = "A - One";
											// Subtract 10 from player value of Cards
											P1_ValueOf_Cards -= 10;
											// User Friendly Sentence
											Console.WriteLine("\nPlayer Had An Ace.. Ace's Value Changed to One, Player has " + P1_ValueOf_Cards);
										}
										else
										{
											// Else End Game and Lose
											lost = true;
											juegoEnCurso = false;
										}
									}
									turnoDeJugador = false;
									dineroApostado = dineroApostado * 2;

								}
								else
								{
									Console.WriteLine("\nUsted no tiene suficiente dinero para doblar");
								}
								break;

							case "4":   //	RENDIRSE

								dineroApostado = dineroApostado / 2;
								lost = true;
								juegoEnCurso = false;
								break;
						}
					}

					//	Condicionales de los 'Splits'
						
				}
            }
		}

        private int getAsIndex(string[] theDeck)
        {
			// Declaring Index Variable
			int index = -1;

			// Declaring Bool Variable
			bool isDoneChecking = false;

			// Implementing While Loop
			while (!isDoneChecking)
			{
				index++;
				if (theDeck[index] == "A" || index == theDeck.Length - 1)
				{
					isDoneChecking = true;
				}
			}

			// Returning Index Value of Ace Location, if no Ace Location, returns the Last Index of Deck
			return index;
		}

        static private int validarSiHayAS(string[] theDeck)
		{
			// Declaring Index Variable
			int index = -1;

			// Declaring Bool Variable
			bool isDoneChecking = false;

			// Implementing While Loop
			while (!isDoneChecking)
			{
				index++;
				if (theDeck[index] == "A" || index == theDeck.Length - 1)
				{
					isDoneChecking = true;
				}
			}

			// Returning Index Value of Ace Location, if no Ace Location, returns the Last Index of Deck
			return index;
		}

		private string[] barajar(string[] deck)
		{
			// Declaring Randomizer 
			Random baraja = new Random();

			// Declaring Variables
			int shuffleIndex;
			int shuffleIndexTwo;
			string temp;

			for (int i = 0; i < 10000; i++)
			{
				shuffleIndex = baraja.Next(0, deck.Length);
				shuffleIndexTwo = baraja.Next(0, deck.Length);
				temp = deck[shuffleIndex];
				deck[shuffleIndex] = deck[shuffleIndexTwo];
				deck[shuffleIndexTwo] = temp;
			}

			// Returning Shuffled Deck
			return deck;
		}
		private int getValueOfCard(string[] deck, int index)
		{
			int returnValue;
			switch (deck[index])
			{
				case "A":
					returnValue = 11;
					break;
				case "K":
				case "Q":
				case "J":
				case "10":
					returnValue = 10;
					break;
				case "9":
					returnValue = 9;
					break;
				case "8":
					returnValue = 8;
					break;
				case "7":
					returnValue = 7;
					break;
				case "6":
					returnValue = 6;
					break;
				case "5":
					returnValue = 5;
					break;
				case "4":
					returnValue = 4;
					break;
				case "3":
					returnValue = 3;
					break;
				case "2":
					returnValue = 2;
					break;
				default:
					returnValue = 0;
					break;
			}
			return returnValue;
		}
	

}
}
