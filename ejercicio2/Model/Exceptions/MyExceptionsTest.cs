using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2.exeptions
{
    public class MyExceptionsTest : Exception
    {
        public MyExceptionsTest()
        {

        }
        public void DivZero(int mNumber)
        {
            int division = -1;
            try
            {
                division = mNumber / 0;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException();
            }
        }
        public int Dividir(int mDividend, int mDividing)
        {
            int mResultado = -1;
                try
                {
                    mResultado = mDividend / mDividing;
                    return mResultado;
                }
                catch (DivideByZeroException)
                {
                    throw new DivideByZeroException();

                }
        }
    }
}