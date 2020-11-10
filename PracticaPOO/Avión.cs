
namespace PracticaPOO
{
    public class Avión : Transporte
    {
        public Avión(int nPasajeros) : base(nPasajeros)
        {
        }

        public override string Avanzar()
        {
            return base.Avanzar();
        }

        public override string Detenerse()
        {
            return base.Detenerse();
        }

        public override int CantPasajeros()
        {
            return base.CantPasajeros();
        }

    }
}
