using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class SocketListener
    {

   
        public static string data = null;
        // Recibiendo los datos del cliente  

        public static void StartListening()
        {
            // Buffer de datos a la espera de datos 
            byte[] bytes = new Byte[1024];

            // Establece el punto final local para el socket.
            // Dns.GetHostName devuelve el nombre del
            // host que ejecuta la aplicación.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Crear TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Vincular el socket al punto final local y
            // escucha las conexiones entrantes.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Comenzar a escuchar por conexiones
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");

                    // El programa es suspendido mientras espera por una conexión entrante 
                    Socket handler = listener.Accept();
                    data = null;

                    // Conexión entrante necesita ser procesada
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                            //Ya se termino la recepción del mensaje
                        }
                    }

                    // Mostrar los datos en consola 
                    Console.WriteLine("Cadena recibida : {0}", data);

                    // Devolver el mensaje al cliente.
                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    //return data;

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }
    }
}
