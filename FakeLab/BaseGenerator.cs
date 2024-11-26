namespace FakeLab
{
    public abstract class BaseGenerator
    {
        protected Random Rand;

        protected bool GenerateBool() => Rand.Next(1) == 1;
    }
}
