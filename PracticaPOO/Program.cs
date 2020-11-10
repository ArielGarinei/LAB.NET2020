using System;
using System.Collections;

namespace PracticaPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ArrayList listTransportes = new ArrayList();
            int contAviones = 0;
            int contAutomóviles = 0;

            #region Generación automática de pasajeros   
            
            for (int i = 0 ; i<5; i++)
            {
                Random rand = new Random(i);
                int num = rand.Next(100);
                listTransportes.Add(new Automóvil(num)); 
                rand = new Random(i+1*3);
                num = rand.Next(100);
                listTransportes.Add(new Avión(num));
            }
            #endregion

            #region Recorrido lista de Transportes identificando Aviones
            foreach (Transporte item in listTransportes)
            {
                if (item is Avión)
                {
                    contAviones++;
                    Console.WriteLine("\nAvión nº" + contAviones + " tiene " + item.CantPasajeros() + " pasajeros");
                }

            }
            #endregion

            Console.WriteLine("\n\n");

            #region Recorrido lista de Transportes identificando Automóviles
            foreach (Transporte item in listTransportes)
            {
                if (item is Automóvil)
                {
                    contAutomóviles++;
                    Console.WriteLine("\nAutomóvil nº" + contAutomóviles + " tiene " + item.CantPasajeros() + " pasajeros");
                }
            }
            #endregion

            Console.WriteLine("\n\n");

            Console.WriteLine("\nCantidad de Aviones: " + contAviones);
            Console.WriteLine("\nCantidad de Automóviles: " + contAutomóviles);
            Console.WriteLine("\nCantidad de Transportes: " + listTransportes.Count);

            Console.ReadKey();

            // :)
        }
    }
}
