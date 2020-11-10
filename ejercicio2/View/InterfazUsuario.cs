using System;

namespace ejercicio2
{
     public class InterfazUsuario
    {

        static public void ShowExeptionMessage(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        static public void ShowCustomMessage(string message)
        {
            Console.WriteLine(message);
        }
        static public void ShowResult(int result)
        {
            Console.WriteLine($"Resultado = {result}");
        }
        static public void ShowSussesFail(bool b)
        {
            if (!b) 
            { Console.WriteLine("Operación fallida"); 
            }else 
            { Console.WriteLine("Operación finalizada con éxito"); 
            }

        }
        static public int GetNumbInt(string mMessage)
        {
            try
            {
                Console.Write(mMessage);
                return int.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                ShowExeptionMessage(ex);
                ShowCustomMessage("¡Seguro ingresó una letra o no ingreso nada!");
                return int.MaxValue;

            }
            catch(System.OverflowException ex)
            {
                ShowExeptionMessage(ex);
                return int.MaxValue;
            }
            
        }

        static public string ContinueExit()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Ingrese la tecla [E] para Finalizar el programa");
            Console.WriteLine("Presione [Enter] para Continuar con el programa");

            string mChar = Console.ReadLine().ToUpper();
            return mChar.Trim();
        }



        
    }
}
