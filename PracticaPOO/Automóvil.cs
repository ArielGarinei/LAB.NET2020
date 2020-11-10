
namespace PracticaPOO
{
    public class Automóvil : Transporte
    {
        public Automóvil(int nPasajeros) : base(nPasajeros)
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
