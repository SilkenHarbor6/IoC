﻿using DLL.Model;
using DLL.ModeloInyeccion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static int res, id;
        static bool per = true, resp;
        static char letra;
        static IPersona oAl = new Alumno();
        //static IRepository datos = new ProxyRepository();
        //static List<Persona> listaPersonas;
        public static void GetMenu()
        {
            Console.WriteLine("*************MENU*************");
            Console.WriteLine("1-Consultar lista de personas");
            Console.WriteLine("2-Consultar persona por id");
            Console.WriteLine("3-Eliminar persona");
            Console.WriteLine("4-Agregar registro");
            Console.WriteLine("5-Actualizar registro");
            Console.WriteLine("6-Salir");
            Console.WriteLine("Ingrese su opcion:");
        }
        public static void MostrarInfo(List<IPersona> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine("Nombre: {0} {1}", item.Nombre, item.Apellido);
                Console.WriteLine("Direccion: {0}", item.Direccion);
                Console.WriteLine("Edad: {0}", item.edad);
                Console.WriteLine("id: {0}", item.IdPersona);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int opcion;
            
            //Registrar las independencias
            Inyector.Map<IBaseDatos, BaseDatos>();
            Inyector.Map<IPersona,Alumno>();

            var alumno = Inyector.Get<IPersona>();
            var gestion = Inyector.Get<IBaseDatos>();

            


            //Lista de registros
            alumno.IdPersona = 1;
            alumno.Nombre = "Juan";
            alumno.Apellido = "Salvador";
            alumno.Direccion = "Santana";
            alumno.edad = 30;
            gestion.Save(alumno);

            alumno = Inyector.Get<IPersona>();
            alumno.IdPersona = 2;
            alumno.Nombre = "Juan";
            alumno.Apellido = "Salvador";
            alumno.Direccion = "Santana";
            alumno.edad = 35;
            gestion.Save(alumno);
            do
            {
                Console.Clear();
                GetMenu();
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        MostrarInfo(gestion.GetAll());
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ingrese el id del usuario que desea conocer");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        oAl = gestion.GetById(id);
                        //persona = datos.GetById(id);
                        if (oAl != null)
                        {
                            Console.WriteLine("Nombre: {0} {1}", oAl.Nombre, oAl.Apellido);
                            Console.WriteLine("Direccion: {0}", oAl.Direccion);
                            Console.WriteLine("Edad: {0}", oAl.edad);
                            Console.WriteLine("id: {0}", oAl.IdPersona);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna persona registrada con ese id");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Ingrese el id de la persona que desea eliminar:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        oAl = gestion.GetById(id);
                        if (oAl != null)
                        {
                            resp = gestion.Delete(oAl);
                            if (resp)
                            {
                                Console.WriteLine("El registro se elimino con exito");
                                MostrarInfo(gestion.GetAll());

                            }
                            else
                            {
                                Console.WriteLine("Error al eliminar el registro");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna persona registrada con ese id");
                        }
                        Console.ReadKey();
                        break;
                    case 4:

                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
