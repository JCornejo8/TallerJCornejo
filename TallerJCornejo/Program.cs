using ServerSocketUtil;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TallerJCornejo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.WriteLine("Inicinado Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);

            if(servidor.Iniciar())
            {
                Console.WriteLine("Servidor iniciado ;)");
                while (true)
                {
                    //Obtener a cliente
                    Console.WriteLine("Esperando Cliente");
                    Socket socketCliente = servidor.ObtenerCliente();
                    //Recibir y habilitar al cliente
                    ClienteCom cliente = new ClienteCom(socketCliente);
                    //Preguntar al cliente su nombre

                    bool estado = true;
                    
                    do{
                        cliente.Escribir("Dime el mensaje");
                        //Asignar el mensaje
                        string mensaje = cliente.Leer();
                        //mostrar el mensaje por la consola del servidor
                        Console.WriteLine("El cliente dijo:{0}", mensaje);
                        //escribir respuesta
                        Console.WriteLine("Ingrese una respuesta");
                        string respuesta = Console.ReadLine();
                        cliente.Escribir(respuesta);
                        if (mensaje == "chao")
                        {
                            cliente.Desconectar();
                            estado = false;
                            Console.WriteLine("Adios");
                            break;

                        }

                    } while (estado);

                   




                }

                }
                else
                {
                    Console.WriteLine("Error, el puerto {0} no se encuentra disponible", puerto);
                }
                  
               
               
            }

        }
    }

