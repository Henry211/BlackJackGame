using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using BlackJack;

namespace BlackJack
{

   
    public partial class MainWindow : Window

    {
        private int ApuestaActual=0;
        private int DineroTotal=1500;
        Mesa mesa = new Mesa();
        private List<Carta> P1_Cartas= new List<Carta>();
        Controller controlador;
        private List<Carta> mazo = new List<Carta>(52);
        static int mn = 0;

        BitmapImage img10 = new BitmapImage(new Uri("/Recursos/10.png", UriKind.Relative));
        BitmapImage img25 = new BitmapImage(new Uri("/Recursos/25.png", UriKind.Relative));
        BitmapImage img50 = new BitmapImage(new Uri("/Recursos/50.png", UriKind.Relative));
        BitmapImage img100 = new BitmapImage(new Uri("/Recursos/100.png", UriKind.Relative));

        public  MainWindow()
        {   
            InitializeComponent();
            controlador = new Controller();
            this.mesa = controlador.getMesa();

            actualizarElementos(controlador);
            //Console.WriteLine(RandomCarta());
        }

        private void actualizarElementos(Controller controlador)
        {
           
            imgCard1.Source = mesa.getMazo().ElementAt(10).getImage();
            imgCard2.Source = mesa.getMazo().ElementAt(43).getImage();
            imgCard3.Source = mesa.getMazo().ElementAt(2).getImage();
            imgCard4.Source = mesa.getMazo().ElementAt(22).getImage();
            imgCard5.Source = mesa.getMazo().ElementAt(43).getImage();
            imgCard6.Source = mesa.getMazo().ElementAt(6).getImage();
            imgCard7.Source = mesa.getMazo().ElementAt(41).getImage();
            imgCard8.Source = mesa.getMazo().ElementAt(4).getImage();
            imgCard9.Source = mesa.getMazo().ElementAt(22).getImage();
            imgCard10.Source = mesa.getMazo().ElementAt(43).getImage();
            imgCard11.Source = mesa.getMazo().ElementAt(41).getImage();
            imgCard12.Source = mesa.getMazo().ElementAt(6).getImage();
            dineroTotal.Content = DineroTotal;
            switch (mesa.getDinero())
            {
                case 10:
                    break;

            }

          //  imgCard11.Source = mesa.getCartasJugador().ElementAt(1).getImage();
         /*   imgCard7.Source = mesa.getCartasConstrarios().ElementAt(5).getImage();
            imgCard8.Source = mesa.getCartasConstrarios().ElementAt(1).getImage();
            imgCard9.Source = mesa.getCartasConstrarios().ElementAt(2).getImage();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void pedirBtn_Click(object sender, RoutedEventArgs e)
        {
            P1_Cartas = controlador.getP1_Cartas();
            BitmapImage img = new BitmapImage();
            //img = P1_Cartas.ElementAt(0).getImage();

            //Random rnd = new Random();
            //int n = rnd.Next(1,5);
            //imgCard2.Source = new BitmapImage(new Uri(RandomCarta(n), UriKind.Relative));
            //imgCard2.Source = img;
                  //imgCard2.Source = new BitmapImage(new Uri("/Recursos/10.png", UriKind.Relative));

        }

        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ___Sin_quedarseBtn__Click(object sender, RoutedEventArgs e)
        {
            controlador.makeStay();
           // imgCard3.Source = image;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            ApuestaActual += 10;
            dineroApostado.Content=ApuestaActual;
            DineroTotal -= 10;
            dineroTotal.Content = DineroTotal;
        }

        private void _25btn_Click(object sender, RoutedEventArgs e)
        {
            ApuestaActual += 25;
            dineroApostado.Content = ApuestaActual;
            DineroTotal -= 25;
            dineroTotal.Content = DineroTotal;
        }

        private void _50btn_Click(object sender, RoutedEventArgs e)
        {
            ApuestaActual += 50;
            dineroApostado.Content = ApuestaActual;
            DineroTotal -= 50;
            dineroTotal.Content = DineroTotal;
        }

        private void _100btn_Click(object sender, RoutedEventArgs e)
        {
            ApuestaActual += 100;
            dineroApostado.Content = ApuestaActual;
            DineroTotal -= 100;
            dineroTotal.Content = DineroTotal;
        }
    }
}
