
namespace PracticaPOO
{
    public abstract class Transporte
    {
        private int cantPasajeros;

        public Transporte(int nPasajeros)
        {
            this.cantPasajeros = nPasajeros;
        }

        public virtual string Avanzar()
        {
            return "Avanzando...";
        }

        public virtual string Detenerse()
        {
            return "Deteniéndose...";
        }

        public virtual int CantPasajeros()
        {
            return this.cantPasajeros;
        }

    }
}
 