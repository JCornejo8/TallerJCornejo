using ClienteHolaMundoS.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteTaller1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese el puerto:");
            int puerto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la ip:");
            string servidor = Console.ReadLine();

            
            Console.WriteLine("Conectado a Servidor {0} en puerto {1}", servidor, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);
            bool estado = true;

            if (clienteSocket.conectar())
            {
                Console.WriteLine("Conectado");

                do
                {
                    string mensajeServidor = clienteSocket.Leer();
                    Console.WriteLine("Servidor: {0}", mensajeServidor);
                    string MensajeCliente = Console.ReadLine().Trim();
                    clienteSocket.Escribir(MensajeCliente);
                    string respuestaServidor = clienteSocket.Leer();
                    Console.WriteLine("Servidor:{0}", respuestaServidor);
                    if (respuestaServidor == "chao")
                    {
                        estado = false;
                        clienteSocket.Escribir("Me despido por que me dijiste chao");
                        clienteSocket.Desconectar();
                        
                    }
                } while (estado);

             

      
  
            }
            else
            {
                Console.WriteLine("Error de comunicacion");
            }
            Console.ReadKey();
        }
    }
}
