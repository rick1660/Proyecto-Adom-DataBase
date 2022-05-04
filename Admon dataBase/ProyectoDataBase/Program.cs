using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoDataBase
{
    class Program
    {
        //Metodo para sacar el nombre
        string Name(string instruccion)
        {
            // Store input argument in a local variable.
            //int input = i;
          return "";
        }


        static void Main(string[] args)
        {




            bool bandera = false;
            string instruccion="";



            try 
            {
                while (bandera == false)
                {

                    System.Console.Clear();


                    Console.WriteLine("Ingresa un comando");
                    instruccion = Console.ReadLine();

                    if (instruccion.Contains("crea base"))
                    {

                        string nombre = instruccion.Substring(10);

                      

                        // Especificar la ruta.
                        string path = @"c:\"+nombre;

                        try
                        {
                            //si el directorio existe
                            if (Directory.Exists(path))
                            {
                                Console.WriteLine("El directorio ya existe.");
                                Console.ReadKey();
                                return;

                            }

                            // intenta crear el directorio.
                            DirectoryInfo di = Directory.CreateDirectory(path);
                            Console.WriteLine("La base de datos fu creada con exito.", Directory.GetCreationTime(path));
                            Console.ReadKey();

                           
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("El proceso fallo: {0}", e.ToString());
                            Console.ReadKey();
                        }
                       
                    }
                    else if(instruccion.Contains("borra base"))
                    {
                        string nombre = instruccion.Substring(11);

                        // Especificar la ruta.
                        string path = @"c:\" + nombre;

                        //Borra el directorio
                        Directory.Delete(path);
                        Console.WriteLine("La base de datos fue borrada con exito.");
                        Console.ReadKey();
                        // Console.WriteLine("Ingresa un comando valido");
                        //Console.ReadKey();
                    }



                }
            }
            
            catch(Exception e)
            {
               
              

            }


           
        }
    }
}
