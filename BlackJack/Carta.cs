using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BlackJack
{
	public class Carta
	{
		string signo, ruta;
		private int numero;
		private BitmapImage cara;
		private Image reves;
		private int posicion;
		private bool estado;
		

		public Carta() { }


	public Carta(int numero, string ruta) {
			this.numero = numero;
			this.ruta = ruta;
	}
	
		
	public Carta(string signo, int numero, bool estado, BitmapImage cara)
    {
		this.signo = signo;
		this.numero = numero;
		this.estado = estado;
		this.cara = cara;
    }

	public void setUrl(string url) => this.ruta = url;
	public string getUrl() => this.ruta;
	public void setNumero(int numero) => this.numero = numero;
	public int getNumero() { return 3; }
	public void setEstado(bool estado) => this.estado = estado;
	public bool getEstado() => estado;
	public void setImage(BitmapImage img) => this.cara = img;
	public void setSigno(string signo) => this.signo = signo;
	public string getSigno() => signo;
	public BitmapImage getImage() => cara;

	public void setUnoToAs()
    {
			if(this.signo == "A")
            {
				this.numero = 1;
            }
     }



	}
}