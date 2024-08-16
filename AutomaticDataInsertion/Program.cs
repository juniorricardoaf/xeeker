using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticDataInsertion
{
    class Program
    {
        public static int datosInsertados = 0;
        [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);


        static void Main(string[] args)
        {
            //se utiliza para minimizar la ventana automaticamente, la ventana de la consola.

            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(handle, 6);
            Console.Write("Conectandose a SQL Server ... ");


            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "xeeker123456.database.windows.net";   // update me
                builder.UserID = "Morph-X";              // update me
                builder.Password = "Wesbrek123";      // update me
                builder.InitialCatalog = "xeeker";

                //SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=XeekerULT;Integrated Security=True");


                //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Conección exitosa. Listo.");

                    Console.WriteLine("Se comienzan a insertar datos en 3 segundos\n\n");
                    System.Threading.Thread.Sleep(3000);// 5 segundos de espera

                    int dataCounter = 0;
                    //insert exceptions
                    do
                    {

                        Console.WriteLine("Intentando llenar TBL_EXCEPCIONES.LLenando base de datos... Intento #" + (dataCounter + 1));


                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_EXCEPCIONES (ID, MENSAJE) VALUES (@0, @1)", connection);

                        if (dataCounter == 0)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 202));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Número de habitación ya existente.Por favor elija otro número de habitación"));

                        }
                        if (dataCounter == 1)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 1));
                            insertCommand.Parameters.Add(new SqlParameter("1", "La identificación que desea ingresar ya se encuentra registrada"));
                        }
                        if (dataCounter == 2)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 2));
                            insertCommand.Parameters.Add(new SqlParameter("1", "El correo que desea ingresar ya se encuentra registrado"));
                        }

                        if (dataCounter == 3)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 600));
                            insertCommand.Parameters.Add(new SqlParameter("1", "El tipo de habitación que desea ingresar ya se encuentra registrada"));
                        }
                        if (dataCounter == 4)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 401));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Cédula jurídica del hotel no reconocida, por favor inténtelo nuevamente."));


                        }
                        if (dataCounter == 5)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 402));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Usuario loggueado no reconocido, por favor inténtelo nuevamente."));

                        }
                        if (dataCounter == 6)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 403));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Imagenes de hotel no agregadas, por favor inténtelo nuevamente."));

                        }
                        if (dataCounter == 7)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 404));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Hotel ya existente, por favor inténtelo nuevamente."));
                        }
                        if (dataCounter == 8)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 405));
                            insertCommand.Parameters.Add(new SqlParameter("1", "El hotel solicitado no existe, por favor inténtelo nuevamente."));
                        }
                        if (dataCounter == 9)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 406));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Estado de hotel no reconocido, por favor inténtelo nuevamente."));
                        }
                        if (dataCounter == 10)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 407));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Cógigo QR no reconocido como llave, inténtelo nuevamente"));
                        }
                        if (dataCounter == 11)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 408));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Aún no se puede efectuar su Check-in en el hotel. Por favor inténtelo el dóa y a la hora indicada"));
                        }
                        if (dataCounter == 12)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 409));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Aún no se puede efectuar su Check-out en el hotel. Por favor inténtelo el dóa y a la hora indicada"));
                        }
                        if (dataCounter == 13)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 410));
                            insertCommand.Parameters.Add(new SqlParameter("1", "Su reservación ya ha terminado, su Llave ya ha vencido."));
                        }
                        if (dataCounter == 14)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 411));
                            insertCommand.Parameters.Add(new SqlParameter("1", "El producto no se ha podido comprar, aún no ha hecho check-in en su hotel reseravado"));
                        }
                        if (dataCounter == 15)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 412));
                            insertCommand.Parameters.Add(new SqlParameter("1", "El producto no se ha podido comprar, su reservación ya ha terminado."));
                        }
                        if (dataCounter == 16)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 413));
                            insertCommand.Parameters.Add(new SqlParameter("1", "El producto indicado no existe."));
                        }

                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter + 1) + ", registrado exitosamente.\n");
                            datosInsertados++;
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 17);

                    dataCounter = 113;
                    //llenando permisos
                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_PERMISOS. LLenando base de datos... Intento #" + (datosInsertados + 1));
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_PERMISOS (ID, NOMBRE) VALUES (@0, @1)", connection);

                        if (dataCounter == 113)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 1));
                            insertCommand.Parameters.Add(new SqlParameter("1", "FinancieroAdmin"));
                        }

                        if (dataCounter == 114)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 2));
                            insertCommand.Parameters.Add(new SqlParameter("1", "AdministrativoAdmin"));
                        }
                        if (dataCounter == 115)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 21));
                            insertCommand.Parameters.Add(new SqlParameter("1", "AdministracionHotel"));
                        }
                        if (dataCounter == 116)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 22));
                            insertCommand.Parameters.Add(new SqlParameter("1", "ServicioHotel"));
                        }
                        if (dataCounter == 117)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 23));
                            insertCommand.Parameters.Add(new SqlParameter("1", "DashboardHotel"));
                        }
                        if (dataCounter == 118)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 24));
                            insertCommand.Parameters.Add(new SqlParameter("1", "CobrosHotel"));
                        }
                        if (dataCounter == 119)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 3));
                            insertCommand.Parameters.Add(new SqlParameter("1", "DashboardAdmin"));
                        }
                        if (dataCounter == 120)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 777));
                            insertCommand.Parameters.Add(new SqlParameter("1", "PermisoTurista"));
                        }

                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter + 1) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 121);

                    dataCounter = 221;
                    //tbl vistas
                    do
                    {

                        Console.WriteLine("Intentando llenar TBL_VISTAS. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_VISTAS (ID, NOMBRE) VALUES (@0, @1)", connection);

                        if (dataCounter == 221)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 1));
                            insertCommand.Parameters.Add(new SqlParameter("1", "FinancieroAdmin"));
                        }

                        if (dataCounter == 222)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 2));
                            insertCommand.Parameters.Add(new SqlParameter("1", "AdministrativoAdmin"));
                        }
                        if (dataCounter == 223)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 21));
                            insertCommand.Parameters.Add(new SqlParameter("1", "AdministracionHotel"));
                        }
                        if (dataCounter == 224)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 22));
                            insertCommand.Parameters.Add(new SqlParameter("1", "ServicioHotel"));
                        }
                        if (dataCounter == 225)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 23));
                            insertCommand.Parameters.Add(new SqlParameter("1", "DashboardHotel"));
                        }
                        if (dataCounter == 226)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 24));
                            insertCommand.Parameters.Add(new SqlParameter("1", "CobrosHotel"));
                        }
                        if (dataCounter == 227)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 3));
                            insertCommand.Parameters.Add(new SqlParameter("1", "DashboardAdmin"));
                        }
                        if (dataCounter == 228)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 777));
                            insertCommand.Parameters.Add(new SqlParameter("1", "PermisoTurista"));
                        }
                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter + 1) + ", registrado exitosamente.\n"); datosInsertados++;
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 229);

                    dataCounter = 1221;

                    //registro de usuarios
                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_USUARIOS. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_USUARIOS (IDENTIFICACION, PRIMER_NOMBRE, SEGUNDO_NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, TELEFONO, CORREO, ESTADO, TIPO, FECHA_INGRESO, CONTRASENNA, RECOMENDACION) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11)", connection);

                        if (dataCounter == 1221)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 123123123));//IDENTIFICACION
                            insertCommand.Parameters.Add(new SqlParameter("1", "Carlos"));//PRIMER_NOMBRE
                            insertCommand.Parameters.Add(new SqlParameter("2", ""));//segundo nombre no mandatorio
                            insertCommand.Parameters.Add(new SqlParameter("3", "Alvarado"));//PRIMER_APELLIDO
                            insertCommand.Parameters.Add(new SqlParameter("4", ""));//SEGUNDO_APELLIDO no mandatorio
                            insertCommand.Parameters.Add(new SqlParameter("5", 84382971));//TELEFONO
                            insertCommand.Parameters.Add(new SqlParameter("6", "carlos@gmail.com"));//CORREO
                            insertCommand.Parameters.Add(new SqlParameter("7", "Habilitado"));//ESTADO
                            insertCommand.Parameters.Add(new SqlParameter("8", "Administrador general"));//TIPO
                            insertCommand.Parameters.Add(new SqlParameter("9", "2019-08-05"));//FECHA_INGRESO
                            insertCommand.Parameters.Add(new SqlParameter("10", "B—ôK•R5$[$—9z“"));//CONTRASENNA
                            insertCommand.Parameters.Add(new SqlParameter("11", "playa"));//RECOMENDACION no mandatorio
                        }

                        if (dataCounter == 1222)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 117230683));//IDENTIFICACION
                            insertCommand.Parameters.Add(new SqlParameter("1", "Junior"));//PRIMER_NOMBRE
                            insertCommand.Parameters.Add(new SqlParameter("2", ""));//segundo nombre no mandatorio
                            insertCommand.Parameters.Add(new SqlParameter("3", "Aburto"));//PRIMER_APELLIDO
                            insertCommand.Parameters.Add(new SqlParameter("4", "Ferreto"));//SEGUNDO_APELLIDO no mandatorio
                            insertCommand.Parameters.Add(new SqlParameter("5", 71514989));//TELEFONO
                            insertCommand.Parameters.Add(new SqlParameter("6", "jaburtof@ucenfotec.ac.cr"));//CORREO
                            insertCommand.Parameters.Add(new SqlParameter("7", "Habilitado"));//ESTADO
                            insertCommand.Parameters.Add(new SqlParameter("8", "Administrador hotel"));//TIPO
                            insertCommand.Parameters.Add(new SqlParameter("9", "2019-08-05"));//FECHA_INGRESO
                            insertCommand.Parameters.Add(new SqlParameter("10", "B—ôK•R5$[$—9z“"));//CONTRASENNA
                            insertCommand.Parameters.Add(new SqlParameter("11", "playa"));//RECOMENDACION no mandatorio
                        }

                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter + 1) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 1223);
                    dataCounter = 300;
                    //registro de cuentas
                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_CUENTAS. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_CUENTAS (ID, ID_USUARIO, INGRESOS, EGRESOS) VALUES (@0, @1, @2, @3)", connection);

                        if (dataCounter == 300)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "87fd8f36-3987-49f9-89db-592e83d4b8f1"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "123123123"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "0.00"));//INGRESOS
                            insertCommand.Parameters.Add(new SqlParameter("3", "0.0"));//EGRESOS

                        }

                        if (dataCounter == 301)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "344AF7C6-98D6-4AD9-8479-2CAFFAB76C58"));
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));
                            insertCommand.Parameters.Add(new SqlParameter("2", "0.00"));
                            insertCommand.Parameters.Add(new SqlParameter("3", "0.00"));
                        }

                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter + 1) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 302);

                    dataCounter = 401;
                    // registro: 
                    //TBL_USUARIOSxVISTASxPERMISOS
                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_USUARIOSxVISTASxPERMISOS. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_USUARIOSxVISTASxPERMISOS (ID, ID_USUARIO, ID_PERMISO, ID_VISTA) VALUES (@0, @1, @2, @3)", connection);

                        if (dataCounter == 401)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "0F3E97C9-065B-4DE4-9EA4-51F54E48E322"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "123123123"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "2"));//ID_PERMISO
                            insertCommand.Parameters.Add(new SqlParameter("3", "2"));//ID_VISTA
                        }
                        if (dataCounter == 402)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "0F3E97C9-065B-4DE4-9EA4-51F54E484444"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "123123123"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "1"));//ID_PERMISO
                            insertCommand.Parameters.Add(new SqlParameter("3", "1"));//ID_VISTA
                        }
                        if (dataCounter == 403)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "78604CA0-513D-49AB-A2D5-B634AE2E9205"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "21"));//ID_PERMISO
                            insertCommand.Parameters.Add(new SqlParameter("3", "21"));//ID_VISTA
                        }
                        if (dataCounter == 404)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "294D989C-6966-43AE-A26D-CFFF9222F35B"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "22"));//ID_PERMISO
                            insertCommand.Parameters.Add(new SqlParameter("3", "22"));//ID_VISTA
                        }
                        if (dataCounter == 405)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "294D989C-6966-43AE-A26D-CFFF9222F333"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "23"));//ID_PERMISO
                            insertCommand.Parameters.Add(new SqlParameter("3", "23"));//ID_VISTA
                        }
                        if (dataCounter == 406)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "294D989C-6966-43AE-A26D-CFFF9222F434"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "24"));//ID_PERMISO
                            insertCommand.Parameters.Add(new SqlParameter("3", "24"));//ID_VISTA
                        }
                        if (dataCounter == 407)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "0F3E97C9-065B-4DE4-9EA4-51F54E485555"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "123123123"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "3"));//ID_PERMISO
                            insertCommand.Parameters.Add(new SqlParameter("3", "3"));//ID_VISTA
                        }

                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter + 1) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + (dataCounter - 1) + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 408);


                    //registro: hoteles paso 1, Solicitudes
                    dataCounter = 500;
                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_SOLICITUDES. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_SOLICITUDES (CEDULA_JURIDICA, ID_USUARIO, NOMBRE, NOMBRE_COMERCIAL, CADENA, CATEGORIA_ESTRELLAS, CORREO, ESTADO) VALUES (@0, @1, @2, @3, @4, @5, @6, @7)", connection);

                        if (dataCounter == 500)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 28348324));//CEDULA_JURIDICA
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "Casinito"));//NOMBRE
                            insertCommand.Parameters.Add(new SqlParameter("3", "Casino"));//NOMBRE_COMERCIAL
                            insertCommand.Parameters.Add(new SqlParameter("4", "Casinos JR"));//CADENA 
                            insertCommand.Parameters.Add(new SqlParameter("5", 2));//CATEGORIA_ESTRELLAS
                            insertCommand.Parameters.Add(new SqlParameter("6", "casinitosJr@gmail.com"));//CORREO
                            insertCommand.Parameters.Add(new SqlParameter("7", "Habilitado"));//ESTADO
                        }

                        if (dataCounter == 501)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 402479871));//CEDULA_JURIDICA
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "Fiesta"));//NOMBRE
                            insertCommand.Parameters.Add(new SqlParameter("3", "Playa"));//NOMBRE_COMERCIAL
                            insertCommand.Parameters.Add(new SqlParameter("4", "Double Tree"));//CADENA 
                            insertCommand.Parameters.Add(new SqlParameter("5", 5));//CATEGORIA_ESTRELLAS
                            insertCommand.Parameters.Add(new SqlParameter("6", "doubletreefiesta@gmail.com"));//CORREO
                            insertCommand.Parameters.Add(new SqlParameter("7", "Habilitado"));//ESTADO
                        }


                        if (dataCounter == 502)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 536763948));//CEDULA_JURIDICA
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "Las cañas"));//NOMBRE
                            insertCommand.Parameters.Add(new SqlParameter("3", "ApartaHotel"));//NOMBRE_COMERCIAL
                            insertCommand.Parameters.Add(new SqlParameter("4", "Los trebol"));//CADENA 
                            insertCommand.Parameters.Add(new SqlParameter("5", 4));//CATEGORIA_ESTRELLAS
                            insertCommand.Parameters.Add(new SqlParameter("6", "caña87@gmail.com"));//CORREO
                            insertCommand.Parameters.Add(new SqlParameter("7", "Habilitado"));//ESTADO
                        }


                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 503);
                    dataCounter = 700;

                    //registro hoteles paso 2, tbl_hoteles

                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_HOTELES. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_HOTELES ([CEDULA_JURIDICA], [FECHA_CANCELACION], [PORCENTAJE_DEVOLUCION]) VALUES (@0, @1, @2)", connection);

                        if (dataCounter == 700)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 28348324));//CEDULA_JURIDICA
                            insertCommand.Parameters.Add(new SqlParameter("1", 6));//FECHA_CANCELACION
                            insertCommand.Parameters.Add(new SqlParameter("2", 7.00));//PORCENTAJE_DEVOLUCION
                        }

                        if (dataCounter == 701)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 402479871));//CEDULA_JURIDICA
                            insertCommand.Parameters.Add(new SqlParameter("1", 5));//FECHA_CANCELACION
                            insertCommand.Parameters.Add(new SqlParameter("2", 12.00));//PORCENTAJE_DEVOLUCION
                        }


                        if (dataCounter == 702)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", 536763948));//CEDULA_JURIDICA
                            insertCommand.Parameters.Add(new SqlParameter("1", 3));//FECHA_CANCELACION
                            insertCommand.Parameters.Add(new SqlParameter("2", 2.00));//PORCENTAJE_DEVOLUCION
                        }


                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 703);
                    dataCounter = 800;

                    //registro hoteles paso 3, TBL_DIRECCIONES
                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_DIRECCIONES. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_DIRECCIONES (ID, ID_HOTEL, DIRECCION_EXACTA, LATITUD, LONGITUD, PROVINCIA, CANTON, DISTRITO) VALUES (@0, @1, @2, @3, @4, @5, @6, @7)", connection);

                        if (dataCounter == 800)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "46a97cab-fcbd-427b-82b4-3c020bb02c67"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "28348324"));//ID_HOTEL
                            insertCommand.Parameters.Add(new SqlParameter("2", "Frente al palí"));//DIRECCION_EXACTA
                            insertCommand.Parameters.Add(new SqlParameter("3", "9.87073181792382"));//LATITUD
                            insertCommand.Parameters.Add(new SqlParameter("4", "-84.0617459637512"));//LONGITUD 
                            insertCommand.Parameters.Add(new SqlParameter("5", "San José"));//PROVINCIA
                            insertCommand.Parameters.Add(new SqlParameter("6", "Desamparados"));//CANTON
                            insertCommand.Parameters.Add(new SqlParameter("7", "San Miguel"));//DISTRITO
                        }

                        if (dataCounter == 801)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "68e26482-e3df-4d5c-9f9f-89b37f1c4d0f"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "402479871"));//ID_HOTEL
                            insertCommand.Parameters.Add(new SqlParameter("2", "500 metros al oeste del restaurante la Sirenita"));//DIRECCION_EXACTA
                            insertCommand.Parameters.Add(new SqlParameter("3", "9.969990408034864"));//LATITUD
                            insertCommand.Parameters.Add(new SqlParameter("4", "-84.73987277573241"));//LONGITUD 
                            insertCommand.Parameters.Add(new SqlParameter("5", "Puntarenas"));//PROVINCIA
                            insertCommand.Parameters.Add(new SqlParameter("6", "Esparza"));//CANTON
                            insertCommand.Parameters.Add(new SqlParameter("7", "Buenos Aires"));//DISTRITO
                        }


                        if (dataCounter == 802)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "982fdbf9-f9f0-432e-9e33-d50f6caeb26d"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "536763948"));//ID_HOTEL
                            insertCommand.Parameters.Add(new SqlParameter("2", "En cañas"));//DIRECCION_EXACTA
                            insertCommand.Parameters.Add(new SqlParameter("3", "9.853961233973624"));//LATITUD
                            insertCommand.Parameters.Add(new SqlParameter("4", "-84.5853825475586"));//LONGITUD 
                            insertCommand.Parameters.Add(new SqlParameter("5", "Cartago"));//PROVINCIA
                            insertCommand.Parameters.Add(new SqlParameter("6", "Jiménez"));//CANTON
                            insertCommand.Parameters.Add(new SqlParameter("7", "Tucurrique"));//DISTRITO
                        }


                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 803);
                    dataCounter = 900;

                    //registro hoteles paso 4, TBL_USUARIOSxHOTELES
                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_USUARIOSxHOTELES. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_USUARIOSxHOTELES (ID,ID_USUARIO,ID_HOTEL) VALUES (@0, @1, @2)", connection);

                        if (dataCounter == 900)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "2B90A576-CD9E-4441-AF96-E1260ED2EE42"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "28348324"));//ID_HOTEL
                        }

                        if (dataCounter == 901)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "38883775-BD3F-4F33-BF6E-14F73890B366"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "536763948"));//ID_HOTEL
                        }

                        if (dataCounter == 902)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "4823119A-312E-4771-BDB4-30FF52A69441"));//ID
                            insertCommand.Parameters.Add(new SqlParameter("1", "117230683"));//ID_USUARIO
                            insertCommand.Parameters.Add(new SqlParameter("2", "402479871"));//ID_HOTEL
                        }

                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 903);
                    dataCounter = 1500;

                    //registro hoteles paso 5, anexar fotos  TBL_IMAGENES_HOTELES
                    do
                    {
                        Console.WriteLine("Intentando llenar TBL_IMAGENES_HOTELES. LLenando base de datos... Intento #" + (datosInsertados + 1));

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO TBL_IMAGENES_HOTELES ([ID_IMAGENESXHOTEL], [ID_HOTEL], [FOTO]) VALUES (@0, @1, @2)", connection);

                        if (dataCounter == 1500)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "078942d2-5624-40b1-9dae-d21c9727d036"));//ID_IMAGENESXHOTEL
                            insertCommand.Parameters.Add(new SqlParameter("1", "402479871"));//ID_HOTEL
                            insertCommand.Parameters.Add(new SqlParameter("2", "https://res.cloudinary.com/dxkujut7c/image/upload/clmlud48uxyjjhixtqbu"));//FOTO
                        }

                        if (dataCounter == 1501)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "07d8a829-48e9-430e-8c6d-0fd710eaefaa"));//ID_IMAGENESXHOTEL
                            insertCommand.Parameters.Add(new SqlParameter("1", "536763948"));//ID_HOTEL
                            insertCommand.Parameters.Add(new SqlParameter("2", "https://res.cloudinary.com/dxkujut7c/image/upload/is6mfyforssu6psahdzb"));//FOTO
                        }

                        if (dataCounter == 1502)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "61709b28-d37b-4d35-bf72-d99a94e6601b"));//ID_IMAGENESXHOTEL
                            insertCommand.Parameters.Add(new SqlParameter("1", "28348324"));//ID_HOTEL
                            insertCommand.Parameters.Add(new SqlParameter("2", "https://res.cloudinary.com/dxkujut7c/image/upload/cb3ofcvib5fejmrxgcii"));//FOTO
                        }
                        if (dataCounter == 1503)
                        {
                            insertCommand.Parameters.Add(new SqlParameter("0", "a072bd43-89ff-4f87-8f46-3a0cfe9cc2b8"));//ID_IMAGENESXHOTEL
                            insertCommand.Parameters.Add(new SqlParameter("1", "402479871"));//ID_HOTEL
                            insertCommand.Parameters.Add(new SqlParameter("2", "https://res.cloudinary.com/dxkujut7c/image/upload/dl7147il3vsqwroyrvtd"));//FOTO
                        }

                        try
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Dato #" + (dataCounter) + ", registrado exitosamente.\n");
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine("Insercion de datos fallida. Dato " + dataCounter + " ya existente.\n\n");
                        }
                        dataCounter++;
                        datosInsertados++;
                    } while (dataCounter != 1504);






                    //Aqui termina la insercion de datos. 
                    Console.WriteLine("\nSe han terminado de insertar datos.\nGarantizamos al menos " + (datosInsertados + 1) + " registros en la BD.");
                    Console.WriteLine("Presione ESC para salir");
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            // Do something
                        }
                    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }



        ////codigo para leer datos y testear consola:
        //SqlCommand command = new SqlCommand("SELECT * FROM TBL_COBROS", connection);
        //using (SqlDataReader reader = command.ExecuteReader())
        //{
        //    // while there is another record present
        //    while (reader.Read())
        //    {
        //        // write the data on to the screen
        //        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
        //        // call the objects from their index
        //        reader[0], reader[1], reader[2], reader[3]));
        //    }
        //}


    }
}
