using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ProyectoDataBase
{
    class Program
    {
    


        static void Main(string[] args)
        {



            //variables globales
            bool bandera = false;
            string instruccion="";

            string path = @"c:\bases\";
            string usabase = "";
            bool resultIsMatch;

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
                    path = @"c:\bases\";
                    System.Console.Clear();


                    Console.WriteLine("Ingresa un comando");
                    instruccion = Console.ReadLine();
                    //Crea base
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


                            } else
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

                    //Borra base

                    else if (instruccion.Contains("borra base"))
                    {
                        try
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
                            //Muestra base
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("El proceso fallo: {0}", e.ToString());
                            Console.ReadKey();
                        }
                        //muestra bases
                    } else if (instruccion.Contains("muestra bases"))
                    {

                        // DirectoryInfo di = new DirectoryInfo(path);
                        string[] folders = Directory.GetDirectories(path);
                        //Console.WriteLine("No search pattern returns:");
                        foreach (string f in folders)
                        {
                            Console.WriteLine("" + f.Substring(9)); // Mostramos las carpetas en la consola

                        }
                        Console.ReadKey();
                    }
                    //Usa base
                    else if (instruccion.Contains("usa base"))
                    {
                        string nombre = instruccion.Substring(9);

                        if (Directory.Exists(path+nombre))
                        {
                            usabase = instruccion.Substring(9);
                            Console.WriteLine("se selecciono la base de datos con exito");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("La base de datos no existe");
                            Console.ReadKey();

                        }
                    }
                    else if (instruccion.Contains("crea tabla"))
                    {
                        if (usabase == "") 
                        {
                            Console.WriteLine("Primero debes de poner en uso una base de datos");
                            Console.ReadKey();
                        }
                        else 
                        {
                            string nombre = instruccion.Substring(10);
                            path = path + usabase;

                            try
                            {
                                // crea un archivo o sobreescribe si en verdad existe.
                                if (Directory.Exists(path)) 
                                {
                                    Console.WriteLine("el nombre de la tabla ya esta en uso");
                                }
                                else 
                                {
                                    using (FileStream fs = File.Create(path + "\\" + nombre + ".est"))
                                    {
                                        //do
                                        //{
                                         //   string estructura = Console.ReadLine();
                                         //   resultIsMatch = Regex.IsMatch(estructura, @"(a-z)");
                                         //   if(resultIsMatch == false) 
                                         //   {
                                         //       Console.WriteLine("La estructura debe ser: Nombre campo1, tipo, longitud \n, Nombre campo2, tipo, longitud \n, Nombre campon, tipo, longitud");
                                         //       Console.ReadKey();

                                          //  }
                                      //  } while (resultIsMatch == true);
                                        
                                        
                                        
                                        Byte[] miinfo = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                                        // Add some information to the file.
                                        fs.Write(miinfo, 0, miinfo.Length);
                                    }

                                }
                                

                                
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                Console.ReadKey();
                            }

                        }
                       

                    }



                }
            }
            catch(Exception )
            {
               
              

            }


           
        }
    }
}
