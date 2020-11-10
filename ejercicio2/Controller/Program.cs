using ejercicio2.exeptions;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ejercicio2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            string mChar = "C";
            while (mChar != "E")
            {

                #region Punto nº1
                Console.WriteLine("\n------Punto 1------  \nDivisión por 0 ");
                int nNumber = InterfazUsuario.GetNumbInt("Ingrese numero a dividir: ");
                logic.DivZero(nNumber);
                //Console.ReadKey();
                #endregion

                #region Punto nº2
                Console.WriteLine("\n\n------Punto 2------");
                int mDividendo = InterfazUsuario.GetNumbInt("Ingrese el numero a dividir: ");
                int mDivisor = InterfazUsuario.GetNumbInt("Ingrese el divisor: ");
                logic.Divide(mDividendo, mDivisor);
                //Console.ReadKey();
                #endregion

                #region Punto nº3
                Console.Write("\n\n------Punto 3------ \nArrojando excepción simple\n\n");
                try
                {
                    logic.TrhowExeption();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nTipo de excepción controlada : {ex.GetType()}");

                    Console.WriteLine($"\nMensaje de la excepción  : {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("\nOperación finalizada");
                }
                #endregion

                #region Punto nº4 
                Console.WriteLine("\n\n------Punto 4------");

                Console.Write("Ingrese el modificador del mensaje de la exepcion: ");
                string mMessage = Console.ReadLine();
                logic = new Logic(mMessage);
                try
                {
                    logic.TrhowCustomExeption();
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"\nTipo de exepcion contrlada : {ex.GetType()}");

                    Console.WriteLine($"\nMensaje de la exepcion : {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Operacion finalizada");
                }
                //Console.ReadKey();
                #endregion

                mChar = InterfazUsuario.ContinueExit();
            }
        }
    }
}
