using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
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
using System.Windows.Shapes;
namespace Login_BlackJack
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        static string server = "LDAP://25.88.61.224";
        private void LogIn(object sender, RoutedEventArgs e)
        {
            string nombre = Usuariotxt.Text;
            string contraseña = Pass.Password;

            if (autentica(nombre, contraseña) == true)
            {
                BlackJack.MainWindow mw = new BlackJack.MainWindow();
                mw.Owner = this;
                mw.ShowDialog();
                MessageBoxResult result = System.Windows.MessageBox.Show("Ha iniciado sesion de forma satisfactoria!!", "Sesion Completa", MessageBoxButton.OK);

            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Debe de crear una cuenta, por favor llene todos los espacios antes de presionar el boton Registrar", "Faltan datos", MessageBoxButton.OK);
                Usuariotxt.Text = "";
                Pass.Password = "";
            }
        }


        public bool autentica(string us, string contra)
        {
            //se arma el string para crear el usuario de active directory
            string creaDominio = us + "@operativos.una";
            try
            {
                DirectoryEntry entry = new DirectoryEntry(server, creaDominio, contra);
                DirectorySearcher search = new DirectorySearcher(entry);
                SearchResult result = search.FindOne();
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OKCancel);
                return false;

            }
        }
        private void Crear(object sender, RoutedEventArgs e)
        {
            string nombre = Usuariotxt.Text;
            string contraseña = Pass.Password;
            if (nombre != " " && contraseña != " ")
            {
                if (register(nombre, contraseña) == true)
                {
                    MessageBoxResult resp = System.Windows.MessageBox.Show("El usuario se ha creado satisfactoriamente", " Su Usuario:" + nombre + "@operativos.una", MessageBoxButton.OKCancel);
                }
                else
                {
                    MessageBoxResult resp = System.Windows.MessageBox.Show("ERROR al crear usuario", " no se pudo  crear el usuario", MessageBoxButton.OKCancel);

                }

            }
            else
            {
                MessageBoxResult resp = System.Windows.MessageBox.Show("ERROR ", " los campos estan vacios, debe de llenarlos", MessageBoxButton.OKCancel);
            }
        }


        public static bool register(string us, string pass)
        {
            try
            {

                using (var contx = new PrincipalContext(ContextType.Domain, "25.88.61.224", "Administrador", "MoMo87247802"))
                {
                    using (var newUser = new UserPrincipal(contx))
                    {
                        newUser.SamAccountName = us;
                        newUser.SetPassword(pass);
                        newUser.Enabled = true;
                        newUser.Save();
                    }
                }
                return true;
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //DoSomethingwith --> E.Message.ToString();
                return false;
            }


        }
    }
}
