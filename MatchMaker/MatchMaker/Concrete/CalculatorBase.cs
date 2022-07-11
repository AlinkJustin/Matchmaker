using MatchMaker.Abstract;

namespace MatchMaker.Concrete
{
    public abstract class CalculatorBase : ICalculator
    {
        public abstract int Calculate(string name, string name2);
    }
}
