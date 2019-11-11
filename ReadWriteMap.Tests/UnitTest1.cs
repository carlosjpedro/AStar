using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ReadWriteMap.Tests
{
    public class Tests
    {
        private readonly IStringToMapMapper _mapper = new StringToMapMapper();

        [Test]
        public void EmptyStringArrayReturnsEmptyMap()
        {
            var stringList = Enumerable.Empty<string>();
            var map = _mapper.ReadMap(stringList);
            Assert.AreEqual(0, map.Length);
        }

        [Test]
        public void MapOneCharList()
        {
            var stringList = new List<string> { "0" };
            var map = _mapper.ReadMap(stringList);
            Assert.AreEqual(1, map.Length);
            Assert.AreEqual(1, map[0].Length);
            Assert.AreEqual(0, map[0][0]);
        }

        [Test]
        public void MapLineWithMultipleChar()
        {
            var stringList = new List<string> { "0124111100005550000222033333" };
            var expectedArray = new[]
            { new[]
                {
                    0, 1, 2, 4, 1, 1, 1, 1, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 2, 2, 2, 0, 3, 3, 3, 3, 3
                }
            };
            var map = _mapper.ReadMap(stringList);

            map.AssertValuesAreEqual(expectedArray);
        }

        [Test]
        public void MapCharLines()
        {
            var stringList = new List<string>
            {
                "0124111100005550000222033333",
                "4340039111116688792221123343",
                "7778881119932364564300003331",
                "4387539900033310089685754324",
            };
            var expectedArray = new[]
            {
                new[]{ 0,1,2,4,1,1,1,1,0,0,0,0,5,5,5,0,0,0,0,2,2,2,0,3,3,3,3,3},
                new[]{ 4,3,4,0,0,3,9,1,1,1,1,1,6,6,8,8,7,9,2,2,2,1,1,2,3,3,4,3},
                new[]{ 7,7,7,8,8,8,1,1,1,9,9,3,2,3,6,4,5,6,4,3,0,0,0,0,3,3,3,1},
                new[]{ 4,3,8,7,5,3,9,9,0,0,0,3,3,3,1,0,0,8,9,6,8,5,7,5,4,3,2,4}
            };

            var map = _mapper.ReadMap(stringList);

            map.AssertValuesAreEqual(expectedArray);
        }

        [Test]
        public void MapRowsWithDifferentSizes()
        {
            var stringList = new List<string>
            {
                "4235", "1"
            };

            Assert.Throws<InvalidRowInMapException>(() => _mapper.ReadMap(stringList));
        }
    }
}