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
        public static string stringBetween(string Source, string Start, string End)
        {
            string result = "";
            if (Source.Contains(Start) && Source.Contains(End))
            {
                int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
                int EndIndex = Source.IndexOf(End, StartIndex);
                result = Source.Substring(StartIndex, EndIndex - StartIndex);
                return result;
            }

            return result;
        }



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




            bool ComandoValido = false;

            try
            {
                while (bandera == false)
                {
                    path = @"c:\bases\";
                    System.Console.Clear();

                    do
                    {

                        Console.WriteLine("Ingresa un comando");
                        instruccion = Console.ReadLine();
                        if (instruccion.Contains("lista * de") == false & instruccion.Contains("borra base") == false & instruccion.Contains("elimina en") == false & instruccion.Contains("crea base") == false & instruccion.Contains("usa base") == false & instruccion.Contains("crea tabla") == false & instruccion.Contains("agrega campo") == false & instruccion.Contains("borra campo") == false & instruccion.Contains("inserta en") == false & instruccion.Contains("muestra bases") == false & instruccion.Contains("muestra tablas") == false & instruccion.Contains("borra tabla") == false)
                        {
                            Console.WriteLine("Ingresa una comando valido");
                            ComandoValido = false;
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else
                        {
                            ComandoValido = true;
                        }

                    } while (ComandoValido == false);


                    //***********************************************************************************************************************Codigo para crear una base de datos*****************************************************/
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

                    //***********************************************************************************************************************Fin de Codigo para crear una base de datos*****************************************************/


                    //***********************************************************************************************************************Codigo para borrar base de datos*****************************************************/

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

                    //***********************************************************************************************************************Fin Codigo para borrar base de datos*****************************************************/


                    //***********************************************************************************************************************Codigo para mostrar tablas*****************************************************/
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
                    //*********************************************************************************************************************** Fin Codigo para mostrar tablas*****************************************************/


                    //***********************************************************************************************************************Codigo para Poner en uso una base de datos *****************************************************/
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
                    //*********************************************************************************************************************** FinCodigo para Poner en uso una base de datos *****************************************************/


                    //***********************************************************************************************************************Codigo para Poner Crear una tabla *****************************************************/
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

                                            Console.WriteLine("Ingresa parametros  del campo \n");

                                            string NombreCampo = "";
                                            string TipoCampo = "";
                                            string Longitud = "";

                                            bool PasaNombre = false;


                                            do
                                            {

                                                Console.WriteLine("\n Nombre");
                                                NombreCampo = Console.ReadLine();


                                                if (NombreCampo.Contains(",") == true | NombreCampo.Contains(" ") == true | NombreCampo == "")
                                                {
                                                    PasaNombre = false;
                                                    Console.WriteLine("En nombre no puede tener comas o  espacios");
                                                }
                                                else
                                                {
                                                    PasaNombre = true;
                                                }


                                            } while (PasaNombre == false);




                                            do
                                            {

                                                Console.WriteLine("\n Tipo");
                                                TipoCampo = Console.ReadLine();
                                                if (TipoCampo == "entero" | TipoCampo == "caracter" | TipoCampo == "decimal" | TipoCampo == "fecha")
                                                {
                                                    PasaNombre = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Tipo de dato invalido, Los tipos de datos validos son: entero, caracter, decimalo fecha");
                                                    PasaNombre = false;
                                                }

                                            } while (PasaNombre == false);


                                            if (TipoCampo == "fecha")
                                            {
                                                Longitud = "8";
                                            }
                                            else if (TipoCampo == "decimal")
                                            {
                                                do
                                                {

                                                    Console.WriteLine("\n longitud");
                                                    Longitud = Console.ReadLine();
                                                    if (Longitud.Contains(",") == true)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("La longitud debe tener la siguiente estructura: enteros,decimales");
                                                    }

                                                } while (Longitud.Contains(",") == false);
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n Longitud");
                                                Longitud = Console.ReadLine();
                                            }




                                            writetext.WriteLine(NombreCampo + ", " + TipoCampo + ", " + Longitud);
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
                    //*********************************************************************************************************************** Fin Codigo para Poner Crear una tabla *****************************************************/

                    //***********************************************************************************************************************Codigo para Poner insertar datos en una tabla es decir al .dat *****************************************************/
                    else if (instruccion.Contains("inserta en"))
                    {

                        if (usabase == "")
                        {
                            Console.WriteLine("Primero debes de poner en uso una base de datos");
                            Console.ReadKey();
                        }
                        else
                        {

                            string tabla = instruccion.Substring(11);
                            path = @"c:\bases\" + usabase;

                            try
                            {
                                //Imprime la tabla como guia

                                // codigo que  lee los campos y guarda la cantidad de campos en un contador
                                string line = "";
                                int cont = 0;
                                using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                                {
                                    Console.WriteLine("\n Estructura de la tabla \n");
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        cont = cont + 1;
                                        Console.WriteLine(line);
                                    }
                                    Console.WriteLine("\n");

                                }


                                //  Console.WriteLine(cont);

                                //vector para guardar los nombre de los campos campos renglon por renglon

                                // Vector para los vampos
                                string[] Campos = new string[cont];

                                // Vector para los tipos de datos
                                string[] TipoDatos = new string[cont];


                                // Vector para los Longitud
                                string[] Longitud = new string[cont];

                                int totalcaracterLongitu = 0;

                                int cont2 = 0;


                                //codigo que guarda los campos en el vector
                                using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                                {
                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        char[] charArray = line.ToCharArray();
                                        char first = charArray[0];


                                        //Guardando nombre de campos
                                        Campos[cont2] = first.ToString() + stringBetween(line, first.ToString(), ",");

                                        //Cuardando TipoDato

                                        TipoDatos[cont2] = stringBetween(line, ", ", ",");


                                        //Guardando  Longitud

                                        totalcaracterLongitu = Campos[cont2].Length + TipoDatos[cont2].Length + 4;
                                        int sumaDecimal = 0;

                                        if (TipoDatos[cont2] == "decimal")
                                        {
                                            Longitud[cont2] = line.Substring(totalcaracterLongitu - 1) + " ";
                                            sumaDecimal = int.Parse(stringBetween(Longitud[cont2], " ", ",")) + int.Parse(stringBetween(Longitud[cont2], ",", " "));
                                            Longitud[cont2] = sumaDecimal.ToString();
                                            // Console.WriteLine("esta es" + sumaDecimal);
                                        }
                                        else
                                        {
                                            Longitud[cont2] = line.Substring(totalcaracterLongitu);
                                        }


                                        //Console.WriteLine(Campos[cont2]);

                                        //   Console.WriteLine(TipoDatos[cont2]);
                                        // Console.WriteLine(Longitud[cont2]);
                                        cont2 = cont2 + 1;


                                    }



                                }

                                string infoCampo = "";
                                string sumaCampo = "";
                                bool pasa = false;

                                for (int i = 0; i < cont2; i++)
                                {

                                    do
                                    {
                                        Console.WriteLine("\n inserta el Campo:" + Campos[i]);
                                        infoCampo = Console.ReadLine();

                                        if (infoCampo.Length <= int.Parse(Longitud[i]))
                                        {
                                            int faltante = int.Parse(Longitud[i]) - infoCampo.Length;
                                            infoCampo = infoCampo + String.Concat(Enumerable.Repeat(" ", faltante));

                                        }

                                        if (infoCampo == "" | infoCampo == " ")
                                        {
                                            infoCampo = String.Concat(Enumerable.Repeat(" ", int.Parse(Longitud[i]))); ;
                                        }

                                        if (TipoDatos[i] == "fecha")
                                        {

                                            if (infoCampo.Length == 8)
                                            {

                                                sumaCampo = sumaCampo + infoCampo;
                                                pasa = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("el parametro se debe representar de la siguiente manera: aaaammdd ejemplo: 20210213");
                                                pasa = false;
                                            }
                                        }
                                        else
                                        {

                                            if (infoCampo.Length <= int.Parse(Longitud[i]))
                                            {

                                                sumaCampo = sumaCampo + infoCampo;
                                                pasa = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("el parametro rebasa la longitud del campo");
                                                pasa = false;
                                            }

                                        }




                                    }
                                    while (pasa == false);


                                }

                                Console.WriteLine("" + sumaCampo);


                                using (StreamWriter sw = new StreamWriter(path + "\\" + tabla + ".dat", true))
                                {


                                    sw.WriteLine(sumaCampo);

                                    Console.WriteLine("Campo agregado con exito");
                                    Console.ReadKey();

                                }


                                /* using (StreamReader readtext = new StreamReader(path + "\\" + tabla + ".dat"), true)
                                 {
                                     string line;
                                     // Read and display lines from the file until the end of
                                     // the file is reached.
                                     while ((line = readtext.ReadLine()) != null)
                                     {
                                         Console.WriteLine(line);
                                         Console.ReadKey();
                                     }
                                 }*/


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                                Console.ReadKey();
                            }


                        }



                    }
                    //*********************************************************************************************************************** Fin Codigo para Poner insertar datos en una tabla es decir al .dat *****************************************************/


                    //***********************************************************************************************************************Codigo para Mostrar las tablas presentes en una base de datos *****************************************************/
                    else if (instruccion.Contains("muestra tablas"))
                    {
                        if (usabase == "")
                        {
                            Console.WriteLine("Primero debes de poner en uso una base de datos");
                            Console.ReadKey();
                        }
                        else
                            try
                            {
                                path = @"c:\bases\" + usabase;

                                //string[] Ruta tablas = new string[cont];


                                string[] files = Directory.GetFiles(path); // Obtener archivos 


                                foreach (string f in files)
                                {
                                    if (f.Contains(".est"))
                                    {
                                        Console.WriteLine("\n" + f + "\n"); // Mostramos los archivos en la consola
                                        string line = "";
                                        using (StreamReader sr = new StreamReader(f))
                                        {
                                            while ((line = sr.ReadLine()) != null)
                                            {

                                                Console.WriteLine(line);
                                            }

                                        }
                                    }
                                    else
                                    {

                                    }



                                }



                                Console.ReadKey();



                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                                Console.ReadKey();
                            }




                    }
                    //*********************************************************************************************************************** Fin Codigo para Mostrar las tablas presentes en una base de datos *****************************************************/

                    //***********************************************************************************************************************Codigo para Borrar una tabla *********************************************************************/
                    else if (instruccion.Contains("borra tabla"))
                    {
                        if (usabase == "")
                        {
                            Console.WriteLine("Primero debes de poner en uso una base de datos");
                            Console.ReadKey();
                        }
                        else
                            try
                            {
                                path = @"c:\bases\" + usabase;
                                string nombre = instruccion.Substring(12);

                                if (File.Exists(path + "\\" + nombre + ".est"))
                                {
                                    File.Delete(path + "\\" + nombre + ".est");
                                    File.Delete(path + "\\" + nombre + ".dat");
                                    Console.WriteLine("Tabla borrada con exito");
                                    Console.ReadKey();


                                }
                                else
                                {
                                    Console.WriteLine("El archivo no existe.");
                                    Console.ReadKey();
                                }



                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                                Console.ReadKey();


                            }


                    }

                    //*********************************************************************************************************************** FIn Codigo para Borrar una tabla *************************************************************/


                    //***********************************************************************************************************************Codigo para Borrar un campo de una tabla *****************************************************/
                    else if (instruccion.Contains("borra campo"))
                    {


                        try
                        {
                            path = @"c:\bases\" + usabase;
                            //string tabla = instruccion.Substring(12);
                            string tabla = stringBetween(instruccion, "campo ", ",");
                            int countToCampo = tabla.Length + 14;
                            string campo = instruccion.Substring(countToCampo);

                            // Console.WriteLine("" + tabla);
                            //  Console.WriteLine("" + campo);
                            // Console.ReadKey();

                            // codigo que  lee los campos y guarda la cantidad de campos en un contador
                            string line = "";
                            int cont = 0;
                            using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                            {
                                while ((line = sr.ReadLine()) != null)
                                {
                                    cont = cont + 1;
                                    Console.WriteLine(cont);
                                }
                                // Console.ReadKey();
                            }




                            //vector para guardar los campos renglon por renglon
                            string[] Campos = new string[cont];
                            int cont2 = 0;
                            bool CamExiste = false;


                            //Variable que localizara la posicion del campo a borrar en el vector;
                            int PosicionDelcampo = 0;




                            // Vector para los campos
                            string[] CamposLongitud = new string[cont];

                            // Vector para los tipos de datos
                            string[] TipoDatosLongitud = new string[cont];


                            // Vector para los Longitud
                            string[] Longitud = new string[cont];

                            int totalcaracterLongitu = 0;

                            //codigo que guarda los campos en el vector
                            using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                            {


                                while ((line = sr.ReadLine()) != null)
                                {

                                    char[] charArray = line.ToCharArray();
                                    char first = charArray[0];


                                    //Guardando nombre de campos
                                    CamposLongitud[cont2] = first.ToString() + stringBetween(line, first.ToString(), ",");

                                    //Cuardando TipoDato

                                    TipoDatosLongitud[cont2] = stringBetween(line, ", ", ",");


                                    //Guardando  Longitud

                                    totalcaracterLongitu = CamposLongitud[cont2].Length + TipoDatosLongitud[cont2].Length + 4;
                                    int sumaDecimal = 0;

                                    if (TipoDatosLongitud[cont2] == "decimal")
                                    {
                                        Longitud[cont2] = line.Substring(totalcaracterLongitu - 1) + " ";
                                        sumaDecimal = int.Parse(stringBetween(Longitud[cont2], " ", ",")) + int.Parse(stringBetween(Longitud[cont2], ",", " "));
                                        Longitud[cont2] = sumaDecimal.ToString();
                                        // Console.WriteLine("esta es" + sumaDecimal);
                                    }
                                    else
                                    {
                                        Longitud[cont2] = line.Substring(totalcaracterLongitu);
                                    }


                                    //  Console.WriteLine(CamposLongitud[cont2]);
                                    //  Console.WriteLine(TipoDatosLongitud[cont2]);
                                    //  Console.WriteLine(Longitud[cont2]);




                                    //if que verifica si se encuentra el nombre del campo y lo remplaza por ""
                                    if (line.Contains(campo) == true)
                                    {
                                        PosicionDelcampo = cont2;
                                        Campos[cont2] = "";
                                        CamExiste = true;
                                    }
                                    else
                                    {
                                        Campos[cont2] = line;

                                    }

                                    //Console.WriteLine(Campos[cont2]);
                                    cont2 = cont2 + 1;


                                }



                            }

                            //variable que cuenta el numero de caracteres para llegar al campo a eliminar
                            int caracteresParaCampo = 0;

                            //variable que obtiene la longitud del campo a eliminar
                            int LongitudCampo = 0;

                            for (int i = 0; i < PosicionDelcampo; i++)
                            {
                                caracteresParaCampo = caracteresParaCampo + int.Parse(Longitud[i]);
                            }

                            LongitudCampo = int.Parse(Longitud[PosicionDelcampo]);

                            Console.WriteLine("caracteres para llegar" + caracteresParaCampo);
                            Console.WriteLine("Caracteres del campo" + LongitudCampo);

                            if (CamExiste == true)
                            {

                                // codigo para sobre escribir archivo .est , el false sirve para que lo sobre escriba

                                using (StreamWriter sw = new StreamWriter(path + "\\" + tabla + ".est", false))
                                {
                                    foreach (string i in Campos)
                                    {
                                        if (i == "")
                                        {

                                        }
                                        else
                                        {
                                            sw.WriteLine(i);
                                        }

                                    }



                                    Console.WriteLine("Campo borrado con exito");
                                    Console.ReadKey();
                                }


                            }
                            else
                            {
                                Console.WriteLine("El campo no existe en la tabla");
                                Console.ReadKey();
                            }



                            //Borrar datos del campo .dat





                            //codigo que  lee los campos y guarda la cantidad de campos en un contador
                            string linedat = "";
                            int contdat = 0;
                            using (StreamReader srdat = new StreamReader(path + "\\" + tabla + ".dat"))
                            {
                                while ((linedat = srdat.ReadLine()) != null)
                                {
                                    contdat = contdat + 1;
                                    //Console.WriteLine(linedat);
                                    // Console.WriteLine(contdat);
                                }

                            }



                            //vector para guardar los campos renglon por renglon
                            string[] Camposdat = new string[contdat];
                            int cont2dat = 0;
                            // bool CamExistedat = false;

                            //codigo que guarda los campos en el vector
                            using (StreamReader srdat = new StreamReader(path + "\\" + tabla + ".dat"))
                            {
                                while ((linedat = srdat.ReadLine()) != null)
                                {

                                    //name = name.Remove(foundS1 + 1, foundS2 - foundS1);
                                    Console.WriteLine("cont" + cont2);
                                    Camposdat[cont2dat] = linedat.Remove(caracteresParaCampo, LongitudCampo);
                                    //   Console.WriteLine(Camposdat[cont2dat]);
                                    cont2dat = cont2dat + 1;


                                }



                            }


                            using (StreamWriter sw = new StreamWriter(path + "\\" + tabla + ".dat", false))
                            {
                                foreach (string i in Camposdat)
                                {
                                    sw.WriteLine(i);
                                }
                            }






                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                            Console.ReadKey();


                        }




                    }
                    //*********************************************************************************************************************** fin Codigo para Borrar un campo de una tabla *****************************************************/


                    //***********************************************************************************************************************Codigo para agregar un campo a una tabla *****************************************************/
                    else if (instruccion.Contains("agrega campo"))
                    {


                        try
                        {
                            if (usabase == "")
                            {
                                Console.WriteLine("Primero debes de poner en uso una base de datos");
                                Console.ReadKey();
                            }
                            else
                            {

                                path = @"c:\bases\" + usabase;
                                //string tabla = instruccion.Substring(12);
                                string tabla = instruccion.Substring(13);



                                // Console.WriteLine("Ingresa los parametros del nuevo campo");


                                if (File.Exists(path + "\\" + tabla + ".est"))
                                {
                                    // This path is a file
                                    //*****************************
                                    do
                                    {

                                        Console.WriteLine("Ingresa parametros  del campo \n");

                                        string NombreCampo = "";
                                        string TipoCampo = "";
                                        string Longitud = "";

                                        bool PasaNombre = false;


                                        do
                                        {

                                            Console.WriteLine("\n Nombre");
                                            NombreCampo = Console.ReadLine();


                                            if (NombreCampo.Contains(",") == true | NombreCampo.Contains(" ") == true | NombreCampo == "")
                                            {
                                                PasaNombre = false;
                                                Console.WriteLine("En nombre no puede tener comas o  espacios");
                                            }
                                            else
                                            {
                                                PasaNombre = true;
                                            }


                                        } while (PasaNombre == false);




                                        do
                                        {

                                            Console.WriteLine("\n Tipo");
                                            TipoCampo = Console.ReadLine();
                                            if (TipoCampo == "entero" | TipoCampo == "caracter" | TipoCampo == "decimal" | TipoCampo == "fecha")
                                            {
                                                PasaNombre = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Tipo de dato invalido, Los tipos de datos validos son: entero, caracter, decimalo fecha");
                                                PasaNombre = false;

                                            }

                                        } while (PasaNombre == false);


                                        if (TipoCampo == "fecha")
                                        {
                                            Longitud = "8";
                                        }
                                        else if (TipoCampo == "decimal")
                                        {
                                            do
                                            {

                                                Console.WriteLine("\n longitud");
                                                Longitud = Console.ReadLine();
                                                if (Longitud.Contains(",") == true)
                                                {

                                                }
                                                else
                                                {
                                                    Console.WriteLine("La longitud debe tener la siguiente estructura: enteros,decimales");
                                                }

                                            } while (Longitud.Contains(",") == false);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n Longitud");
                                            Longitud = Console.ReadLine();
                                        }




                                        string NuevoCampo = (NombreCampo + ", " + TipoCampo + ", " + Longitud);
                                        Console.Clear();


                                        string campo = NombreCampo;




                                        // codigo que  lee los campos y guarda la cantidad de campos en un contador
                                        string line = "";
                                        int cont = 0;
                                        using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                                        {
                                            while ((line = sr.ReadLine()) != null)
                                            {
                                                cont = cont + 1;
                                                //Console.WriteLine(line);
                                            }
                                            // Console.ReadKey();
                                        }


                                        //vector para guardar los campos renglon por renglon
                                        string[] Campos = new string[cont];
                                        int cont2 = 0;
                                        bool CamExiste = false;

                                        //codigo que guarda los campos en el vector
                                        using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                                        {
                                            while ((line = sr.ReadLine()) != null)
                                            {


                                                Campos[cont2] = line;
                                                if (line.Contains(campo))
                                                {
                                                    CamExiste = true;
                                                }
                                                //Console.WriteLine(Campos[cont2]);
                                                cont2 = cont2 + 1;


                                            }



                                        }

                                        if (CamExiste == true)
                                        {

                                            Console.WriteLine("El campo ya existe");
                                            Console.ReadKey();


                                        }
                                        else
                                        {
                                            // codigo para sobre escribir archivo .est , el false sirve para que lo sobre escriba

                                            using (StreamWriter sw = new StreamWriter(path + "\\" + tabla + ".est", true))
                                            {
                                                //foreach (string i in Campos)
                                                //{

                                                sw.WriteLine(NuevoCampo);
                                                //}

                                                Console.WriteLine("Campo ingresado con exito");
                                                Console.ReadKey();
                                            }
                                        }

                                        CamExiste = false;

                                        Console.Clear();
                                        Console.WriteLine("¿Desea agregar otro campo?");
                                        Console.WriteLine("s) si");
                                        Console.WriteLine("n) no");
                                        respuesta = char.Parse(Console.ReadLine());
                                        Console.Clear();

                                    }
                                    while (respuesta == 's');

                                    //*******************************


                                }

                                else
                                {
                                    Console.WriteLine("la tabla no existe");
                                    Console.ReadKey();
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                            Console.ReadKey();
                        }

                    }
                    //***********************************************************************************************************************Fin Codigo para agregar un campo una tabla *****************************************************/

                    //elimina en tbl1 donde c1=3
                    //***********************************************************************************************************************Codigo (elimina en nombre tabla donde campo = dato*************************************
                    else if (instruccion.Contains("elimina en"))
                    {
                        if (usabase == "")
                        {
                            Console.WriteLine("Primero debes de poner en uso una base de datos");
                            Console.ReadKey();
                        }
                        else
                        {

                            try
                            {
                                path = @"c:\bases\" + usabase;

                                string cadena = instruccion + "i";

                                string tabla = stringBetween(instruccion, "en ", " donde");
                                string campo = stringBetween(cadena, "donde ", "=");
                                string valor = stringBetween(cadena, "=", "i");
                                //string tabla = instruccion.Substring(12);
                                //string tabla = instruccion.Substring(12);

                                //Console.WriteLine("tabla: " + tabla);
                                //Console.WriteLine("tabla: " + campo);
                                //Console.WriteLine("tabla: " + valor);
                                // Console.ReadKey();

                                //variables
                                string line;
                                int conta = 0;
                                bool CampoExiste = false;

                                //Leemos los datos del .est de la tabla
                                using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                                {
                                    while ((line = sr.ReadLine()) != null)
                                    {


                                        conta = conta + 1;
                                        // Console.WriteLine("" + line);

                                        if (line.Contains(campo) == true)
                                        {
                                            CampoExiste = true;
                                        }

                                        //  Console.ReadKey();


                                    }



                                }


                                // codigo que  lee los campos y guarda la cantidad de campos en un contador

                                //Registramos los datos de la estructura de la tabla para est
                                string lineas = "";
                                int cont = 0;
                                using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                                {
                                    while ((lineas = sr.ReadLine()) != null)
                                    {
                                        cont = cont + 1;
                                        //      Console.WriteLine(cont);
                                    }
                                    // Console.ReadKey();
                                }


                                //vector para guardar los campos renglon por renglon
                                string[] Campos = new string[cont];
                                int cont2 = 0;



                                //Variable que localizara la posicion del campo a borrar en el vector;
                                int PosicionDelcampo = 0;




                                // Vector para los campos
                                string[] CamposLongitud = new string[cont];

                                // Vector para los tipos de datos
                                string[] TipoDatosLongitud = new string[cont];


                                // Vector para los Longitud
                                string[] Longitud = new string[cont];

                                int totalcaracterLongitu = 0;

                                //codigo que guarda los campos en el vector
                                using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                                {


                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        char[] charArray = line.ToCharArray();
                                        char first = charArray[0];


                                        //Guardando nombre de campos
                                        CamposLongitud[cont2] = first.ToString() + stringBetween(line, first.ToString(), ",");

                                        //Cuardando TipoDato

                                        TipoDatosLongitud[cont2] = stringBetween(line, ", ", ",");


                                        //Guardando  Longitud

                                        totalcaracterLongitu = CamposLongitud[cont2].Length + TipoDatosLongitud[cont2].Length + 4;
                                        int sumaDecimal = 0;

                                        if (TipoDatosLongitud[cont2] == "decimal")
                                        {
                                            Longitud[cont2] = line.Substring(totalcaracterLongitu - 1) + " ";
                                            sumaDecimal = int.Parse(stringBetween(Longitud[cont2], " ", ",")) + int.Parse(stringBetween(Longitud[cont2], ",", " "));
                                            Longitud[cont2] = sumaDecimal.ToString();
                                            // Console.WriteLine("esta es" + sumaDecimal);
                                        }
                                        else
                                        {
                                            Longitud[cont2] = line.Substring(totalcaracterLongitu);


                                            //if que verifica si se encuentra el nombre del campo y lo remplaza por ""
                                            if (line.Contains(campo) == true)
                                            {
                                                PosicionDelcampo = cont2;


                                            }
                                            else
                                            {
                                                Campos[cont2] = line;

                                            }

                                            //Console.WriteLine(Campos[cont2]);
                                            cont2 = cont2 + 1;







                                        }
                                    }

                                }





                                //variable que cuenta el numero de caracteres para llegar al campo a eliminar
                                int caracteresParaCampo = 0;

                                //variable que obtiene la longitud del campo a eliminar
                                int LongitudCampo = 0;

                                int contadorVecesDato = 0;
                                bool valorExiste = false;

                                for (int i = 0; i < PosicionDelcampo; i++)
                                {
                                    caracteresParaCampo = caracteresParaCampo + int.Parse(Longitud[i]);
                                }

                                LongitudCampo = int.Parse(Longitud[PosicionDelcampo]);

                                if (CampoExiste == true)
                                {

                                    //Verificamos si el valor existe en la pocion del campo del archivo dat
                                    string lineasdat = "";
                                    int contdat = 0;
                                    using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".dat"))
                                    {
                                        while ((lineasdat = sr.ReadLine()) != null)
                                        {


                                            if (lineasdat.Substring(caracteresParaCampo, LongitudCampo) == valor)
                                            {
                                                contadorVecesDato++;
                                                valorExiste = true;
                                            }

                                            contdat = contdat + 1;
                                            //Console.WriteLine(cont);
                                        }
                                        // Console.ReadKey();
                                    }


                                    string[] Registros = new string[contdat];
                                    int cont2dat = 0;


                                    //Guardamos leemo y guardamo solo los registros que no tengan el valo el campo
                                    using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".dat"))
                                    {
                                        while ((lineasdat = sr.ReadLine()) != null)
                                        {



                                            if (lineasdat.Substring(caracteresParaCampo, LongitudCampo).Contains(valor) == true)
                                            {
                                                Registros[cont2dat] = "";
                                            }
                                            else
                                            {
                                                Registros[cont2dat] = lineasdat;
                                            }

                                            cont2dat++;
                                            //Console.WriteLine(cont);
                                        }
                                        // Console.ReadKey();
                                    }


                                    if (valorExiste == true)
                                    {
                                        // codigo para sobre escribir archivo .est , el false sirve para que lo sobre escriba

                                        using (StreamWriter sw = new StreamWriter(path + "\\" + tabla + ".dat", false))
                                        {
                                            foreach (string i in Registros)
                                            {

                                                if (i == "")
                                                {

                                                }
                                                else
                                                {
                                                    sw.WriteLine(i);
                                                }
                                            }
                                            Console.WriteLine("Registros eliminados con exito");
                                            Console.ReadKey();






                                            //  Console.WriteLine("Campo borrado con exito");
                                            //Console.ReadKey();
                                        }



                                    }
                                    else
                                    {
                                        Console.WriteLine("no existe ningun campo: " + campo + " con el valor: " + valor);
                                        Console.ReadKey();
                                    }


                                }
                                else
                                {
                                    Console.WriteLine("El campo no existe en los registros");
                                    Console.ReadKey();
                                }

                                //[] Camposdat = new string[contdat];

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                                Console.ReadKey();
                            }



                        }





                    }
                    //*********************************************************************************************************************Fin Codigo (elimina en nombre tabla donde campo = dato**********************************


                    //*********************************************************************************************************************Fin Codigo (elimina en nombre tabla donde campo = dato**********************************
                    else if (instruccion.Contains("lista * de"))
                    {
                        
                        if (usabase == "")
                        {
                            Console.WriteLine("Primero debes de poner en uso una base de datos");
                            Console.ReadKey();
                        }
                        else
                        {
                            try
                            {


                                path = @"c:\bases\" + usabase;
                                string tabla = instruccion.Substring(11);


                                string line;

                                Console.WriteLine("\n Estructura \n");
                                using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".est"))
                                {
                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        Console.WriteLine(line);
                                       // Console.ReadKey();
                                    }

                                }
                                Console.WriteLine("");


                                Console.WriteLine("\n datos \n");
                                using (StreamReader sr = new StreamReader(path + "\\" + tabla + ".dat"))
                                {
                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        Console.WriteLine(line);
                                       // Console.ReadKey();
                                    }

                                }

                                Console.ReadKey();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                                Console.ReadKey();
                            }

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

