using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            new Usuarios().Menu();
        }
    }

    public class Usuarios
    {
        private UsuarioLogic UsuarioNegocio;

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            int op;

            do
            {
                Console.WriteLine("" +
                    "1– Listado General " +
                    " 2– Consulta" +
                    " 3– Agregar" +
                    " 4 - Modificar" +
                    " 5 - Eliminar" +
                    " 6 - Salir");
                op = int.Parse(Console.ReadLine());
                switch(op)
                {
                    case 1:
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        Eliminar();
                        break;
                }
            } while (op != 6);
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach(Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }    
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID debe ser un numero entero");
            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Agregar()
        {
            Usuario u = new Usuario();
            Console.Clear();
            //Console.Write("Ingrese nombre: ");
            //u.Nombre = Console.ReadLine();
            //Console.Write("Ingrese apellido: ");
            //u.Apellido = Console.ReadLine();
            Console.Write("Ingrese nombre usuario: ");
            u.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese clave: ");
            u.Clave = Console.ReadLine();
            //Console.Write("Ingrese email: ");
            //u.EMail = Console.ReadLine();
            Console.Write("Ingrese habilitacion (1-Si/Otro-No): ");
            u.Habilitado = (Console.ReadLine() == "1");
            u.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(u);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", u.ID);
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario u = UsuarioNegocio.GetOne(ID);
               // Console.Write("Ingrese nombre: ");
               // u.Nombre = Console.ReadLine();
               // Console.Write("Ingrese apellido: ");
               // u.Apellido = Console.ReadLine();
                Console.Write("Ingrese nombre usuario: ");
                u.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese clave: ");
                u.Clave = Console.ReadLine();
              //  Console.Write("Ingrese email: ");
               // u.EMail = Console.ReadLine();
                Console.Write("Ingrese habilitacion (1-Si/Otro-No): ");
                u.Habilitado = (Console.ReadLine() == "1");
                u.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(u);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: " + usr.ID);
           // Console.WriteLine("Nombre: " + usr.Nombre);
            Console.WriteLine();
        }
    }
}
