using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace admonProyect
{
    class Program
    {
        static void Main(string[] args)
        {


            //variables globales
            bool bandera = false;
            string instruccion = "";

            //variable para ver si desea insertar otro  campo
            char respuesta;
            string path = @"c:\bases\";
            string usabase = "";
            // bool resultIsMatch;

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


                            }
                            else
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
                    }
                    else if (instruccion.Contains("muestra bases"))
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

                        if (Directory.Exists(path + nombre))
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
                            string nombre = instruccion.Substring(11);
                            path = @"c:\bases\" + usabase + "\\" + nombre;

                            try
                            {
                                // crea un archivo o sobreescribe si en verdad existe.
                                if (File.Exists(path + ".est"))
                                {
                                    Console.WriteLine("el nombre de la tabla ya esta en uso");
                                    Console.ReadKey();
                                }
                                else
                                {

                                    using (StreamWriter writetext = new StreamWriter(path + ".est"))
                                    {
                                       // writetext.WriteLine(Text);
                                       // Console.WriteLine("creada con exito");
                                       // Console.Read();
                                        do
                                        {
                                            
                                            Console.WriteLine("Ingresa los campos ");
                                            // byte[] miinfo = new UTF8Encoding(true).GetBytes(Console.ReadLine() + "\n");
                                            // Add some information to the file.
                                            // writetext.Write(miinfo, 0, miinfo.Length);
                                            //Console.WriteLine("creada con exito");
                                            // Console.Read();

                                            string campo = Console.ReadLine();
                                            writetext.WriteLine(campo);
                                            Console.Clear();
                                            Console.WriteLine("¿Desea agregar otro campo?");
                                            Console.WriteLine("s) si");
                                            Console.WriteLine("n) no");
                                            respuesta = char.Parse(Console.ReadLine());
                                            Console.Clear();

                                        }
                                        while (respuesta == 's');

                                        writetext.Close();


                                    }




                                    using (StreamWriter writetext = new StreamWriter(path + ".dat")) 
                                    { 

                                        //Close the file
                                        writetext.Close();
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
                    else if (instruccion.Contains("inserta en"))
                    {

                        string nombre = instruccion.Substring(11);
                        path = @"c:\bases\" + usabase;


                       // String line;
                        try
                        {


                            using (StreamReader readtext = new StreamReader(path + "\\"+nombre+".dat"))
                            {
                                string line;
                                // Read and display lines from the file until the end of
                                // the file is reached.
                                while ((line = readtext.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }

                           
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                            Console.ReadKey();
                        }
                       


                    }




                }
            }
            catch (Exception)
            {



            }



        }
    }
}

