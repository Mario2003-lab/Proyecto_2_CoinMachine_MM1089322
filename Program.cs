using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2_CoinMachine_MM1089322
{

    using System;
    using static System.Net.Mime.MediaTypeNames;

    class Jugador
    {
        public string NombreCompleto { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public int Edad => (int)((DateTime.Now - FechaNacimiento).TotalDays / 365.25);

        //Ganancias y monto?





        public bool EsMayorDeEdad()
        {
            var fechaActual = DateTime.Now;
            var edad = fechaActual.Year - FechaNacimiento.Year;
            if (FechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }
            return edad >= 21;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal monto = 0;

            var jugador = new Jugador();
            Console.WriteLine("Datos del jugador:");
            Console.Write("Nombre completo: ");
            jugador.NombreCompleto = Console.ReadLine();
            Console.Write("Número de identificación: ");
            jugador.NumeroIdentificacion = Console.ReadLine();
            Console.Write("Fecha de nacimiento (año-mes-día): ");
            jugador.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.Write("Nacionalidad: ");
            jugador.Nacionalidad = Console.ReadLine();

            Console.Clear();

            if (jugador.EsMayorDeEdad())
            {
                Console.WriteLine("El jugador cumple el requisito de edad.");
            }
            else
            {
                Console.WriteLine("El jugador no tiene la edad requerida para jugar (21 años)...");
                Console.ReadLine();
                Environment.Exit(0);
            }

            // ASCII
            Console.WriteLine("\nTrébol: \u2663" +
                "\nPor cada aparición en pantalla el usuario duplicará su apuesta.");

            Console.WriteLine("\nDiamante: \u2666" +
                "\nAl obtener 4 obtendrá el 1000% de su apuesta, con menos de 4 no tendrá ningún valor.");

            Console.WriteLine("\nCarita feliz: \u263A" +
                "\nPor cada aparición, recibirá el 100% de su apuesta, es decir, se duplica. ");

            Console.WriteLine("\nSol: \u002A" +
                "\nPor cada ícono de sol el usuario obtendrá el 25% de su apuesta" +
                "\nes decir si se llega a acumular 4 se obtendrá el 100% de su apuesta.");

            Console.WriteLine("\nCasa: \u2302" +
                "\nAl momento de aparecer dicho ícono no se tendrá ningún retorno.");

            Console.WriteLine("\nBomba: \u0021" +
                "\nSi al usuario le aparece dicho elemento perderá toda su apuesta sin importar las otras figuras.");

            Console.WriteLine(
                "\na. Probabilidad de obtener el 1000% de la apuesta: 0.00256% \r" +

                "\nb. Probabilidad de duplicar la apuesta: 31% \r" +

                "\nc. Probabilidad de obtener de regreso su apuesta: 2.56% \r" +

                "\nd. Probabilidad de perder la mitad de su apuesta: 3% \r" +

                "\ne. Probabilidad de perder toda su apuesta: 1%\r\n");


            Console.Write("\nDesea continuar? (Si/No): ");
            string respuesta = Console.ReadLine();

            Console.Clear();


            //metodo de pago
            if (respuesta == "Si" || respuesta == "si")
            {
                Console.Write("\n¿Apostará en efectivo o con tarjeta de crédito? (Efectivo/Tarjeta): ");
                string metodoPago = Console.ReadLine();



                //tarjeta
                if (metodoPago == "Tarjeta" || metodoPago == "tarjeta")
                {
                    Console.Write("\nIngrese el monto a apostar(Q): ");
                    monto = decimal.Parse(Console.ReadLine());

                    Console.Write("\nIngrese el número de la tarjeta de crédito (16 dígitos): ");
                    string numTarjeta = Console.ReadLine();

                    if (numTarjeta.Length == 16 && numTarjeta.All(char.IsDigit))
                    {
                        Console.Write("\nIngrese el nombre del titular de la tarjeta: ");
                        string nombreTitular = Console.ReadLine();

                        Console.Write("\nIngrese la fecha de expiración de la tarjeta (mes/año): ");
                        string fechaExpiracion = Console.ReadLine();

                        // comprobación fecha expiración de tarjeta
                        DateTime fechaActual = DateTime.Now;
                        DateTime fechaExpiracionDT = DateTime.ParseExact(fechaExpiracion, "MM/yy", null);

                        if (fechaExpiracionDT < fechaActual)
                        {
                            Console.WriteLine("\nLa tarjeta ha expirado.");
                            Console.WriteLine("El programa se cerrará.");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("\nPago exitoso");
                        }

                        Console.WriteLine("Monto a apostar(Q): " + monto);
                        Console.WriteLine("Número de tarjeta de crédito: " + numTarjeta);
                        Console.WriteLine("Titular de la tarjeta: " + nombreTitular);
                        Console.WriteLine("Fecha de expiración de la tarjeta: " + fechaExpiracion);
                    }
                    else
                    {
                        Console.WriteLine("El número de tarjeta ingresado es inválido.");
                        Environment.Exit(0);
                    }
                }

                //efectivo
                else if (metodoPago == "Efectivo" || metodoPago == "efectivo")
                {
                    Console.WriteLine("El método de pago seleccionado es: " + metodoPago);

                    Console.Write("\nIngrese el monto a apostar(Q): ");
                    monto = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Monto a apostar(Q): " + monto);
                }
                else
                {
                    Console.WriteLine("Método de pago inválido.");
                    Environment.Exit(0);
                }
            }

            else
            {
                Console.WriteLine("Cerrando programa");
                Environment.Exit(0);
            }

            Console.Write("\nDesea continuar y apostar? (Si/No): ");
            string respuesta2 = Console.ReadLine();
            Console.Clear();

            if (respuesta2 == "Si" || respuesta2 == "si")
            {
               

                // Probabilidades de aparición de cada ícono
                double probabilidadTrebol = (10.00/100);
                double probabilidadDiamante = (4.00/100);
                double probabilidadHappyFace = (20.00 / 100);
                double probabilidadSol = (25.00 / 100);
                double probabilidadCasa = (40.00 / 100);
                double probabilidadBomba = (1.00 / 100);


                // Generación 4 iconos aleatorios
                string[] iconos = { "Trebol \u2663", "Diamante \u2666", "Carita Feliz \u263A", "Sol \u002A", "Casa \u2302", "Bomba \u0021" };
                Random random = new Random();
                string[] iconosGenerados = new string[4];

                //apostar ganancias obtenidas
                string respuesta3 = "Si";

                decimal montoCalculado = monto;

                Console.WriteLine("Los iconos generados son: ");
                while (respuesta3 == "Si" || respuesta3 == "si")
                {

                    int cantidadTrebol = 0;
                    int cantidadDiamante = 0;
                    int cantidadHappyFace = 0;
                    int cantidadSol = 0;
                    int cantidadCasa = 0;
                    int cantidadBomba = 0;

                    //volver a generar los íconos 
                    for (int i = 0; i < 4; i++)
                    {
                        double r = random.NextDouble();
                        string iconoGenerado = "";

                        if (r < probabilidadTrebol)
                        {
                            cantidadTrebol++;
                            iconoGenerado = "Trebol \u2663";
                        }
                        else if (r < probabilidadTrebol + probabilidadDiamante)
                        {
                            cantidadDiamante++;
                            iconoGenerado = "Diamante \u2666";
                        }
                        else if (r < probabilidadTrebol + probabilidadDiamante + probabilidadHappyFace)
                        {
                            cantidadHappyFace++;
                            iconoGenerado = "Carita Feliz \u263A";
                        }
                        else if (r < probabilidadTrebol + probabilidadDiamante + probabilidadHappyFace + probabilidadSol)
                        {
                            cantidadSol++;
                            iconoGenerado = "Sol \u002A";
                        }
                        else if (r < probabilidadTrebol + probabilidadDiamante + probabilidadHappyFace + probabilidadSol + probabilidadCasa)
                        {
                            cantidadCasa++;
                            iconoGenerado = "Casa \u2302";
                        }
                        else if (r < probabilidadTrebol + probabilidadDiamante + probabilidadHappyFace + probabilidadSol + probabilidadCasa + probabilidadBomba)
                        {
                            cantidadBomba++;
                            iconoGenerado = "Bomba \u0021";
                        }

                        iconosGenerados[i] = iconoGenerado;

                        Console.WriteLine(iconoGenerado);
                    }

                    //calcula el resultado
                    //trebol
                    montoCalculado = montoCalculado + cantidadTrebol * (monto * 2);
                    //diamante
                    if (cantidadDiamante == 4) montoCalculado = montoCalculado + monto * 10;
                    //happyface
                    montoCalculado = montoCalculado + cantidadHappyFace * (monto);
                    //sol
                    montoCalculado = montoCalculado + cantidadSol * ((monto / 4));
                    //casa
                    montoCalculado = montoCalculado;
                    //bomba
                    if (cantidadBomba>0)
                        montoCalculado = 0;

                    Console.WriteLine($"monto total: {montoCalculado}");

                    Console.WriteLine("Desea apostar su monto total? (Si/No): ");
                    respuesta3 = Console.ReadLine();
                    

                    monto = montoCalculado;
                }

                
                Console.Clear();

                //mostrar informacion personal del jugador (Nombre, id, nacionalidad y edad) + las ganancias acumuladas con el impuesto del 40%

                Console.WriteLine("Nombre: " + jugador.NombreCompleto);
                Console.WriteLine("ID: " + jugador.NumeroIdentificacion);
                Console.WriteLine("Nacionalidad: " + jugador.Nacionalidad);
                Console.WriteLine("Edad: " + jugador.Edad + " años");

                Console.WriteLine("Ganancias acumuladas (Q): " + montoCalculado); //Ganancias acumuladas

                // aplicar impuesto del 40% a las ganancias acumuladas
                decimal impuesto = 0.4m; 
                decimal gananciasTotales = montoCalculado * impuesto; 

                Console.WriteLine("- impuesto del 40%");
                Console.WriteLine("Ganancias totales (Q): " + gananciasTotales); //ganancias totales


            }

            else
            {

                Console.WriteLine("Cerrando programa");
                Environment.Exit(0);

            }

            Console.ReadLine();

        }
    }

}
