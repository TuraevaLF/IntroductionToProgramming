namespace TuraevaLF.Tasks
{
    internal sealed class RandomGenerator
    {
        internal readonly int RangeFrom;
        internal readonly int RangeTo;

        internal RandomGenerator(int rangeFrom, int rangeTo)
        {
            RangeFrom = rangeFrom;
            RangeTo = rangeTo;
        }

        internal int GetNext()
        {
            return 0;
        }
    }
}
