using NUnit.Framework;
using Sparkfish.Services;

namespace Sparkfish.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase(0, 100, 1, 1)]
        [TestCase(0, 100, 50, 50)]
        [TestCase(0, 100, 100, 100)]
        [TestCase(100, 200, 1, 101)]
        [TestCase(100, 200, 50, 150)]
        [TestCase(100, 200, 100, 200)]

        public void Listify_Should_Listify(int begin, int end, int target, int expected)
        {
            // arrange
            var list = new Listify();

            // act
            list.Create(begin, end);
            var val = list[target];

            // assert
            Assert.AreEqual(val, expected);
        }
    }
}