using KellermanSoftware.CompareNetObjects;

namespace AGLTest.UnitTests
{
    public static class CompareLogicCreator
    {
        public static CompareLogic Create()
        {
            var config = new ComparisonConfig
            {
                MaxDifferences=1000
            };

            var compareLogic = new CompareLogic(config);
            return compareLogic;
        }

    }
}