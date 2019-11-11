using NUnit.Framework;

namespace ReadWriteMap.Tests
{
    public static class UnitTestExtensions
    {
        public static void AssertValuesAreEqual<T>(this T[][] self, T[][] expected)
        {
            Assert.AreEqual(expected.Length, self.Length);
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Length, self[i].Length);

                for (var j = 0; j < self[i].Length; j++)
                {
                    Assert.AreEqual(expected[i][j], self[i][j]);
                }
            }
        }
    }
}