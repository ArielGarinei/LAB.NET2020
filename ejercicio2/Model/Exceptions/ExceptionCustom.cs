using System;

namespace ejercicio2.exeptions
{
    public class ExceptionCustom : Exception
    {
        public ExceptionCustom() : base("Esta excepción no será la excepción") { }
        public ExceptionCustom(string mMessage) : base($"{mMessage} Esta excepción no será la excepción") { }
    }
}
