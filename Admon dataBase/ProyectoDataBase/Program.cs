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
    


        static void Main(string[] args)
        {




            bool bandera = false;
            string instruccion="";

            string path = @"c:\bases\";

            if (Directory.Exists(path))
            {
              

            }
            else 
            {
                DirectoryInfo di = Directory.CreateDirectory(path);

            }


            // intenta crear el directorio.
            



       

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

                       path = path + nombre;

                        try
                        {
                            //si el directorio existe
                            if (Directory.Exists(path))
                            {
                                Console.WriteLine("El directorio ya existe.");
                                Console.ReadKey();
                               

                            }else 
                            {
                                // intenta crear el directorio.
                                DirectoryInfo di = Directory.CreateDirectory(path);
                                Console.WriteLine("La base de datos fue creada con exito.", Directory.GetCreationTime(path));
                                Console.ReadKey();
                            }

                            

                           
                            
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
                        path = path + nombre;

                        //Borra el directorio
                        Directory.Delete(path);
                        Console.WriteLine("La base de datos fue borrada con exito.");
                        Console.ReadKey();
                        // Console.WriteLine("Ingresa un comando valido");
                        //Console.ReadKey();
                    }else if(instruccion.Contains("muestra bases")) 
                    {

                        // DirectoryInfo di = new DirectoryInfo(path);
                        string[] folders = Directory.GetDirectories(path);
                        //Console.WriteLine("No search pattern returns:");
                        foreach (string f in folders)
                        {
                            Console.WriteLine(""+ f.Substring(9)); // Mostramos las carpetas en la consola
                            
                        }
                        Console.ReadKey();
                    }



                }
            }
            catch(Exception )
            {
               
              

            }


           
        }
    }
}
