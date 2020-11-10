using ejercicio2;
using System;

namespace ejercicio2.exeptions
{
    public class Logic : Exception
    {
        //Atributes
        string mMessage;

        //Constructors
        public Logic(string message)
        {
            this.mMessage = message;
        }
        public Logic()
        {
        }

        //Methods
        public void TrhowCustomExeption()
        {
            throw new ExceptionCustom(this.mMessage);
        }

        public void TrhowExeption()
        {
            throw new DivideByZeroException();
        }

        public int DivZero(int mNumber)
        {
            /*1) Realizar una método que al ingresar un valor genere una simple excepción al intentar hacer una división por cero. 
             * Esta misma excepción deberá ser capturada, mostrando el mensaje de la excepción 
             * y siempre deberá avisar cuando terminó de realizarse la operación haya sido exitosa o no.*/

            int mResult = -1;
            if (mNumber < 0 )
            {
                InterfazUsuario.ShowCustomMessage("¿Capo... que haces? no se puede dividir números negativos");
                InterfazUsuario.ShowSussesFail(false);
                return int.MaxValue;
            }
            try
            {
                mResult = mNumber / 0;
                InterfazUsuario.ShowResult(mResult);
                return int.MaxValue;
            }
            catch (DivideByZeroException ex)
            {
                InterfazUsuario.ShowExeptionMessage(ex);
                return int.MaxValue;
            }
            finally
            {
                if (mResult < 0 || mResult == int.MaxValue)
                { InterfazUsuario.ShowSussesFail(false); }
                else
                { InterfazUsuario.ShowSussesFail(true); }
            }
        }
        public int Divide(int mDividend, int mDividing)
        {
            /*2) Realizar un método que permita ingresar 2 números (dividendo y divisor) y realice la división de los mismos. 
             * Se deberán mostrar el resultado (Si es un Unit Test tener en cuenta los Assert). 
             * Si hay una excepción de división por cero se deberá mostrar el siguiente mensaje: “Solo Chuck Norris divide por cero!” (Se acepta todo tipo de creatividad) 
             * más el mensaje de la excepción propia. También se deberá capturar una excepción si el usuario no ingresa ningún número o el mismo no es un número válido,
             * informando la situación de “Seguro Ingreso una letra o no ingreso nada!”.*/
            int mResult = -1;
            if (mDividend < 0 || mDividend < 0)
            {
                InterfazUsuario.ShowCustomMessage("¿Capo... que haces? no se puede dividir números negativoss");
                InterfazUsuario.ShowSussesFail(false);
                return int.MaxValue;
            }
            else
            {
                try
                {
                    if(mDividend == int.MaxValue || mDividing == int.MaxValue)
                    {
                        return int.MaxValue;
                    }
                    else
                    {
                    mResult = mDividend / mDividing;
                    InterfazUsuario.ShowResult(mResult);
                    return mResult;
                    }
                }
                catch (DivideByZeroException ex)
                {
                    InterfazUsuario.ShowExeptionMessage(ex);
                    InterfazUsuario.ShowCustomMessage("Solo Chuck Norris divide por cero!");
                    return int.MaxValue;

                }
                finally
                {
                    if (mResult <  0|| mDividend == int.MaxValue|| mDividing == int.MaxValue)
                    { InterfazUsuario.ShowSussesFail(false); }
                    else
                    { InterfazUsuario.ShowSussesFail(true); }
                }
            }
        }
    }
}
